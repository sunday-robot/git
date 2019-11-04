#pragma once

#include "Vvram.h"
#include "Tank.h"

enum {
	GH_NOTHIT = 0, GH_GUN = 1, GH_WBREAK = 2, GH_NOTBREAK = 4,
	GH_TBREAK = 8
};

class Gun {
	// 砲弾のリスト(戦車が打つたびにインスタンスを生成したりせず、予め最大数を生成しておき、使いまわす)
	static const int maxGunCount = 100;
	static Gun guns[maxGunCount];

	Vvram *vvram;
	Tank *tanks;	// 他の戦車のリスト

	Point position;
	int dir;	// 位置と向き
	Status status;	// DEAD, LIVE, BURST のうちどれか
	int hit;		// ほかの弾に当てられた
	int burst_time;
	bool isPowerUpped;	// パワーアップした状態か?(パワーアップしている場合、レンガを一度に大量に壊すことができる)
//	Sprite sprite;
	int speed;	// 1コマで進む距離
	bool isPlayers;	// プレイヤー戦車の弾か否(コンピューター戦車の弾)か

private:
	static void getNewPositionAndCheckPoint(
		const Point &currentPosition,
		const int dir,
		Point *newPosition,
		Point checkPositions[]) {
		switch (dir) {
		case 0:	// 下
			newPosition->x = currentPosition.x;
			newPosition->y = currentPosition.y + 2;
			checkPositions[0].x = currentPosition.x;
			checkPositions[1].x = currentPosition.x + 15;
			checkPositions[0].y = currentPosition.y + 17;
			checkPositions[1].y = currentPosition.y + 17;
			break;
		case 1:	// 右
			newPosition->x = currentPosition.x + 2;
			newPosition->y = currentPosition.y;
			checkPositions[0].x = currentPosition.x + 17;
			checkPositions[1].x = currentPosition.x + 17;
			checkPositions[0].y = currentPosition.y;
			checkPositions[1].y = currentPosition.y + 15;
			break;
		case 2:	// 上
			newPosition->x = currentPosition.x;
			newPosition->y = currentPosition.y - 2;
			checkPositions[0].x = currentPosition.x;
			checkPositions[1].x = currentPosition.x + 15;
			checkPositions[0].y = newPosition->y;
			checkPositions[1].y = newPosition->y;
			break;
		default:	// case 3:	// 左
			newPosition->x = currentPosition.x - 2;
			newPosition->y = currentPosition.y;
			checkPositions[0].x = newPosition->x;
			checkPositions[1].x = newPosition->x;
			checkPositions[0].y = currentPosition.y;
			checkPositions[1].y = currentPosition.y + 15;
		}
	}

	static int checkCollisionWithBG(Vvram *vvram, const bool isPowerUpped, const int dir, const Point checkPositions[], bool *isBaseDestroyed) {
		int flg = 0;
		*isBaseDestroyed = false;

		int i;
		for (i = 0; i < 2; i++) {
			VvramCell *v;
			int x = checkPositions[i].x;
			int y = checkPositions[i].y;
			switch ((v = &vvram->cells[y / 16][x / 16])->type) {
			case RENGA:
				{
					// ブロック内のどの領域か？ 左上から1,2,4,8となっている
					int pat = ((y & 8) ? 12 : 3) & ((x & 8) ? 10 : 5);
					if (v->pat & pat) {
						flg |= GH_WBREAK;
						if (isPowerUpped) {
							// パワーアップしていたら一発で壊してしまう
							v->type = ROAD;
////							change_BG(x / 16, y / 16, 0, PAT_ROAD);
						} else {
							int erace_pat;
							if (dir & 1)
								// 左or右
								erace_pat = (pat & 5) ? 10 : 5;
							else
								// 上or下
								erace_pat = (pat & 3) ? 12 : 3;
							if ((v->pat &= erace_pat) == 0) {
								v->type = ROAD;
////								change_BG(x / 16, y / 16, 0, PAT_ROAD);
							} else {
////								change_BG(x / 16, y / 16, 0, PAT_RENGA
////								+ v->pat);
							}
						}
					}
				}
				break;
			case CONCRETE:
				if (isPowerUpped) {
					// パワーアップしているならコンクリートも一発で壊せる
					flg |= GH_WBREAK;
					v->type = ROAD;
////					change_BG(x / 16, y / 16, 0, PAT_ROAD);
				} else
					flg |= GH_NOTBREAK;
				break;
			case FRAME:
				flg |= GH_NOTBREAK;
				break;
			case BASE:
				flg |= GH_TBREAK;
				*isBaseDestroyed = true;
				break;
			}
		}
		return flg;
	}

