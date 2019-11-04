#include <stdio.h>
#include <stdlib.h>
#include "eio.h"

static int width_table[8] = {1, 2, 4, 4, 8, 8, 8, 8};	// �F�[�x���Ƃ́A1�h�b�g������̃r�b�g��?
static int mask_table[8] = {1, 3, 7, 15, 31, 63, 127, 255};

//static FILE *fp;
static int width;
static int mask;
static int position;
static unsigned int c;

// ���m�N�����̐F
static int mono_font_color = 4;

void set_mono_font_color(int color)
{
	if (color <= 0 || color > 15) {
		fprintf(stderr, "set_mono_color(): color is out of range"
						" (color = %d)\n", color);
		exit(1);
	}
	mono_font_color = color;
}

void reset_color_data(int color_depth)
{
	if (color_depth < 0 || color_depth > 8) {
		fprintf(stderr, "reset_color_data(): width is out of range"
				" (color_depth = %d)\n", color_depth);
		exit(1);
	}
	position = 0;
	width = width_table[color_depth];
	mask = mask_table[color_depth];
}

// �F�����o���i�P�|�Q�T�U�F�܂łȂ�n�j�j
int get_color(FILE *fp)
{
	int r;

	if (position == 0) {
		c = egetc(fp);
	}
	r = (c >> (8 - width)) & mask;
	if ((position += width) >= 8) {
		position = 0;
	} else {
		c <<= width;
	}
	return (width != 1) ? r : (r ? mono_font_color : 0);
}
