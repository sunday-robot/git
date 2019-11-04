#include "GameModel.h"

Point player_tank_position[2] = {
	{(STAGE_SIZE / 2 - 4) * 16, (STAGE_SIZE - 3) * 16},
	{(STAGE_SIZE / 2 + 2) * 16, (STAGE_SIZE - 3) * 16}
};

Point init_comp_tank_position[3] = {
	{16, 16},
	{(STAGE_SIZE / 2 - 1) * 16, 16},
	{(STAGE_SIZE - 3) * 16, 16}
};
