// win_input.c -- win32 mouse and joystick code
// 02/21/97 JCB Added extended DirectInput code to support external controllers.

#include "../client.h"
#include "../../qcommon/win32/win_local.h"
#include "../../cgame_ui/keycodes.h"


typedef struct {
	int			oldButtonState;
	qboolean	mouseActive;
	qboolean	mouseInitialized;
	qboolean  mouseStartupDelayed; // delay mouse init to try DI again when we have a window
} WinMouseVars_t;

static WinMouseVars_t s_wmv;

static int	window_center_x, window_center_y;


#define MAX_MIDIIN_DEVICES	8

typedef struct {
	int			numDevices;
	MIDIINCAPS	caps[MAX_MIDIIN_DEVICES];

	HMIDIIN		hMidiIn;
} MidiInfo_t;

static MidiInfo_t s_midiInfo;


#define	JOY_MAX_AXES		6				// X, Y, Z, R, U, V

typedef struct {
	qboolean	avail;
	int			id;			// joystick number
	JOYCAPS		jc;			// ジョイスティックの仕様(X, Y, Z, R, U, V軸の値の範囲、ボタンの数、メーカーコード(?)など)

	int			oldbuttonstate;
	int			oldpovstate;
} joystickInfo_t;

static	joystickInfo_t	joy;


cvar_t	*in_midi;
cvar_t	*in_midiport;
cvar_t	*in_midichannel;
cvar_t	*in_mididevice;

cvar_t	*in_mouse;
cvar_t  *in_logitechbug;
cvar_t	*in_joystick;
cvar_t	*in_joyBallScale;
cvar_t	*in_debugJoystick;
cvar_t	*joy_threshold;

qboolean	in_appactive;


void IN_ActivateWin32Mouse(void) {
	int			width, height;
	RECT		window_rect;

	width = GetSystemMetrics(SM_CXSCREEN);
	height = GetSystemMetrics(SM_CYSCREEN);

	GetWindowRect(g_wv.hWnd, &window_rect);
	if (window_rect.left < 0)
		window_rect.left = 0;
	if (window_rect.top < 0)
		window_rect.top = 0;
	if (window_rect.right >= width)
		window_rect.right = width - 1;
	if (window_rect.bottom >= height - 1)
		window_rect.bottom = height - 1;
	window_center_x = (window_rect.right + window_rect.left) / 2;
	window_center_y = (window_rect.top + window_rect.bottom) / 2;

	SetCursorPos(window_center_x, window_center_y);

	SetCapture(g_wv.hWnd);
	ClipCursor(&window_rect);
	while (ShowCursor(FALSE) >= 0)
		;
}


void IN_DeactivateWin32Mouse(void) {
	ClipCursor(NULL);
	ReleaseCapture();
	while (ShowCursor(TRUE) < 0)
		;
}


void IN_Win32Mouse(int *mx, int *my) {
	POINT		current_pos;

	// find mouse movement
	GetCursorPos(&current_pos);

	// force the mouse to the center, so there's room to move
	SetCursorPos(window_center_x, window_center_y);

	*mx = current_pos.x - window_center_x;
	*my = current_pos.y - window_center_y;
}


/*
============================================================

DIRECT INPUT MOUSE CONTROL

============================================================
*/

#undef DEFINE_GUID

#define DEFINE_GUID(name, l, w1, w2, b1, b2, b3, b4, b5, b6, b7, b8) \
	EXTERN_C const GUID name \
	= {l, w1, w2, {b1, b2, b3, b4, b5, b6, b7, b8}}

DEFINE_GUID(GUID_SysMouse, 0x6F1D2B60, 0xD5A0, 0x11CF, 0xBF, 0xC7, 0x44, 0x45, 0x53, 0x54, 0x00, 0x00);
DEFINE_GUID(GUID_XAxis, 0xA36D02E0, 0xC9F3, 0x11CF, 0xBF, 0xC7, 0x44, 0x45, 0x53, 0x54, 0x00, 0x00);
DEFINE_GUID(GUID_YAxis, 0xA36D02E1, 0xC9F3, 0x11CF, 0xBF, 0xC7, 0x44, 0x45, 0x53, 0x54, 0x00, 0x00);
DEFINE_GUID(GUID_ZAxis, 0xA36D02E2, 0xC9F3, 0x11CF, 0xBF, 0xC7, 0x44, 0x45, 0x53, 0x54, 0x00, 0x00);


