#include <mem.h>

typedef char A[10];

void **a = new (*void)[10];

//A a = "abc";

void get(A b)
{
	memcpy(b, a, sizeof(A));
//	b = a;
}

main()
{
	A b;
	get(b);
}