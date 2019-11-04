#pragma once

struct TankType {
	int speed;
	int hit_point;
	int num_of_gun;
	int gun_speed;
	bool isHyperGun;	// true�Ȃ�R���N���[�g���ꔭ�ŉ󂷂��Ƃ��ł���
	int pattern_num;

	TankType(int speed, int hitPoint, int maxGunCount, int gunSpeed, bool isHyperGun, int patternNumber) {
		this->speed = speed;
		this->hit_point = hitPoint;
		this->num_of_gun = maxGunCount;
		this->gun_speed = gunSpeed;
		this->isHyperGun = isHyperGun;
		this->pattern_num = patternNumber;
	}
};

struct PlayerTankType : TankType {
	const PlayerTankType *next;		// ���ɂǂ̃^�C�v�ɂȂ邩�i�v���C���[�j

	PlayerTankType(int speed, int hitPoint, int maxGunCount, int gunSpeed, bool isHyperGun, int patternNumber, const PlayerTankType *next)
		: TankType(speed, hitPoint, maxGunCount, gunSpeed, isHyperGun, patternNumber) {
			this->next = next;
	}
};

struct ComputerTankType : TankType {
	// ���_�ƂȂ��Ă��邪�A���ꂪ���ړ��_�ƂȂ�̂ł͂Ȃ��B
	// �X�e�[�W�I����ɁA���_�̏W�v������̂ŁA�Q�[�����͂ǂ̃^�C�v�̐�Ԃ�
	// �������������A�Ƃ������Ƃ�\�ɓo�^����B���̗v�f�͂��̕\(int�^��
	// �T�C�Y4�̔z��)�̉��ԖڂȂ̂���\���Ă���B
	int point;						// ���_
	int shoot_rate;					// �e�����m��(1/rate)
	int dir_change_rate[3];			// ������ύX����m��(1/rate)

	ComputerTankType(int speed, int hitPoint, int maxGunCount, int gunSpeed, bool isHyperGun, int patternNumber, int point, int shootRate, int dirChangeRate[3])
		: TankType(speed, hitPoint, maxGunCount, gunSpeed, isHyperGun, patternNumber) {
			this->point = point;
			this->shoot_rate = shootRate;
			this->dir_change_rate[0] = dirChangeRate[0];
			this->dir_change_rate[1] = dirChangeRate[1];
			this->dir_change_rate[2] = dirChangeRate[2];
	}
};

extern PlayerTankType player1Tank1;
extern PlayerTankType player2Tank1;
extern ComputerTankType computerTankTypeA;
extern ComputerTankType computerTankTypeB;
extern ComputerTankType computerTankTypeC;
extern ComputerTankType computerTankTypeD;
