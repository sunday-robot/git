#if !defined(__PARRAY_H__)
#define __PARRAY_H__

class Parray {
	void **array;
	int size;
	int num;
public:
	Parray();
	Parray(int _size);
	~Parray();
	void *operator[](int _index);
	int insert(void *_obj, int _index);
	int append(void *_obj) {return insert(_obj, num);};
	int remove(int _index);
	int getSize() {return size;};
	int getNum() {return num;};
};
#endif	// __PARRAY_H__
