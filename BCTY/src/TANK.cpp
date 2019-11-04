#include "Tank.h"
#include "Gun.h"

// 弾を撃つ
int Tank::shoot_gun() {
	// 念のためチェック
	if (shoot_interval_time)
		return 0;

	static int g_x[4] = {8, 16, 8, 0};
	static int g_y[4] = {16, 8, 0, 8};

	Gun::spawn(x + g_x[dir], g_y[dir], dir, this);
	shoot_interval_time = SHOOT_INTERVAL_TIME;
#if !defined(PROF)
//	if (flg == PLAYER) {
//		sound_out(EFS_SHOOT);
//	}
#endif
	return 1;
}