#define DINPUT_BUFFERSIZE           16
#define iDirectInputCreate(a,b,c,d)	pDirectInputCreate(a,b,c,d)

HRESULT(WINAPI *pDirectInputCreate)(HINSTANCE hinst, DWORD dwVersion,
									LPDIRECTINPUT * lplpDirectInput, LPUNKNOWN punkOuter);

static HINSTANCE hInstDI;

typedef struct MYDATA {
	LONG  lX;                   // X axis goes here
	LONG  lY;                   // Y axis goes here
	LONG  lZ;                   // Z axis goes here
	BYTE  bButtonA;             // One button goes here
	BYTE  bButtonB;             // Another button goes here
	BYTE  bButtonC;             // Another button goes here
	BYTE  bButtonD;             // Another button goes here
} MYDATA;

static DIOBJECTDATAFORMAT rgodf[] = {
	{&GUID_XAxis, FIELD_OFFSET(MYDATA, lX), DIDFT_AXIS | DIDFT_ANYINSTANCE, 0, },
	{&GUID_YAxis, FIELD_OFFSET(MYDATA, lY), DIDFT_AXIS | DIDFT_ANYINSTANCE, 0, },
	{&GUID_ZAxis, FIELD_OFFSET(MYDATA, lZ), 0x80000000 | DIDFT_AXIS | DIDFT_ANYINSTANCE, 0, },
	{0, FIELD_OFFSET(MYDATA, bButtonA), DIDFT_BUTTON | DIDFT_ANYINSTANCE, 0, },
	{0, FIELD_OFFSET(MYDATA, bButtonB), DIDFT_BUTTON | DIDFT_ANYINSTANCE, 0, },
	{0, FIELD_OFFSET(MYDATA, bButtonC), 0x80000000 | DIDFT_BUTTON | DIDFT_ANYINSTANCE, 0, },
	{0, FIELD_OFFSET(MYDATA, bButtonD), 0x80000000 | DIDFT_BUTTON | DIDFT_ANYINSTANCE, 0, },
};

#define NUM_OBJECTS (sizeof(rgodf) / sizeof(rgodf[0]))

// NOTE TTimo: would be easier using c_dfDIMouse or c_dfDIMouse2 
static DIDATAFORMAT	df = {
	sizeof(DIDATAFORMAT),       // this structure
	sizeof(DIOBJECTDATAFORMAT), // size of object data format
	DIDF_RELAXIS,               // absolute axis coordinates
	sizeof(MYDATA),             // device data size
	NUM_OBJECTS,                // number of objects
	rgodf,                      // and here they are
};

static LPDIRECTINPUT		g_pdi;
static LPDIRECTINPUTDEVICE	g_pMouse;

