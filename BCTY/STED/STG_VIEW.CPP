// �X�e�[�W�t�@�C���̍\���F
// �X�e�[�W�f�[�^�̏W��
// �X�e�[�W�f�[�^�̍\���F
// �n�`�f�[�^���Q�U�o�C�g���Q�U�s����A���̌�A�G��Ԃ̃f�[�^�Q�O�䕪
//
// $Header: stg_lst.cpv  1.2  92/09/30 18:10:44  akiyama  Exp $
//
#include <stdio.h>
#include <gr.h>
#include <mylib.h>

#include "sl_scrn.h"

//  "+ 2" = CR/LF
#define STAGE_DATA_SIZE ((MAP_SIZE + 2) * MAP_SIZE + COM_TANK + 2)

static char *class_name = "StageList::";

static int source_stage;

StageList::StageList(int _size) : Parray(_size)
{
	visible = current_stage_number = 0;
	panelList = Parray(nButtons + 1);
};

// �X�e�[�W�t�@�C����ǂݍ���
int StageList::read(char *fileName)
{
	static char *method_name = "read(): ";
	FILE *fp;

	if ((fp = fopen(fileName, "rt")) == NULL) {
		fprintf(stderr, "%s%s�t�@�C�����I�[�v���ł��܂���(%s)\n",
			class_name, method_name, fileName);
		return 0;
	}
	while (1) {
		Stage *pstage = new Stage;
		if (pstage == NULL) {
			fprintf(stderr, "%s%s�X�e�[�W�̃��������m�ۂł��܂���\n"
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

// �X�e�[�W�f�[�^���t�@�C���ɏ����o��
int StageList::write(char *fileName)
{
	static char *method_name = "write(): ";
	FILE *fp;

	if ((fp = fopen(fileName, "wt")) == NULL) {
		fprintf(stderr, "%s%s�t�@�C�����I�[�v���ł��܂���(%s)\n",
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

// �X�e�[�W��\������
void StageList::view(int stage_number)
{
	int x, y;

	if (stage_number < 0)
		stage_number = 0;
	else if (stage_number > getSize() - 50)
		stage_number = getSize() - 50;
	current_stage_number = stage_number;
	for (y = 16; y < PAGE_SIZE_Y * MIN_STAGE_SIZE_Y; y += MIN_STAGE_SIZE_Y) {
		for (x = 0; x < PAGE_SIZE_X * MIN_STAGE_SIZE_X;
			x += MIN_STAGE_SIZE_X) {
			Stage *pstage = (Stage *) (*this)[stage_number++];
			pstage->show(x, y);
		}
	}
}

void StageList::show()
{
	visible = 1;

	for (int i = 0; i < nButtons; i++)
		(Button *) (panelList[i])->show();
	view(current_stage_number);
}

void StageList::processEvent(Event *event)
{
	if (event->type == (LeftButtonPress | RightButtonPress)) {
		if (event->mouse.y < ButtonHeight) {
			// �{�^���������ꂽ
			if (event->mouse.x >= RollButtonX) {
				if (event->mouse.x >= RollButtonX + ButtonWidth) {
					// roll down
					rollDownButton.down();
					view(current_stage_number - 10);
					rollDownButton.up();
				} else {
					// roll up
					rollUpButton.down();
					view(current_stage_number + 10);
					rollUpButton.up();
				}
			} else {
				if (operateMode != None)
					operateButton[operateMode].up();
				if (event->type == LeftButtonPress) {
					operateMode = event->mouse.x / ButtonWidth;
					operateState = 0;
					operateButton[operateMode].down();
					if (operateMode == Edit) {
						visible = 0;
//						event_manager.changeMode(mStageEdit);
					}
				}
			}
		} else {
			// �X�e�[�W���I�����ꂽ
			int stage_number = current_stage_number + event->mouse.x
				/ MIN_STAGE_SIZE_X + (event->mouse.y / MIN_STAGE_SIZE_Y) * (640
				/ MIN_STAGE_SIZE_X);
			switch (operateMode) {
			case Copy:
				if (operateState == 0) {
					source_stage = stage_number;
				} else {
					
				}
				break;
			case Move:
				break;
			case Delete:
				break;
			case New:
				break;
			case Save:
				break;
			case Quit:
				break;
			}
		}
	}
}

int StageList::insert(Stage *_stage, int _index)
{
	int r;
	r = Parray::insert((void *)_stage, _index);
	if (visible)
		view();
	return r;
}

int StageList::append(Stage *_stage)
{
	int r;
	r = Parray::append((void *)_stage);
	if (visible)
		view();
	return r;
}

int StageList::remove(int _index)
{
	int r;
	r = Parray::remove(_index);
	if (visible)
		view();
	return r;
}