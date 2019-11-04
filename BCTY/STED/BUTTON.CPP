#include <stdio.h>
#include <string.h>
#include <mylib.h>
#include <mouse.h>

#include "button.h"

static int c_base[2] = {15, 15};
static int c_ul[2] = {7, 13};
static int c_lr[2] = {13, 7};
static int c_name[2] = {0, 0};

Button::Button(char *_name, int _x, int _y, int _width, int _height)
	: Panel (_x, _y, _width, _height, nButtonCallback)
{
	state = Up;
	setName(_name);
}

void Button::setName(char *_name)
{
	strncpy(name, _name, MaxButtonName)[MaxButtonName] = '\0';
	name_off = size.getX() / 2 - 4 * strlen(name);
}

void Button::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);
	shadow_box(getX(), getY(), getX() + size.getX() - 1,
		getY() + size.getY() - 1, c_base[state], c_ul[state], c_lr[state]);
	fntPuts(getX() + name_off, getY(), name, c_name[state]);
	m_cursor(mcs);
}

//#define TEST
#ifdef TEST

#include <gr.h>
#include <mylib.h>

void main()
{
	fntInit("a:\\_misc\\ank.bft");
	grStart();
	grReadBfntPalet("bcty16.bft", 1);
	fade_in();
	Button a(0, 0), b(0, 16);
	a.setName("A_button");
	a.show();
	b.setName("Bbutton");
	b.show();
	b.down();
	Button c(ButtonWidth, 0, 24);
	c.setName("CB");
	c.down();
}
#endif	// TEST