static void IN_DIMouse(int *mx, int *my) {
	DIDEVICEOBJECTDATA	od;
	DIMOUSESTATE		state;
	DWORD				dwElements;
	HRESULT				hr;
	int value;
	static float		oldSysTime;

	if (!g_pMouse) {
		return;
	}

	// fetch new events
	for (;;) {
		dwElements = 1;

		hr = IDirectInputDevice_GetDeviceData(g_pMouse,
											  sizeof(DIDEVICEOBJECTDATA), &od, &dwElements, 0);
		if ((hr == DIERR_INPUTLOST) || (hr == DIERR_NOTACQUIRED)) {
			IDirectInputDevice_Acquire(g_pMouse);
			return;
		}

		/* Unable to read data or no data available */
		if (FAILED(hr)) {
			break;
		}

		if (dwElements == 0) {
			break;
		}

		// dwTimeStampはシステム起動からの経過時間(単位はms)
		switch (od.dwOfs) {
		case DIMOFS_BUTTON0:
			if (od.dwData & 0x80)
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE1, 1, 0, NULL);
			else
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE1, 0, 0, NULL);
			break;

		case DIMOFS_BUTTON1:
			if (od.dwData & 0x80)
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE2, 1, 0, NULL);
			else
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE2, 0, 0, NULL);
			break;

		case DIMOFS_BUTTON2:
			if (od.dwData & 0x80)
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE3, 1, 0, NULL);
			else
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE3, 0, 0, NULL);
			break;

		case DIMOFS_BUTTON3:
			if (od.dwData & 0x80)
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE4, 1, 0, NULL);
			else
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MOUSE4, 0, 0, NULL);
			break;
			// https://zerowing.idsoftware.com/bugzilla/show_bug.cgi?id=50
		case DIMOFS_Z:
			value = od.dwData;
			if (value == 0) {

			} else if (value < 0) {
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MWHEELDOWN, 1, 0, NULL);
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MWHEELDOWN, 0, 0, NULL);
			} else {
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MWHEELUP, 1, 0, NULL);
				Sys_QueEvent(od.dwTimeStamp, SE_KEY, K_MWHEELUP, 0, 0, NULL);
			}
			break;
		}
	}

	// read the raw delta counter and ignore
	// the individual sample time / values
	hr = IDirectInputDevice_GetDeviceState(g_pMouse,
										   sizeof(DIDEVICEOBJECTDATA), &state);
	if (FAILED(hr)) {
		*mx = *my = 0;
		return;
	}
	*mx = state.lX;
	*my = state.lY;
}


qboolean IN_InitDIMouse(void) {
	HRESULT		hr;
	int			x, y;
	DIPROPDWORD	dipdw = {
		{
			sizeof(DIPROPDWORD),        // diph.dwSize
			sizeof(DIPROPHEADER),       // diph.dwHeaderSize
			0,                          // diph.dwObj
			DIPH_DEVICE,                // diph.dwHow
		},
		DINPUT_BUFFERSIZE,              // dwData
	};

	Com_Printf("Initializing DirectInput...\n");

	if (!hInstDI) {
		hInstDI = LoadLibrary("dinput.dll");

		if (hInstDI == NULL) {
			Com_Printf("Couldn't load dinput.dll\n");
			return 0;
		}
	}

	if (!pDirectInputCreate) {
		pDirectInputCreate = (long(__stdcall *)(void *, unsigned long, struct IDirectInputA **, struct IUnknown *))
			GetProcAddress(hInstDI, "DirectInputCreateA");

		if (!pDirectInputCreate) {
			Com_Printf("Couldn't get DI proc addr\n");
			return 0;
		}
	}

	// register with DirectInput and get an IDirectInput to play with.
	hr = iDirectInputCreate(g_wv.hInstance, DIRECTINPUT_VERSION, &g_pdi, NULL);

	if (FAILED(hr)) {
		Com_Printf("iDirectInputCreate failed\n");
		return 0;
	}

	// obtain an interface to the system mouse device.
	hr = IDirectInput_CreateDevice(g_pdi, &GUID_SysMouse, &g_pMouse, NULL);

	if (FAILED(hr)) {
		Com_Printf("Couldn't open DI mouse device\n");
		return 0;
	}

	// set the data format to "mouse format".
	hr = IDirectInputDevice_SetDataFormat(g_pMouse, &df);

	if (FAILED(hr)) {
		Com_Printf("Couldn't set DI mouse format\n");
		return 0;
	}

	// set the cooperativity level.
	hr = IDirectInputDevice_SetCooperativeLevel(g_pMouse, g_wv.hWnd,
												DISCL_EXCLUSIVE | DISCL_FOREGROUND);

	// https://zerowing.idsoftware.com/bugzilla/show_bug.cgi?id=50
	if (FAILED(hr)) {
		Com_Printf("Couldn't set DI coop level\n");
		return 0;
	}


	// set the buffer size to DINPUT_BUFFERSIZE elements.
	// the buffer size is a DWORD property associated with the device
	hr = IDirectInputDevice_SetProperty(g_pMouse, DIPROP_BUFFERSIZE, &dipdw.diph);

	if (FAILED(hr)) {
		Com_Printf("Couldn't set DI buffersize\n");
		return 0;
	}

	// clear any pending samples
	IN_DIMouse(&x, &y);
	IN_DIMouse(&x, &y);

	Com_Printf("DirectInput initialized.\n");
	return 1;
}


