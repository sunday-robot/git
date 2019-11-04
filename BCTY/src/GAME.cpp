#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>

#include <super.h>
#include "bgmopn.h"
#include "gr.h"
#include "mylib.h"

#include "bcty.h"
#include "bcvtimer.h"
#include "hi_score.h"
#include "info_mes.h"
#include "key.h"
#include "palet.h"
#include "pat.h"
#include "pilot.h"
#include "result.h"
#include "sprite_t.h"
#include "sprite.h"
#include "stage.h"
#include "tank.h"
#include "GameModel.h"

// 画面右の部分に表示する情報の座標(Xは16ドット単位、Yは14ドット単位)
#define IB_X STAGE_SIZE				// IB...Infomation Box
#define IB_Y 0
#define IBS_X 8						// IBS...IB Size
#define IBS_Y STAGE_SIZE
#define RCT_X (IB_X + 3)			// RCT...Rest Computer Tanks
#define RCT_Y 2
#define RCTI_X (IB_X + 1)			// RCTI...RCT Icon
#define RCTI_Y RCT_Y
#define RCTS_X 3					// RCTS...RCT Size
#define RCTS_Y 10
#define RPT_X (IB_X + 3)			// RPT...Rest Player Tanks
#define RPT_Y (RCT_Y + RCTS_Y + 5)
#define RPT_DY 3
#define RPTI_X (IB_X + 1)			// RPTI...RPT Icon
#define RPTI_Y (RPT_Y)
#define SN_X (IB_X + 3)				// SN...Stage Number
#define SN_Y (RPT_Y + RPT_DY + 5)
#define SNI_X (IB_X + 1)			// SNI...SN Icon
#define SNI_Y SN_Y

#include "GameModel.h"


static int old_rest_comp_tank;

static int game_mode;
static int player_destroyed;

// 残りの敵戦車の数を表示する
static void print_rest_comp_tank(int rest)
{
	int i;
	if (old_rest_comp_tank < rest)
		for (i = old_rest_comp_tank; i < rest; i++)
			BG_putc(RCT_X + (i >= 10 ? 2 : 0), RCT_Y + i % 10, 1, 0x12);
	else
		for (i = rest; i < old_rest_comp_tank; i++)
			BG_putc(RCT_X + (i >= 10 ? 2 : 0), RCT_Y + i % 10, 1, ' ');
	old_rest_comp_tank = rest;
}

void BG_putw(int x, int y, int level, int n)
{
	BG_putc(x, y, level, n / 10 + '0');
	BG_putc(x + 1, y, level, n % 10 + '0');
}

#define print_rest_player_tank(num, rest) \
	BG_putw(RPT_X, RPT_Y + RPT_DY * num, 1, rest)

static void draw_box(int x, int y, int width, int height)
{
	int x2 = x + width - 1, y2 = y + height - 1, i;
	set_BG(x, y, 0, PAT_INFO_BOX_2UL);
	set_BG(x2, y, 0, PAT_INFO_BOX_2UR);
	set_BG(x, y2, 0, PAT_INFO_BOX_2DL);
	set_BG(x2, y2, 0, PAT_INFO_BOX_2DR);
	for (i = x + 1; i < x2; i++) {
		set_BG(i, y, 0, PAT_INFO_BOX_2U);
		set_BG(i, y2, 0, PAT_INFO_BOX_2D);
	}
	for (i = y + 1; i < y2; i++) {
		set_BG(x, i, 0, PAT_INFO_BOX_2L);
		set_BG(x2, i, 0, PAT_INFO_BOX_2R);
	}
	set_BG_box(x + 1, y + 1, width - 2, height - 2, 0, PAT_INFO_BOX_2);
}

// 右側の情報ボックスを描く
static void draw_screen(void)
{
	set_BG_box(IB_X, IB_Y, IBS_X, IBS_Y, 0, PAT_INFO_BOX_1);
	// 残りのコンピュータの戦車を表示する部分
	set_BG(RCTI_X, RCTI_Y, 1, PAT_COM_ICON);
	draw_box(RCT_X - 1, RCT_Y - 1, RCTS_X + 2, RCTS_Y + 2);
	// ステージナンバー
	set_BG(SNI_X, SNI_Y, 1, PAT_STAGE_ICON);
	draw_box(SN_X - 1, SN_Y - 1, 4, 3);
	// プレイヤー1
	set_BG(RPTI_X, RPTI_Y, 1, PAT_PLAYER_1_ICON);
	draw_box(RPT_X - 1, RPT_Y - 1, 4, 3);
	if (game_mode) {
		// プレイヤー2
		set_BG(RPTI_X, RPTI_Y + RPT_DY, 1, PAT_PLAYER_2_ICON);
		draw_box(RPT_X - 1, RPT_Y + RPT_DY - 1, 4, 3);
	}
}

void drawGame(const GameModel* model) {
	// プレイヤーの、残りの戦車の表示をする
	print_rest_player_tank(0, model->getLeftTankCount(0));
	if (model->is2pMode())
		print_rest_player_tank(1, model->getLeftTankCount(1));
	// 敵戦車の残りを表示する
	print_rest_comp_tank(model->getLeftComputerTankCount());
}

// １ステージゲームを行う
static EndCode game(void)
{
	GameModel *gameModel = new GameModel();

	change_tone(0);
	txtCls();

	// スプライト、背景のリセット
	reset_sprite();
	// ステージデータの展開
	int comp_tanks[20];
	read_stage_data(comp_tanks);
	// 画面右端部分を描く
	draw_screen();
	update_screen();
	change_page();

	reset_game_over_message();
	// ステージナンバーを表示する
	BG_putw(SN_X, SN_Y, 1, get_stage_number());

#if !defined(PROF)
	// BGMを鳴らす
	music_play(BGM_OPENING, 0);
#endif

	set_wait_count(WAIT_COUNT_IN_GAME);
	change_tone(128);
	set_key_mode(KM_GAME);
	// 人間かコンピュータどちらかの戦車が全滅するまでループ
	for (;;) {
		bool isGameActive = gameModel->tick();
		drawGame(gameModel);
		if (!isGameActive)
			break;
	}
	return gameModel->getEndCode();
}

static void game_over_screen(void)
{
	change_tone(0);
	grCls();
	gf_zoom_center_puts(200 - 16 * 10, 10, 2, 10, "GAME");
	gf_zoom_center_puts(200, 10, 2, 10, "OVER");
	change_tone(128);
#if !defined(PROF)
	music_play(BGM_GAME_OVER, 0);
	wait_button2_or_bgm();
	music_fadeout();
	set_wait_count(30);
	wait();
	music_stop();
#endif
}

#if 0
void start_game(int mode) {
	_game_view _game_view;
	_game_view.main(mode != 0);
}
#endif
