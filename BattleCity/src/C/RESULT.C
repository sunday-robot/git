#include <stdio.h>
#include <conio.h>

#if !defined(PROF)
	#include "bgmopn.h"
#endif
#include "gr.h"
#include "super.h"
#include "mylib.h"

#include "bcty.h"
#include "bcvtimer.h"
#include "game.h"
#include "hits_t.h"
#include "key.h"
#include "palet.h"
#include "pat.h"
#include "stage.h"

#define HI_SCORE_X 24
#define HI_SCORE_Y 0
#define HI_SCORE1_COLOR1 2
#define HI_SCORE1_COLOR2 10
#define HI_SCORE2_COLOR1 11
#define HI_SCORE2_COLOR2 14

#define STAGE_NUM_X 32
#define STAGE_NUM_Y (HI_SCORE_Y + 32)
#define STAGE_NUM_COLOR1 7
#define STAGE_NUM_COLOR2 15

#define PLAYER_X1 8
#define PLAYER_X2 56
#define PLAYER_Y (STAGE_NUM_Y + 32)
#define PLAYER_COLOR1 2
#define PLAYER_COLOR2 10

static int player_x[] = {PLAYER_X1, PLAYER_X2};

#define SCORE_X1 10
#define SCORE_X2 56
#define SCORE_Y (PLAYER_Y + 16)
#define SCORE_COLOR1 11
#define SCORE_COLOR2 14

int score_x[] = {SCORE_X1, SCORE_X2};

#define POINTS1_X1 14
#define POINTS1_X2 54
#define POINTS2_X1 28
#define POINTS2_X2 48
#define POINTS3_X1 4
#define POINTS3_X2 68
#define POINTS_Y (SCORE_Y + 48)
#define POINTS_COLOR1 7
#define POINTS_COLOR2 15

int points1_x[] = {POINTS1_X1, POINTS1_X2};
int points2_x[] = {POINTS2_X1, POINTS2_X2};
int points3_x[] = {POINTS3_X1, POINTS3_X2};

#define ARROW_X1 34
#define ARROW_X2 44
#define ARROW_Y POINTS_Y
#define ARROW_COLOR1 7
#define ARROW_COLOR2 15
#define ARROW_CHAR1 0x10
#define ARROW_CHAR2 0x11

int arrow_x[] = {ARROW_X1, ARROW_X2};
char arrow_char[] = {ARROW_CHAR1, ARROW_CHAR2};

#define TANK_X (320 - 16)
#define TANK_Y (POINTS_Y - 6)

#define TOTAL_X 16
#define TOTAL_Y (POINTS_Y + 48 * 4 - 16)
#define TOTAL_COLOR1 7
#define TOTAL_COLOR2 15
#define TOTAL_STR "TOTAL\x13\x13\x13\x13\x13\x13\x13\x13\x13\x13\x13\x13\x13\x13"

#define TOTAL_BAR_X1 (320 - 7 * 16)
#define TOTAL_BAR_Y1 (TOTAL_Y + 7)
#define TOTAL_BAR_X2 (TOTAL_BAR_X1 + 14 * 16)
#define TOTAL_BAR_Y2 (TOTAL_BAR_Y1 + 1)
#define TOTAL_BAR_COLOR1 7
#define TOTAL_BAR_COLOR2 15

#define BONUS_X1 12
#define BONUS_X2 58
#define BONUS_Y (TOTAL_Y + 48)
#define BONUS1_COLOR1 11
#define BONUS1_COLOR2 14
#define BONUS2_COLOR1 7
#define BONUS2_COLOR2 15
#define BONUS_STR "BONUS"

static int bonus_x[] = {BONUS_X1, BONUS_X2};

