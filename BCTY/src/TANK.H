#pragma once

#include "Status.h"
#include "Vvram.h"
#include "EnvInfo.h"
#include "TankType.h"
#include "Point.h"
#include <math.h>
#include <stdio.h>

class Tank {

	Status status;	// ���݂̏��(����ł�Ƃ������Ă�Ƃ��������Ƃ�)

protected:
	Vvram *vvram;
	Tank *tanks;	// ���̐�Ԃ̃��X�g

	const TankType *tankType;
	int x;
	int y;
	int dir;		// �ʒu�ƌ���
	int misc_time;	// �o�ꎞ�ԁA�������ԁA��჎���
private:
	void (*pilot)(int);	// ��Ԃ𑀏c����֐�
	int hit_point;	// �q�b�g�|�C���g�A���ʂ� 1
	int move_flg;	// (*pilot)() ����Amove_tank() ���Ă΂ꂽ���ǂ����̃t���O
	int srip_time;
	int shoot_interval_time;	//// ���̒e�����Ă�܂ł̑҂�����?
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

	// ��Ԃ����݌����Ă�������ɂP�h�b�g�i�߂�A�����Ȃ�������O��Ԃ�
	int move_tank_sub() {
		Point check_point[2];
		int t_x = this->x;
		int t_y = this->y;
		int new_x;
		int new_y;

		switch (this->dir) {
		case 0:	// ��
			new_x = t_x;	new_y = t_y + 1;
			check_point[0].x = t_x / 16;
			check_point[1].x = (t_x + 31) / 16;
			check_point[0].y = check_point[1].y = (t_y + 32) / 16;
			break;
		case 1:	// �E
			new_x = t_x + 1;	new_y = t_y;
			check_point[0].x = check_point[1].x = (t_x + 32) / 16;
			check_point[0].y = t_y / 16;
			check_point[1].y = (t_y + 31) / 16;
			break;
		case 2:	// ��
			new_x = t_x;	new_y = t_y - 1;
			check_point[0].x = t_x / 16;
			check_point[1].x = (t_x + 31) / 16;
			check_point[0].y = check_point[1].y = (t_y - 1) / 16;
			break;
		case 3:	// ��
			new_x = t_x - 1;	new_y = t_y;
			check_point[0].x = check_point[1].x = (t_x - 1) / 16;
			check_point[0].y = t_y / 16;
			check_point[1].y = (t_y + 31) / 16;
			break;
		}

		{	// �n�`���`�F�b�N
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

		{	// �ق��̐�ԂƂ̐ڐG�`�F�b�N
			for (Tank *t2 = tanks; t2 != 0; t2++) {
				if (t2->status != ALIVE || t2 == this)
					// ���̐�Ԃ������Ă��Ȃ��A���͎������g�Ȃ牽�����Ȃ�
					continue;
				int dist_x = abs(new_x - t2->x);
				int dist_y = abs(new_y - t2->y);
				if (dist_x < 32 && dist_y < 32) {
					// ���̐�ԂƐڂ��Ă���
					int o_dist_x, o_dist_y;
					o_dist_x = abs(t_x - t2->x);
					o_dist_y = abs(t_y - t2->y);
					if (dist_x + dist_y < o_dist_x + o_dist_y)
						// ���݂����X�ɋ߂Â����Ƃ͏o���Ȃ�
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

	// ��Ԃ�o�ꂳ����
	void spawn(int x, int y, int dir, const TankType &tankType) {
		if ((x < 16 || x > (STAGE_SIZE - 1 - 2) * 16)
			|| (y < 16 || y > (STAGE_SIZE - 1 - 2) * 16)
			|| (dir < 0 || dir >= 4)) {
				printf("generate_tank(): ���W���ςł�(%d, %d, %d)\n", x, y, dir);
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

	// ��Ԃ𓮂���
	int move_tank(int dir) {
		if (dir < -1 || dir > 3) {
			throw "wrong direction";
		}
		move_flg = 1;
		if (dir != -1 && dir != dir) {
			if ((dir ^ dir) & 1) {
				// ���݂̌����ƂX�O�x�Ⴄ�Ȃ���W�𒲐߂���
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
			int moved = 0;	// ���������ǂ����̃t���O
			for (i = tankType->gun_speed; i > 0; i--)
				if (!(moved |= move_tank_sub()))
					break;
			return moved;
		}
	}

	// ��Ԃ��X�̏�ɂ��邩�ǂ������`�F�b�N����
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

	// ��ԂɃ_���[�W��^���� �G��ԓ��m�̑��ł��Ȃ炱��͌Ă΂�Ȃ�
	// dest_t: �_���[�W���󂯂���
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
				////				barrier_time = (flg == PLAYER) ? BARRIER_TIME2 : 0;	// �v���C���[��ԌŗL�̏���
				////				change_pattern(&sprite, tank_type[type].pattern_num
				////					+ (hit_point - 1) * 4, 0);
				koma = dir;
			} else
				if ((koma = misc_time & 3) == 3)
					koma = 1;
			break;
		case ALIVE:
			if (hit_point <= 0) {
				// ����ł��܂���
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
						// ������n������Ă����瓮���Ȃ�
						if (misc_time)	// ���̏ꍇ��misc_time�͖�჏�Ԃ�
							misc_time--;	// ���Ԃ�\���Ă���
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
				// �o���A
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

	// �e�����Ă邩�ǂ������`�F�b�N����
	bool can_shoot_gun() {
		return shoot_interval_time == 0;
	}

	// �e������
	int shoot_gun();

	static int fix_position(int p) {
		return (p + 8) & ~15;
	}

};