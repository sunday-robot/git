#include <stdio.h>
#include <stdlib.h>
#include "mylib.h"
#if !defined(PROF)
	#include "bgmopn.h"
#endif

#include "bcty.h"
#include "game.h"
#include "pat.h"
#include "sprite_t.h"
#include "sprite.h"
#include "tank.h"
#include "t_type_t.h"
#include "item_num.h"

#define BASE_X (STAGE_SIZE / 2 - 1)
#define BASE_Y (STAGE_SIZE - 3)
#define GUN_SIZE 16				// �e�ƒe�Ƃ̏Փ˔���̍ۂɎg����e�̑傫��

extern TankType tank_type[];

typedef struct {
	int x, y;
} Point;

typedef struct {
	int x, y, dir;	// �ʒu�ƌ���
	Status status;	// DEAD, LIVE, BURST �̂����ǂꂩ
	int hit;		// �ق��̒e�ɓ��Ă�ꂽ
	int burst_time;
	Sprite sprite;
} Gun;

typedef struct {
	Status status;	// ���݂̏��(����ł�Ƃ������Ă�Ƃ��������Ƃ�)
	int flg;		// �v���C���[���R���s���[�^��
	int number;		// �z��̓Y�����ɓ���
	int x, y, dir;	// �ʒu�ƌ���
	void (*pilot)(int);	// ��Ԃ𑀏c����֐�
	int type;		// ��Ԃ̎��
	int speed;		// ��Ԃ̃X�s�[�h
	int hit_point;	// �q�b�g�|�C���g�A���ʂ� 1
	int item;		// �G��Ԃ݈̂Ӗ�������A�A�C�e���������Ă�����P
	int move_flg;	// (*pilot)() ����Amove_tank() ���Ă΂ꂽ���ǂ����̃t���O
	int disp_point_flg;	// �����I���㓾�_��\�����邩�ǂ����̃t���O
	int misc_time;	// �o�ꎞ�ԁA�������ԁA��჎���
	int barrier_time;
	int srip_time;
	int shoot_interval_time;
	int num_of_gun;	// �e�̐�
	int gun_speed;	// �e�̃X�s�[�h
	int gun_power;	// �v���C���[�̐�Ԃ̂ݗL���A�R���N���[�g�̕ǂ��󂹂��肷��
	Gun gun[2];		// �e�͓����ɂQ������(?)�ł���
	int koma;
	Sprite sprite;
} Tank;

typedef struct {
	unsigned char type, pat;
} Vvram;

static Tank tank[MAX_TANK];

static Sprite barrier_sprite = {
	PAT_BARRIER, 1 /* level */
};

static Vvram vvram[STAGE_SIZE][STAGE_SIZE];

static int comp_tank_pararize_time;

static struct {
	int status;
	int x, y;
	ItemType type;
	int time, time2;
	Sprite sprite;
} item;

static struct {
	int status;
	int hit;
	int burst_time;
	int guard_time;
	int koma;
	Sprite sprite;
} base = {DEAD, 0, 0, 0, 0, {PAT_BURST, 1}};	// �X�v���C�g�̕����ȊO�̓_�~�[

void control_comp_tank_pararize_timer(void)
{
	if (comp_tank_pararize_time)
		comp_tank_pararize_time--;
}

void control_item(void)
{
	switch (item.status) {
	case LIVE:
		if (!(item.time2 & 4))			// �A�C�e����_�ł����邽��
			if (!put_sprite(&item.sprite, item.x, item.y, item.type))
				puts("control_item(): error on put_sprite()");
		break;
	case DISP_POINT:
		if (--item.time == 0)
			item.status = DEAD;
		if (!put_sprite(&item.sprite, item.x, item.y, item.type))
			puts("control_item(): error on put_sprite()");
		break;
	}
	item.time2++;
}

static int base_wall_x[] = {
	BASE_X - 1, BASE_X, BASE_X + 1, BASE_X + 2, BASE_X - 1, BASE_X + 2,
	BASE_X - 1, BASE_X + 2};
static int base_wall_y[] = {
	BASE_Y - 1, BASE_Y - 1, BASE_Y - 1, BASE_Y - 1, BASE_Y, BASE_Y,
	BASE_Y + 1, BASE_Y + 1};

