#include <stdlib.h>

#include "mylib.h"
#include "tank.h"
#include "key.h"
#include "ComputerTank.h"

static void player1_pilot(Tank *t) {
	int dir = get_dir(0);
	if (dir != -1)
		t->move_tank(dir);
	if (check_button(0, 0))
		if (t->shoot_gun())
			reset_button(0, 0);
}

static void player2_pilot(Tank *t) {
	int dir = get_dir(1);
	if (dir != -1)
		t->move_tank(dir);
	if (check_button(1, 0))
		if (t->shoot_gun())
			reset_button(1, 0);
}

static int get_new_dir(int old_dir, EnvInfo env_info[]) {
	// 1:左、2:後、3:右
	static int dir_diff[] = {1, 1, 2, 2, 2, 3, 3};
	int new_dir;
	int i;
	new_dir = (old_dir + dir_diff[random(sizeof(dir_diff)
								  / sizeof(dir_diff[0]))]) & 3;
	for (i = 0; i < 4; i++) {	// 川、コンクリ以外の方向を探す
		if ((old_dir != new_dir)
			&& (env_info[new_dir] != eiUnthroughable))
			break;
		new_dir = (new_dir + 1) & 3;
	}
	return new_dir;
}

#include "stdlib.h"

void computer_pilot(Tank *t) {
	const ComputerTankType *ct = (const ComputerTankType *) t->getTankType();
	int dir = t->getDirection();

	// 周りの通行上の障害物の情報を取得
	EnvInfo env_info[4];
	((ComputerTank *) t)->get_tank_env_info(env_info);
	if (random(ct->dir_change_rate[eiNothing]) == 0) {
		// 前方に通行を妨げる壁や川がない時でもたまに方向を変える
		t->move_tank(get_new_dir(dir, env_info));
	} else if (!t->move_tank(-1)) {		// とりあえず前進
		EnvInfo frontEnvInfo = env_info[dir];
		// 前方に何等かの障害物があって動けない
		if (frontEnvInfo == eiNothing) {
			// 前方に壁、川がないのに動けないなら他の戦車がいる
			frontEnvInfo = eiRenga;	// 前にレンガの壁があるのと同様に扱う
		}
		// 前方の障害物に従って、方向転換するかどうか決める
		if (random(ct->dir_change_rate[frontEnvInfo]) == 0) {
			t->move_tank(get_new_dir(dir, env_info));
		}
	}
	if (t->can_shoot_gun() && (random(ct->shoot_rate) == 0))
		t->shoot_gun();
}

#if 0
void (*player_pilot[])(int) = {
	player1_pilot, player2_pilot
};
#endif
