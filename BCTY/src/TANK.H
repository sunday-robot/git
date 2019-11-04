#pragma once

#include "Status.h"
#include "Vvram.h"
#include "EnvInfo.h"
#include "TankType.h"
#include "Point.h"
#include <math.h>
#include <stdio.h>

class Tank {

	Status status;	// 現在の状態(死んでるとか生きてるとか爆発中とか)

protected:
	Vvram *vvram;
	Tank *tanks;	// 他の戦車のリスト

	const TankType *tankType;
	int x;
	int y;
	int dir;		// 位置と向き
	int misc_time;	// 登場時間、爆発時間、麻痺時間
private:
	void (*pilot)(int);	// 戦車を操縦する関数
	int hit_point;	// ヒットポイント、普通は 1
	int move_flg;	// (*pilot)() から、move_tank() が呼ばれたかどうかのフラグ
	int srip_time;
	int shoot_interval_time;	//// 次の弾を撃てるまでの待ち時間?
	int koma;
	//	Sprite sprite;

public:
	int getDirection() {
		return dir;
	}

	const TankType *getTankType() {
		return tankType;
	}

protected:
	void set_tank_type(const TankType &tt) {
		hit_point = tt.hit_point;
	}

	// 戦車を現在向いている方向に１ドット進める、動けなかったら０を返す
	int move_tank_sub() {
		Point check_point[2];
		int t_x = this->x;
		int t_y = this->y;
		int new_x;
		int new_y;

		switch (this->dir) {
		case 0:	// 下
			new_x = t_x;	new_y = t_y + 1;
			check_point[0].x = t_x / 16;
			check_point[1].x = (t_x + 31) / 16;
			check_point[0].y = check_point[1].y = (t_y + 32) / 16;
			break;
		case 1:	// 右
			new_x = t_x + 1;	new_y = t_y;
			check_point[0].x = check_point[1].x = (t_x + 32) / 16;
			check_point[0].y = t_y / 16;
			check_point[1].y = (t_y + 31) / 16;
			break;
		case 2:	// 上
			new_x = t_x;	new_y = t_y - 1;
			check_point[0].x = t_x / 16;
			check_point[1].x = (t_x + 31) / 16;
			check_point[0].y = check_point[1].y = (t_y - 1) / 16;
			break;
		case 3:	// 左
			new_x = t_x - 1;	new_y = t_y;
			check_point[0].x = check_point[1].x = (t_x - 1) / 16;
			check_point[0].y = t_y / 16;
			check_point[1].y = (t_y + 31) / 16;
			break;
		}

		{	// 地形をチェック
			int i;
			for (i = 0; i < 2; i++) {
				switch (this->vvram->cells[check_point[i].y][check_point[i].x].type) {
				case ROAD:
					//			case WOOD:
				case ICE:
					break;
				default:
					return 0;
				}
			}
		}

		{	// ほかの戦車との接触チェック
			for (Tank *t2 = tanks; t2 != 0; t2++) {
				if (t2->status != ALIVE || t2 == this)
					// その戦車が生きていない、或は自分自身なら何もしない
					continue;
				int dist_x = abs(new_x - t2->x);
				int dist_y = abs(new_y - t2->y);
				if (dist_x < 32 && dist_y < 32) {
					// その戦車と接している
					int o_dist_x, o_dist_y;
					o_dist_x = abs(t_x - t2->x);
					o_dist_y = abs(t_y - t2->y);
					if (dist_x + dist_y < o_dist_x + o_dist_y)
						// 現在よりも更に近づくことは出来ない
						return 0;
				}
			}
		}
		this->x = new_x;
		this->y = new_y;
		return 1;
	}

public:
	Status getStatus() {
		return status;
	}

	void setPilot(void (*pilot)(int)) {
		this->pilot = pilot;
	}

	// 戦車を登場させる
	void spawn(int x, int y, int dir, const TankType &tankType) {
		if ((x < 16 || x > (STAGE_SIZE - 1 - 2) * 16)
			|| (y < 16 || y > (STAGE_SIZE - 1 - 2) * 16)
			|| (dir < 0 || dir >= 4)) {
				printf("generate_tank(): 座標が変です(%d, %d, %d)\n", x, y, dir);
				return;
		}
		this->pilot = pilot;
		this->x = x;
		this->y = y;
		this->dir = dir;
		this->status = BORN;
		this->tankType = &tankType;
		this->misc_time = BORN_TIME;
//		change_pattern(&this->sprite, PAT_BORN, 0);
		set_tank_type(tankType);
	}

	void die() {
		if (status == ALIVE) {
			hit_point = 0;
		}
	}

