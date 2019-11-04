#if !defined(MEM_H)
#include <string.h>

#define _fmemcpy memcpy
#define _fmemset memset
#define MK_FP(a, b) (void *) (b)

#endif
