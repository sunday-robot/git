#if !defined(GR_H)
#define GR_H
#include <dummy_library.h>
void grPSet(int, int, int);
//void grPal(char [16][3]);
#define grPal (void)
#define grOn void_void
#define grVPage void_int
#define grAPage void_int
#define grCls void_void
#define txtCls void_void
//void grByteBox(int x, int y, int x2, int y2, int colorNumber);
#define grByteBox (void)
#define txtStore void_void
int grStoreVram(int page);
int gfLoad(const char *fontFileName, int _);
void grEnd(void);
//void gfDisp(int row, int column, int colorNumber, const char *s);
#define gfDisp (void)
//void grPalTone(char palette[16][3], int tone);
//void grPal1(int colorNumber, int r, int g, int b);
#define grPalTone (void)
#define grPal1 (void)

#define OK 0
#define NG -1
void grStart(void);
enum {
	TXT_RED = 2,
	TXT_YELLOW = 6,
	TXT_WHITE = 7,
	TXT_REVERSE = 8,
	TXT_BLINK = 9
};
#define timereset void_void
#define spenttime int_void
#define timestop void_void
#define timeReset timereset
#define timeReset2 timereset
#define timeSpent spenttime
#define timeSpent2 spenttime
//void WaitVsync(void);
#define WaitVsync void_void
void timeStopDos(void);
void timeStartDos(void);
void gfRestore(void);
void grRestoreVram(void);
void txtRestore(void);
//void gfDispChr(int row, int column, int color1Number, int color2Number);
#define gfDispChr (void)

#endif
