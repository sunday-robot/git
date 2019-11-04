#if !defined(__BUTTON_H__)
#define __BUTTON_H__

#include "panel.h"

#define MaxButtonName 8
#define ButtonWidth (8 * MaxButtonName)
#define ButtonHeight 16
#define nButtonCallback 4

class Button : public Panel {
	enum {Up, Down} state;
	int name_off;
	char name[MaxButtonName + 1];
public:
	Button(char *_name = "", int _x = 0, int _y = 0, int _width = ButtonWidth,
		int _height = ButtonHeight);
	void setName(char *_name);
	void setPosition(int _x, int _y) {move(_x, _y);};
	void show();
	void down() {state = Down; show();};
	void up() {state = Up; show();};
};

#endif // __BUTTON_H__
