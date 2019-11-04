#if !defined(JOY_H)
#define JOY_H
#include "dummy_library.h"

//void joy_assign(int);
#define joy_assign void_int
enum {
	JOY_NORMAL,
	JOY_SHIFT
};

typedef struct {
	int x;
} JOY_INFO;

void joy_read_info(JOY_INFO[]);
void joy_read_info2(JOY_INFO[]);

#endif