// �i�ߕ��̎���̕ǂ̊G��ς���
static void set_base_wall_pattern(int flg)
{
	int pat = flg ? PAT_CONCRETE : PAT_RENGA + 15;
	int i;

//	printf("set_base_wall_pattern(): flg = %d\n", flg);
	for (i = 0; i < 8; i++)
		change_BG(base_wall_x[i], base_wall_y[i], 0, pat);
}

// �i�ߕ��̎���̕ǂ̑�����ς���
static void set_base_wall_type(int flg)
{
	int i;

	if (flg)
		for (i = 0; i < 8; i++)
			vvram[base_wall_y[i]][base_wall_x[i]].type = CONCRETE;
	else
		for (i = 0; i < 8; i++) {
			vvram[base_wall_y[i]][base_wall_x[i]].type = RENGA;
			vvram[base_wall_y[i]][base_wall_x[i]].pat = 15;
		}
}

// �i�ߕ��̎�����K�[�h����
static void guard_base(void)
{
	base.guard_time = BASE_GUARD_TIME;
	set_base_wall_type(1);
	set_base_wall_pattern(1);
}

int control_base(void)
{
	switch (base.status) {
	case LIVE:
		if (base.guard_time) {
			if (--base.guard_time) {
				if (base.guard_time < BASE_GUARD_TIME / 4
					&& (base.guard_time & 3) == 0) {
					// �c�莞�Ԃ����Ȃ��Ȃ�����A�K���ȊԊu�œ_�ł�����
					set_base_wall_pattern(base.guard_time & 4);
				}
			} else {
				// ����̕ǂ������K�ɕς���
				set_base_wall_pattern(0);
				set_base_wall_type(0);
			}
		}
		if (base.hit) {
#if !defined(PROF)
			sound_out(EFS_BURST);
#endif
			base.status = BURST;
			base.burst_time = BURST_TIME;
		}
		break;
	case BURST:
		switch (--base.burst_time) {
		case 0:
			base.status = DEAD3;
			// BG �̕ύX(�~���̔�����)
			change_BG(BASE_X, BASE_Y,  0, PAT_W_FLAG);
			change_BG(BASE_X + 1, BASE_Y,  0, PAT_W_FLAG + 1);
			change_BG(BASE_X, BASE_Y + 1,  0, PAT_W_FLAG + 2);
			change_BG(BASE_X + 1, BASE_Y + 1,  0, PAT_W_FLAG + 3);
			break;
		case BURST_TIME * 5 / 6:
		case BURST_TIME * 3 / 6:
			base.koma++;
		default:
			if (!put_sprite(&base.sprite, (BASE_X - 1) * 16, (BASE_Y - 1) * 16,
							base.koma))
				puts("control_base(): error on put_sprite()");
			break;
		}
		break;
	case DEAD3:
		base.status = DEAD;
		break;
	}
	return base.status;
}

static void set_tank_type(Tank *t)
{
	TankType *tt = &tank_type[t->type];

	t->speed = tt->speed;
	t->hit_point = tt->hit_point;
	t->num_of_gun = tt->num_of_gun;
	t->gun_speed = tt->gun_speed;
	t->gun_power = tt->gun_power;
}

// ��Ԃ�o�ꂳ����
void generate_tank(int tank_num, int flg, void (*pilot)(int), int x, int y,
				   int dir, int tank_type, int item_flg)
{
	Tank *t;

//	printf("generate_tank(): num = %d, type = %d\n", tank_num, tank_type);
	if (tank_num < 0 || tank_num >= MAX_TANK) {
		printf("generate_tank(): tank_num �̒l���ςł�(%d)\n", tank_num);
		return;
	}
	if ((x < 16 || x > (STAGE_SIZE - 1 - 2) * 16)
		|| (y < 16 || y > (STAGE_SIZE - 1 - 2) * 16)
		|| (dir < 0 || dir >= 4)) {
		printf("generate_tank(): ���W���ςł�(%d, %d, %d)\n", x, y, dir);
		return;
	}
	if (tank_type < 0 || tank_type >= MAX_TANK_TYPE) {
		printf("generate_tank(): tank_type �̒l���ςł�(%d)\n", tank_type);
		return;
	}
	t = &tank[tank_num];
	t->flg = flg;
	t->number = tank_num;
	t->pilot = pilot;
	t->x = x;
	t->y = y;
	t->dir = dir;
	t->status = BORN;
	t->type = tank_type;
	t->disp_point_flg = 0;
	t->misc_time = BORN_TIME;
	if (item_flg) {
		t->item = 1;
		item.status = DEAD;
	} else
		item_flg = 0;
	change_pattern(&t->sprite, PAT_BORN, 0);
	set_tank_type(t);
}

