#include <stdlib.h>

#include "mylib.h"
#include "tank.h"
#include "key.h"

static void player1_pilot(int n)
{
	int dir;

	dir = get_dir(0);
	if (dir != -1)
		move_tank(n, dir);
	if (check_button(0, 0))
		if (shoot_gun(n))
			reset_button(0, 0);
}

static void player2_pilot(int n)
{
	int dir;

	dir = get_dir(1);
	if (dir != -1)
		move_tank(n, dir);
	if (check_button(1, 0))
		if (shoot_gun(n))
			reset_button(1, 0);
}

static int get_new_dir(int old_dir, EnvInfo env_info[])
{
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

void computer_pilot(int n)
{
	int dir;
	EnvInfo env_info[4];

	// 今現在向いている方向と、周りの通行上の障害物の情報を取得
	get_tank_env_info(n, &dir, env_info);
	if (random(get_tank_change_dir_rate(n, eiNothing)) == 0) {
		// 前方に通行を妨げる壁や川がない時でもたまに方向を変える
		move_tank(n, get_new_dir(dir, env_info));
	} else if (!move_tank(n, -1)) {		// とりあえず前進
		// 前方に何等かの障害物があって動けない
		if (env_info[dir] == eiNothing) {
			// 前方に壁、川がないのに動けないなら他の戦車がいる
			env_info[dir] = eiRenga;	// 前にレンガの壁があるのと同様に扱う
		}
		// 前方の障害物に従って、方向転換するかどうか決める
		if (random(get_tank_change_dir_rate(n, env_info[dir])) == 0) {
			move_tank(n, get_new_dir(dir, env_info));
		}
	}
	if (can_shoot_gun(n) && (random(get_tank_shoot_rate(n)) == 0))
		shoot_gun(n);
}

void (*player_pilot[])(int) = {
	player1_pilot, player2_pilot
};
