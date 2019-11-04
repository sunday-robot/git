//
// ゲーム中、"PAUSE" や "GAME OVER" などのメッセージを表示するためのルーチン
//
#include "gr.h"
#include "bcty.h"

enum {GO_NOTHING = 0, GO_1, GO_2, GO_ALL};

static int mode;
static int time;

static char info_mes[4][10] = {"         ", "GAME OVER", "PAUSE", "     "};

static struct {
	int row, column;
} info_mes_position[4] = {
	{25 * 2 / 3, STAGE_SIZE / 2 - 9},
	{25 * 2 / 3, STAGE_SIZE * 3 / 2 - 9},
	{25 / 2, STAGE_SIZE - 9},
	{25 / 2 - 1, STAGE_SIZE - 5}
};

void reset_game_over_message(void)
{
	mode = GO_NOTHING;
}

static void puts_game_over_message(int sw)
{
	gfDisp(info_mes_position[mode - 1].row, info_mes_position[mode - 1].column,
		TXT_RED, info_mes[sw]);
}

void game_over_message(int n)
{
	time = GAME_OVER_TIME;
	if (mode != GO_NOTHING)
		puts_game_over_message(0);
	mode = n;
	puts_game_over_message(1);
}

void ctrl_game_over_message(void)
{
	if (mode != GO_NOTHING)
		if (--time == 0) {
			puts_game_over_message(0);
			mode = GO_NOTHING;
		}
}

void pause_message(int sw)
{
	gfDisp(info_mes_position[3].row, info_mes_position[3].column, TXT_WHITE,
		info_mes[sw ? 2 : 3]);
}
