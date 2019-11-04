#include <stdio.h>
#include <stdlib.h>
#include "gr.h"
#include "bfonti.h"
#include "getcol.h"

static int start_column = 0, start_line = 0;
static int width, height;
static int max_width = 640;

void set_max_width(int w)
{
	max_width = w;
}

static void disp_char(int x, int y, FILE *fp)
{
	int xx;
	int x2 = x + width, y2 = y + height;
	for (; y < y2; y++)
		for (xx = x; xx < x2; xx++)
			grPSet(xx, y, get_color(fp));
}

void display_data(BFontInfo *bfi)
{
	int nchar = bfi->END - bfi->START + 1;

	width = bfi->Xdots;
	height = bfi->Ydots;
	int screen_width = width * (max_width / width - 1);
	int screen_height = height * (400 / height - 1);

	if ((start_line > screen_height) && (nchar != 0)) {
		fprintf(stderr, "Sorry, can't display all characters\n");
		exit(1);
	}

	while (nchar--) {
		disp_char(start_column, start_line, bfi->fp);
		start_column += width;
		if (start_column > screen_width) {
			start_column = 0;
			start_line += height;
			if ((start_line > screen_height) && (nchar != 0)) {
				fprintf(stderr, "Sorry, can't display all characters\n");
				exit(1);
			}
		}
	}
	if (start_column != 0) {
		start_column = 0;
		start_line += height;
	}
}
