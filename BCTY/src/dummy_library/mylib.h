#if !defined(MYLIB_H)
#define MYLIB_H

#include <stdlib.h>

//void bf_mvcprintf(int x, int y, int color1Number, int color2Number, const char *formatString, ...);
//void bf_mvprintf(int x, int y, const char *formatString, ...);
//void bf_mvcputs(int x, int y, int color1Number, int color2Number, const char *string);
#define bf_mvcprintf (void)
#define bf_mvprintf (void)
#define bf_mvcputs (void)
//void bf_mvputs(int x, int y, const char *string);
#define bf_mvputs (void)
#define bf_setcolor (void)
#define bf_printf (void)
#define bf_mvcputc (void)
#define random(n) (rand() % n)

struct date {
	int da_year;
	int da_mon;
	int da_day;
};

struct time {
	int ti_hour;
	int ti_min;
	int ti_sec;
};


void getdate(struct date *date);
void gettime(struct time *time);

#endif
