#pragma once

#include "Tank.h"

#include "Item.h"
#include "Gun.h"

class ComputerTank : public Tank {
private:
	static int paralyzed_time;

	bool hasItem;		// アイテムを持っていたらtrue(どのアイテムかはアイテムを出す際にランダムで決める)
	int disp_point_flg;	// 爆発終了後得点を表示するかどうかのフラグ
public:
	void spawn(int x, int y,
		int dir, const ComputerTankType &tank_type, int item_flg) {
		Tank::spawn(x, y, dir, tank_type);
		hasItem = item_flg != 0;
		disp_point_flg = 0;
	}

	static void beParalyzed() {
		paralyzed_time = COMP_TANK_PARARIZE_TIME;
	}

	static void control_comp_tank_pararize_timer(void) {
		if (paralyzed_time)
			paralyzed_time--;
	}

	virtual int beShot(bool isPlayerBullet) {
		int r = GH_NOTBREAK;

			if (hasItem) {
				// アイテムを持っていたらそれを出す(死んだらアイテムを出すのではなく、はじめに撃たれたときに出す。)
				hasItem = false;
				item.spawn();
			}
			if (decreaseHitPoint() == 0) {
				r = GH_TBREAK;
				if (isPlayerBullet) {
					// add_score(t->number, tank_type[dest_t->type].option.point);
					disp_point_flg = 1;
				}
			} else {
////				change_pattern(&sprite, tank_type[dest_t->type].pattern_num	+ (dest_t->hit_point - 1) * 4, 0);
			}
		return r;
	}

	// 周囲の障害物の情報を返す
	// (コンピューター戦車用のメソッド)
	void get_tank_env_info(EnvInfo ei[4]) {
		static Point check_point[4][2] = {
			{{0, 32}, {16, 32}},
			{{32, 0}, {32, 16}},
			{{0, -1}, {16, -1}},
			{{-1, 0}, {-1, 16}},
		};
		int i;
		int fx = x;
		int fy = y;

		if (dir & 1) {
			// 戦車が横向き
			fx = fix_position(x);
		} else {
			// 戦車が縦向き
			fy = fix_position(y);
		}
		for (i = 0; i < 4; i++) {
			int j;
			int e = 0;

			for (j = 0; j < 2; j++) {
				int cx = (fx + check_point[i][j].x) / 16;
				int cy = (fy + check_point[i][j].y) / 16;
				switch(vvram->cells[cy][cx].type) {
				case RENGA:
					e |= 1;
					break;
				case CONCRETE:
				case RIVER:
				case FRAME:
					e |= 2;
					break;
				}
			}
			{
				static EnvInfo table[] = {eiNothing, eiRenga, eiUnthroughable,
					eiUnthroughable};
				ei[i] = table[e];
			}
		}
	}

};
