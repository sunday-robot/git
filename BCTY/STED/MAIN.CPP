#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <dir.h>
#include <mylib.h>
#include <mouse.h>

#include "gr.h"
#include "super.h"
#include "event.h"

#include "..\pat.h"
#include "stg_lst.h"
#include "sl_scrn.h"
#include "se_scrn.h"
#include "ev_mngr.h"

EventManager event_manager(2);

char stage_file_name[MAXPATH];

void read_files(char *argv0)
{
	char drive[MAXDRIVE], dir[MAXDIR];
	char file_name[MAXPATH];

	int npat = 0;
	int r;
	fnsplit(argv0, drive, dir, NULL, NULL);
	fnmerge(file_name, drive, dir, "bcty16", ".bft");
	if ((r = super_entry_bfnt((unsigned char *) file_name, 0, 0)) < 0) {
		printf("can not load %s\n", file_name);
		exit(1);
	}
	npat += r;
	fnmerge(file_name, drive, dir, "bcty32_1", ".bft");
	if ((r = super_entry_bfnt((unsigned char *) file_name, 0, 0)) < 0) {
		printf("can not load %s\n", file_name);
		exit(1);
	}
	npat += r;
	fnmerge(file_name, drive, dir, "bcty32_2", ".bft");
	if ((r = super_entry_bfnt((unsigned char *) file_name, 0, 0)) < 0) {
		printf("can not load %s\n", file_name);
		exit(1);
	}
	npat += r;
	{
//		for (int i = 0; i < npat; i++)
//			super_put((i % 20) * 32, (i / 20) * 32, i);
	}
	grReadBfntPalet("bcty16.bft", 1);
	grPal1(0, 0, 0, 0);	// パレット0を真っ黒に
	grPalTone(grSt.pal, 100);
}

atexit_t fin(void)
{
	m_cursor(0);
	cursor_on();
	eqFin();
//	grEnd();
	return 0;
}

void init(void)
{
	atexit(fin);
	grStart();
	if (!fntInit("ank.bft"))
		fntInit(NULL);
	txtCls();
	eqInit();
	int ev_mask = KeyEvent | MouseEvent;
	if (ev_mask != eqSetEventMask(ev_mask)) {
		fprintf(stderr, "Install mouse driver !\n");
		exit(1);
	}
	m_cursor(1);
	cursor_off();
}

void main(int argc, char *argv[])
{
	init();

	read_files(argv[0]);

	event_manager.addScreen(&stage_list_screen);
	event_manager.addScreen(&stage_edit_screen);
	event_manager.changeMode(0);
	event_manager.run();
}
