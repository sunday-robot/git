#include <assert.h>
#include <stdlib.h>
#include "button.h"
#include "sl_scrn.h"
#include "se_scrn.h"
#include "ev_mngr.h"
#include "stg_lst.h"
#include "sted.h"

StageListScreen stage_list_screen;

struct RollData {
	StageList *stageList;
	int delta;
	RollData(StageList *_stage_list, int _delta)
	{
		stageList = _stage_list;
		delta = _delta;
	};
};

struct ChangeModeData {
	Operate operate;
	StageList *stage_list;
	ChangeModeData(Operate _op, StageList *_sl)
	{
		operate = _op;
		stage_list = _sl;
	};
};

void changeMode(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
//	puts("changeMode");
	Operate om;
	if ((om = stage_list_screen.getOperateMode()) != None)
		((Button *) stage_list_screen.panelList[om])->up();
	Button *b = (Button *) p;
	b->down();
	ChangeModeData *cmd = (ChangeModeData *) d;
	stage_list_screen.setOperateMode(cmd->operate);
	cmd->stage_list->setSource(-1);
}

void rollUpDown(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
//	puts("rollUpDown");
	Button *b = (Button *) p;
	b->down();
	RollData *roll = (RollData *) d;
	roll->stageList->roll(roll->delta);
	b->up();
}

void save(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
//	puts("save");
	Button *b = (Button *) p;
	b->down();
	StageList *sl = (StageList *) d;
	sl->write();
	b->up();
}

void quit(Panel *p, Event *e, void *d)
{
	if (!(e->type & LeftButtonPress))
		return;
//	puts("quit");
	Button *b = (Button *) p;
	b->down();
	exit(1);
}

StageListScreen::StageListScreen() : Screen(nButton + 1)
{
	Button *b;

	operateMode = None;

	StageList *stage_list = new StageList(100);
	if (stage_list == 0) {
		fprintf(stderr, "ステージリスト用のメモリを確保できません\n");
		exit(1);
	}

	b = new Button("Copy", Copy * ButtonWidth, 0);
	assert(b->addCallback(new Callback(changeMode, new ChangeModeData(Copy,
		stage_list))));
	addPanel(b);
	b = new Button("Move", Move * ButtonWidth, 0);
	assert(b->addCallback(new Callback(changeMode, new ChangeModeData(Move,
		stage_list))));
	addPanel(b);
	b = new Button("Edit", Edit * ButtonWidth, 0);
	assert(b->addCallback(new Callback(changeMode, new ChangeModeData(Edit,
		stage_list))));
	addPanel(b);
	b = new Button("Delete", Delete * ButtonWidth, 0);
	assert(b->addCallback(new Callback(changeMode, new ChangeModeData(Delete,
		stage_list))));
	addPanel(b);
	b = new Button("New", New * ButtonWidth, 0);
	assert(b->addCallback(new Callback(changeMode, new ChangeModeData(New,
		stage_list))));
	addPanel(b);

	b = new Button("Save", Save * ButtonWidth, 0);
	assert(b->addCallback(new Callback(save, (void *) stage_list)));
	addPanel(b);
	b = new Button("Quit", Quit * ButtonWidth, 0);
	assert(b->addCallback(new Callback(quit, (void *) 0)));
	addPanel(b);

	RollData *roll = new RollData(stage_list, +10);
	b = new Button("RollUp", RollUp * ButtonWidth, 0);
	assert(b->addCallback(new Callback(rollUpDown, roll)));
	addPanel(b);
	roll = new RollData(stage_list, -10);
	b = new Button("RollDown", RollDown * ButtonWidth, 0);
	assert(b->addCallback(new Callback(rollUpDown, roll)));
	addPanel(b);
	addPanel(stage_list);
}

void StageListScreen::edit(Stage *stage)
{
	stage_edit_screen.setStage(stage);
	event_manager.changeMode(modeEdit);
}

/*
void StageListScreen::show()
{
	Panel *p;
	int i = 0;
	while ((p = (Panel *) (this->panelList)[i++]) != NULL)
		p->show();
}
*/
