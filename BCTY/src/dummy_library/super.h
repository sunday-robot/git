#if !defined(SUPER_H)
#define SUPER_H
#include "dummy_library.h"

//void over_put_8(int x, int y, int spriteNumber);
//void super_put(int x, int y, int spriteNumber);
//int super_entry_bfnt(const char *bftFileName);
//int super_getsize_pat_x(int spriteNumber);
//void gf_zoom_center_puts(int y, int zoomRate, int color1Number, int color2Number, const char *string);
int super_entry_pat(int patsize, void *image, int clear_color);
#define over_put_8 (void)
#define super_put (void)
#define super_entry_bfnt int_char_p
#define super_getsize_pat_x int_int
#define gf_zoom_center_puts (void)

enum {
	SET
};

enum {
	InsufficientMemory = -1,
	FileNotFound = -2,
	InvalidData = -3,
	GeneralFailure = -4
};

#define SIZE8x8 0x0108
#define SIZE16x16 0x0210
#define SIZE24x24 0x0318
#define SIZE32x32 0x0420

#endif
