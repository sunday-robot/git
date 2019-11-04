/*
===========================================================================
Copyright (C) 1999-2005 Id Software, Inc.

This file is part of Quake III Arena source code.

Quake III Arena source code is free software; you can redistribute it
and/or modify it under the terms of the GNU General Public License as
published by the Free Software Foundation; either version 2 of the License,
or (at your option) any later version.

Quake III Arena source code is distributed in the hope that it will be
useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
===========================================================================
*/
#include "../client.h"
#include "../../qcommon/qcommon.h"
#include "../../qcommon/win32/win_local.h"

/*
========================================================================

EVENT LOOP

========================================================================
*/

#define	MAX_QUED_EVENTS		256
#define	MASK_QUED_EVENTS	( MAX_QUED_EVENTS - 1 )

static sysEvent_t	eventQue[MAX_QUED_EVENTS];
static int			eventHead;	// ���̃C�x���g������ʒu(��ԐV�����C�x���g�̎��̈ʒu)
static int			eventTail;	// ���ɃC�x���g�����o���ʒu(��ԌÂ��C�x���g�̈ʒu)
static byte		sys_packetReceived[MAX_MSGLEN];

/*
================
Sys_QueEvent

A time of 0 will get the current time
Ptr should either be null, or point to a block of data that can
be freed by the game later.
================
*/
void Sys_QueEvent(int time, sysEventType_t type, int value, int value2, int ptrLength, void *ptr) {
	sysEvent_t	*ev;

	ev = &eventQue[eventHead & MASK_QUED_EVENTS];
	if (eventHead - eventTail >= MAX_QUED_EVENTS) {
		// �C�x���g�L���[����t(256��)�̏ꍇ�A��ԌÂ��C�x���g���̂ĂĂ��܂��B
		Com_Printf("Sys_QueEvent: overflow\n");
		// we are discarding an event, but don't leak memory
		if (ev->evPtr) {
			Z_Free(ev->evPtr);
		}
		eventTail++;
	}

	eventHead++;

	ev->evTime = (time == 0) ? Sys_Milliseconds() : time;	// ���̃����o�[�ɃZ�b�g�����̂�time�ł����Windows�N������̌o�ߎ��ԁASys_Milliseconds()�ł���΃Q�[���N������̌o�ߎ��ԁc
	ev->evType = type;
	ev->evValue = value;
	ev->evValue2 = value2;
	ev->evPtrLength = ptrLength;
	ev->evPtr = ptr;
}

/*
�}�E�X�A�W���C�X�e�B�b�N�Ȃǂ�Q3A�Ǝ��̃C�x���g�L���[�B
�ȉ��̃C�x���g����������C�x���g�����o���Aquake�̃C�x���g�L���[�ɓo�^����B
�EWindows�̃C�x���g�L���[
�Equake�R���\�[����ʂɓ��͂��ꂽ�R�}���h
�E�ʐM�p�P�b�g
���o���ꂽ�C�x���g�̐擪�̂���(��ԌÂ�����)��Ԃ��B
�����C�x���g�����o���Ȃ��ꍇ�́A�_�~�[�C�x���g�𐶐����A�Ԃ��B
*/
sysEvent_t Sys_GetEvent(void) {
	MSG			msg;
	sysEvent_t	ev;
	char		*s;
	msg_t		netmsg;
	netadr_t	adr;

	// �L���[�ɂ��܂��Ă�����̂�����΂�������o���āA�Ԃ��B
	if (eventHead > eventTail) {
		eventTail++;
		return eventQue[(eventTail - 1) & MASK_QUED_EVENTS];
	}

	// Windows�̃C�x���g�L���[���痭�܂��Ă���C�x���g��S�Ď��o���Aquake�̃C�x���g�L���[�ɂ��ߍ��ށB(quake�̃C�x���g�L���[�ւ̂��ߍ��ݏ����́A�{�֐��ł͂Ȃ��ADispatchMessage�o�R�ŌĂяo�����WndProc�ōs���炵���B)
	while (PeekMessage(&msg, NULL, 0, 0, PM_NOREMOVE)) {
		if (!GetMessage(&msg, NULL, 0, 0))
			Com_Quit_f();	// ��펖�ԂŁA�A�v���P�[�V�������I��点�Ă��܂��炵���B(Com_�́ACommand���ł͂Ȃ��ACommon�̗��炵���B)

		// save the msg time, because wndprocs don't have access to the timestamp
		g_wv.sysMsgTime = msg.time;	// �V�X�e���N������̌o�ߎ���(�P��ms)

		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	// check for console commands
	s = Sys_ConsoleInput();
	if (s != NULL) {
		int len = strlen(s) + 1;
		char *b = Z_Malloc(len);
		Q_strncpyz(b, s, len - 1);
		Sys_QueEvent(0, SE_CONSOLE, 0, 0, len, b);
	}

	// check for network packets
	MSG_Init(&netmsg, sys_packetReceived, sizeof(sys_packetReceived));
	if (Sys_GetPacket(&adr, &netmsg)) {
		// copy out to a seperate buffer for qeueing
		// the readcount stepahead is for SOCKS support
		int len = sizeof(netadr_t)+netmsg.cursize - netmsg.readcount;
		netadr_t *buf = Z_Malloc(len);
		*buf = adr;
		memcpy(buf + 1, &netmsg.data[netmsg.readcount], netmsg.cursize - netmsg.readcount);
		Sys_QueEvent(0, SE_PACKET, 0, 0, len, buf);
	}

	// return if we have data
	if (eventHead > eventTail) {
		eventTail++;
		return eventQue[(eventTail - 1) & MASK_QUED_EVENTS];
	}

	// create an empty event to return
	memset(&ev, 0, sizeof(ev));
	ev.evTime = timeGetTime();	// Windows�N������̌o�ߎ���(ms�P��)

	return ev;
}
