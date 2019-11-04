#ifndef __CURSOR_H__
#define __CURSOR_H__

#include "region.h"

class Cursor : public Vector {
	int visible;
	int color;
	Region *region;				// カーソルの動く範囲(ドット単位)
	Vector positionUnit;		// カーソルの位置の単位(16,16とか)
	Vector size;				// positionUnitを単位とするカーソルのサイズ
	Region cursorRegion;		// カーソルの存在範囲(グラフィック画面内での
								// 絶対座標)、画面復帰のための変数
	void (*restore)(int x1, int y1, int x2, int y2);
	void setCursorRegion();
public:
	Cursor(Region *r, void (*_restore)(int, int, int, int));
	void setPosition(Vector);	// グラフィック画面内での絶対座標、ドット単位
	void setPosition(int _x, int _y) {setPosition(Vector(_x, _y));};
	void setUnit(Vector v) {positionUnit = v;};
	Vector getUnit() {return positionUnit;};
	void setSize(Vector s);
	Vector getSize() {return size;};
	void show(int sw = 0);
	void hide(int sw = 0);
};

#endif
