#include "panel.h"
#include "stage.h"

class Cursor : public Vector {
	Vector positionUnit;	// �J�[�\���̈ʒu�̒P��(16,16�Ƃ�)
public:

};

class MapEditPanel : public Panel {
	Map map;
public:
	MapEditPanel();
	void show();
	void getMap(Map m);
	void setMap(Map m);
	MapParts getParts(int _x, int _y);
	void putParts(int _x, int _y, MapParts mp);
};

class BoxCursor :  public Region {
};