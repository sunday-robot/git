#include <stdio.h>
#include <stdlib.h>
#include "mylib.h"
#if !defined(PROF)
#include "bgmopn.h"
#endif

#include "bcty.h"
#include "pat.h"
#include "sprite_t.h"
#include "sprite.h"
#include "oldtank.h"
#include "TankType.h"
#include "item_num.h"
#include "Item.h"

#define GUN_SIZE 16				// 弾と弾との衝突判定の際に使われる弾の大きさ

extern TankType tank_type[];

#include "Point.h"

#include "Vvram.h"

class Tank;

#include "Gun.h"
#include "Tank.h"
#include "ComputerTank.h"


#include "Base.h"

Base base;

const Point Base::guardBlockPositions[] = {
	{BASE_X - 1, BASE_Y - 1},
	{BASE_X + 0, BASE_Y - 1},
	{BASE_X + 1, BASE_Y - 1},
	{BASE_X + 2, BASE_Y - 1},
	{BASE_X - 1, BASE_Y - 0},
	{BASE_X + 0, BASE_Y - 0},
	{BASE_X + 1, BASE_Y - 0},
	{BASE_X + 2, BASE_Y - 0},
	{BASE_X - 1, BASE_Y + 1},
	{BASE_X + 0, BASE_Y + 1},
	{BASE_X + 1, BASE_Y + 1},
	{BASE_X + 2, BASE_Y + 1}
};

class Stage {
	Tank *tanks;
	Base base;
	Item item;
	Vvram vvram;
};

static Stage stage;


////static Tank tank[MAX_TANK];

static Sprite barrier_sprite = {
	PAT_BARRIER, 1 /* level */
};

Vvram vvram;

// 戦車等のリセット ステージが変わるごとに呼び出す
void reset_tanks(void) {
#if 0
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
#endif
}

void set_stage_char(int x, int y, int type) {
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
		vvram.cells[y][x].pat = 15;
	vvram.cells[y][x].type = type;
}

#if 0
void get_player_tank_type(int type[])
{
	type[0] = tank[0].type;
	type[1] = tank[1].type;
}
#endif
