#include "panel.h"
#include "stage.h"

class Cursor : public Vector {
	Vector positionUnit;	// カーソルの位置の単位(16,16とか)
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
