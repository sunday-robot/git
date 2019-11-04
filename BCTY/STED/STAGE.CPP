#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <alloc.h>
#include <gr.h>
#include <mylib.h>
#include <mouse.h>

#include "stage.h"

static char *class_name = "Stage";

#define puts_err_head() fprintf(stderr, "%s::%s(): ", class_name, method_name);

void put4_8(int x, int y, int type, int color);

Stage::Stage()
{
	struct StageData {
		Map map;
		Tank tank;
	};

	change = 0;
	StageData far *stg_dat = (StageData far *)farcalloc(1, sizeof(StageData));
	if (stg_dat != NULL) {
		map = stg_dat->map;
		tank = stg_dat->tank;
	} else
		delete this;
}

Stage::~Stage()
{
	farfree(map);
}

void Stage::copy(Stage *stage)
{
	_fmemcpy(map, stage->map, sizeof(Map));
	_fmemcpy(tank, stage->tank, sizeof(Tank));
}

// グラフィック画面の座標(x,y)に1ステージ表示する
void Stage::show(int x, int y, int sw)
{
	static int color_table[] = {8, 10, 4, 7, 15, 1};
	int xx, yy;

//	int mcs = m_get_cursor_state();
//	m_cursor(0);

	if (this == NULL) {
		shadow_box(x, y, x + MIN_STAGE_SIZE_X - 1, y + MIN_STAGE_SIZE_Y - 1,
			MIN_STAGE_FRAME_COLOR_1, MIN_STAGE_FRAME_COLOR_3,
			MIN_STAGE_FRAME_COLOR_2);
	} else {
		if (!change && isAlreadyGot()) {
			put(x / 8, y);
		} else {
			shadow_box(x, y, x + MIN_STAGE_SIZE_X - 1,
				y + MIN_STAGE_SIZE_Y - 1, MIN_STAGE_FRAME_COLOR_1,
				MIN_STAGE_FRAME_COLOR_2, MIN_STAGE_FRAME_COLOR_3);
			for (yy = 0; yy < MAP_SIZE; yy++) {
				for (xx = 0; xx < MAP_SIZE; xx++) {
					grBox(x + xx * 2 + 6, y + yy * 2 + 3, x + xx * 2 + 7,
						y + yy * 2 + 4, color_table[map[yy * MAP_SIZE + xx]]);
				}
			}
			grBox(x + 12, y + 2 * MAP_SIZE + 5, x + 12 + 10 * 4 - 1,
				y + 2 * MAP_SIZE + 5 + 16 - 1, 8);
			for (int i = 0; i < COM_TANK; i++) {
				put4_8(x + 12 + (i % 10) * 4, y + 2 * MAP_SIZE + 5 + 8 * (i
					/ 10), tank[i].type, (tank[i].item) ? 2 : 7);
			}
			get(x / 8, y, 8, 76);
			change = 0;
		}
		if (sw) {
			grHLine(x, x + MIN_STAGE_SIZE_X - 1, y, MIN_STAGE_FRAME_COLOR_3);
			grVLine(x, y, y + MIN_STAGE_SIZE_Y - 1, MIN_STAGE_FRAME_COLOR_3);
			grHLine(x, x + MIN_STAGE_SIZE_X - 1, y + MIN_STAGE_SIZE_Y - 1,
				MIN_STAGE_FRAME_COLOR_2);
			grVLine(x + MIN_STAGE_SIZE_X - 1, y, y + MIN_STAGE_SIZE_Y - 1,
				MIN_STAGE_FRAME_COLOR_2);
		}
	}

//	m_cursor(mcs);
}

static char stage_char[] = ".#*%$~";

// ステージデータを1つ読み込む
int Stage::read(FILE *fp, int stage_num)
{
	static char *method_name = "read";
	int x, y;

	if (feof(fp))
		return 0;
	for (y = 0; y < MAP_SIZE; y++) {
		for (x = 0; x < MAP_SIZE; x++) {
			char c = fgetc(fp);
			if (feof(fp))
				return 0;
			char *s = strchr(stage_char, c);
			if (s == NULL || c == '\0') {
				puts_err_head();
				fprintf(stderr, "ステージファイル %d 行 %d 桁に"
					"異常な文字('%c', %02xh) があります。\n",
					(stage_num - 1) * (MAP_SIZE + 1) + y + 1, x + 1,
					isprint(c) ? 'c' : '.', c);
				s = stage_char;
			}
			map[y * MAP_SIZE + x] = (MapParts) ((int) s - (int) stage_char);
		}
		fgetc(fp);	// 改行コードを読み飛ばす
	}
	for (x = 0; x < COM_TANK; x++) {
		char c = fgetc(fp), cc;
		if (feof(fp))
			return 0;
		TankElement te;
		te.item = isupper(c) ? 1 : 0;
		if (!isalpha(c) || (cc = toupper(c)) >= ('A' + 4)) {
			puts_err_head();
			fprintf(stderr, "戦車の種類が異常です。('%c', %02xh)\n",
					isprint(c) ? '.' : c, c);
			te.type = 0;
			te.item = 0;
		} else
			te.type = cc - 'A';
		tank[x] = te;
	}
	fgetc(fp);	// 改行コードを読み飛ばす
//	show(0, 0);
	return 1;
}

// ステージファイルに書き出す
int Stage::write(FILE *fp, int stage_num)
{
	static char *method_name = "write";
	int x, y;

	for (y = 0; y < MAP_SIZE; y++) {
		for (x = 0; x < MAP_SIZE; x++) {
			int type = map[y * MAP_SIZE + x];
			if (type > sizeof(stage_char)) {
				puts_err_head();
				fprintf(stderr, "ステージデータ %d の %d 行 %d 桁に異常な値"
					"(%d)があります。\n", stage_num, y, x, type);
				type = 0;
			}
			fputc(stage_char[type], fp);
		}
		fputc('\n', fp);	// 改行コード
	}
	for (x = 0; x < COM_TANK; x++) {
		TankElement te(tank[x].type, tank[x].item);

		if (te.type >= 4) {
			puts_err_head();
			fprintf(stderr, "戦車の種類が異常です(%d)\n", te.type);
			te.type = 0;
			te.item = 0;
		}
//		printf("%x ", *(unsigned char *) &te);
		fputc((te.item ? 'A' : 'a') + te.type, fp);
	}
//	putchar('\n');
	fputc('\n', fp);		// 改行コード
	return 1;
}

void Stage::getMap(Map m)
{
	_fmemcpy(m, map, sizeof(Map));
}

void Stage::setMap(Map m)
{
	change = 1;
	_fmemcpy(map, m, sizeof(Map));
}

void Stage::getTank(Tank t)
{
	_fmemcpy(t, tank, sizeof(Tank));
}

void Stage::setTank(Tank t)
{
	change = 1;
	_fmemcpy(tank, t, sizeof(Tank));
}
