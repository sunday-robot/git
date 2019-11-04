#include <stdlib.h>
#include <mem.h>
#include "parray.h"

Parray::Parray()
{
	array = (void **) 0;
	size = num = 0;
}

Parray::Parray(int _size)
{
//	array = (void **) malloc(_size * sizeof(void *));
	typedef void *voidp;
	array = new voidp[_size];
	if (array != 0) {
		size = _size;
		memset(array, 0, size * sizeof(void *));
	} else {
		size = 0;
	}
	num = 0;
}

Parray::~Parray()
{
	if (size > 0) {
		size = 0;
		num = 0;
//		free(array);
		delete array;
	}
}

void *Parray::operator[](int _index)
{
	if (size > _index && _index >= 0)
		return *(array + _index);
	else
		return 0;
}

int Parray::insert(void *_obj, int _index)
{
	if (num < size) {
		if (_index >= num)
			_index = num;
		else {
			if (_index < 0)
				_index = 0;
			memmove(array + _index + 1, array + _index,
				sizeof(void *) * (num - _index));
		}
		*(array + _index) = _obj;
		num++;
		return 1;
	} else
		return 0;
}

int Parray::remove(int _index)
{
	if (num > 0) {
		num--;
		if (_index >= num)
			_index = num;
		else {
			if (_index < 0)
				_index = 0;
			memmove(array + _index, array + _index + 1,
				sizeof(void *) * (num - _index));
		}
		*(array + num) = (void *) 0;
		return 1;
	} else
		return 0;
}
