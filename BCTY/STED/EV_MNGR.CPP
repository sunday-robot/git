#include "ev_mngr.h"

void EventManager::run()
{
	if (currentScreen)
		currentScreen->show();
#if 1
	while (1) {
		Event e;
		while (!eqGetEvent(&e))
			;
		if ((e.type & KeyPress) && e.key.char_code == 0x1b)
			break;
		currentScreen->processEvent(&e);
	}
#endif
}

void EventManager::changeMode(int _mode)
{
	if (_mode >= 0 && _mode < getNum()) {
		currentScreen = (Screen *) (*this)[_mode];
		currentScreen->show();
	}
	eqClearQueue();
}

int EventManager::addScreen(Screen *_screen)
{
	int r = append((void *) _screen);
	if (r)
		currentScreen = _screen;
	return r;
};
