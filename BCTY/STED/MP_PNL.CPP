#include <assert.h>
#include <gr.h>
#include <mouse.h>
#include "..\super_bc.h"
#include "..\pat.h"
#include "sted_pat.h"
#include "mp_pnl.h"
#include "se_scrn.h"

CurrentMapPartsPanel::CurrentMapPartsPanel()
	: Panel(CMP_X, CMP_Y, CMP_WIDTH, CMP_HEIGHT, 0)
{
	currentParts = mpRoad;
	pensize = 1;
}

void CurrentMapPartsPanel::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);

	int xx = getX() / 16;
	int yy = getY() / 14;

	if (pensize == 2) {
		over_put_1614(xx, yy, map_pat_table[currentParts]);
		over_put_1614(xx + 1, yy, map_pat_table[currentParts]);
		over_put_1614(xx, yy + 1, map_pat_table[currentParts]);
		over_put_1614(xx + 1, yy + 1, map_pat_table[currentParts]);
	} else {
		over_put_1614(xx, yy, map_pat_table[currentParts]);
		over_put_1614(xx + 1, yy, PAT_BATU);
		over_put_1614(xx, yy + 1, PAT_BATU);
		over_put_1614(xx + 1, yy + 1, PAT_BATU);
	}
	m_cursor(mcs);
}

void CurrentMapPartsPanel::setParts(MapParts mp)
{
	if ((mp >= mpRoad) && (mp < nParts)) {
		currentParts = mp;
		show();
	} else {
		sound(700);
		delay(700);
		nosound();
	}
}

void CurrentMapPartsPanel::setPensize(int ps)
{
	if (ps < 1 || ps > 2)
		return;
	if (pensize != ps) {
		pensize = ps;
		show();
	}
}

MapSelectPanel::MapSelectPanel()
	: Panel(MSP_X, MSP_Y, MSP_WIDTH, MSP_HEIGHT, 1)
{
}

void MapSelectPanel::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);
	for (int i = 0; i < nParts; i++)
		over_put_1614(getX() / 16 + i, getY() / 14, map_pat_table[i]);
	m_cursor(mcs);
}
