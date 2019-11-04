#include "parray.h"
#include "screen.h"

class EventManager : public Parray {
	Screen *currentScreen;
public:
	EventManager(int _size) : Parray(_size) {currentScreen = 0;};
	int addScreen(Screen *_screen);
	void run();
	void changeMode(int _mode);
};

extern EventManager event_manager;