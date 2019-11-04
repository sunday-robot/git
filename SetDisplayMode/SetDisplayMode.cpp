// 用語：
// pel...picture elementの略らしい(直訳すると画素?)。pixelと同じものらしい。

#include "stdafx.h"
#include <windows.h>
#include <WinUser.h>

void printDisplayMode(const DEVMODE* devMode) {
	DWORD displayFlags = devMode->dmDisplayFlags;
	if ((displayFlags & DM_INTERLACED) != 0) {
		wprintf(L"DM_INTERLACED mode\n");
		displayFlags &= ~DM_INTERLACED;
	}
	if ((displayFlags & DMDISPLAYFLAGS_TEXTMODE) != 0) {
		wprintf(L"DMDISPLAYFLAGS_TEXTMODE mode\n");
		displayFlags &= ~DMDISPLAYFLAGS_TEXTMODE;
	}
	if (displayFlags != 0) {
		wprintf(L"unknown dmDisplayFlags = %08x\n", displayFlags);
	}
#if 0
	wprintf(L"dmBitsPerPel = %d\n", devMode->dmBitsPerPel);
	wprintf(L"dmPelsWidth = %d\n", devMode->dmPelsWidth);
	wprintf(L"dmPelsHeight = %d\n", devMode->dmPelsHeight);
	wprintf(L"dmDisplayFlags = %08x\n", devMode->dmDisplayFlags);
	wprintf(L"dmDisplayFrequency = %d\n", devMode->dmDisplayFrequency);
	wprintf(L"\n");
#else
	wprintf(L"%dbits, %dx%d, %dHz\n", devMode->dmBitsPerPel, devMode->dmPelsWidth, devMode->dmPelsHeight, devMode->dmDisplayFrequency);
#endif
}

// 指定されたデバイス(ディスプレイ)に設定可能な設定(画素数、ビット深度、周波数)を列挙する。
void enumerateDisplaySettings(const WCHAR* deviceName) {
	DEVMODE devMode;
	devMode.dmSize = sizeof(devMode);
	devMode.dmDriverExtra = 0;// ???
	//DWORD flags = EDS_RAWMODE;
	//DWORD flags = EDS_ROTATEDMODE;
	//DWORD flags = EDS_RAWMODE | EDS_ROTATEDMODE;
	DWORD flags = 0;

	int modeNum = 0;
	for (;;) {
		if (!EnumDisplaySettingsEx(deviceName, modeNum, &devMode, flags))
			break;
		wprintf(L"%d:\n", modeNum);
		printDisplayMode(&devMode);
		modeNum++;
	}
}

// PCに存在するディスプレイアダプターの情報を列挙する。
void enumerateDisplaySettings() {
	for (int i = 0;; i++) {
		DISPLAY_DEVICE displayDevice;
		memset(&displayDevice, 0, sizeof(displayDevice));
		displayDevice.cb = sizeof(displayDevice);
		if (!EnumDisplayDevices(NULL, i, &displayDevice, 0)) {
			break;
		}

		wprintf(L"%d:\n", i);
		DWORD stateFlags = displayDevice.StateFlags;
		if ((stateFlags & DISPLAY_DEVICE_ACTIVE) != 0) {
			wprintf(L"DISPLAY_DEVICE_ACTIVE\n");
			stateFlags &= ~DISPLAY_DEVICE_ACTIVE;
		}
		if ((stateFlags & DISPLAY_DEVICE_MIRRORING_DRIVER) != 0) {
			wprintf(L"DISPLAY_DEVICE_MIRRORING_DRIVER\n");
			stateFlags &= ~DISPLAY_DEVICE_MIRRORING_DRIVER;
		}
		if ((stateFlags & DISPLAY_DEVICE_MODESPRUNED) != 0) {
			wprintf(L"DISPLAY_DEVICE_MODESPRUNED\n");
			stateFlags &= ~DISPLAY_DEVICE_MODESPRUNED;
		}
		if ((stateFlags & DISPLAY_DEVICE_PRIMARY_DEVICE) != 0) {
			wprintf(L"DISPLAY_DEVICE_PRIMARY_DEVICE\n");
			stateFlags &= ~DISPLAY_DEVICE_PRIMARY_DEVICE;
		}
		if ((stateFlags & DISPLAY_DEVICE_REMOVABLE) != 0) {
			wprintf(L"DISPLAY_DEVICE_REMOVABLE\n");
			stateFlags &= ~DISPLAY_DEVICE_REMOVABLE;
		}
		if ((stateFlags & DISPLAY_DEVICE_VGA_COMPATIBLE) != 0) {
			wprintf(L"DISPLAY_DEVICE_VGA_COMPATIBLE\n");
			stateFlags &= ~DISPLAY_DEVICE_VGA_COMPATIBLE;
		}
		if (stateFlags != 0) {
			wprintf(L"unknown stateFlags = %08x\n", stateFlags);
		}
		wprintf(L"DeviceName = %s\n", displayDevice.DeviceName);
		wprintf(L"DeviceString = %s\n", displayDevice.DeviceString);
		wprintf(L"StateFlags = %08x\n", displayDevice.StateFlags);
		wprintf(L"DeviceID = %s\n", displayDevice.DeviceID);
		wprintf(L"DeviceKey = %s\n", displayDevice.DeviceKey);
		wprintf(L"\n");

		enumerateDisplaySettings(displayDevice.DeviceName);
	}
}

