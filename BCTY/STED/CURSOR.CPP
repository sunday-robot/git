#include <gr.h>
#include "cursor.h"

void Cursor::setCursorRegion()
{
	cursorRegion.move(region->Vector::operator + (this->zoom(positionUnit)));
	cursorRegion.resize(size.zoom(positionUnit));
}

Cursor::Cursor(Region *r, void (*_restore)(int, int, int, int))
{
	region = r;
	visible = 0;
	color = 7;
	this->Vector::operator = (Vector(0, 0));
	positionUnit = Vector(1, 1);
	size = Vector(1, 1);
	restore = _restore;
	setCursorRegion();
}

void Cursor::setPosition(Vector p)
{
	Vector current_size = (region->getSize()).mooz(positionUnit) - size;
	p = (p - Vector(*region)).mooz(positionUnit);
	if (p.getX() > current_size.getX())
		p.setX(current_size.getX());
	if (p.getY() > current_size.getY())
		p.setY(current_size.getY());
	if (*this != p) {
		if (visible) {
			hide();
			this->Vector::operator = (p);
			show();
		} else
			this->Vector::operator = (p);
	}
}

void Cursor::setSize(Vector s)
{
	if (s <= Vector(0, 0) || region->isIn(s.zoom(positionUnit)))
		return;
	if (visible) {
		hide();
		size = s;
		show();
	} else
		size = s;
}

void Cursor::show(int sw)
{
	if (!sw && visible)
		return;
	visible = 1;
	grBox(cursorRegion.getX(), cursorRegion.getY(),
		cursorRegion.getX() + cursorRegion.getWidth() - 1,
		cursorRegion.getY() + cursorRegion.getHeight() - 1, color);
}

void Cursor::hide(int sw)
{
	if (!sw && !visible)
		return;
	visible = 1;
	if (restore != 0)
		restore(cursorRegion.getX(), cursorRegion.getY(),
			cursorRegion.getX() + cursorRegion.getWidth() - 1,
			cursorRegion.getY() + cursorRegion.getHeight() - 1);
}
