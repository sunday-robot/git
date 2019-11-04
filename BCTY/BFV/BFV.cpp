#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "gr.h"
#include "eio.h"
#include "bfonti.h"
#include "getcol.h"
#include "dispdata.h"

int no_extention = 0;
int linked_bfnt_mode = 0;
int bfa_mode = 0;
int gajet_mode = 0;

// ヘッダ部分を読み込み、拡張ヘッダがあればそれを読み込み、表示する
void read_header(BFontInfo *bfi)
{
	int extSize, hdrSize;
	{	// ヘッダー文字列("BFNT\x1a")のチェック
		unsigned char buf[5];
		efread(buf, sizeof(unsigned char), 5, bfi->fp);
		if (memcmp(buf, "BFNT\x1a", 5) != 0) {
			fprintf(stderr, "read_header():this is not BFNT file\n");
			exit(1);
		}
	}
	bfi->col = egetc(bfi->fp);
	if ((bfi->col & 0x7f) > 3) {	// 色数が 16 よりも多いものは扱えない
		fprintf(stderr, "read_header():number of colors is too many "
			"(col = %d).\n", bfi->col);
		exit(1);
	}
	bfi->ncolor = 2 << (bfi->col & 0x7f);
	bfi->ttl = egetc(bfi->fp);
	bfi->num = egetc(bfi->fp);
	bfi->Xdots = egetw(bfi->fp);
	bfi->Ydots = egetw(bfi->fp);
	bfi->START = egetw(bfi->fp);
	bfi->END = egetw(bfi->fp);
	if (bfa_mode) {
		fseek(bfi->fp, 0x8, SEEK_CUR);
		efread(bfi->font_name, sizeof(unsigned char), 8, bfi->fp);
		bfi->font_name[8] = '\0';
	} else {
		efread(bfi->font_name, sizeof(unsigned char), 8, bfi->fp);
		bfi->font_name[8] = '\0';
		// 時刻は読み込むだけで何もしない
		efread(bfi->time, sizeof(unsigned char), 4, bfi->fp);
		extSize = egetw(bfi->fp);
		hdrSize = egetw(bfi->fp);
	}
	if (no_extention)
		return;
	if (extSize > 0) {
		while (hdrSize > 0) {
			static char *s[] = {
				"Extended Font Name", "File Name", "Directory Name",
				"Designer", "Comment"
			};
			unsigned char id = egetc(bfi->fp) & 0x7f;// 最上位ビットを無視する
			if (id == 0x3f)
				id = 4;
			if (id > 4) {
				printf("unknown ID(%02x)\n", id);
				fseek(bfi->fp, hdrSize - 3, SEEK_CUR);
			} else {
				int i;
				printf("%s:\n", s[id]);
				for (i = 3; i < hdrSize; i++)	// ヘッダのサイズとその種類で 3
					putchar(egetc(bfi->fp));
				putchar('\n');
			}
			hdrSize = egetw(bfi->fp);
		}
	}
}

// パレットを読み込み、設定、表示する
void set_palet(BFontInfo *bfi)
{
	int i, j;
	char palet[16][3];

	for (i = 0; i < bfi->ncolor; i++) {
		for (j = 0; j < 3; j++)
			printf("%X", palet[i][(j + 2) % 3] = egetc(bfi->fp) >> 4);
		putchar(((i & 7) == 7) ? '\n' : ' ');
	}
	grPal(palet);
}

// リンクドBFNT(+)ファイルの中の１つを読み込む
void read_bfont(BFontInfo *bfi)
{
	read_header(bfi);
	if (bfi->font_name[0] != '\0')
		printf(bfi->font_name);
	else
		printf("(no name)");
	printf(": size = (%3d, %3d), %3d->%3d\n", bfi->Xdots, bfi->Ydots,
		   bfi->START, bfi->END);
	if (bfi->col & 0x80)
		set_palet(bfi);
	reset_color_data(bfi->col & 0x7f);
	display_data(bfi);
}

// リンクドBFNT(+)ファイルを読み込む
void read_linked_bfont(char *fname)
{
	BFontInfo bfi;

	bfi.fp = efopen(fname, "rb");
	read_bfont(&bfi);
	if (linked_bfnt_mode) {
		int ttl = bfi.ttl;
		while (bfi.num < ttl) {
			read_bfont(&bfi);
		}
	}
}

void usage(const char *argv0)
{
	fprintf(stderr, "Usage:\t%s {<option>} <filename>\n", argv0);
	fprintf(stderr, "option:\n");
	fprintf(stderr, "-a\t\tassume archived by bfa\n");
	fprintf(stderr, "-c<1-15>\tset monochromatic font color\n");
	fprintf(stderr, "-e\t\tignore extention\n");
	fprintf(stderr, "-g\t\tset width 256\n");
	fprintf(stderr, "-l\t\tassume BFNT version <= 1.5\n");
	exit(1);
}

void parse_command_line(int argc, char *argv[], char **fname)
{
	int ac = 1;

	while (argv[ac][0] == '-') {
		switch (argv[ac][1]) {
		case 'a':	// bfaによってアーカイブされたファイルを扱う
			bfa_mode = 1;
			linked_bfnt_mode = 1;
			no_extention = 1;	// bfaでのファイルには拡張ヘッダは(多分)無い
			break;
		case 'c':	// モノクロのフォントの表示色を設定する
			{
				int color = atoi(&argv[ac][2]);
				if (color < 1 || color > 15)	// 0は背景色なのではねる
					usage(argv[0]);
				set_mono_font_color(color);
			}
			break;
		case 'e':	// BFNT(+)規格Rev.1.5で拡張された部分(拡張ヘッダ)を無視する
			no_extention = 1;
			break;
		case 'g':
			set_max_width(256);
			break;
		case 'l':
			linked_bfnt_mode = 1;
			break;
		default:
			usage(argv[0]);
		}
		ac++;
	}
	if (argc <= ac)
		usage(argv[0]);
	*fname = argv[ac];
}

void initialize_screen(void)
{
	// パレットを変更したくないので gr_start() を使っていない
	grOn();
	grVPage(0);
	grAPage(0);
	grCls();
	txtCls();
}

void main(int argc, char *argv[])
{
	char *fname;

//	profinit("main", main);
	parse_command_line(argc, argv, &fname);
	initialize_screen();
	read_linked_bfont(fname);
}
