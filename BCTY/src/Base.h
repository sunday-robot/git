#pragma once

#include "Point.h"
#include "Vvram.h"
#include "PAT.H"


#define BASE_X (STAGE_SIZE / 2 - 1)
#define BASE_Y (STAGE_SIZE - 3)

class Base {
	static const Point guardBlockPositions[];

	Vvram *vvram;

	int status;
	int hit;
	int burst_time;
	int guard_time;
	int koma;
//	Sprite sprite;

public:
	Base() {
		status = DEAD;
		hit = 0;
		burst_time = 0;
		guard_time = 0;
		koma  = 0;
		////		static Base base = {DEAD, 0, 0, 0, 0, {PAT_BURST, 1}};	// スプライトの部分以外はダミー
	}

	// 司令部の周りの壁の属性を変える
	void set_base_wall_type(int flg) {
		int i;

		if (flg)
			for (i = 0; i < 8; i++) {
				const Point &p = guardBlockPositions[i];
				vvram->cells[p.y][p.x].type = CONCRETE;
			}
		else
			for (i = 0; i < 8; i++) {
				const Point &p = guardBlockPositions[i];
				vvram->cells[p.y][p.x].type = RENGA;
				vvram->cells[p.y][p.x].pat = 15;
			}
	}

	// 司令部の周りの壁の絵を変える
	void set_base_wall_pattern(int flg) {
		int pat = flg ? PAT_CONCRETE : PAT_RENGA + 15;
		int i;

		for (i = 0; i < 8; i++) {
			const Point &p = guardBlockPositions[i];
//			change_BG(p.x, p.y, 0, pat);
		}
	}

	// 司令部の周りをガードする
	void guard_base(void) {
		guard_time = BASE_GUARD_TIME;
		set_base_wall_type(1);
		set_base_wall_pattern(1);
	}

	int control_base(void) {
		switch (status) {
		case ALIVE:
			if (guard_time) {
				if (--guard_time) {
					if (guard_time < BASE_GUARD_TIME / 4
						&& (guard_time & 3) == 0) {
							// 残り時間が少なくなったら、適当な間隔で点滅させる
							set_base_wall_pattern(guard_time & 4);
					}
				} else {
					// 周りの壁をレンガに変える
					set_base_wall_pattern(0);
					set_base_wall_type(0);
				}
			}
			if (hit) {
#if !defined(PROF)
//				sound_out(EFS_BURST);
#endif
				status = BURST;
				burst_time = BURST_TIME;
			}
			break;
		case BURST:
			switch (--burst_time) {
			case 0:
				status = DEAD3;
				// BG の変更(降伏の白い旗)
#if 0
				change_BG(BASE_X, BASE_Y,  0, PAT_W_FLAG);
				change_BG(BASE_X + 1, BASE_Y,  0, PAT_W_FLAG + 1);
				change_BG(BASE_X, BASE_Y + 1,  0, PAT_W_FLAG + 2);
				change_BG(BASE_X + 1, BASE_Y + 1,  0, PAT_W_FLAG + 3);
#endif
				break;
			case BURST_TIME * 5 / 6:
			case BURST_TIME * 3 / 6:
				koma++;
			default:
////				if (!put_sprite(&sprite, (BASE_X - 1) * 16, (BASE_Y - 1) * 16, koma))
////					puts("control_base(): error on put_sprite()");
				break;
			}
			break;
		case DEAD3:
			status = DEAD;
			break;
		}
		return status;
	}

};

extern Base base;
