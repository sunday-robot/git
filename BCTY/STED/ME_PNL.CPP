#include <mem.h>
#include <mouse.h>
#include "..\super_bc.h"
#include "..\pat.h"
#include "se_scrn.h"
#include "me_pnl.h"
#include "sted_pat.h"

MapEditPanel::MapEditPanel()
	: Panel(MEP_X, MEP_Y, MEP_WIDTH, MEP_HEIGHT, 4)
{
}

void MapEditPanel::show()
{
	int mcs = m_get_cursor_state();
	m_cursor(0);

	int xx = getX() / 16;
	int yy = getY() / 14;
	{
		int x, y;
		for (y = 0; y < MAP_SIZE; y++) {
			for (x = 0; x < MAP_SIZE; x++) {
				over_put_1614(xx + x, yy + y,
					map_pat_table[map[y * MAP_SIZE + x]]);
			}
		}
	}

	m_cursor(mcs);
}

void MapEditPanel::getMap(Map m)
{
	memcpy(m, map, sizeof(Map));
}

void MapEditPanel::setMap(Map m)
{
	memcpy(map, m, sizeof(Map));
}

void MapEditPanel::putParts(int _x, int _y, MapParts mp)
{
	if (_x < 0 || _y < 0 || _x >= MAP_SIZE || _y >= MAP_SIZE)
		return;
	int index = _y * MAP_SIZE + _x;
	if (map[index] == mp)
		return;
	map[index] = mp;
	int mcs = m_get_cursor_state();
	m_cursor(0);
	over_put_1614(getX() / 16 + _x, getY() / 14 + _y, map_pat_table[mp]);
	m_cursor(mcs);
}

MapParts MapEditPanel::getParts(int _x, int _y)
{
	return (MapParts) map[_y * MAP_SIZE + _x];
}
