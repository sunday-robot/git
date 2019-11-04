#pragma once

#include "ItemType.h"
#include "mylib.h"
#include "Status.h"
#include "BCTY.H"

class Item;
extern Item item;

// アイテム
// 同時にはひとつしか存在し得ない
class Item {
	static int item_rate[/*NUM_OF_ITEM_TYPE*/];
	static int item_rate_sum;

	int status;
	int x, y;
	ItemType type;
	int time;	// 得点表示時間管理用のタイマー
	int time2;	// 点滅アニメーション用のタイマー
//	Sprite sprite;

public:
	void control_item(void) {
		switch (status) {
		case ALIVE:
#if 0
			if (!(time2 & 4))			// アイテムを点滅させるため
				if (!put_sprite(&sprite, x, y, type))
					puts("control_item(): error on put_sprite()");
#endif
			break;
		case DISP_POINT:
			if (--time == 0)
				status = DEAD;
#if 0
			if (!put_sprite(&sprite, x, y, type))
				puts("control_item(): error on put_sprite()");
#endif
			break;
		}
		time2++;
	}

	void setStatus(int s) {
		status = s;
	}

	void setTimer(int t) {
		time = t;
	}

	void setType(ItemType t) {
		type = t;
	}

	int getStatus() {
		return status;
	}

	ItemType getType() {
		return type;
	}

	int getX() {
		return x;
	}

	int getY() {
		return y;
	}

	void spawn() {
		status = ALIVE;
		x = random((STAGE_SIZE - 4) * 16) + 16;
		y = random((STAGE_SIZE - 4) * 16) + 16;
		type = get_item_number();
//		change_pattern(&sprite, PAT_ITEM, 2);
	}

	static ItemType get_item_number() {
		int i;
		int n;

		if (item_rate_sum == 0) {
			for (i = 0; i < NUM_OF_ITEM_TYPE; i++)
				item_rate_sum += item_rate[i];
		}
		n = random(item_rate_sum);
		i = 0;
		while ((n -= item_rate[i]) >= 0)
			i++;
		return (ItemType) i;
	}
};