	// 戦車を動かす
	int move_tank(int dir) {
		if (dir < -1 || dir > 3) {
			throw "wrong direction";
		}
		move_flg = 1;
		if (dir != -1 && dir != dir) {
			if ((dir ^ dir) & 1) {
				// 現在の向きと９０度違うなら座標を調節する
				if (dir & 1) {
					y = fix_position(y);
				} else {
					x = fix_position(x);
				}
			}
			this->dir = dir;
			return 1;
		} else {
			int i;
			int moved = 0;	// 動いたかどうかのフラグ
			for (i = tankType->gun_speed; i > 0; i--)
				if (!(moved |= move_tank_sub()))
					break;
			return moved;
		}
	}

	// 戦車が氷の上にいるかどうかをチェックする
	int is_on_ice() {
		int cx1 = (x + 15) / 16;
		int cy1 = (y + 15) / 16;
		int cx2 = (x + 16) / 16;
		int cy2 = (y + 16) / 16;

		if (vvram->cells[cy1][cx1].type == ICE
			&& vvram->cells[cy1][cx2].type == ICE
			&& vvram->cells[cy2][cx1].type == ICE
			&& vvram->cells[cy2][cx2].type == ICE)
			return 1;
		else
			return 0;
	}

	// 戦車にダメージを与える 敵戦車同士の相打ちならこれは呼ばれない
	// dest_t: ダメージを受ける戦車
	virtual int beShot(bool isPlayerBullet) = 0;

	int decreaseHitPoint() {
		hit_point--;
		return hit_point;
	}
#if 0
	void control_gun() {
		for (int i = 0; i < num_of_gun; i++) {
			gun[i].control();
		}
	}
#endif

public:
	int control_tank() {
		switch (status) {
		case BORN:
			if (--misc_time == 0) {
				status = ALIVE;
				////				barrier_time = (flg == PLAYER) ? BARRIER_TIME2 : 0;	// プレイヤー戦車固有の処理
				////				change_pattern(&sprite, tank_type[type].pattern_num
				////					+ (hit_point - 1) * 4, 0);
				koma = dir;
			} else
				if ((koma = misc_time & 3) == 3)
					koma = 1;
			break;
		case ALIVE:
			if (hit_point <= 0) {
				// 死んでしまった
				status = BURST;
				misc_time = BURST_TIME;
				x -= 16;
				y -= 16;
				koma = 0;
////				change_pattern(&sprite, PAT_BURST, 1);
#if !defined(PROF)
////				sound_out(EFS_BURST);
#endif
			} else {
				move_flg = 0;
#if 0
				if (flg == PLAYER) {
					if (base.status == LIVE) {
						// 味方基地がやられていたら動かない
						if (misc_time)	// この場合のmisc_timeは麻痺状態の
							misc_time--;	// 時間を表している
						else
							pilot(tn);
					}
				} else if (comp_tank_pararize_time == 0)
					pilot(tn);
#endif
				if (is_on_ice()) {
					if (move_flg)
						srip_time = SRIP_TIME;
					else
						if (srip_time) {
							srip_time--;
							move_tank(dir);
						}
				}
#if 0
				// バリア
				if (barrier_time) {
					barrier_time--;
					if (!put_sprite(&barrier_sprite, x, y, barrier_time
						& 1))
						puts("control_tank(): error on put_sprite() barrier");
				}
				if (item && (item.time2 & 3))
					koma = dir + 4;
				else
					koma = dir;
#endif
			}
			break;
		case BURST:
			misc_time--;
			switch (misc_time) {
			case 0:
#if 0
				if (disp_point_flg) {
					status = DISP_POINT;
					x += 16;
					y += 16;
					misc_time = DISP_POINT_TIME;
					koma = tank_type[type].option.point;
					change_pattern(&sprite, PAT_POINT, 2);
				} else {
					status = DEAD3;
				}
#endif
				break;
			case BURST_TIME * 5 / 6:
			case BURST_TIME * 3 / 6:
				koma++;
				break;
			}
			break;
#if 0
		case DISP_POINT:
			if (--misc_time == 0) {
				status = DEAD3;
			}
			break;
#endif
		case DEAD3:
			status = DEAD2;
			break;
		case DEAD2:
#if 0
			if (gun[0].status == DEAD && gun[1].status == DEAD)
				status = DEAD;
#endif
			break;
		}
		if (status != DEAD) {
			if (shoot_interval_time)
				shoot_interval_time--;
			////		control_gun();
		}
#if 0
		if (status > DEAD3) {
			if (status != ALIVE || ((misc_time & 4) == 0))
				if (!put_sprite(&sprite, x, y, koma))
					puts("control_tank(): error on put_sprite()");
		}
#endif
		return status;
	}

	// 弾が撃てるかどうかをチェックする
	bool can_shoot_gun() {
		return shoot_interval_time == 0;
	}

	// 弾を撃つ
	int shoot_gun();

	static int fix_position(int p) {
		return (p + 8) & ~15;
	}

};
