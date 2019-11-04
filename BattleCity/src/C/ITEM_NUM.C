#include <stdlib.h>
#include "bcty.h"
#include <mylib.h>

static int item_rate[NUM_OF_ITEM_TYPE] = {3, 3, 2, 1, 4, 2};

static int item_rate_sum = 0;

int get_item_number()
{
	int i, n;

	if (item_rate_sum == 0) {
		for (i = 0; i < NUM_OF_ITEM_TYPE; i++)
			item_rate_sum += item_rate[i];
	}
	n = random(item_rate_sum);
	i = 0;
	while ((n -= item_rate[i]) >= 0)
		i++;
	return i;
}
