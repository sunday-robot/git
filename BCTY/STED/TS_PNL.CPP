#include <assert.h>
#include <gr.h>
#include <mouse.h>
#include <super.h>
#include "..\super_bc.h"
#include "sted_pat.h"
#include "se_scrn.h"
#include "ts_pnl.h"

#define put_tank(_x, _y) over_put_8(getX() + _x * 32, getY() + _y * 32,\
	tank_pat_table[_x] + _y * 4)

CurrentTankPanel::CurrentTankPanel()
	: Panel(CTP_X, CTP_Y, CTP_WIDTH, CTP_HEIGHT, 0)
{
}

void CurrentTankPanel::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);
	over_put_8(getX(), getY(), tank_pat_table[currentTank.getType()]
		+ (currentTank.getItem() ? 4 : 0));
	m_cursor(mcs);
}

void CurrentTankPanel::setTank(TankElement te)
{
	currentTank = te;
	show();
}

TankSelectPanel::TankSelectPanel()
	: Panel(TSP_X, TSP_Y, TSP_WIDTH, TSP_HEIGHT, 1),
	currentTankElement(0, 0)
{
}

void TankSelectPanel::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);
	{
		int type, item;
		for (item = 0; item < 2; item++)
			for (type = 0; type < 4; type++) {
				put_tank(type, item);
			}
	}
	m_cursor(mcs);
}