	static int checkCollisionWithTanks(const Point &newPosition, Tank *tanks) {
		int flg = 0;
#if 0
		Tank *t2 = tanks;
		int i;

		for (i = 0; i < MAX_TANK; i++, t2++) {
			int dist_x, dist_y;

			if (t2->getStatus() == DEAD)
				continue;
			if (t2->flg == t->flg && t->flg == COMPUTER)
				continue;
			{ // 弾との衝突チェック
				Gun *g2 = t2->gun;
				int j;
				for (j = 0; j < t2->num_of_gun; j++, g2++) {
					if (g2->status != ALIVE)
						continue;
					dist_x = abs(newPosition.x - g2->x);
					dist_y = abs(newPosition.y - g2->y);
					if (dist_x < GUN_SIZE && dist_y < GUN_SIZE) {
						// その弾と接している
						flg |= GH_GUN;
						g2->hit |= GH_GUN;
					}
				}
			}
			if (t2->status == ALIVE) {
				// 戦車との衝突チェック
				dist_x = newPosition.x - t2->x;
				dist_y = newPosition.x - t2->y;
				if (dist_x < 32 && dist_x > -16 && dist_y < 32
					&& dist_y > -16) {
						flg |= damage_tank(t2, t);
				}
			}
		}
#endif
		return flg;
	}
public:
	// 弾を 1 ドット動かす
	int move_gun_sub(/*Tank *t, Gun *g*/) {
		int flg;	// 弾が何かに当たったかどうかのフラグ（レンガや戦車に当たってもチェックはすべて行わなければいけない）

		// 現在の位置と方向から、移動後の位置、衝突チェックを行う点の座標を取得する
		Point newPosition;
		Point check_point[2];
		getNewPositionAndCheckPoint(position, dir, &newPosition, check_point);

		bool isBaseDestroyed;

		// 地形との衝突をチェック
		flg = checkCollisionWithBG(vvram, isPowerUpped, dir, check_point, &isBaseDestroyed);
#if 0
		if (isBaseDestroyed)
			base.hit = 1;
#endif

		// ほかの戦車とその弾との接触チェック
		checkCollisionWithTanks(newPosition, tanks);

		position = newPosition;
		return hit |= flg;
	}

	void move_gun() {
		for (int i = 0; i < speed; i++)
			if (move_gun_sub())
				break;
	}

	void control() {
		switch (status) {
		case ALIVE:
			move_gun();
			if (hit != GH_NOTHIT) {
				if (hit != GH_GUN) {
					status = BURST;
					burst_time = BURST_TIME2;
					position.x -= 8;
					position.y -= 8;
					dir = 0;
//					change_pattern(&sprite, PAT_BURST2, 1);
					if (isPlayers) {
						if ((hit & GH_WBREAK) != 0) {
////							sound_out(EFS_BREAK_WALL);
						} else if ((hit & GH_NOTBREAK) != 0) {
////							sound_out(EFS_REFLECT);
						}
					}
				} else
					status = DEAD;
			}
			break;
		case BURST:
			switch (--burst_time) {
			case BURST_TIME2 * 2 / 3:
				dir = 1;
				break;
			case 0:
				status = DEAD;
				break;
			}
			break;
		}
#if 0
		if (status != DEAD)
			if (!put_sprite(&sprite, position.x, position.y, dir))
				puts("control_gun(): error on put_sprite()");
#endif
	}

	static void spawn(int x, int y, int dir, const Tank *tank) {
		int i;
		for (i = 0; i < maxGunCount; i++) {
			Gun *g = guns + i;
			if (g->status == DEAD) {
				g->status = ALIVE;
				g->hit = 0;
////				change_pattern(&g->sprite, PAT_GUN, 1);
				return;
			}
		}
		throw "砲弾の数が足りません。";
	}

};

