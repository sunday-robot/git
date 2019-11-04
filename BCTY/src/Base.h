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
		////		static Base base = {DEAD, 0, 0, 0, 0, {PAT_BURST, 1}};	// �X�v���C�g�̕����ȊO�̓_�~�[
	}

	// �i�ߕ��̎���̕ǂ̑�����ς���
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

	// �i�ߕ��̎���̕ǂ̊G��ς���
	void set_base_wall_pattern(int flg) {
		int pat = flg ? PAT_CONCRETE : PAT_RENGA + 15;
		int i;

		for (i = 0; i < 8; i++) {
			const Point &p = guardBlockPositions[i];
//			change_BG(p.x, p.y, 0, pat);
		}
	}

	// �i�ߕ��̎�����K�[�h����
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
							// �c�莞�Ԃ����Ȃ��Ȃ�����A�K���ȊԊu�œ_�ł�����
							set_base_wall_pattern(guard_time & 4);
					}
				} else {
					// ����̕ǂ������K�ɕς���
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
				// BG �̕ύX(�~���̔�����)
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