// ステージを終了したあと結果を表示し、ボーナスの判定もする
// mode bit 0,1 でプレイヤー1,2のスコアを計算するかを表す
void result(int mode, int score[2], Hits hits[])
{
	int i, j;
	int total[2] = {0, 0};

	change_tone(0);
	grAPage(0);
	grVPage(0);
	grCls();
	txtCls();

	// ハイスコアの表示
	bf_mvcputs(HI_SCORE_X, HI_SCORE_Y, HI_SCORE1_COLOR1, HI_SCORE1_COLOR2,
			   "HI-SCORE ");
	bf_setcolor(HI_SCORE2_COLOR1, HI_SCORE2_COLOR2);
	bf_printf("%05d00", get_high_score());

	// ステージ番号の表示
	bf_mvcprintf(STAGE_NUM_X, STAGE_NUM_Y, STAGE_NUM_COLOR1, STAGE_NUM_COLOR2,
				"STAGE %2d", get_stage_number());

	// "TOTAL"の文字列と線の表示
	bf_mvcputs(TOTAL_X, TOTAL_Y, TOTAL_COLOR1, TOTAL_COLOR2, TOTAL_STR);
	// 戦車の表示
	for (i = 0; i < 4; i++) {
		over_put_8(TANK_X, TANK_Y + 48 * i, PAT_COMP_TANK + 2 + i * 8);
	}

	// "?-PLAYER", "?00pts", 矢印の表示
	for (i = 0; i < 2; i++) {
		if (!(mode & (1 << i)))
			continue;
		bf_mvcprintf(player_x[i], PLAYER_Y, PLAYER_COLOR1, PLAYER_COLOR2,
					 "%d-PLAYER", i + 1);
		bf_mvcprintf(score_x[i], SCORE_Y, SCORE_COLOR1, SCORE_COLOR2, "%05d00",
					 score[i]);
		for (j = 0; j < 4; j++) {
			bf_mvcprintf(points1_x[i], POINTS_Y + 48 * j, POINTS_COLOR1,
						 POINTS_COLOR2, "%d00pts", j + 1);
			bf_mvcputc(arrow_x[i], ARROW_Y + 48 * j, ARROW_COLOR1,
					   ARROW_COLOR2, arrow_char[i]);
		}
	}

	change_tone(128);
	set_key_mode(KM_SELECT);
	set_wait_count(WAIT_COUNT_IN_RESULT);
	wait_button();
	bf_setcolor(POINTS_COLOR1, POINTS_COLOR2);
	// やっつけた戦車の数と得点の表示
	for (i = 0; i < 4; i++) {
		for (j = 0; j < 2; j++) {
			int p;
			if (!(mode & (1 << j)))
				continue;
			total[j] += hits[j].num[i];
			bf_mvprintf(points2_x[j], POINTS_Y + 48 * i, "%2d",
						hits[j].num[i]);
			p = hits[j].num[i] * (i + 1);
			bf_mvprintf(points3_x[j], POINTS_Y + 48 * i, "%4d", p * 100);
		}
#if !defined(PROF)
		sound_out(EFS_RESULT);
#endif
		wait_button();
	}
	// やっつけた戦車の数の合計を表示
	bf_setcolor(TOTAL_COLOR1, TOTAL_COLOR2);
	for (i = 0; i < 2; i++) {
		if (!(mode & (1 << i)))
			continue;
		bf_mvprintf(points2_x[i], TOTAL_Y + 16, "%2d", total[i]);
	}
#if !defined(PROF)
	sound_out(EFS_RESULT);
#endif
	wait_button();
	// ボーナスの処理
	if (mode == 3) {
		int bonus, winner;
		bonus = total[0] - total[1];
		if (bonus != 0) {
			if (bonus > 0)
				winner = 0;
			else {
				bonus = -bonus;
				winner = 1;
			}
			score[winner] += bonus;
			grByteBox(score_x[winner], SCORE_Y, score_x[winner] + 9,
					   SCORE_Y + 15, 0);
			bf_mvcprintf(score_x[winner], SCORE_Y, SCORE_COLOR1, SCORE_COLOR2,
						 "%05d", score[winner]);
			bf_mvcputs(bonus_x[winner], BONUS_Y, BONUS1_COLOR1, BONUS1_COLOR2,
					   BONUS_STR);
			bf_mvcprintf(bonus_x[winner] + 2, BONUS_Y + 16, BONUS2_COLOR1,
						 BONUS2_COLOR2, "%2d00", bonus);
#if !defined(PROF)
			sound_out(EFS_BONUS);
#endif
		}
	}
	wait_button2_or_time(2 * 60);
}

#if defined(RESULT_TEST)

int get_stage_number(void)
{
	return 21;
}

void main()
{
	int score[2] = {100, 2000};
	Hits hits[2] = {{1, 2, 3, 4, 5}, {0, 5, 6, 7, 9}};

	stop_off();
	timestart();
	init_key();
	gr_start();
	gf_load("bcty.bft");
	read_palet_bfnt("bcty16.bft");
	super_entry_bfnt("bcty16.bft", 0, !SET);
	super_entry_bfnt("bcty32_1.bft", 0, !SET);
	result(1, score, hits);
	result(2, score, hits);
	result(3, score, hits);
	hits[0][3] = 20;
	result(3, score, hits);
	finish_key();
	timestop();
	stop_on();
}

#endif
