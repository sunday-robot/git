#pragma once

int get_stage_number(void);
void read_stage_data(int comp_tanks[20 ]);

#if 0
class Stage {
};

/* stage.c */
void reset_stage_number(void);
void inc_stage_number(void);
void open_stage_file(char *fname);
void close_stage_file(void);
void select_stage(void);

#endif
