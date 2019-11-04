#include "panel.h"
#include "stage.h"

class CurrentMapPartsPanel : public Panel {
	MapParts currentParts;
	int pensize;
public:
	CurrentMapPartsPanel();
	void show();
	MapParts getParts() {return currentParts;};
	void setParts(MapParts mp);
	int getPensize() {return pensize;};
	void setPensize(int _ps);
};

class MapSelectPanel : public Panel {
public:
	MapSelectPanel();
	void show();
};
