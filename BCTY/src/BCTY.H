#pragma once

#define STAGE_SIZE 28					// １６ドット単位で回りの枠も含めたもの

#define NUM_OF_PLAYER_TANK_TYPE 4		// プレイヤー戦車の種類

#define WAIT_COUNT_IN_RESULT 40
#define WAIT_COUNT_IN_GAME 2

#define CLOCK (60 / WAIT_COUNT_IN_GAME)

#define BORN_TIME (CLOCK * 1)			// 戦車登場時、ピカピカしている時間
#define BURST_TIME (CLOCK / 4)			// 戦車、司令部が爆発している時間
#define BURST_TIME2 (CLOCK / 8)			// 弾が爆発している時間
#define BARRIER_TIME (CLOCK * 10)
#define BARRIER_TIME2 (CLOCK * 3)		// プレイヤー戦車が登場したときの
#define SRIP_TIME (CLOCK / 2)			// 氷の上に乗って、スリップしている時間
#define PARARIZE_TIME (CLOCK * 9 / 2)	// 相討ちされて動けずにいる時間
#define DISP_POINT_TIME (CLOCK * 1)		// 敵戦車が死んだあと得点を表示している
										// 時間
#define GENERATE_INTERVAL (CLOCK * 3)	// 敵戦車が登場する間隔
#define MAX_END_COUNT (CLOCK * 4)		// ゲームオーバーになってから、実際に終
										// 了するまでの時間
#define SHOOT_INTERVAL_TIME (CLOCK / 4)	// 弾を打った後、次のを発射するまでの待
										// ち時間
#define BASE_GUARD_TIME (CLOCK * 43 / 2)	// 司令部がコンクリートの壁で守られ
										// ている時間
#define COMP_TANK_PARARIZE_TIME (CLOCK * 10)	// ストップウォッチのアイテムを
										// 取ったとき敵戦車が動けずにいる時間
#define GAME_OVER_TIME MAX_END_COUNT	// "GAME OVER" を表示している時間

typedef enum {
	BGM_TITLE = 1, BGM_OPENING, BGM_GAME_OVER, BGM_HIGH_SCORE
} BgmNumber;

typedef enum {
	EFS_SHOOT = 1, EFS_BREAK_WALL, EFS_REFLECT, EFS_BURST,	EFS_GET_ITEM,
	EFS_ONE_UP, EFS_PAUSE, EFS_RESULT, EFS_BONUS, EFS_SELECT, EFS_DETERM,
	EFS_S_SELECT
} EfsNumber;

typedef enum {PLAYER, COMPUTER} Flag;

typedef enum {ROAD, RENGA, WOOD, ICE, CONCRETE, RIVER, FRAME, BASE} Ground;

