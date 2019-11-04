#pragma once

#include "Vvram.h"
#include "Tank.h"

enum {
	GH_NOTHIT = 0, GH_GUN = 1, GH_WBREAK = 2, GH_NOTBREAK = 4,
	GH_TBREAK = 8
};

class Gun {
	// �C�e�̃��X�g(��Ԃ��ł��тɃC���X�^���X�𐶐������肹���A�\�ߍő吔�𐶐����Ă����A�g���܂킷)
	static const int maxGunCount = 100;
	static Gun guns[maxGunCount];

	Vvram *vvram;
	Tank *tanks;	// ���̐�Ԃ̃��X�g

	Point position;
	int dir;	// �ʒu�ƌ���
	Status status;	// DEAD, LIVE, BURST �̂����ǂꂩ
	int hit;		// �ق��̒e�ɓ��Ă�ꂽ
	int burst_time;
	bool isPowerUpped;	// �p���[�A�b�v������Ԃ�?(�p���[�A�b�v���Ă���ꍇ�A�����K����x�ɑ�ʂɉ󂷂��Ƃ��ł���)
//	Sprite sprite;
	int speed;	// 1�R�}�Ői�ދ���
	bool isPlayers;	// �v���C���[��Ԃ̒e����(�R���s���[�^�[��Ԃ̒e)��

private:
	static void getNewPositionAndCheckPoint(
		const Point &currentPosition,
		const int dir,
		Point *newPosition,
		Point checkPositions[]) {
		switch (dir) {
		case 0:	// ��
			newPosition->x = currentPosition.x;
			newPosition->y = currentPosition.y + 2;
			checkPositions[0].x = currentPosition.x;
			checkPositions[1].x = currentPosition.x + 15;
			checkPositions[0].y = currentPosition.y + 17;
			checkPositions[1].y = currentPosition.y + 17;
			break;
		case 1:	// �E
			newPosition->x = currentPosition.x + 2;
			newPosition->y = currentPosition.y;
			checkPositions[0].x = currentPosition.x + 17;
			checkPositions[1].x = currentPosition.x + 17;
			checkPositions[0].y = currentPosition.y;
			checkPositions[1].y = currentPosition.y + 15;
			break;
		case 2:	// ��
			newPosition->x = currentPosition.x;
			newPosition->y = currentPosition.y - 2;
			checkPositions[0].x = currentPosition.x;
			checkPositions[1].x = currentPosition.x + 15;
			checkPositions[0].y = newPosition->y;
			checkPositions[1].y = newPosition->y;
			break;
		default:	// case 3:	// ��
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
					// �u���b�N���̂ǂ̗̈悩�H ���ォ��1,2,4,8�ƂȂ��Ă���
					int pat = ((y & 8) ? 12 : 3) & ((x & 8) ? 10 : 5);
					if (v->pat & pat) {
						flg |= GH_WBREAK;
						if (isPowerUpped) {
							// �p���[�A�b�v���Ă�����ꔭ�ŉ󂵂Ă��܂�
							v->type = ROAD;
////							change_BG(x / 16, y / 16, 0, PAT_ROAD);
						} else {
							int erace_pat;
							if (dir & 1)
								// ��or�E
								erace_pat = (pat & 5) ? 10 : 5;
							else
								// ��or��
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
					// �p���[�A�b�v���Ă���Ȃ�R���N���[�g���ꔭ�ŉ󂹂�
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
			{ // �e�Ƃ̏Փ˃`�F�b�N
				Gun *g2 = t2->gun;
				int j;
				for (j = 0; j < t2->num_of_gun; j++, g2++) {
					if (g2->status != ALIVE)
						continue;
					dist_x = abs(newPosition.x - g2->x);
					dist_y = abs(newPosition.y - g2->y);
					if (dist_x < GUN_SIZE && dist_y < GUN_SIZE) {
						// ���̒e�Ɛڂ��Ă���
						flg |= GH_GUN;
						g2->hit |= GH_GUN;
					}
				}
			}
			if (t2->status == ALIVE) {
				// ��ԂƂ̏Փ˃`�F�b�N
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
	// �e�� 1 �h�b�g������
	int move_gun_sub(/*Tank *t, Gun *g*/) {
		int flg;	// �e�������ɓ����������ǂ����̃t���O�i�����K���Ԃɓ������Ă��`�F�b�N�͂��ׂčs��Ȃ���΂����Ȃ��j

		// ���݂̈ʒu�ƕ�������A�ړ���̈ʒu�A�Փ˃`�F�b�N���s���_�̍��W���擾����
		Point newPosition;
		Point check_point[2];
		getNewPositionAndCheckPoint(position, dir, &newPosition, check_point);

		bool isBaseDestroyed;

		// �n�`�Ƃ̏Փ˂��`�F�b�N
		flg = checkCollisionWithBG(vvram, isPowerUpped, dir, check_point, &isBaseDestroyed);
#if 0
		if (isBaseDestroyed)
			base.hit = 1;
#endif

		// �ق��̐�ԂƂ��̒e�Ƃ̐ڐG�`�F�b�N
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
		throw "�C�e�̐�������܂���B";
	}

};

