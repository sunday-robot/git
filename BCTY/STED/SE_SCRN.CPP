#include <stdio.h>
#include <assert.h>
#include <mouse.h>
#include <mylib.h>
#include "..\super_bc.h"
#include "..\pat.h"
#include "ev_mngr.h"
#include "button.h"
#include "se_scrn.h"
#include "mp_pnl.h"
#include "me_pnl.h"
#include "te_pnl.h"
#include "ts_pnl.h"

#define nPanels 10

#define BUTTON_X ((MAP_SIZE + 3) * 16)
#define BUTTON_Y (400 - 32)

StageEditScreen stage_edit_screen;

CurrentMapPartsPanel *current_map_parts_panel;
MapSelectPanel *map_select_panel;
MapEditPanel *map_edit_panel;
CurrentTankPanel *current_tank_panel;
TankEditPanel *tank_edit_panel;
TankSelectPanel *tank_select_panel;

void cbpMapEdit(Panel *p, Event *e, void *d)
{
	if (!(e->type & (MotionNotify | LeftButtonPress | RightButtonPress)))
		return;
	int xx, yy;
	xx = (e->mouse.x - p->getX()) / 16;
	yy = (e->mouse.y - p->getY()) / 14;
	MapEditPanel *mep = (MapEditPanel *) p;
	CurrentMapPartsPanel *cmpp = (CurrentMapPartsPanel *) d;
	if ((e->type & MotionNotify && e->mouse.left_button)
		|| (e->type & LeftButtonPress)) {
		MapParts mp = cmpp->getParts();
		if (cmpp->getPensize() == 2) {
			mep->putParts(xx, yy, mp);
			mep->putParts(xx + 1, yy, mp);
			mep->putParts(xx, yy + 1, mp);
			mep->putParts(xx + 1, yy + 1, mp);
		} else
			mep->putParts(xx, yy, mp);
	}
	if (e->type & RightButtonPress) {
		cmpp->setParts(mep->getParts(xx, yy));
	}
}

void cbpMapSelect(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
	CurrentMapPartsPanel *cmpp = (CurrentMapPartsPanel *) d;
	cmpp->setParts((MapParts) ((e->mouse.x - p->getX()) / 16));
}

void cbpTankEdit(Panel *p, Event *e, void *d)
{
	if (!(e->type & (MotionNotify | LeftButtonPress | RightButtonPress)))
		return;
	int xx, yy;
	xx = (e->mouse.x - p->getX()) / 32;
	yy = (e->mouse.y - p->getY()) / 32;
	TankEditPanel *tep = (TankEditPanel *) p;
	CurrentTankPanel *ctp = (CurrentTankPanel *) d;
	if (e->type & MotionNotify) {
		if (e->mouse.left_button) {
			tep->putTankElement(xx, yy, ctp->getTank());
		}
	}
	if (e->type & LeftButtonPress) {
		tep->putTankElement(xx, yy, ctp->getTank());
	}
	if (e->type & RightButtonPress) {
		ctp->setTank(tep->getTankElement(xx, yy));
	}
}

void cbpSelectTank(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
	CurrentTankPanel *ctp = (CurrentTankPanel *) d;
	ctp->setTank(TankElement((e->mouse.x - p->getX()) / 32,
		(e->mouse.y - p->getY()) / 32));
}

struct SetPensizeData {
	CurrentMapPartsPanel *cmpp;
	Button *anotherButton;
	int pensize;
	SetPensizeData(CurrentMapPartsPanel *_cmpp, Button * _ab, int _pensize)
	{
		cmpp = _cmpp;
		anotherButton = _ab;
		pensize = _pensize;
	};
};

void cbpSetPensize(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
	Button *b = (Button *) p;
	b->down();
	SetPensizeData *spd = (SetPensizeData *) d;
	spd->anotherButton->up();
	spd->cmpp->setPensize(spd->pensize);
}

void cbpEditEndAbort(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
	Button *b = (Button *) p;
	b->down();
	if (d != 0) {
		Stage *stage = *(Stage **) d;
		Map m;
		map_edit_panel->getMap(m);
		stage->setMap(m);
		Tank t;
		tank_edit_panel->getTank(t);
		stage->setTank(t);
	}
	b->up();
	event_manager.changeMode(0);
}

