#pragma once

#define STAGE_SIZE 28					// �P�U�h�b�g�P�ʂŉ��̘g���܂߂�����

#define NUM_OF_PLAYER_TANK_TYPE 4		// �v���C���[��Ԃ̎��

#define WAIT_COUNT_IN_RESULT 40
#define WAIT_COUNT_IN_GAME 2

#define CLOCK (60 / WAIT_COUNT_IN_GAME)

#define BORN_TIME (CLOCK * 1)			// ��ԓo�ꎞ�A�s�J�s�J���Ă��鎞��
#define BURST_TIME (CLOCK / 4)			// ��ԁA�i�ߕ����������Ă��鎞��
#define BURST_TIME2 (CLOCK / 8)			// �e���������Ă��鎞��
#define BARRIER_TIME (CLOCK * 10)
#define BARRIER_TIME2 (CLOCK * 3)		// �v���C���[��Ԃ��o�ꂵ���Ƃ���
#define SRIP_TIME (CLOCK / 2)			// �X�̏�ɏ���āA�X���b�v���Ă��鎞��
#define PARARIZE_TIME (CLOCK * 9 / 2)	// ����������ē������ɂ��鎞��
#define DISP_POINT_TIME (CLOCK * 1)		// �G��Ԃ����񂾂��Ɠ��_��\�����Ă���
										// ����
#define GENERATE_INTERVAL (CLOCK * 3)	// �G��Ԃ��o�ꂷ��Ԋu
#define MAX_END_COUNT (CLOCK * 4)		// �Q�[���I�[�o�[�ɂȂ��Ă���A���ۂɏI
										// ������܂ł̎���
#define SHOOT_INTERVAL_TIME (CLOCK / 4)	// �e��ł�����A���̂𔭎˂���܂ł̑�
										// ������
#define BASE_GUARD_TIME (CLOCK * 43 / 2)	// �i�ߕ����R���N���[�g�̕ǂŎ���
										// �Ă��鎞��
#define COMP_TANK_PARARIZE_TIME (CLOCK * 10)	// �X�g�b�v�E�H�b�`�̃A�C�e����
										// ������Ƃ��G��Ԃ��������ɂ��鎞��
#define GAME_OVER_TIME MAX_END_COUNT	// "GAME OVER" ��\�����Ă��鎞��

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
