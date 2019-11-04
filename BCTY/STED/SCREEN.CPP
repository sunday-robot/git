#include <stdio.h>
#include "screen.h"

void Screen::show()
{
	int i = 0;
	Panel *p;
	while ((p = (Panel *) panelList[i++]) != 0)
		p->show();
}

void Screen::processEvent(Event *e)
{
	Panel *p;
	int i = 0;

	while ((p = (Panel *) panelList[i++]) != 0) {
		if (p->processEvent(e))
			break;
	}
}
