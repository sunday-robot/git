#pragma once

#include "Tank.h"
#include "Hits.h"
#include "Item.h"
#include "Base.h"
#include "ComputerTank.h"

// ゲーム中のプレイヤー戦車の状態を管理するクラス
class PlayerTank : public Tank {
	bool destroyed;
	int tankType;		// プレイヤー戦車のレベルと思われる
	int score;
	Hits hits;
	int barrier_time;

public:
	int leftTankCount;	// 残りの戦車の数(画面に登場している戦車は除く)

	void initialize(bool isActive) {
		if (isActive) {
			destroyed = false;
			tankType = -1;	// ???初期値はどうする?
			leftTankCount = 3;
			score = 0;
		} else {
			destroyed = true;
		}
	}

private:
	void add_score(int p) {
		if (p < 0 || p > 4) {
			fprintf(stderr, "add_score(): arguments out of range %d\n", p);
			throw "exception";
		}
		hits.num[p]++;
#define ONE_UP_THRESHOLD 200/*00*/		// 1upする点数 / 100
		int a = this->score / ONE_UP_THRESHOLD;
		this->score += (p + 1);
		int b = this->score / ONE_UP_THRESHOLD;
		if (a != b) {
			this->leftTankCount++;
			// sound_out(EFS_ONE_UP);
			//// print_rest_player_tank(tn, ++GameModel.playerTanks[tn].num_of_tank);
		}
	}

	void power_up_tank() {
//		this->type = tank_type[this->type].option.next_type;
//		set_tank_type(this);
		////		change_pattern(&this->sprite, tank_type[this->type].pattern_num, 0);
	}

	// 戦車を現在向いている方向に１ドット進める、動けなかったら０を返す
	int move_tank_sub() {
		if (!Tank::move_tank_sub())
			return 0;

		// アイテムのチェック
		if (item.getStatus() != ALIVE) {
			return 1;
		}
		if (abs(this->x - item.getX()) < 32 && abs(this->y - item.getY()) < 32) {
			add_score(4);
			switch (item.getType()) {
			case BOMB:	// 爆弾、得点は入らないのでこの場で処理する
				{
					for (Tank *t = tanks; t != NULL; t++) {
						t->die();
					}
				}
				break;
			case SHOVEL:	// 司令部を一定時間コンクリートの壁でガードすると
				// ともに壁の修理もする。
				base.guard_base();
				break;
			case STAR:	// 戦車のパワーアップ
				power_up_tank();
				break;
			case TANK:	// 1up
				////				one_up();
				break;
			case HELMET:
				this->barrier_time = BARRIER_TIME;
				break;
			case STOP_WATCH:
				ComputerTank::beParalyzed();
				break;
			default:
				printf("move_tank_sub():???? アイテムの種類が異常です (%d)\n",
					item.getType());
				break;
			}
			if (item.getType() != BOMB || item.getType() != TANK) {
////				sound_out(EFS_GET_ITEM);
			}
			item.setStatus(DISP_POINT);
			item.setTimer(DISP_POINT_TIME);
////必要ないはず			item.setType(0);
////			change_pattern(&item.sprite, PAT_POINT + 4, 2);
		}
	}

	virtual int beShot(bool isPlayerBullet)
	{
		int r = GH_NOTBREAK;

		if (barrier_time > 0)
			return GH_NOTBREAK;
		if (isPlayerBullet) {
			// プレイヤー戦車同士の相撃ちの場合は、撃たれた側が一定時間動けなくなる
			misc_time = PARARIZE_TIME;
			return GH_NOTBREAK;
		}
		if (decreaseHitPoint() == 0) {
			r = GH_TBREAK;
		} else {
////				change_pattern(&sprite, tank_type[dest_t->type].pattern_num	+ (dest_t->hit_point - 1) * 4, 0);
		}
		return (int) r;
	}
};
