// �X�e�[�W�t�@�C���̍\���F
// �X�e�[�W�f�[�^�̏W��
// �X�e�[�W�f�[�^�̍\���F
// �n�`�f�[�^���Q�U�o�C�g���Q�U�s����A���̌�A�G��Ԃ̃f�[�^�Q�O�䕪

#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include <io.h>
#include <conio.h>

#include "gr.h"
#if !defined(PROF)
	#include "bgmopn.h"
#endif
//#include "mylib.h"

#include "bcty.h"
//#include "bcvtimer.h"
#include "oldtank.h"
#include "key.h"
#include "palet.h"

#define STAGE_DATA_SIZE ((26 + 2) * 26 + 20 + 2)

static FILE *fp;

static int num_of_stages;		// �X�e�[�W��
static int stage_number = 0;	// ���݂̃X�e�[�W�ԍ�

int get_stage_number(void)
{
	return stage_number + 1;
}

void reset_stage_number(void)
{
	stage_number = 0;
}

void inc_stage_number(void)
{
	if (++stage_number == num_of_stages)
		stage_number = 0;
}

// �X�e�[�W�t�@�C�����I�[�v������
void open_stage_file(char *fname)
{
	if ((fp = fopen(fname, "rt")) == NULL) {
		fprintf(stderr, "open_stage_file: can not open file (%s)\n", fname);
		exit(1);
	}
	num_of_stages = filelength(fileno(fp)) / STAGE_DATA_SIZE;
}

void close_stage_file(void)
{
	fclose(fp);
}

// �w�肵���X�e�[�W�̃f�[�^��ǂݍ��݁A�\������
void read_stage_data(int comp_tanks[20])
{
	static char stage_char[] = ".#*%$~";
	int x, y;

	fseek(fp, stage_number * STAGE_DATA_SIZE, SEEK_SET);

	set_stage_char(0, 0, FRAME + 2);
	set_stage_char(STAGE_SIZE - 1, 0, FRAME + 3);
	set_stage_char(0, STAGE_SIZE - 1, FRAME + 4);
	set_stage_char(STAGE_SIZE - 1, STAGE_SIZE - 1, FRAME + 5);
	// ����̘g�i�㉺�Q�{�j
	for (x = 1; x < STAGE_SIZE - 1; x++) {
		set_stage_char(x, 0, FRAME);
		set_stage_char(x, STAGE_SIZE - 1, FRAME);
	}
	for (y = 1; y < STAGE_SIZE - 1; y++) {
		set_stage_char(0, y, FRAME + 1);				// ����̘g�i���E�Q�{�j
		set_stage_char(STAGE_SIZE - 1, y, FRAME + 1);
		for (x = 1; x < STAGE_SIZE - 1; x++) {
			char c = fgetc(fp);
			int type = (int)strchr(stage_char, c);
			if (type == 0) {
				fprintf(stderr, "stage.c, read_stage_data(): "
					   "�X�e�[�W�t�@�C�� %d �s %d ���Ɉُ�ȕ���('%c', %02x)��"
					   "����܂��B\n", stage_number * 27 + 2 + y - 1, x, c, c);
				type = 0;
			} else
				type -= (int)stage_char;
			set_stage_char(x, y, type);
		}
		fgetc(fp);	// ���s�R�[�h��ǂݔ�΂�
	}
	for (x = 0; x < 20; x++) {
		char c = fgetc(fp);
		int ct = (toupper(c) - 'A') * 2 + (isupper(c) ? 1 : 0);
		if (ct < 0 || ct > 7) {
			fprintf(stderr, "read_stage(): illegal tank type '%c'\n", c);
			ct = 0;
		}
		comp_tanks[x] = ct;
	}
}

// �X�e�[�W�̑I�����s��
void select_stage(void)
{
	static char s[] = "STAGE";
	static int add_value[] = {-1, -10, 1, 10};
	char buf[3];

	txtCls();
	change_tone(0);
	grAPage(0);
	grVPage(0);
	grCls();
	gfDisp(25 / 2, (80 - sizeof(s) - 3) / 2, TXT_WHITE, s);
	sprintf(buf, "%02d", stage_number + 1);
	gfDisp(25 / 2, 40 + (sizeof(s) + 1), TXT_WHITE, buf);

	set_key_mode(KM_SELECT);
	while (1) {
		KeyCode key;

		while (!kq_deq(&key))
			;
////		key &= ~K_P2;
		if (key <= K_LEFT) {
			int new_sn = stage_number + add_value[key];
			if (new_sn >= 0 && new_sn < num_of_stages) {
#if !defined(PROF)
				sound_out(EFS_S_SELECT);
#endif
				stage_number = new_sn;
				sprintf(buf, "%02d", stage_number + 1);
				gfDisp(25 / 2, 40 + (sizeof(s) + 1), TXT_WHITE, buf);
			}
		} else if (key <= K_B)
			break;
	}
#if !defined(PROF)
	sound_out(EFS_DETERM);
#endif
}
