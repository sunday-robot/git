#include "screen.h"
#include "stage.h"

enum Operate {None = -1, Copy = 0, Move, Edit, Delete, New, Save, Quit, RollUp,
	RollDown, nButton};

class StageListScreen : public Screen {
	Operate operateMode;
public:
	StageListScreen();
	Operate getOperateMode() {return operateMode;};
	void setOperateMode(Operate _operate) {operateMode = _operate;};
	void edit(Stage *_stage);
//	virtual void show();
};

extern StageListScreen stage_list_screen;