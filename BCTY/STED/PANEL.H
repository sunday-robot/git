#if !defined(__PANEL_H__)
#define __PANEL_H__

#include <event.h>
#include "parray.h"
#include "region.h"
#include "callback.h"

class Panel : public Region {
	int isVisible;
	Parray callbackList;
public:
	Panel::Panel(int _x, int _y, int _width, int _height, int ncallback);
	int processEvent(Event *_event);
	int addCallback(Callback *_callback);
	virtual void show();
};

#endif	// __PANEL_H__
