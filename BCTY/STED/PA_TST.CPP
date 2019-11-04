#include <stdio.h>
#include <stdlib.h>
#include "parray.h"

void print_array(Parray &parray)
{
	for (int i = 0; ; i++) {
		if (parray[i] == NULL || parray[i] == (void *)-1)
			break;
		printf("%2d, ", *(int *)parray[i]);
	}
	printf("\n");
}

void main()
{
	Parray array(100);
	int i;

	for (i = 0; ; i++) {
		int *a = new int(i);
		if (array.append(a) == 0)
			break;
	}
	printf("size = %d, num = %d\n", array.getSize(), array.getNum());
	print_array(array);
	array.remove(99);
	array.remove(0);
	array.remove(5);
	print_array(array);
}