void IN_ShutdownDIMouse(void) {
	if (g_pMouse) {
		IDirectInputDevice_Release(g_pMouse);
		g_pMouse = NULL;
	}

	if (g_pdi) {
		IDirectInput_Release(g_pdi);
		g_pdi = NULL;
	}
}


void IN_ActivateDIMouse(void) {
	HRESULT		hr;

	if (!g_pMouse)
		return;

	// we may fail to reacquire if the window has been recreated
	hr = IDirectInputDevice_Acquire(g_pMouse);
	if (FAILED(hr)) {
		if (!IN_InitDIMouse()) {
			Com_Printf("Falling back to Win32 mouse support...\n");
			Cvar_Set("in_mouse", "-1");
		}
	}
}


void IN_DeactivateDIMouse(void) {
	if (!g_pMouse) {
		return;
	}
	IDirectInputDevice_Unacquire(g_pMouse);
}


/*
============================================================

MOUSE CONTROL

============================================================
*/

/*
Called when the window gains focus or changes in some way
*/
void IN_ActivateMouse() {
	if (!s_wmv.mouseInitialized)
		return;
	if (!in_mouse->integer) {
		s_wmv.mouseActive = 0;
		return;
	}
	if (s_wmv.mouseActive)
		return;

	s_wmv.mouseActive = 1;

	if (in_mouse->integer != -1)
		IN_ActivateDIMouse();
	IN_ActivateWin32Mouse();
}


/*
Called when the window loses focus
*/
void IN_DeactivateMouse(void) {
	if (!s_wmv.mouseInitialized) {
		return;
	}
	if (!s_wmv.mouseActive) {
		return;
	}
	s_wmv.mouseActive = 0;

	IN_DeactivateDIMouse();
	IN_DeactivateWin32Mouse();
}


void IN_StartupMouse(void) {
	s_wmv.mouseInitialized = 0;
	s_wmv.mouseStartupDelayed = 0;

	if (in_mouse->integer == 0) {
		Com_Printf("Mouse control not active.\n");
		return;
	}

	// nt4.0 direct input is screwed up
	if ((g_wv.osversion.dwPlatformId == VER_PLATFORM_WIN32_NT) &&
		(g_wv.osversion.dwMajorVersion == 4)) {
		Com_Printf("Disallowing DirectInput on NT 4.0\n");
		Cvar_Set("in_mouse", "-1");
	}

	if (in_mouse->integer == -1) {
		Com_Printf("Skipping check for DirectInput\n");
	} else {
		if (!g_wv.hWnd) {
			Com_Printf("No window for DirectInput mouse init, delaying\n");
			s_wmv.mouseStartupDelayed = 1;
			return;
		}
		if (IN_InitDIMouse()) {
			s_wmv.mouseInitialized = 1;
			return;
		}
		Com_Printf("Falling back to Win32 mouse support...\n");
	}
	s_wmv.mouseInitialized = 1;
}


void IN_MouseEvent(int mstate) {
	int i;
	int changed_button;

	if (!s_wmv.mouseInitialized)
		return;

	changed_button = mstate ^ s_wmv.oldButtonState;
	for (i = 0; i < 3; i++) {
		int mask = 1 << i;
		if ((changed_button & mask) == 0)
			continue;
		Sys_QueEvent(g_wv.sysMsgTime, SE_KEY, K_MOUSE1 + i, (mstate & mask) != 0, 0, NULL);
	}
	s_wmv.oldButtonState = mstate;
}


