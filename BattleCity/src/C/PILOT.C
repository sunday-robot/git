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
	// 1:���A2:��A3:�E
	static int dir_diff[] = {1, 1, 2, 2, 2, 3, 3};
	int new_dir;
	int i;
	new_dir = (old_dir + dir_diff[random(sizeof(dir_diff)
								  / sizeof(dir_diff[0]))]) & 3;
	for (i = 0; i < 4; i++) {	// ��A�R���N���ȊO�̕�����T��
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

	// �����݌����Ă�������ƁA����̒ʍs��̏�Q���̏����擾
	get_tank_env_info(n, &dir, env_info);
	if (random(get_tank_change_dir_rate(n, eiNothing)) == 0) {
		// �O���ɒʍs��W����ǂ�삪�Ȃ����ł����܂ɕ�����ς���
		move_tank(n, get_new_dir(dir, env_info));
	} else if (!move_tank(n, -1)) {		// �Ƃ肠�����O�i
		// �O���ɉ������̏�Q���������ē����Ȃ�
		if (env_info[dir] == eiNothing) {
			// �O���ɕǁA�삪�Ȃ��̂ɓ����Ȃ��Ȃ瑼�̐�Ԃ�����
			env_info[dir] = eiRenga;	// �O�Ƀ����K�̕ǂ�����̂Ɠ��l�Ɉ���
		}
		// �O���̏�Q���ɏ]���āA�����]�����邩�ǂ������߂�
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