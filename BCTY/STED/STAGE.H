#if !defined(__STAGE_H__)
#define __STAGE_H__

#include <stdio.h>
#include "stg_def.h"
#include "image.h"

enum MapParts {mpRoad, mpRenga, mpWood, mpIce, mpConcrete, mpRiver, nParts};

typedef MapParts Map[MAP_SIZE * MAP_SIZE];

struct TankElement {
	unsigned char type:2;
	unsigned char item:1;
	TankElement(int _type, int _item)
	{
		type = _type;
		item = _item ? 1 : 0;
	}
	TankElement() {TankElement(0, 0);};
	int getType() {return type;};
	int getItem() {return item;};
	operator int() {return int(type * 2 + item);};
};

typedef TankElement Tank[COM_TANK];

class Stage : public Image {
	int change;
	MapParts far *map;
	TankElement far *tank;
public:
	Stage();
	~Stage();
	void copy(Stage *stage);
	// 指定された座標に小さく表示("大きく"はない)
	void show(int _x, int _y, int _sw = 0);
	int read(FILE *fp, int _num);	// ファイルから読み込む
	int write(FILE *fp, int _num);	// ファイルに書き出す
	void getMap(Map m);
	void getTank(Tank t);
	void setMap(Map m);
	void setTank(Tank t);
};
#endif	// __STAGE_H__