/*
前回(1フレーム前)からのマウスの移動量(ドット数)を取得し、イベントキューにポストする。
*/
void IN_MouseMove(void) {
	int		mx, my;

	if (g_pMouse) {
		IN_DIMouse(&mx, &my);
	} else {
		IN_Win32Mouse(&mx, &my);
	}

	if (!mx && !my) {
		return;
	}

	Sys_QueEvent(0, SE_MOUSE, mx, my, 0, NULL);
}


void IN_StartupJoystick(void) {
	int			numdevs;
	MMRESULT	mmr;

	// assume no joystick
	joy.avail = 0;

	if (!in_joystick->integer) {
		Com_Printf("Joystick is not active.\n");
		return;
	}

	// verify joystick driver is present
	if ((numdevs = joyGetNumDevs()) == 0) {
		Com_Printf("joystick not found -- driver not present\n");
		return;
	}

	// cycle through the joystick ids for the first valid one
	mmr = 0;
	for (joy.id = 0; joy.id < numdevs; joy.id++) {
		JOYINFOEX ji;
		Com_Memset(&ji, 0, sizeof(ji));
		ji.dwSize = sizeof(ji);
		ji.dwFlags = JOY_RETURNCENTERED;

		if ((mmr = joyGetPosEx(joy.id, &ji)) == JOYERR_NOERROR)
			break;
	}

	// abort startup if we didn't find a valid joystick
	if (mmr != JOYERR_NOERROR) {
		Com_Printf("joystick not found -- no valid joysticks (%x)\n", mmr);
		return;
	}

	// get the capabilities of the selected joystick
	// abort startup if command fails
	Com_Memset(&joy.jc, 0, sizeof(joy.jc));
	if ((mmr = joyGetDevCaps(joy.id, &joy.jc, sizeof(joy.jc))) != JOYERR_NOERROR) {
		Com_Printf("joystick not found -- invalid joystick capabilities (%x)\n", mmr);
		return;
	}

	Com_Printf("Joystick found.\n");
	Com_Printf("Pname: %s\n", joy.jc.szPname);
	Com_Printf("OemVxD: %s\n", joy.jc.szOEMVxD);
	Com_Printf("RegKey: %s\n", joy.jc.szRegKey);

	Com_Printf("Numbuttons: %i / %i\n", joy.jc.wNumButtons, joy.jc.wMaxButtons);
	Com_Printf("Axis: %i / %i\n", joy.jc.wNumAxes, joy.jc.wMaxAxes);
	Com_Printf("Caps: 0x%x\n", joy.jc.wCaps);
	if (joy.jc.wCaps & JOYCAPS_HASPOV) {
		Com_Printf("HASPOV\n");
	} else {
		Com_Printf("no POV\n");
	}

	// old button and POV states default to no buttons pressed
	joy.oldbuttonstate = 0;
	joy.oldpovstate = 0;

	// mark the joystick as available
	joy.avail = 1;
}


static void MIDI_NoteOff(int note) {
	int qkey;

	qkey = note - 60 + K_AUX1;

	if (qkey > 255 || qkey < K_AUX1)
		return;

	Sys_QueEvent(g_wv.sysMsgTime, SE_KEY, qkey, 0, 0, NULL);
}


static void MIDI_NoteOn(int note, int velocity) {
	int qkey;

	if (velocity == 0)
		MIDI_NoteOff(note);

	qkey = note - 60 + K_AUX1;

	if (qkey > 255 || qkey < K_AUX1)
		return;

	Sys_QueEvent(g_wv.sysMsgTime, SE_KEY, qkey, 1, 0, NULL);
}


