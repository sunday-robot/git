#include "stage.h"
#include "panel.h"

class CurrentTankPanel : public Panel {
	TankElement currentTank;
public:
	CurrentTankPanel();
	void show();
	TankElement getTank() {return currentTank;};
	void setTank(TankElement te);
};

class TankSelectPanel : public Panel {
	TankElement currentTankElement;
public:
	TankSelectPanel();
	void show();
};
