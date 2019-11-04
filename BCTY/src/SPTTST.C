#include <stdio.h>
#include <stdlib.h>
#include "gr.h"
#include "super.h"

void super_put_bc(int, int, int);

void count_time(int xx, int patnum)
{
	int x, y;

	timereset();
	for (y = 0; y < 400 - 64; y += 8)
		for (x = 0; x < 500; x += 8)
			super_put(x + xx, y, patnum);
	printf("%d\n", spenttime());
	timereset();
	for (y = 0; y < 400 - 64; y += 8)
		for (x = 0; x < 500; x += 8)
			super_put_bc(x + xx, y, patnum);
	printf("%d\n", spenttime());
}

void main()
{
	grStart();
	if (super_entry_bfnt("bcty32_2.bft", 0, !SET) < 0)
		exit(1);
	if (super_entry_bfnt("bcty64.bft", 0, !SET) < 0)
		exit(1);
	if (super_entry_bfnt("bcty16.bft", 0, SET) < 0)
		exit(1);
//	timestart();

	count_time(0, 0);
	count_time(8, 0);
	count_time(7, 0);
	count_time(15, 0);

	count_time(0, 35);
	count_time(8, 35);
	count_time(7, 35);
	count_time(15, 35);

	count_time(0, 32);
	count_time(8, 32);
	count_time(7, 32);
	count_time(15, 32);

	timestop();
}
