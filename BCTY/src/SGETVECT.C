#include <dos.h>
#include <mem.h>

typedef void /*interrupt*/ (*IntrFunc)();

IntrFunc abs_getvect(int n)
{
	return *((IntrFunc *) MK_FP(0, n << 2));
}

void abs_setvect(int n, IntrFunc intr_func)
{
//	disable();
    *((IntrFunc *) MK_FP(0, n << 2)) = intr_func;
//    enable();
}