static void CALLBACK MidiInProc(HMIDIIN hMidiIn, UINT uMsg, DWORD dwInstance,
								DWORD dwParam1, DWORD dwParam2) {
	int message;

	switch (uMsg) {
	case MIM_OPEN:
		break;
	case MIM_CLOSE:
		break;
	case MIM_DATA:
		message = dwParam1 & 0xff;

		// note on
		if ((message & 0xf0) == 0x90) {
			if (((message & 0x0f) + 1) == in_midichannel->integer)
				MIDI_NoteOn((dwParam1 & 0xff00) >> 8, (dwParam1 & 0xff0000) >> 16);
		} else if ((message & 0xf0) == 0x80) {
			if (((message & 0x0f) + 1) == in_midichannel->integer)
				MIDI_NoteOff((dwParam1 & 0xff00) >> 8);
		}
		break;
	case MIM_LONGDATA:
		break;
	case MIM_ERROR:
		break;
	case MIM_LONGERROR:
		break;
	}
}


static void IN_StartupMIDI(void) {
	int i;

	if (!Cvar_VariableValue("in_midi"))
		return;

	// enumerate MIDI IN devices
	s_midiInfo.numDevices = midiInGetNumDevs();

	for (i = 0; i < s_midiInfo.numDevices; i++) {
		midiInGetDevCaps(i, &s_midiInfo.caps[i], sizeof(s_midiInfo.caps[i]));
	}

	// open the MIDI IN port
	if (midiInOpen(&s_midiInfo.hMidiIn,
		in_mididevice->integer,
		(unsigned long) MidiInProc,
		(unsigned long) NULL,
		CALLBACK_FUNCTION) != MMSYSERR_NOERROR) {
		Com_Printf("WARNING: could not open MIDI device %d: '%s'\n", in_mididevice->integer, s_midiInfo.caps[(int) in_mididevice->value]);
		return;
	}

	midiInStart(s_midiInfo.hMidiIn);
}


void IN_Startup(void) {
	Com_Printf("\n------- Input Initialization -------\n");
	IN_StartupMouse();
	IN_StartupJoystick();
	IN_StartupMIDI();
	Com_Printf("------------------------------------\n");

	in_mouse->modified = 0;
	in_joystick->modified = 0;
}


static void IN_ShutdownMIDI(void) {
	if (s_midiInfo.hMidiIn) {
		midiInClose(s_midiInfo.hMidiIn);
	}
	Com_Memset(&s_midiInfo, 0, sizeof(s_midiInfo));
}


void IN_Shutdown(void) {
	IN_DeactivateMouse();
	IN_ShutdownDIMouse();
	IN_ShutdownMIDI();
	Cmd_RemoveCommand("midiinfo");
}


static void MidiInfo_f(void) {
	int i;

	const char *enableStrings[] = {"disabled", "enabled"};

	Com_Printf("\nMIDI control:       %s\n", enableStrings[in_midi->integer != 0]);
	Com_Printf("port:               %d\n", in_midiport->integer);
	Com_Printf("channel:            %d\n", in_midichannel->integer);
	Com_Printf("current device:     %d\n", in_mididevice->integer);
	Com_Printf("number of devices:  %d\n", s_midiInfo.numDevices);
	for (i = 0; i < s_midiInfo.numDevices; i++) {
		if (i == Cvar_VariableValue("in_mididevice"))
			Com_Printf("***");
		else
			Com_Printf("...");
		Com_Printf("device %2d:       %s\n", i, s_midiInfo.caps[i].szPname);
		Com_Printf("...manufacturer ID: 0x%hx\n", s_midiInfo.caps[i].wMid);
		Com_Printf("...product ID:      0x%hx\n", s_midiInfo.caps[i].wPid);

		Com_Printf("\n");
	}
}


void IN_Init(void) {
	// MIDI input controler variables
	in_midi = Cvar_Get("in_midi", "0", CVAR_ARCHIVE);
	in_midiport = Cvar_Get("in_midiport", "1", CVAR_ARCHIVE);
	in_midichannel = Cvar_Get("in_midichannel", "1", CVAR_ARCHIVE);
	in_mididevice = Cvar_Get("in_mididevice", "0", CVAR_ARCHIVE);

	Cmd_AddCommand("midiinfo", MidiInfo_f);

	// mouse variables
	in_mouse = Cvar_Get("in_mouse", "1", CVAR_ARCHIVE | CVAR_LATCH);
	in_logitechbug = Cvar_Get("in_logitechbug", "0", CVAR_ARCHIVE);

	// joystick variables
	in_joystick = Cvar_Get("in_joystick", "0", CVAR_ARCHIVE | CVAR_LATCH);
	in_joyBallScale = Cvar_Get("in_joyBallScale", "0.02", CVAR_ARCHIVE);
	in_debugJoystick = Cvar_Get("in_debugjoystick", "0", CVAR_TEMP);

	joy_threshold = Cvar_Get("joy_threshold", "0.15", CVAR_ARCHIVE);

	IN_Startup();
}


