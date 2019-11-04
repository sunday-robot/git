#pragma once

#include "Tank.h"
#include "Hits.h"
#include "Item.h"
#include "Base.h"
#include "ComputerTank.h"

// �Q�[�����̃v���C���[��Ԃ̏�Ԃ��Ǘ�����N���X
class PlayerTank : public Tank {
	bool destroyed;
	int tankType;		// �v���C���[��Ԃ̃��x���Ǝv����
	int score;
	Hits hits;
	int barrier_time;

public:
	int leftTankCount;	// �c��̐�Ԃ̐�(��ʂɓo�ꂵ�Ă����Ԃ͏���)

	void initialize(bool isActive) {
		if (isActive) {
			destroyed = false;
			tankType = -1;	// ???�����l�͂ǂ�����?
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
#define ONE_UP_THRESHOLD 200/*00*/		// 1up����_�� / 100
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

	// ��Ԃ����݌����Ă�������ɂP�h�b�g�i�߂�A�����Ȃ�������O��Ԃ�
	int move_tank_sub() {
		if (!Tank::move_tank_sub())
			return 0;

		// �A�C�e���̃`�F�b�N
		if (item.getStatus() != ALIVE) {
			return 1;
		}
		if (abs(this->x - item.getX()) < 32 && abs(this->y - item.getY()) < 32) {
			add_score(4);
			switch (item.getType()) {
			case BOMB:	// ���e�A���_�͓���Ȃ��̂ł��̏�ŏ�������
				{
					for (Tank *t = tanks; t != NULL; t++) {
						t->die();
					}
				}
				break;
			case SHOVEL:	// �i�ߕ�����莞�ԃR���N���[�g�̕ǂŃK�[�h�����
				// �Ƃ��ɕǂ̏C��������B
				base.guard_base();
				break;
			case STAR:	// ��Ԃ̃p���[�A�b�v
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
				printf("move_tank_sub():???? �A�C�e���̎�ނ��ُ�ł� (%d)\n",
					item.getType());
				break;
			}
			if (item.getType() != BOMB || item.getType() != TANK) {
////				sound_out(EFS_GET_ITEM);
			}
			item.setStatus(DISP_POINT);
			item.setTimer(DISP_POINT_TIME);
////�K�v�Ȃ��͂�			item.setType(0);
////			change_pattern(&item.sprite, PAT_POINT + 4, 2);
		}
	}

	virtual int beShot(bool isPlayerBullet)
	{
		int r = GH_NOTBREAK;

		if (barrier_time > 0)
			return GH_NOTBREAK;
		if (isPlayerBullet) {
			// �v���C���[��ԓ��m�̑������̏ꍇ�́A�����ꂽ������莞�ԓ����Ȃ��Ȃ�
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
