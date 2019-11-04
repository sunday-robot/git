#include <mem.h>
#include <super.h>
#include <mouse.h>
#include "sted_pat.h"
#include "se_scrn.h"
#include "te_pnl.h"

TankEditPanel::TankEditPanel()
	: Panel(TEP_X, TEP_Y, TEP_WIDTH, TEP_HEIGHT, 2)
{
}

void TankEditPanel::getTank(Tank t)
{
	memcpy(t, tank, sizeof(Tank));
}

void TankEditPanel::setTank(Tank t)
{
	memcpy(tank, t, sizeof(Tank));
}

TankElement TankEditPanel::getTankElement(int _x, int _y)
{
	int index = _y * 5 + _x;
	if (index < 0 || index >= 20)
		return TankElement(0, 0);
	else
		return tank[index];
}

#define disp_tank(xx, yy, te) over_put_8(getX() + xx * 32, getY() + yy * 32,\
	tank_pat_table[te.type] + (te.item ? 4 : 0));

void TankEditPanel::putTankElement(int _x, int _y, TankElement _te)
{
	int index = _y * 5 + _x;
	if (index < 0 || index >= 20)
		return;
	tank[index] = _te;
	int mcs = m_get_cursor_state();
	m_cursor(0);
	disp_tank(_x, _y, _te);
	m_cursor(mcs);
}

void TankEditPanel::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);
	int i = 0;
	for (int yy = 0; yy < 4; yy++)
		for (int xx = 0; xx < 5; xx++) {
			disp_tank(xx, yy, tank[i]);
			i++;
		}
	m_cursor(mcs);
}
