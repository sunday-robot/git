#if !defined(__REGION_H__)
#define __REGION_H_

// ‹éŒ`—Ìˆæ‚ÌƒNƒ‰ƒX
#include "vector.h"

class Region : public Vector {
	Vector size;
public:
	Region(int _x = 0, int _y = 0, int width = 16, int height = 16)
		: Vector (_x, _y) { size = Vector(width, height);};
	Vector getSize() {return size;};
	int getWidth() {return size.getX();};
	int getHeight() {return size.getY();};
	int isIn(Vector _v) {return (*this <= _v) && ((*this + size) > _v);};
	int isIn(int _x, int _y) {return isIn(Vector(_x, _y));};
	void move(Vector _v) {*(Vector *)this = _v;};
//	void move(Vector _v) {this->Vector::operator =(_v);};
	void move(int _x, int _y) {move(Vector(_x, _y));};
	void resize(Vector _v) {size = _v;};
	void resize(int width, int height) {resize(Vector(width, height));};
};
#endif	// __REGION_H__