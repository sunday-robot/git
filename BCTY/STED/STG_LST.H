#include <dir.h>
#include <event.h>
#include "stage.h"
#include "panel.h"

#define RollButtonX (640 - 2 * ButtonWidth)
#define nButtons 10
#define StageListY 16

class StageList : public Panel, public Parray {
	char stageFileName[MAXPATH];
	int visible;
	int currentStageNumber;	// 表示されているステージの先頭
	int sourceStageNumber;	// コピー、ムーブの時のソース
public:
	StageList(int _size);
	int getCurrentStageNumber() {return currentStageNumber;};
	void view(int _stage_number);
	void view() {view(currentStageNumber);};
	void roll(int _delta) {show(currentStageNumber + _delta);};
	void show(int _stage_number);
	virtual void show() {show(currentStageNumber);};
	void processEvent(Event *event);
	void setSource(int _stage_number);
	void edit(int _stage_number);
	void copy(int _stage_number);
	void move(int _stage_number);
	void new_(int _stage_number);
	void del(int _stage_number);
	int read(char *fileName);
	int write(char *fileName);
	int write() {return write(stageFileName);};
	int insert(Stage *_obj, int _index);
	int append(Stage *_obj);
	int remove(int _index);
};
