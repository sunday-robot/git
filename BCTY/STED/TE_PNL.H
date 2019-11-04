#include "stage.h"
#include "panel.h"

class TankEditPanel : public Panel {
	Tank tank;
public:
	TankEditPanel();
	void show();
	void getTank(Tank t);
	void setTank(Tank t);
	TankElement getTankElement(int _x, int _y);
	void putTankElement(int _x, int _y, TankElement _te);
};
