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
#include "hits_t.h"
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

typedef enum {STAGE_CLEAR, GAME_OVER, EXIT_GAME} EndCode;

static Hits hits[2];

static int score[2] = {0, -1};
static int one_up_threshold[2];

static int old_rest_comp_tank;

static int game_mode;
static int max_tank;
static int player_destroyed;

static struct {
	int tank_type;
	int num_of_tank;
} player_tank[2] = {0, 0, 0, 0};

void get_last_score(int ls[2])
{
	ls[0] = score[0];
	ls[1] = score[1];
}

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

// １ステージゲームを行う
static int game(void)
{
	int comp_tanks[20];
	EndCode end_code = STAGE_CLEAR;
	int end_flg = 0, end_count = 0;
	int num_of_died_comp_tank = 0;
	int comp_tank_index = 0;
	// 敵戦車の出現間隔のカウンタ
	int comp_tank_generate_interval = GENERATE_INTERVAL / 2;
	int i, j;
	static struct {
		int x, y;
	} player_tank_position[2] = {
		{(STAGE_SIZE / 2 - 4) * 16, (STAGE_SIZE - 3) * 16},
		{(STAGE_SIZE / 2 + 2) * 16, (STAGE_SIZE - 3) * 16}
	}, init_comp_tank_position[3] = {
		{16, 16},
		{(STAGE_SIZE / 2 - 1) * 16, 16},
		{(STAGE_SIZE - 3) * 16, 16}
	};

	change_tone(0);
	txtCls();

	// スプライト、背景のリセット
	reset_sprite();
	// ステージデータの展開
	read_stage_data(comp_tanks);
	// 画面右端部分を描く
	draw_screen();
	update_screen();
	change_page();

	// 戦車のリセット（みんな死んだ状態にする）
	reset_tanks();
	// 撃墜数の初期化
	for (i = 0; i < 2; i++)
		for (j = 0; j < 5; j ++)
			hits[i].num[j] = 0;
	reset_game_over_message();
	// ステージナンバーを表示する
	BG_putw(SN_X, SN_Y, 1, get_stage_number());
	// プレイヤーの、残りの戦車の表示をする
	for (i = 0; i <= game_mode; i++)
		print_rest_player_tank(i, player_tank[i].num_of_tank);
	// 敵戦車の残りを表示する
	print_rest_comp_tank(20 - comp_tank_index);

#if !defined(PROF)
	// BGMを鳴らす
	music_play(BGM_OPENING, 0);
#endif

	set_wait_count(WAIT_COUNT_IN_GAME);
	change_tone(128);
	set_key_mode(KM_GAME);
	// 人間かコンピュータどちらかの戦車が全滅するまでループ
	while (!end_flg) {
		int r;
		for (i = 0; i < max_tank; i++) {
			switch (r = control_tank(i)) {
			case BORN:
			case LIVE:
			case BURST:
			case DISP_POINT:
			case DEAD2:
				break;
			case DEAD:
				if (i < 2) {
					if (player_tank[i].num_of_tank) {
						// 死んでいて、残りがあるなら、戦車を登場させる
						generate_tank(i, PLAYER, player_pilot[i],
									  player_tank_position[i].x,
									  player_tank_position[i].y, 2,
									  player_tank[i].tank_type, 0);
						print_rest_player_tank(i,
											   --player_tank[i].num_of_tank);
					}
				} else {
					if (comp_tank_index < 20
						&& comp_tank_generate_interval >= GENERATE_INTERVAL) {
						// 死んでいて、控えの戦車があり、前のを登場させてから
						// 充分な時間が経っていたら、登場させる
						generate_tank(i, COMPUTER, computer_pilot,
						  init_comp_tank_position[comp_tank_index % 3].x,
						  init_comp_tank_position[comp_tank_index % 3].y, 0,
						  comp_tanks[comp_tank_index] / 2 + 8,
						  comp_tanks[comp_tank_index] & 1);
						print_rest_comp_tank(20 - ++comp_tank_index);
						comp_tank_generate_interval = 0;
					}
				}
				break;
			case DEAD3:			// 今死んだところ
				if (i < 2) {
					if (!player_tank[i].num_of_tank)
						if ((player_destroyed |= 1 << i) == 3) {
							game_over_message(3);
							end_code = GAME_OVER;
							end_count++;
						} else
							game_over_message(1 << i);
					else
						player_tank[i].tank_type = i * NUM_OF_PLAYER_TANK_TYPE;
				} else {
					if (++num_of_died_comp_tank == 20) {
						// 終了カウンタをスタートさせる
						end_count++;
					}
				}
				break;
			default:			// その他
				printf("game():	control_tank()の戻り値が異常です"
				  " i = %d, r = %d\n", i, r);
			}
		}
		comp_tank_generate_interval++;
		control_comp_tank_pararize_timer();
		// アイテム、司令部の処理
		control_item();
		if (control_base() == DEAD3) {
			game_over_message(3);
			end_code = GAME_OVER;
			end_count++;
		}
		ctrl_game_over_message();

		if (end_count) {
			if (++end_count > MAX_END_COUNT)
				end_flg = 1;
		}
		// 表示
		update_screen();
		wait();
		change_page();
		// PAUSE の処理
		if (get_esc_key()) {
#if !defined(PROF)
			sound_out(EFS_PAUSE);
#endif
			pause_message(1);
			while (1) {
				if (get_esc_key()) {
#if !defined(PROF)
					sound_out(EFS_PAUSE);
#endif
					break;
				} else if (get_quit_key()) {	// 'q'キーが押されたら強制終了
					end_flg = 1;
					end_code = EXIT_GAME;
					break;
				}
			}
			pause_message(0);
		}
	}
	return end_code;
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

// mode:	一人プレイか二人プレイか
void start_game(int mode)
{
	EndCode end_code;
	int i;

	// スコアや、プレーヤーの戦車の初期化をする
	game_mode = (mode) ? 1 : 0;
	if (game_mode) {
		max_tank = MAX_TANK_2P;
		player_destroyed = 0;
		set_joy_assign(JA_2P);
	} else {
		max_tank = MAX_TANK_1P;
		player_destroyed = 2;
		player_tank[1].num_of_tank = 0;
		set_joy_assign(JA_1P);
	}
	for (i = 0; i <= game_mode; i++) {
		player_tank[i].tank_type = i * NUM_OF_PLAYER_TANK_TYPE;
		player_tank[i].num_of_tank = 3;
		score[i] = 0;
		one_up_threshold[i] = ONE_UP_THRESHOLD;
	}
	old_rest_comp_tank = 0;
	reset_stage_number();
	do {
		int result_mode = player_destroyed ^ 3;
		int type[2];

		select_stage();
		end_code = game();
		if (end_code != EXIT_GAME) {
			for (i = 0; i < 2; i++)
				if (~player_destroyed & (1 << i))
					player_tank[i].num_of_tank++;
			get_player_tank_type(type);	// プレイヤーの戦車の種類を得る
			for (i = 0; i < 2; i++)
				player_tank[i].tank_type = type[i];
			result(result_mode, score, hits);
			inc_stage_number();
		}
	} while (end_code == STAGE_CLEAR);	// 生きている限り繰り返す
	if (end_code == GAME_OVER) {
		int high_scorer = 0;
		if (game_mode) {
			high_scorer = (score[1] > score[0]) ? 1 : 0;
		}
		game_over_screen();
		input_high_score(score[high_scorer], game_mode, high_scorer);
	}
}

void one_up(int tn)
{
#if !defined(PROF)
	sound_out(EFS_ONE_UP);
#endif
	print_rest_player_tank(tn, ++player_tank[tn].num_of_tank);
}

void add_score(int tn, int p)
{
	if (tn < 0 || tn > 1 || p < 0 || p > 4)
		fprintf(stderr, "add_score(): arguments out of range %d, %d\n", tn, p);
	else {
		hits[tn].num[p]++;
		if ((score[tn] += p + 1) >= one_up_threshold[tn]) {
			one_up(tn);
			one_up_threshold[tn] += ONE_UP_THRESHOLD;
		}
	}
}