/*
===========
IN_Activate

Called when the main window gains or loses focus.
The window may have been destroyed and recreated
between a deactivate and an activate.
===========
*/
void IN_Activate(qboolean active) {
	in_appactive = active;

	if (!active)
		IN_DeactivateMouse();
}


/*
convert range from 0..32768..65535 to -1..0..1
*/
static float JoyToF(int value) {
	if (value < 0)
		return -1;
	if (value > 65535)
		return 1;
	return (value - 32768) / 32768.0;
}


static int JoyToI(int value) {
	// move centerpoint to zero
	value -= 32768;

	return value;
}


int	joyDirectionKeys[16] = {
	K_LEFTARROW, K_RIGHTARROW,	// X軸
	K_UPARROW, K_DOWNARROW,		// Y軸
	K_JOY16, K_JOY17,			// Z軸(負の方向、正の方向)
	K_JOY18, K_JOY19,			// R軸(負の方向、正の方向)
	K_JOY20, K_JOY21,			// (使われていない)
	K_JOY22, K_JOY23,			// (使われていない)

	K_JOY24, K_JOY25,			// POVのforward, backward
	K_JOY26, K_JOY27			// POVのright, left
};


/*
ジョイスティックの状態を調べ、キーイベントとしてイベントキューにポストする。
(ボタンだけでなく、スティック(X,Y,Z,R)についても各軸の正負の方向それぞれに仮想的なボタン(キー)を割り当て、キーイベントとして扱う。)
(スティックの傾きは、仕様上は0から65535までの値をとるが、本プログラムでは、負、0、正の3つの値しかとらない。)
ただし、トラックボール(U、V軸)は、マウスカーソルのイベントとしてイベントキューにポストされる。
*/
void IN_JoyMove(void) {
	JOYINFOEX ji;
	// verify joystick is available and that the user wants to use it
	if (!joy.avail)
		return;

	// collect the joystick data, if possible
	Com_Memset(&ji, 0, sizeof(ji));
	ji.dwSize = sizeof(ji);
	ji.dwFlags = JOY_RETURNALL;
	if (joyGetPosEx(joy.id, &ji) != JOYERR_NOERROR) {
		// read error occurred
		// turning off the joystick seems too harsh(厳しい) for 1 read error,
		// but what should be done?
		return;
	}

	if (in_debugJoystick->integer) {
		Com_Printf("%8x %5i %5.2f %5.2f %5.2f %5.2f %6i %6i\n",
				   ji.dwButtons,
				   ji.dwPOV,
				   JoyToF(ji.dwXpos), JoyToF(ji.dwYpos),
				   JoyToF(ji.dwZpos), JoyToF(ji.dwRpos),
				   JoyToI(ji.dwUpos), JoyToI(ji.dwVpos));
	}

	// 前回チェックした時(通常は直前のフレーム)と押下状態の異なるボタンがあれば、それらのボタンに対応するイベントをキューにポストする
	{
		DWORD buttonState = ji.dwButtons;
		int buttonstateChanged = ji.dwButtons ^ joy.oldbuttonstate;
		for (int i = 0; i < joy.jc.wNumButtons; i++) {
			// old new
			// off off -> no event
			// off on  -> pressed event
			// on  off -> released event
			// on  on  -> no event
			int buttonBit = 1 << i;
			if ((buttonstateChanged & buttonBit) == 0)
				continue;
			Sys_QueEvent(g_wv.sysMsgTime, SE_KEY, K_JOY1 + i, ((buttonState & buttonBit) != 0) ? 1 : 0, 0, NULL);
		}
		joy.oldbuttonstate = buttonState;
	}

	// povstate bit0が1の場合、ジョイスティックが閾値よりも左(負の方向)に倒れていることを示す。
	// bit1が1の場合、閾値よりも右(正の方向)に倒れていることを示す。以下同様に、YZRUVと続く。
	// bit     軸
	//  0, 1...X
	//  2, 3...Y
	//  4, 5...Z
	//  6, 7...R
	// 12,13...POV_Y
	// 14,15...POV_X
	// (8〜11は使われない。U、V軸については、トラックボールなので別扱いしている)
	// 各ビットの意味は、本関数内部でしか使用されない。

	DWORD povstate = 0;
	// convert main joystick motion into 6 direction button bits
	for (int i = 0; i < joy.jc.wNumAxes && i < 4; i++) {
		// get the floating point zero-centered, potentially-inverted data for the current axis
		float fAxisValue = JoyToF((&ji.dwXpos)[i]);	// dwXpos, dwYpos, dwZpos, dwRpos, dwUpos, dwVpos

		if (fAxisValue < -joy_threshold->value)
			povstate |= (1 << (i * 2));
		else if (fAxisValue > joy_threshold->value)
			povstate |= (1 << (i * 2 + 1));
	}

	// convert POV information from a direction into 4 button bits
	if (joy.jc.wCaps & JOYCAPS_HASPOV) {
		if (ji.dwPOV != JOY_POVCENTERED) {
			if (ji.dwPOV == JOY_POVFORWARD)
				povstate |= 1 << 12;
			if (ji.dwPOV == JOY_POVBACKWARD)
				povstate |= 1 << 13;
			if (ji.dwPOV == JOY_POVRIGHT)
				povstate |= 1 << 14;
			if (ji.dwPOV == JOY_POVLEFT)
				povstate |= 1 << 15;
		}
	}

	// determine which bits have changed and key an auxillary event for each change
	for (int i = 0; i < 16; i++) {
		if ((povstate & (1 << i)) && !(joy.oldpovstate & (1 << i))) {
			Sys_QueEvent(g_wv.sysMsgTime, SE_KEY, joyDirectionKeys[i], 1, 0, NULL);
		}

		if (!(povstate & (1 << i)) && (joy.oldpovstate & (1 << i))) {
			Sys_QueEvent(g_wv.sysMsgTime, SE_KEY, joyDirectionKeys[i], 0, 0, NULL);
		}
	}
	joy.oldpovstate = povstate;

	// if there is a trackball like interface, simulate mouse moves
	if (joy.jc.wNumAxes >= 6) {
		int x = JoyToI(ji.dwUpos) * in_joyBallScale->value;
		int y = JoyToI(ji.dwVpos) * in_joyBallScale->value;
		if (x || y) {
			Sys_QueEvent(g_wv.sysMsgTime, SE_MOUSE, x, y, 0, NULL);
		}
	}
}


/*
Called every frame, even if not generating commands
*/
void IN_Frame(void) {
	// post joystick events
	IN_JoyMove();

	if (!s_wmv.mouseInitialized) {
		if (s_wmv.mouseStartupDelayed && g_wv.hWnd) {
			Com_Printf("Proceeding with delayed mouse init\n");
			IN_StartupMouse();
			s_wmv.mouseStartupDelayed = 0;
		}
		return;
	}

	if (cls.keyCatchers & KEYCATCH_CONSOLE) {
		// temporarily deactivate if not in the game and
		// running on the desktop
		if (Cvar_VariableValue("r_fullscreen") == 0) {
			IN_DeactivateMouse();
			return;
		}
	}

	if (!in_appactive) {
		IN_DeactivateMouse();
		return;
	}

	IN_ActivateMouse();

	// post events to the system que
	IN_MouseMove();
}


void IN_ClearStates(void) {
	s_wmv.oldButtonState = 0;
}


