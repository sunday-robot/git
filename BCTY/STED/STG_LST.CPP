// ステージファイルの構造：
// ステージデータの集合
// ステージデータの構造：
// 地形データが２６バイト＊２６行あり、その後、敵戦車のデータ２０台分
//
// $Header: stg_lst.cpv  1.2  92/09/30 18:10:44  akiyama  Exp $
//
#include <stdio.h>
#include <assert.h>
#include <gr.h>
#include <mylib.h>
#include <mouse.h>

#include "sted.h"
#include "stg_lst.h"
#include "sl_scrn.h"

//  "+ 2" = CR/LF
#define STAGE_DATA_SIZE ((MAP_SIZE + 2) * MAP_SIZE + COM_TANK + 2)

static char *class_name = "StageList::";

void StageList::setSource(int _stage_number)
{
	if (_stage_number < 0 || _stage_number >= getNum())
		sourceStageNumber = -1;
	else
		sourceStageNumber = _stage_number;
	if (visible)
		show();
}

void StageList::edit(int stage_number)
{
	Stage *stage = (Stage *) (*this)[stage_number];

	if (stage != 0)
		stage_list_screen.edit(stage);
}

void StageList::new_(int stage_number)
{
	Stage *stage = new Stage;
	insert(stage, stage_number);
}

void StageList::copy(int stage_number)
{
	Stage *source_stage = (Stage *) (*this)[sourceStageNumber];
	if (source_stage == 0)
		return;
	Stage *new_stage = new Stage;
	new_stage->copy(source_stage);
	if (stage_number <= sourceStageNumber)
		sourceStageNumber++;
	insert(new_stage, stage_number);
}

void StageList::move(int stage_number)
{
	Stage *stage = (Stage *) (*this)[sourceStageNumber];
	if (stage == 0)
		return;
	int org_visible = visible;
	visible = 0;
	remove(sourceStageNumber);
	if (sourceStageNumber < stage_number)
		stage_number--;
	setSource(-1);
	visible = org_visible;
	insert(stage, stage_number);
}

void cbStageList(Panel *_this, Event *event, void *dummy)
{
	StageList *sl = (StageList *)_this;
	int stage_number;

	if (!(event->type & (LeftButtonPress | RightButtonPress)))
		return;
	stage_number = sl->getCurrentStageNumber() + event->mouse.x
		/ MIN_STAGE_SIZE_X + ((event->mouse.y - StageListY)
		/ MIN_STAGE_SIZE_Y) * (640 / MIN_STAGE_SIZE_X);
//	printf("%d\n", stage_number);
	if (event->type & LeftButtonPress) {
		switch (stage_list_screen.getOperateMode()) {
		case Copy:
		case Move:
			sl->setSource(stage_number);
			break;
		case Edit:
			sl->edit(stage_number);
			break;
		case Delete:
			sl->remove(stage_number);
			break;
		case New:
			sl->new_(stage_number);
			break;
		}
	} else {
		switch (stage_list_screen.getOperateMode()) {
		case Copy:
			sl->copy(stage_number);
			break;
		case Move:
			sl->move(stage_number);
			break;
		}
	}
}

StageList::StageList(int _size)
	: Parray(_size), Panel(0, StageListY, 640, MIN_STAGE_SIZE_Y * 5, 1)
{
	stageFileName[0] = '\0';
	visible = currentStageNumber = 0;
	setSource(-1);
	assert(addCallback(new Callback(cbStageList, 0)));
};

// ステージファイルを読み込む
int StageList::read(char *fileName)
{
	static char *method_name = "read(): ";
	FILE *fp;

	if ((fp = fopen(fileName, "rt")) == NULL) {
		fprintf(stderr, "%s%sファイルがオープンできません(%s)\n",
			class_name, method_name, fileName);
		return 0;
	}
	while (1) {
		Stage *pstage = new Stage;
		if (pstage == NULL) {
			fprintf(stderr, "%s%sステージのメモリが確保できません\n"
				"Stage No. = %d\n", class_name, method_name,
				getNum() + 1);
			break;
		}
		if (!pstage->read(fp, getNum() + 1)) {
			delete pstage;
			break;
		}
		append(pstage);
	}
	fclose(fp);
	return 1;
}

// ステージデータをファイルに書き出す
int StageList::write(char *fileName)
{
	static char *method_name = "write(): ";
	FILE *fp;

	if ((fp = fopen(fileName, "wt")) == NULL) {
		fprintf(stderr, "%s%sファイルがオープンできません(%s)\n",
			class_name, method_name, fileName);
		return 0;
	}
	int i = 0;
	Stage *pstage;
	while ((pstage = (Stage *) (*this)[i]) != NULL) {
		if (!pstage->write(fp, i++))
			break;
	}
	fclose(fp);
	return 1;
}

// ステージを表示する
void StageList::show(int stage_number)
{
	int mcs = m_get_cursor_state();
	m_cursor(0);

	if (stageFileName[0] == '\0') {
		char drive[MAXDRIVE], dir[MAXDIR];
		fnsplit(_argv[0], drive, dir, NULL, NULL);
		fnmerge(stageFileName, drive, dir, "bcty", ".stg");
//		puts(stageFileName);
		read(stageFileName);
	}
	int x, y;

	visible = 1;

	if (stage_number < 0)
		stage_number = 0;
	else if (stage_number > getSize() - 50)
		stage_number = getSize() - 50;
//	printf("currentStageNumber = %d\n", currentStageNumber);
	currentStageNumber = stage_number;
	for (y = 16; y < PAGE_SIZE_Y * MIN_STAGE_SIZE_Y + 16;
		y += MIN_STAGE_SIZE_Y) {
		for (x = 0; x < PAGE_SIZE_X * MIN_STAGE_SIZE_X;
			x += MIN_STAGE_SIZE_X) {
			Stage *pstage = (Stage *) (*this)[stage_number];
			pstage->show(x, y, stage_number == sourceStageNumber);
			stage_number++;
		}
	}

	m_cursor(mcs);
}

int StageList::insert(Stage *_stage, int _index)
{
	int r;
	r = Parray::insert((void *)_stage, _index);
	if (visible)
		show();
	return r;
}

int StageList::append(Stage *_stage)
{
	int r;
	r = Parray::append((void *)_stage);
	if (visible)
		show();
	return r;
}

int StageList::remove(int _index)
{
	int r;
	if ((*this)[_index] == 0)
		return 0;
	r = Parray::remove(_index);
	if (visible)
		show();
	return r;
}