// ��ԓ��̃��Z�b�g �X�e�[�W���ς�邲�ƂɌĂяo��
void reset_tanks(void)
{
	Tank *t = tank;
	Gun *g;
	int i, j;

	for (i = 0; i < MAX_TANK; i++, t++) {
		t->status = DEAD;
		for (j = 0, g = t->gun; j < 2; j++, g++) {
			g->status = DEAD;
		}
	}

	item.status = DEAD;
	item.time = 0;

	base.status = LIVE;
	base.hit = 0;
	base.burst_time = 0;
	base.guard_time = 0;
	base.koma = 0;
	vvram[BASE_Y][BASE_X].type = vvram[BASE_Y][BASE_X + 1].type
							   = vvram[BASE_Y + 1][BASE_X].type
							   = vvram[BASE_Y + 1][BASE_X + 1].type
							   = BASE;
	set_BG(BASE_X, BASE_Y, 0, PAT_BASE);
	set_BG(BASE_X + 1, BASE_Y, 0, PAT_BASE + 1);
	set_BG(BASE_X, BASE_Y + 1, 0, PAT_BASE + 2);
	set_BG(BASE_X + 1, BASE_Y + 1, 0, PAT_BASE + 3);

	comp_tank_pararize_time = 0;
}

static void power_up_tank(Tank *t)
{
	t->type = tank_type[t->type].option.next_type;
	set_tank_type(t);
	change_pattern(&t->sprite, tank_type[t->type].pattern_num, 0);
}

