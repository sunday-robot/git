/* tank.c */
#include "EnvInfo.h"

void control_comp_tank_pararize_timer(void);
void control_item(void);
int control_base(void);
void generate_tank(int tank_num, int flg, void (*pilot )(int ), int x, int y, int dir, int tank_type, int item_flg);
void reset_tanks(void);
int move_tank(int tn, int dir);
int control_tank(int tn);
int can_shoot_gun(int tn);
int shoot_gun(int tn);
void set_stage_char(int x, int y, int type);
void get_player_tank_type(int type[]);
void get_tank_env_info(int tn, int *dir, EnvInfo ei[4]);
int get_tank_shoot_rate(int tn);
int get_tank_change_dir_rate(int tn, EnvInfo ei);
