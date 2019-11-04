#include <stdio.h>
#include <stdlib.h>
#include <mem.h>

#include "gr.h"

static char _palet_table[16][3];

//static char _fade_color_palet[3];
static int _fade_level = 30;
static int current_tone = 128;

static struct {
	int flg;
	int num;
	char palet[3];
} _flash_palet;

void change_tone(int tone)
{
	int i;
	int tone_diff = tone - current_tone;

	for (i = 0; i <= _fade_level; i++) {
		WaitVsync();
		grPalTone(_palet_table, i * tone_diff / _fade_level + current_tone);
	}
	current_tone = tone;
}

// B-FONT ファイルからパレットの部分をその並びをrgbに変えて読み込む
void read_bfnt_palet(char *fname)
{
	unsigned short extSize;
	FILE *fp;
	char buf[5];
	int i, j;

	if ((fp = fopen(fname, "rb")) == NULL) {
		fprintf(stderr, "read_bfnt_palet(): can not open %s\n", fname);
		exit(1);
	}
	fread(buf, sizeof(char), 5, fp);
	if (memcmp("BFNT\x1a", buf, 5) != 0) {
		fprintf(stderr, "read_bfnt_palet(): this is not b-font file %s\n",
				fname);
		exit(1);
	}
	if ((fgetc(fp) & 0x80) == 0) {
		fprintf(stderr, "read_bfnt_palet(): this file does not have palet data"
				" %s\n", fname);
		exit(1);
	}
	// extSize の部分までシークする
	fseek(fp, 0x1c, SEEK_SET);
	extSize = getw(fp);
	// パレットの部分までシーク
	fseek(fp, 0x20 + extSize, SEEK_SET);
	for (i = 0; i < 16; i++)
		for (j = 0; j < 3; j++)
			_palet_table[i][(j + 2) % 3] = fgetc(fp) >> 4;
	// カラー番号０は黒にする
	_palet_table[0][0] = _palet_table[0][1] = _palet_table[0][2] = 0;
	grPal(_palet_table);
	fclose(fp);
}

void set_flash_palet(int palet_num, char palet[3])
{
	int i;

	_flash_palet.num = palet_num;
	for (i = 0; i < 3; i++)
		_flash_palet.palet[i] = palet[i];
}

void flash_palet(void)
{
	if (_flash_palet.flg++ & 1)
		grPal1(_flash_palet.num, _flash_palet.palet[0], _flash_palet.palet[1],
				_flash_palet.palet[2]);
	else
		grPal1(_flash_palet.num, _palet_table[_flash_palet.num][0],
				_palet_table[_flash_palet.num][1],
				_palet_table[_flash_palet.num][2]);
}

// #define TEST
#if defined(TEST)

#include <string.h>
#include <conio.h>

void main(int argc, char *argv[])
{
	int i;

	gr_start();
	for (i = 0; i < 16; i++)
		gr_bytebox(i * 80 / 16, 0, i * 80 / 16 + 80 / 16 - 1, 31, i);
	read_bfnt_palet("bcty16.bft");
	if (argc >= 2)
		_fade_level = atoi(argv[1]);
	while (!kbhit()) {
		fade_out(4, 15, 12);
		fade_in();
	}
}

#endif
