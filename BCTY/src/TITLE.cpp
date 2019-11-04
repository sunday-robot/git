#include "GameView.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#if !defined(PROF)
	#include "bgmopn.h"
#endif
#include "gr.h"
#include "super.h"
#include "mylib.h"

#include "bcty.h"
//#include "bcvtimer.h"
#include "key.h"
#include "palet.h"
#include "pat.h"

#define TITLE1_STR "BATTLE"
#define TITLE2_STR "CITYs"
#define TITLE_Y 32
#define TITLE_ZOOM_RATE 6
#define TITLE_COLOR1 15
#define TITLE_COLOR2 13

#define HI_SCORE_X 30
#define HI_SCORE_Y 0
#define HI_SCORE_COLOR1 11
#define HI_SCORE_COLOR2 14

#define LAST_SCORE_Y 0
#define LAST_SCORE_X1 0
#define LAST_SCORE_X2 60

int last_score_x[] = {LAST_SCORE_X1, LAST_SCORE_X2};

#define SELECT_TERM_HEIGHT 28
#define SELECT_TERM_Y 240
#define SELECT_TERM_COLOR1 11
#define SELECT_TERM_COLOR2 14
#define SELECT_TERM1_X 31
#define SELECT_TERM1_STR "1-PLAYER"
#define SELECT_TERM2_X 31
#define SELECT_TERM2_STR "2-PLAYERS"
#define SELECT_TERM3_X 36
#define SELECT_TERM3_STR "QUIT"
#define SELECT_TERM4_X 34
#define SELECT_TERM4_STR "RECORD"

#define AUTHOR_Y 352
#define AUTHOR_COLOR1 2
#define AUTHOR_COLOR2 10
#define AUTHOR1_STR "Program: Akiyama"
#define AUTHOR2_STR "Graphic: Okuda"

#define LIBS_Y AUTHOR_Y
#define LIBS_COLOR1 4
#define LIBS_COLOR2 12
#define LIBS1_X 40
#define LIBS1_STR "Libraries:"
#define LIBS2_X 42
#define LIBS2_STR "BGM.LIB GR.LIB"
#define LIBS3_X 42
#define LIBS3_STR "JOY.LIB SUPER.LIB"

#define CURSOR_X 26
#define CURSOR_Y (SELECT_TERM_Y - 6)
#define PAT_CURSOR (PAT_PLAYER1_TANK + 1)

static int cursor = 0;

static void set_cursor(int new_cursor)
{
	grByteBox(CURSOR_X, CURSOR_Y +cursor * SELECT_TERM_HEIGHT, CURSOR_X + 3,
		CURSOR_Y + cursor * SELECT_TERM_HEIGHT + 31, 0);
	over_put_8(CURSOR_X * 8, CURSOR_Y + new_cursor * SELECT_TERM_HEIGHT, PAT_CURSOR);
	cursor = new_cursor;
}

static void move_cursor(int dir)
{
	int new_cursor;

#if !defined(PROF)
	sound_out(EFS_SELECT);
#endif
	if (dir < 2) {
		if ((new_cursor = cursor + 1) == 4)
			new_cursor = 0;
	} else {
		if ((new_cursor = cursor - 1) == -1)
			new_cursor = 3;
	}
	set_cursor(new_cursor);
}

// タイトル画面を表示し、ゲームモードを返す
static void title_draw(const int highScore) {
	int last_score[2];
	int i;

	change_tone(0);
	grVPage(0);
	grAPage(0);
	grCls();
	txtCls();

	// スコア
	bf_mvcprintf(HI_SCORE_X, HI_SCORE_Y, HI_SCORE_COLOR1, HI_SCORE_COLOR2,
				 "HI-%05d00", highScore);
//	get_last_score(last_score);
	for (i = 0; i < 2; i++) {
		if (last_score[i] != -1) {
			bf_mvprintf(last_score_x[i], LAST_SCORE_Y, "%1dp-%05d00", i + 1,
						last_score[i]);
		}
	}

	// タイトル
	gf_zoom_center_puts(TITLE_Y, TITLE_ZOOM_RATE, TITLE_COLOR1, TITLE_COLOR2,
						TITLE1_STR);
	gf_zoom_center_puts(TITLE_Y + 16 * TITLE_ZOOM_RATE, TITLE_ZOOM_RATE,
						TITLE_COLOR1, TITLE_COLOR2, TITLE2_STR);

	// 選択項目
	bf_mvcputs(SELECT_TERM1_X, SELECT_TERM_Y, SELECT_TERM_COLOR1,
			SELECT_TERM_COLOR2, SELECT_TERM1_STR);
	bf_mvputs(SELECT_TERM2_X, SELECT_TERM_Y + SELECT_TERM_HEIGHT, SELECT_TERM2_STR);
	bf_mvputs(SELECT_TERM3_X, SELECT_TERM_Y + SELECT_TERM_HEIGHT * 2, SELECT_TERM3_STR);
	bf_mvputs(SELECT_TERM4_X, SELECT_TERM_Y + SELECT_TERM_HEIGHT * 3, SELECT_TERM4_STR);

	// 作者名
	bf_mvcputs(0, AUTHOR_Y, AUTHOR_COLOR1, AUTHOR_COLOR2, AUTHOR1_STR);
	bf_mvputs(0, AUTHOR_Y + 16, AUTHOR2_STR);

	// 使用ライブラリ
	bf_mvcputs(LIBS1_X, LIBS_Y, LIBS_COLOR1, LIBS_COLOR2, LIBS1_STR);
	bf_mvputs(LIBS2_X, LIBS_Y + 16, LIBS2_STR);
	bf_mvputs(LIBS3_X, LIBS_Y + 16 * 2, LIBS3_STR);

	set_cursor(cursor);
	change_tone(128);
}

int GameView::showTitleScreen() {
	int selected = 0;

	music_play(BGM_TITLE, 1);
	title_draw(model->getHighScore());
	set_key_mode(KM_SELECT);
	do {
		KeyCode key;

		while (!kq_deq(&key))
			;
////		key &= ~K_P2;
		if (key <= K_LEFT)
			move_cursor(key);
		else if (key <= K_B)
			selected = 1;
		else {
			set_cursor(2);
			selected = 1;
		}
	} while (!selected);
	sound_out(EFS_DETERM);
	return cursor;
}
