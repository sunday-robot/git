#include "drand48.h"
#include	 <stdlib.h>

double drand48() {
	return ((double)rand())/ (RAND_MAX + 1);
}
