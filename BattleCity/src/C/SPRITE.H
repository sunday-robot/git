/* sprite.c */
int put_sprite(Sprite *sp, int x, int y, int koma);
void set_BG(int x, int y, int level, int pat_num);
void set_BG_box(int x, int y, int width, int height, int level, int pat_num);
void change_BG(int x, int y, int level, int pat_num);
void update_screen(void);
void change_page(void);
void change_pattern(Sprite *spr, int pat_num, int level);
void reset_sprite(void);
int read_bfnt(char *fname, ...);
void set_font_color(int color);
void BG_putc(int x, int y, int level, int c);
void BG_puts(int x, int y, int level, char *s);
void init_sprite(void);