// 指定されたディスプレイアダプターの表示サイズ(ピクセル数)を変更する。
// ビット深度、周波数などは変更しない。
// ディスプレイアダプターが対応していない表示サイズが指定された場合は失敗する。
boolean setDisplaySize(const WCHAR* displayAdapterName, int width, int height) {
	DEVMODE devMode;
	memset(&devMode, 0, sizeof(devMode));
	devMode.dmSize = sizeof(devMode);
	if (!EnumDisplaySettingsEx(displayAdapterName, ENUM_CURRENT_SETTINGS, &devMode, 0))
		return false;
	devMode.dmPelsWidth = width;
	devMode.dmPelsHeight = height;
	if (!ChangeDisplaySettingsEx(displayAdapterName, &devMode, NULL, 0, NULL)) {
		return false;
	}
	return true;
}

// 指定されたディスプレイアダプターに接続されているモニターの情報を列挙する。
void enumerateDisplayMonitors(WCHAR* displayAdapterName) {
	for (int i = 0;; i++) {
		DISPLAY_DEVICE displayDevice;
		memset(&displayDevice, 0, sizeof(displayDevice));
		displayDevice.cb = sizeof(displayDevice);
		if (!EnumDisplayDevices(displayAdapterName, i, &displayDevice, 0)) {
			break;
		}

		wprintf(L"%d:\n", i);
		wprintf(L"DeviceName = %s\n", displayDevice.DeviceName);
		wprintf(L"DeviceString = %s\n", displayDevice.DeviceString);
		wprintf(L"StateFlags = %08x\n", displayDevice.StateFlags);
		wprintf(L"DeviceID = %s\n", displayDevice.DeviceID);
		wprintf(L"DeviceKey = %s\n", displayDevice.DeviceKey);
		wprintf(L"\n");

	}
}

// PCに存在するディスプレイアダプターの情報を列挙する。
void enumerateDisplayAdapters() {
	for (int i = 0;; i++) {
		DISPLAY_DEVICE displayDevice;
		memset(&displayDevice, 0, sizeof(displayDevice));
		displayDevice.cb = sizeof(displayDevice);
		if (!EnumDisplayDevices(NULL, i, &displayDevice, 0)) {
			break;
		}

		wprintf(L"%d:\n", i);
		wprintf(L"DeviceName = %s\n", displayDevice.DeviceName);
		wprintf(L"DeviceString = %s\n", displayDevice.DeviceString);
		wprintf(L"StateFlags = %08x\n", displayDevice.StateFlags);
		wprintf(L"DeviceID = %s\n", displayDevice.DeviceID);
		wprintf(L"DeviceKey = %s\n", displayDevice.DeviceKey);
		wprintf(L"\n");

		enumerateDisplayMonitors(displayDevice.DeviceName);
	}
}

void printCurrentDisplaySetting(const WCHAR* deviceName) {
	DEVMODE devMode;
	memset(&devMode, 0, sizeof(devMode));
	devMode.dmSize = sizeof(devMode);
	if (!EnumDisplaySettingsEx(deviceName, ENUM_CURRENT_SETTINGS, &devMode, 0))
		return;
	printDisplayMode(&devMode);
}

int _tmain(int argc, _TCHAR* argv[]) {
#if 0
	const int MAX_DISPLAY_COUNT = 10;
	int displayCount = MAX_DISPLAY_COUNT;
	WCHAR deviceNames[MAX_DISPLAY_COUNT][32];
	for (int i = 0; i < MAX_DISPLAY_COUNT; i++) {
		DISPLAY_DEVICE displayDevice;
		displayDevice.cb = sizeof(displayDevice);
		if (!EnumDisplayDevices(NULL, i, &displayDevice, 0)) {
			displayCount = i;
			break;
		}
		wcscpy_s(deviceNames[i], 32, displayDevice.DeviceName);
		wprintf(L"%s\n", deviceNames[i]);
		//		setDisplaySize(deviceNames[i], 1024, 768);
		//		return 0;
		enumSettings(deviceNames[i]);
	}
	//DEVMODE devMode;
	//devMode.dmFields = DM_POSITION;
	//devMode.dmPosition = 
	//ChangeDisplaySettingsEx(deviceName, devMode, hwnd, flags, param);
#else
	enumerateDisplaySettings();
	//	enumerateDisplayAdapters();
#endif
	(void)getchar();
	return 0;
}


//namespace SetDisplayMode
//{
//	class Program
//	{
//		[DllImport("coredll.dll")]
//
//		static extern int ChangeDisplaySettingsEx(string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, int dwflags, IntPtr lParam);
//
//		[StructLayout(LayoutKind.Sequential)]
//		public struct DEVMODE
//		{
//			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
//			public string dmDeviceName;
//			public short dmSpecVersion;
//			public short dmDriverVersion;
//			public short dmSize;
//			public short dmDriverExtra;
//			public int dmFields;
//			public short dmOrientation;
//			public short dmPaperSize;
//			public short dmPaperLength;
//			public short dmPaperWidth;
//			public short dmScale;
//			public short dmCopies;
//			public short dmDefaultSource;
//			public short dmPrintQuality;
//			public short dmColor;
//			public short dmDuplex;
//			public short dmYResolution;
//			public short dmTTOption;
//			public short dmCollate;
//			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
//			public string dmFormName;
//			public short dmLogPixels;
//			public int dmBitsPerPel;
//			public int dmPelsWidth;
//			public int dmPelsHeight;
//			public int dmDisplayFlags;
//			public int dmDisplayFrequency;
//			public int dmDisplayOrientation;
//		}