StageEditScreen::StageEditScreen() : Screen(nPanels)
{
	Callback *cb;
	Button *size1, *size2;
	Button *edit_end, *edit_abort;

	assert(map_edit_panel = new MapEditPanel);
	assert(current_map_parts_panel = new CurrentMapPartsPanel);
	assert(map_select_panel = new MapSelectPanel);
	assert(tank_edit_panel = new TankEditPanel);
	assert(current_tank_panel = new CurrentTankPanel);
	assert(tank_select_panel = new TankSelectPanel);
	assert(size1 = new Button("x1", SPB_X, SPB_Y, SPB_WIDTH, SPB_HEIGHT));
	assert(size2 = new Button("x2", SPB_X + SPB_WIDTH, SPB_Y, SPB_WIDTH,
		SPB_HEIGHT));
	size1->down();
	assert(edit_end = new Button("End", BUTTON_X, BUTTON_Y));
	assert(edit_abort = new Button("Abort", BUTTON_X + ButtonWidth, BUTTON_Y));

	assert(cb = new Callback(cbpMapEdit, current_map_parts_panel));
	assert(map_edit_panel->addCallback(cb));
	assert(cb = new Callback(cbpMapSelect, current_map_parts_panel));
	assert(map_select_panel->addCallback(cb));
	assert(cb = new Callback(cbpTankEdit, current_tank_panel));
	assert(tank_edit_panel->addCallback(cb));
	assert(cb = new Callback(cbpSelectTank, current_tank_panel));
	assert(tank_select_panel->addCallback(cb));
	assert(cb = new Callback(cbpSetPensize,
		new SetPensizeData(current_map_parts_panel, size2, 1)));
	assert(size1->addCallback(cb));
	assert(cb = new Callback(cbpSetPensize,
		new SetPensizeData(current_map_parts_panel, size1, 2)));
	assert(size2->addCallback(cb));
	assert(cb = new Callback(cbpEditEndAbort, &stage));
	assert(edit_end->addCallback(cb));
	assert(cb = new Callback(cbpEditEndAbort, 0));
	assert(edit_abort->addCallback(cb));

	assert(addPanel(map_edit_panel));
	assert(addPanel(tank_edit_panel));
	assert(addPanel(map_select_panel));
	assert(addPanel(tank_select_panel));
	assert(addPanel(current_map_parts_panel));
	assert(addPanel(current_tank_panel));
	assert(addPanel(size1));
	assert(addPanel(size2));
	assert(addPanel(edit_end));
	assert(addPanel(edit_abort));
}

void StageEditScreen::setStage(Stage *_stage)
{
	stage = _stage;
	Map map;
	Tank tank;
	stage->getMap(map);
	stage->getTank(tank);
	map_edit_panel->setMap(map);
	tank_edit_panel->setTank(tank);
}

void StageEditScreen::show()
{
	int i = 0;
	int mcs = m_get_cursor_state();
	m_cursor(0);
	over_put_1614(0, 0, PAT_FRAME_UL);
	over_put_1614(MAP_SIZE + 1, 0, PAT_FRAME_UR);
	over_put_1614(0, MAP_SIZE + 1, PAT_FRAME_LL);
	over_put_1614(MAP_SIZE + 1, MAP_SIZE + 1, PAT_FRAME_LR);
	for (i = 0; i < MAP_SIZE; i++) {
		// Žü‚è‚Ì˜g(ã‰º)
		over_put_1614(i + 1, 0, PAT_FRAME_H);
		over_put_1614(i + 1, MAP_SIZE + 1, PAT_FRAME_H);
		// Žü‚è‚Ì˜g(¶‰E)
		over_put_1614(0, i + 1, PAT_FRAME_V);
		over_put_1614(MAP_SIZE + 1, i + 1, PAT_FRAME_V);
	}
	shadow_box((MAP_SIZE + 2) * 16, 0, 639, 399, 13, 15, 8);
	m_cursor(mcs);
	Screen::show();
}
