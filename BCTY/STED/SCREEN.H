#if !defined(__SCREEN_H__)
#define __SCREEN_H__

#include "panel.h"

class Screen {
// protected:
public:
	Parray panelList;
public:
	Screen(int _size) : panelList(_size) {};
	int addPanel(Panel *p) {return panelList.append((void *) p);};
	void processEvent(Event *e);
	virtual void show();
};

#endif // __SCREEN_H__
