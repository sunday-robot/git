#if !defined(__IMAGE_H__)
#define __IMAGE_H__

#include <alloc.h>

class Image {
// �������́A�o�C�g�P��
	int width, height;
	unsigned char far *data;
public:
	Image() {data = NULL;};
	~Image() {if (data) farfree(data);};
	int get(int x, int y, int _width, int _height);
	void put(int x, int y);
	int isAlreadyGot() {return data ? 1 : 0;};
};

#endif	// __IMAGE_H__