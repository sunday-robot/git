// SetVolume.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"
#include "windows.h"
#include <string>

void showMixerCaps(int deviceNumber) {
	MMRESULT r;

	MIXERCAPS mixerCaps;
	memset(&mixerCaps, 0, sizeof(mixerCaps));
	r = mixerGetDevCaps(deviceNumber, &mixerCaps, sizeof(mixerCaps));
	printf("device number　= %d:\n", deviceNumber);
	printf("wMid           = %d\n", mixerCaps.wMid);	// Manifacture Identifier(メーカーの番号)
	printf("wPid           = %d\n", mixerCaps.wPid);	// Product Identifier(製品番号)
	printf("vDriverVersion = %04xh\n", mixerCaps.vDriverVersion);	// ドライバーのバージョン、上位8ビットがメジャー、下位8ビットがマイナー
	printf("szPname        = [%s]\n", mixerCaps.szPname);	// 製品名
	printf("fdwSupport     = %d\n", mixerCaps.fdwSupport);	// 現在のところ常に0?
	printf("cDestinations  = %d\n", mixerCaps.cDestinations);	// よくわからないが、このミキサーの出力のライン数とのこと
	printf("\n");
}

void showAllMixerCaps() {
	UINT numDevs;
	numDevs = mixerGetNumDevs();
	for (int i = 0; i < (int) numDevs; i++) {
		showMixerCaps(i);
	}
}

bool openMasterVolumeMixer(HMIXER *hmx) {
	MMRESULT r;

	// ミキサーをオープン(最初のデバイスがマスターボリュームらしい)
	r = mixerOpen(hmx, 0, 0, 0, MIXER_OBJECTF_MIXER);
	if (r != MMSYSERR_NOERROR) {
		perror("mixerOpen()");
		return false;
	}

	return true;
}

bool getMasterVolumeControl(HMIXER hmx, MIXERCONTROL *ctl) {
	MMRESULT r;

	memset(ctl, 0, sizeof(*ctl));

	MIXERLINECONTROLS mxlc;
	memset(&mxlc, 0, sizeof(mxlc));
	mxlc.cbStruct = sizeof(mxlc);
	mxlc.dwControlType = MIXERCONTROL_CONTROLTYPE_VOLUME;
	mxlc.cControls = 1;
	mxlc.cbmxctrl = sizeof(*ctl);
	mxlc.pamxctrl = ctl;
	r = mixerGetLineControls((HMIXEROBJ) hmx, &mxlc, MIXER_OBJECTF_HMIXER | MIXER_GETLINECONTROLSF_ONEBYTYPE);
	if (r != MMSYSERR_NOERROR) {
		perror("mixerGetLineControls()");
		return false;
	}
	return true;
}

bool getMasterVolume(
	HMIXER hmx,
	const MIXERCONTROL &ctl,
	int *volume) {
	MMRESULT r;

	MIXERCONTROLDETAILS_UNSIGNED mxcdVolume;
	mxcdVolume.dwValue = 0;
	MIXERCONTROLDETAILS mxcd;
	memset(&mxcd, 0, sizeof(mxcd));
	mxcd.cbStruct = sizeof(mxcd);
	mxcd.dwControlID = ctl.dwControlID;
	mxcd.cChannels = 1;
	mxcd.cMultipleItems = 0;
	mxcd.cbDetails = sizeof(MIXERCONTROLDETAILS_UNSIGNED);
	mxcd.paDetails = &mxcdVolume;
	r = mixerGetControlDetails((HMIXEROBJ) hmx, &mxcd, MIXER_GETCONTROLDETAILSF_VALUE | MIXER_OBJECTF_HMIXER);
	if (r != MMSYSERR_NOERROR) {
		perror("mixerGetLineControls()");
		return false;
	}

	*volume = (int) mxcdVolume.dwValue;
	return true;
}

int _tmain(int argc, _TCHAR* argv[])
{
	MMRESULT r;

	HMIXER hmx;
	openMasterVolumeMixer(&hmx);

	MIXERCONTROL ctl;
	getMasterVolumeControl(hmx, &ctl);

	int volume;
	getMasterVolume(hmx, ctl, &volume);

	showAllMixerCaps();

	UINT numDevs;
	numDevs = mixerGetNumDevs();
	for (int i = 0; i < numDevs; i++) {

		MIXERCAPS mixerCaps;
		memset(&mixerCaps, 0, sizeof(mixerCaps));
		r = mixerGetDevCaps(i, &mixerCaps, sizeof(mixerCaps));

		HMIXER hmx;
		r = mixerOpen(&hmx, i, 0, 0, MIXER_OBJECTF_MIXER);

		MIXERLINE mxl;
		memset(&mxl, 0, sizeof(mxl));
		mxl.cbStruct = sizeof(mxl);
		mxl.dwComponentType = MIXERLINE_COMPONENTTYPE_DST_SPEAKERS;
		r = mixerGetLineInfo((HMIXEROBJ) hmx, &mxl, MIXER_OBJECTF_HMIXER | MIXER_GETLINEINFOF_COMPONENTTYPE);

		MIXERCONTROL *ctl = new MIXERCONTROL[mxl.cControls];
		MIXERLINECONTROLS mxlc;
		memset(&mxlc, 0, sizeof(mxlc));
		mxlc.cbStruct = sizeof(mxlc);
		mxlc.cControls = mxl.cControls;
		mxlc.dwLineID = mxl.dwLineID;
		mxlc.cbmxctrl = sizeof(*ctl);
		mxlc.pamxctrl = ctl;
		r = mixerGetLineControls((HMIXEROBJ) hmx, &mxlc, 0);
		for (int j = 0; j < mxl.cControls; j++) {
			if (ctl[j].dwControlType == MIXERCONTROL_CONTROLTYPE_VOLUME) {
				break;
			}
		}
		r = 0;
	}
	return 0;
}