// ��Ԃ����݌����Ă�������ɂP�h�b�g�i�߂�A�����Ȃ�������O��Ԃ�
static int move_tank_sub(Tank *t)
{
	Point check_point[2];
	int t_x = t->x, t_y = t->y, new_x, new_y;

	switch (t->dir) {
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
			switch (vvram[check_point[i].y][check_point[i].x].type) {
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
		Tank *t2 = tank;
		int i;

		for (i = 0; i < MAX_TANK; i++, t2++) {
			int dist_x, dist_y;
			if (t2->status != LIVE || t2 == t)
				// ���̐�Ԃ������Ă��Ȃ��A���͎������g�Ȃ牽�����Ȃ�
				continue;
			dist_x = abs(new_x - t2->x);
			dist_y = abs(new_y - t2->y);
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
	// �A�C�e���̃`�F�b�N
	if (t->flg == PLAYER && item.status == LIVE) {
		if (abs(new_x - item.x) < 32 && abs(new_y - item.y) < 32) {
			add_score(t->number, 4);
			switch (item.type) {
			case BOMB:	// ���e�A���_�͓���Ȃ��̂ł��̏�ŏ�������
				{
					int i;
					for (i = 2; i < MAX_TANK; i++)
						if (tank[i].status == LIVE)
							tank[i].hit_point = 0;
				}
				break;
			case SHOVEL:	// �i�ߕ�����莞�ԃR���N���[�g�̕ǂŃK�[�h�����
							// �Ƃ��ɕǂ̏C��������B
				guard_base();
				break;
			case STAR:	// ��Ԃ̃p���[�A�b�v
				power_up_tank(t);
				break;
			case TANK:	// 1up
				one_up(t->number);
				break;
			case HELMET:
				t->barrier_time = BARRIER_TIME;
				break;
			case STOP_WATCH:
				comp_tank_pararize_time = COMP_TANK_PARARIZE_TIME;
				break;
			default:
				printf("move_tank_sub():???? �A�C�e���̎�ނ��ُ�ł� (%d)\n",
					   item.type);
				break;
			}
#if !defined(PROF)
			if (item.type != BOMB || item.type != TANK) {
				sound_out(EFS_GET_ITEM);
			}
#endif
			item.status = DISP_POINT;
			item.time = DISP_POINT_TIME;
			item.type = 0;
			change_pattern(&item.sprite, PAT_POINT + 4, 2);
		}
	}
	t->x = new_x;
	t->y = new_y;
	return 1;
}

#define fix_position(p) (((p) + 8) & ~15)

void get_tank_env_info(int tn, int *dir, EnvInfo ei[4])
{
	static Point check_point[4][2] = {
		{{0, 32}, {16, 32}},
		{{32, 0}, {32, 16}},
		{{0, -1}, {16, -1}},
		{{-1, 0}, {-1, 16}},
	};
	Tank *t = &tank[tn];
	int x, y;
	int i;

	*dir = t->dir;
	x = t->x;
	y = t->y;
	if (*dir & 1) {
		// ��Ԃ�������
//		printf("x:%d->",x);
		x = fix_position(x);
//		printf("%d\n", x);
	} else {
		// ��Ԃ��c����
//		printf("y:%d->", y);
		y = fix_position(y);
//		printf("%d\n", y);
	}
	for (i = 0; i < 4; i++) {
		int j;
		int e = 0;

		for (j = 0; j < 2; j++) {
			switch(vvram[(y + check_point[i][j].y) / 16]
					[(x + check_point[i][j].x) / 16].type) {
			case RENGA:
				e |= 1;
				break;
			case CONCRETE:
			case RIVER:
			case FRAME:
				e |= 2;
				break;
			}
		}
		{
			static EnvInfo table[] = {eiNothing, eiRenga, eiUnthroughable,
				eiUnthroughable};
			ei[i] = table[e];
//			printf("sizeof(ei[]) = %d\n", sizeof(ei[0]));
		}
	}
#if 0
	printf("env(%3d, %3d) = ", t->x, t->y);
	for (i = 0; i < 4; i++) {
		printf("%d", ei[i]);
	}
	putchar('\n');
#endif
}

int get_tank_shoot_rate(int tn)
{
	return tank_type[tank[tn].type].shoot_rate;
}

int get_tank_change_dir_rate(int tn, EnvInfo ei)
{
	return tank_type[tank[tn].type].dir_change_rate[ei];
}

// tn �Ԗڂ̐�Ԃ𓮂���
int move_tank(int tn, int dir)
{
	Tank *t = &tank[tn];

//	puts("move_tank():");
	if (dir < -1 || dir > 3) {
		printf("move_tank():dir�̒l��-1����3�܂łł��B(tn = %d, dir = %d)\n",
			tn, dir);
		return 0;
	}
	t->move_flg = 1;
	if (dir != -1 && t->dir != dir) {
		if ((t->dir ^ dir) & 1) {
			// ���݂̌����ƂX�O�x�Ⴄ�Ȃ���W�𒲐߂���
			if (dir & 1) {
//				printf("y:%d->", t->y);
				t->y = fix_position(t->y);
//				printf("%d\n", t->y);
			} else {
//				printf("x:%d->", t->x);
				t->x = fix_position(t->x);
//				printf("%d\n", t->x);
			}
		}
		t->dir = dir;
//		printf("(%d,%d)\n", t->x, t->y);
		return 1;
	} else {
		int i;
		int moved = 0;	// ���������ǂ����̃t���O
		for (i = t->speed; i > 0; i--)
			if (!(moved |= move_tank_sub(t)))
				break;
//		printf("(%d,%d)\n", t->x, t->y);
		return moved;
	}
}

// ��Ԃ��X�̏�ɂ��邩�ǂ������`�F�b�N����
static int is_on_ice(Tank *t)
{
	int x = t->x, y = t->y;
	if (vvram[(y + 15) / 16][(x + 15) / 16].type == ICE
		&& vvram[(y + 15) / 16][(x + 16) / 16].type == ICE
		&& vvram[(y + 16) / 16][(x + 15) / 16].type == ICE
		&& vvram[(y + 16) / 16][(x + 16) / 16].type == ICE)
		return 1;
	else
		return 0;
}

enum {
    GH_NOTHIT = 0, GH_GUN = 1, GH_WBREAK = 2, GH_NOTBREAK = 4,
    GH_TBREAK = 8
};

// ��ԂɃ_���[�W��^���� �G��ԓ��m�̑��ł��Ȃ炱��͌Ă΂�Ȃ�
// dest_t: �_���[�W���󂯂���
static int damage_tank(Tank *dest_t, Tank *t)
{
	int r = GH_NOTBREAK;

	if (dest_t->flg == PLAYER && dest_t->flg == t->flg
		&& dest_t->barrier_time == 0) {
		dest_t->misc_time = PARARIZE_TIME;
	} else {
		if (dest_t->item) {
			// �A�C�e���������Ă����炻����o��
//			puts("damage_tank():item");
			dest_t->item = 0;
			item.status = LIVE;
			item.x = random((STAGE_SIZE - 4) * 16) + 16;
			item.y = random((STAGE_SIZE - 4) * 16) + 16;
			item.type = get_item_number();
//			printf("type = %d\n", item.type);
			change_pattern(&item.sprite, PAT_ITEM, 2);
		}
		if (dest_t->barrier_time == 0 && --dest_t->hit_point == 0) {
			r = GH_TBREAK;
			if (t->flg == PLAYER) {
				add_score(t->number, tank_type[dest_t->type].option.point);
				dest_t->disp_point_flg = 1;
			}
		} else {
			change_pattern(&dest_t->sprite, tank_type[dest_t->type].pattern_num
									   + (dest_t->hit_point - 1) * 4, 0);
		}
	}
	return r;
}

// ��� t �� i �Ԗڂ̒e�� 1 �h�b�g������
static int move_gun_sub(Tank *t, Gun *g)
{
	int flg = GH_NOTHIT;	// �e�������ɓ����������ǂ����̃t���O�i�����K���Ԃɓ�����
					// �Ă��`�F�b�N�͂��ׂčs��Ȃ���΂����Ȃ��j
	Point check_point[2];
	int new_x, new_y;

	{
		int g_x = g->x, g_y = g->y;

		switch (g->dir) {
		case 0:	// ��
			new_x = g_x;	new_y = g_y + 2;
			check_point[0].x = g_x;
			check_point[1].x = g_x + 15;
			check_point[0].y = check_point[1].y = g_y + 17;
			break;
		case 1:	// �E
			new_x = g_x + 2;	new_y = g_y;
			check_point[0].x = check_point[1].x = g_x + 17;
			check_point[0].y = g_y;
			check_point[1].y = g_y + 15;
			break;
		case 2:	// ��
			new_x = g_x;	new_y = g_y - 2;
			check_point[0].x = g_x;
			check_point[1].x = g_x + 15;
			check_point[0].y = check_point[1].y = new_y;
			break;
		case 3:	// ��
			new_x = g_x - 2;	new_y = g_y;
			check_point[0].x = check_point[1].x = new_x;
			check_point[0].y = g_y;
			check_point[1].y = g_y + 15;
			break;
		}
	}

	{ // �n�`���`�F�b�N
		int i;
		for (i = 0; i < 2; i++) {
			Vvram *v;
			int x = check_point[i].x, y = check_point[i].y;
			switch ((v = &vvram[y / 16][x / 16])->type) {
			case RENGA:
//				puts("renga");
//				printf("pat = %02x\n", v->pat);
				{
					// �u���b�N���̂ǂ̗̈悩�H ���ォ��1,2,4,8�ƂȂ��Ă���
					int pat = ((y & 8) ? 12 : 3) & ((x & 8) ? 10 : 5);
					if (v->pat & pat) {
						flg |= GH_WBREAK;
						if (t->gun_power) {
							// �p���[�A�b�v���Ă�����ꔭ�ŉ󂵂Ă��܂�
							v->type = ROAD;
							change_BG(x / 16, y / 16, 0, PAT_ROAD);
						} else {
							int erace_pat;
							if (g->dir & 1)
								// ��or�E
								erace_pat = (pat & 5) ? 10 : 5;
							else
								// ��or��
								erace_pat = (pat & 3) ? 12 : 3;
							if ((v->pat &= erace_pat) == 0) {
								v->type = ROAD;
								change_BG(x / 16, y / 16, 0, PAT_ROAD);
							} else
								change_BG(x / 16, y / 16, 0, PAT_RENGA
															 + v->pat);
						}
					}
				}
				break;
			case CONCRETE:
				if (t->gun_power) {
					// �p���[�A�b�v���Ă���Ȃ�R���N���[�g���ꔭ�ŉ󂹂�
					flg |= GH_WBREAK;
					v->type = ROAD;
					change_BG(x / 16, y / 16, 0, PAT_ROAD);
				} else
					flg |= GH_NOTBREAK;
				break;
			case FRAME:
//				puts("frame");
				flg |= GH_NOTBREAK;
				break;
			case BASE:
//				puts("base");
				flg |= GH_TBREAK;
				base.hit = 1;
				break;
			}
		}
	}
	{ // �ق��̐�ԂƂ��̒e�Ƃ̐ڐG�`�F�b�N
		Tank *t2 = tank;
		int i;

		for (i = 0; i < MAX_TANK; i++, t2++) {
			int dist_x, dist_y;

			if (t2->status == DEAD || (t2->flg == t->flg && t->flg == COMPUTER)
				|| t2 == t)
				continue;
			{ // �e�Ƃ̏Փ˃`�F�b�N
				Gun *g2 = t2->gun;
				int j;
				for (j = 0; j < t2->num_of_gun; j++, g2++) {
					if (g2->status != LIVE)
						continue;
					dist_x = abs(new_x - g2->x);
					dist_y = abs(new_y - g2->y);
					if (dist_x < GUN_SIZE && dist_y < GUN_SIZE) {
						// ���̒e�Ɛڂ��Ă���
						flg |= GH_GUN;
						g2->hit |= GH_GUN;
					}
				}
			}
			if (t2->status == LIVE) {
				// ��ԂƂ̏Փ˃`�F�b�N
				dist_x = new_x - t2->x;
				dist_y = new_y - t2->y;
				if (dist_x < 32 && dist_x > -16 && dist_y < 32
					&& dist_y > -16) {
					flg |= damage_tank(t2, t);
				}
			}
		}
	}
	g->x = new_x;
	g->y = new_y;
	return g->hit |= flg;
}

static void move_gun(Tank *t, Gun *g)
{
	int i;

	for (i = t->gun_speed; i > 0; i--) {
		if (move_gun_sub(t, g)) {
			break;
		}
	}
}

static void control_gun(Tank *t)
{
	Gun *g = t->gun;
	int i;
	for (i = 0; i < t->num_of_gun; i++, g++) {
		switch (g->status) {
		case LIVE:
			move_gun(t, g);
			if (g->hit != GH_NOTHIT) {
			    if (g->hit != GH_GUN) {
					g->status = BURST;
					g->burst_time = BURST_TIME2;
					g->x -= 8;
					g->y -= 8;
					g->dir = 0;
					change_pattern(&g->sprite, PAT_BURST2, 1);
					if ((g->hit & GH_WBREAK) && t->flg == PLAYER) {
#if !defined(PROF)
						sound_out(EFS_BREAK_WALL);
#endif
					} else if ((g->hit & GH_NOTBREAK) && t->flg == PLAYER) {
#if !defined(PROF)
					    sound_out(EFS_REFLECT);
#endif
					}
			    } else
			        g->status = DEAD;
			}
			break;
		case BURST:
			switch (--g->burst_time) {
			case BURST_TIME2 * 2 / 3:
				g->dir = 1;
				break;
			case 0:
				g->status = DEAD;
				break;
			}
			break;
		}
		if (g->status != DEAD)
			if (!put_sprite(&g->sprite, g->x, g->y, g->dir))
				puts("control_gun(): error on put_sprite()");
	}
}

int control_tank(int tn)
{
	Tank *t = &tank[tn];

	switch (t->status) {
	case BORN:
		if (--t->misc_time == 0) {
			t->status = LIVE;
			t->barrier_time = (t->flg == PLAYER) ? BARRIER_TIME2 : 0;
			change_pattern(&t->sprite, tank_type[t->type].pattern_num
						   + (t->hit_point - 1) * 4, 0);
			t->koma = t->dir;
		} else
			if ((t->koma = t->misc_time & 3) == 3)
				t->koma = 1;
		break;
	case LIVE:
		if (t->hit_point <= 0) {
			// ����ł��܂���
			t->status = BURST;
			t->misc_time = BURST_TIME;
			t->x -= 16;
			t->y -= 16;
			t->koma = 0;
			change_pattern(&t->sprite, PAT_BURST, 1);
#if !defined(PROF)
			sound_out(EFS_BURST);
#endif
		} else {
			t->move_flg = 0;
			if (t->flg == PLAYER) {
				if (base.status == LIVE) {
					// ������n������Ă����瓮���Ȃ�
					if (t->misc_time)	// ���̏ꍇ��t->misc_time�͖�჏�Ԃ�
						t->misc_time--;	// ���Ԃ�\���Ă���
					else
						t->pilot(tn);
				}
			} else if (comp_tank_pararize_time == 0)
				t->pilot(tn);
			if (is_on_ice(t)) {
				if (t->move_flg)
					t->srip_time = SRIP_TIME;
				else
					if (t->srip_time) {
						t->srip_time--;
						move_tank(tn, t->dir);
					}
			}
			// �o���A
			if (t->barrier_time) {
				t->barrier_time--;
				if (!put_sprite(&barrier_sprite, t->x, t->y, t->barrier_time
															 & 1))
					puts("control_tank(): error on put_sprite() barrier");
			}
			if (t->item && (item.time2 & 3))
				t->koma = t->dir + 4;
			else
				t->koma = t->dir;
		}
		break;
	case BURST:
		switch (--t->misc_time) {
		case 0:
			if (t->disp_point_flg) {
				t->status = DISP_POINT;
				t->x += 16;
				t->y += 16;
				t->misc_time = DISP_POINT_TIME;
				t->koma = tank_type[t->type].option.point;
				change_pattern(&t->sprite, PAT_POINT, 2);
			} else {
				t->status = DEAD3;
			}
			break;
		case BURST_TIME * 5 / 6:
		case BURST_TIME * 3 / 6:
			t->koma++;
			break;
		}
		break;
	case DISP_POINT:
		if (--t->misc_time == 0) {
			t->status = DEAD3;
		}
		break;
	case DEAD3:
		t->status = DEAD2;
		break;
	case DEAD2:
		if (t->gun[0].status == DEAD && t->gun[1].status ==DEAD)
			t->status = DEAD;
		break;
	}
	if (t->status != DEAD) {
		if (t->shoot_interval_time)
			t->shoot_interval_time--;
		control_gun(t);
	}
	if (t->status > DEAD3) {
		if (t->status != LIVE || ((t->misc_time & 4) == 0))
			if (!put_sprite(&t->sprite, t->x, t->y, t->koma))
				puts("control_tank(): error on put_sprite()");
	}
	return t->status;
}

// �e�����Ă邩�ǂ������`�F�b�N����
int can_shoot_gun(int tn)
{
	return tank[tn].shoot_interval_time ? 0 : 1;
}

// �e������
int shoot_gun(int tn)
{
	Tank *t = &tank[tn];
	int i;

	// �O�̂��߃`�F�b�N
	if (t->shoot_interval_time)
		return 0;
	for (i = 0; i < t->num_of_gun; i++) {
		Gun *g = &t->gun[i];
		if (g->status == DEAD) {
			static g_x[4] = {8, 16, 8, 0}, g_y[4] = {16, 8, 0, 8};
			g->dir = t->dir;
			g->x = t->x + g_x[g->dir];
			g->y = t->y + g_y[g->dir];
			g->status = LIVE;
			g->hit = 0;
			change_pattern(&g->sprite, PAT_GUN, 1);
			t->shoot_interval_time = SHOOT_INTERVAL_TIME;
#if !defined(PROF)
			if (t->flg == PLAYER) {
				sound_out(EFS_SHOOT);
			}
#endif
			return 1;
		}
	}
	return 0;
}

void set_stage_char(int x, int y, int type)
{
	static int pat_table[] = {PAT_ROAD, PAT_RENGA + 15, PAT_ROAD, PAT_ICE,
							  PAT_CONCRETE, PAT_RIVER, PAT_FRAME_H,
							  PAT_FRAME_V,PAT_FRAME_UL, PAT_FRAME_UR,
							  PAT_FRAME_LL, PAT_FRAME_LR};

	set_BG(x, y, 0, pat_table[type]);
	if (type >= FRAME)
		type = FRAME;
	else if (type == WOOD) {
		type = ROAD;
		set_BG(x, y, 1, PAT_WOOD);
	} else if (type == RENGA)
		vvram[y][x].pat = 15;
	vvram[y][x].type = type;
}

void get_player_tank_type(int type[])
{
	type[0] = tank[0].type;
	type[1] = tank[1].type;
}