#ifndef __CURSOR_H__
#define __CURSOR_H__

#include "region.h"

class Cursor : public Vector {
	int visible;
	int color;
	Region *region;				// �J�[�\���̓����͈�(�h�b�g�P��)
	Vector positionUnit;		// �J�[�\���̈ʒu�̒P��(16,16�Ƃ�)
	Vector size;				// positionUnit��P�ʂƂ���J�[�\���̃T�C�Y
	Region cursorRegion;		// �J�[�\���̑��ݔ͈�(�O���t�B�b�N��ʓ��ł�
								// ��΍��W)�A��ʕ��A�̂��߂̕ϐ�
	void (*restore)(int x1, int y1, int x2, int y2);
	void setCursorRegion();
public:
	Cursor(Region *r, void (*_restore)(int, int, int, int));
	void setPosition(Vector);	// �O���t�B�b�N��ʓ��ł̐�΍��W�A�h�b�g�P��
	void setPosition(int _x, int _y) {setPosition(Vector(_x, _y));};
	void setUnit(Vector v) {positionUnit = v;};
	Vector getUnit() {return positionUnit;};
	void setSize(Vector s);
	Vector getSize() {return size;};
	void show(int sw = 0);
	void hide(int sw = 0);
};

#endif