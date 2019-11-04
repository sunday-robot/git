#pragma once

struct TankType {
	int speed;
	int hit_point;
	int num_of_gun;
	int gun_speed;
	bool isHyperGun;	// trueならコンクリートも一発で壊すことができる
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
	const PlayerTankType *next;		// 次にどのタイプになるか（プレイヤー）

	PlayerTankType(int speed, int hitPoint, int maxGunCount, int gunSpeed, bool isHyperGun, int patternNumber, const PlayerTankType *next)
		: TankType(speed, hitPoint, maxGunCount, gunSpeed, isHyperGun, patternNumber) {
			this->next = next;
	}
};

struct ComputerTankType : TankType {
	// 得点となっているが、これが直接得点となるのではない。
	// ステージ終了後に、得点の集計をするので、ゲーム中はどのタイプの戦車を
	// 何台やっつけたか、ということを表に登録する。この要素はこの表(int型で
	// サイズ4の配列)の何番目なのかを表している。
	int point;						// 得点
	int shoot_rate;					// 弾を撃つ確率(1/rate)
	int dir_change_rate[3];			// 方向を変更する確率(1/rate)

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
