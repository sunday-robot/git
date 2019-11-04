#if !defined(__RADIO_B_H__)
#define __RADIO_B_H__

class RadioButtonManager : public Parray {
	int pushedButtonNumber;
public:
	RadioButtonManager(int nButton) : Parray(nButton)
	{
		pushedButtonNumber = -1;
	};
	int addButton(Button *b) {return append((void *) b);};
	void reset();
	int getPushedButtonNumber() {return pushedButtonNumber;};
};

class RadioButton : public Button {
public:
	RadioButton(char *_name = "", int _x = 0, int _y = 0,
		int _width = ButtonWidth, int _height = ButtonHeight,
		RadioButtonManager *_rbm) : Button(_name, _x, _y, _width, _height)
	{
	};
	down();
	up();
};

#endif // __RADIO_B_H__
