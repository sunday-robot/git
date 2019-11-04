#include <stdio.h>
#include "panel.h"

Panel::Panel(int _x, int _y, int _width, int _height, int ncallback)
	: Region(_x, _y, _width, _height), callbackList(ncallback)
{
}

void Panel::show()
{
}

int Panel::addCallback(Callback *_callback)
{
	int r = callbackList.append((void *) _callback);
	if (r == 0)
		fprintf(stderr, "Panel::addCallback() : can not append callback\n");
	return r;
}

int Panel::processEvent(Event *e)
{
	if (e->type & /* MouseEvent*/ (MotionNotify | LeftButtonPress | RightButtonPress)) {
//		printf("event (%d, %d), panel (%d, %d), (%d, %d)\n", e->mouse.x,
//			e->mouse.y, this->getX(), this->getY(), this->getWidth(),
//			this->getHeight());
		if (isIn(Vector(e->mouse.x, e->mouse.y))) {
//			puts("in");
			int i = 0;
			Callback *callback;

			while ((callback = (Callback *) callbackList[i++]) != 0)
				callback->call(this, e);
			return 1;
		} else {
//			puts("out");
		}
	}
	return 0;
}
