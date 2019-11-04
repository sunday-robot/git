/*
  ●2画面切り替えでスクロールなしのスプライト環境を実現するためのモジュール
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdarg.h>
#include <mem.h>

#include "gr.h"
#include "super.h"

#include "super_bc.h"

#define MAX_BG_X 64						// (640 / 16) 計算を速くするため
#define MAX_BG_Y 32						// (400 / 14)
#define MAX_BG_RESTORE_INFO 150			// BGの復元情報の最大数
#define BG_EMPTY 0xff

typedef struct {
	char level, index;
} SpriteAddress;

typedef struct {
	int use;
	int visible;
	int pattern;
	int cur_pat;
	int size;
	int x, y;
	SpriteAddress address;
} Sprite;

typedef struct {
	int nsprite;
	Sprite *sp_array;
} SpriteMap;

typedef unsigned char BgVram[MAX_BG_Y][MAX_BG_X];

typedef struct {
	int x, y;
} BgRestoreInfo;

typedef struct {
	BgVram bg_vram;
	BgVram set_table;
	BgRestoreInfo bri[MAX_BG_RESTORE_INFO];
	int ninfo;
} BG;

struct {
	Sprite *sprite;
	int nsprite;
	SpriteMap *sprite_location;
	int nlevel;
	BG *bg;
	int nbg;
	char *layer;
	int npat;
} sprite_set;

// スプライトの初期化
// nsprite:	スプライトの個数
// layer:	スプライトの層構造を指定するもの
//			"BSSBSB"のような文字列で、'S'がスプライト用の層、'B'がBG用の層
int spInit(int nsprite, char *layer)
{
	int i, len;

	if ((sprite_set.sprite = (Sprite *)malloc(sizeof(Sprite) * nsprite))
		== NULL) {
		fprintf(stderr, "spInit(): sprite用のメモリを確保できません\n");
		return 0;
	}
	sprite_set.nsprite = nsprite;
	for (i = 0; i < sprite_set.nsprite; i++)
		sprite_set.sprite[i].use = 0;
	if ((sprite_set.layer = (char *)malloc((len = strlen(layer)) + 1))
		== NULL) {
		fprintf(stderr, "spInit(): スプライトの層構造用のメモリを"
			"確保できません\n");
		return 0;
	}
	sprite_set.nbg = 0;
	for (i = 0; *(layer + i); i++) {
		switch (*(layer +i)) {
		case 'S':
			break;
		case 'B':
			sprite_set.nbg++;
			break;
		default:
			fprintf(stderr, "spInit(): スプライトの層構造の記述に"
				"誤りがあります %ps, ", layer);
			return 0;
		}
	}
	if (*layer != 'B') {
		fprintf(stderr, "spInit(): スプライトの層構造の最下層は"
			"BG('B')でなければなりません\n");
		return 0;
	}
	strcpy(sprite_set.layer, layer);
	if ((sprite_set.bg = (BG *)malloc(sizeof(BG) * sprite_set.nbg))
		== NULL) {
		fprintf(stderr, "spInit(): BG用のメモリを確保できません\n");
		return 0;
	}
	sprite_set.nlevel = len - sprite_set.nbg;
	if ((sprite_set.sprite_location = (SpriteMap *) malloc(
		sizeof(SpriteMap) * sprite_set.nlevel)) == NULL) {
		fprintf(stderr, "spInit(): スプライト配置情報用のメモリを"
			"確保できません\n");
		return 0;
	}
	for (i = 0; i < sprite_set.nlevel; i++) {
		if (((sprite_set.sprite_location + i)->sp_array = (Sprite *) malloc(
			sizeof(Sprite) * (sprite_set.nsprite + 1))) == NULL) {
			fprintf(stderr, "spInit(): スプライト配置情報用のメモリを"
				"確保できません\n");
			return 0;
		}
	}
	return 1;
}

// スプライトを割り当てる
int spAllocate(void)
{
	int i;
	Sprite *sp = sprite_set.sprite;

	for (i =  0; i < sprite_set.nsprite; sp++, i++)
		if (!sp->use) {
			sp->pattern = 0;
			sp->cur_pat = 0;
			sp->x = 0;
			sp->y = 0;
			sp->address.level = -1;
			return i;
		}
	return -1;
}

// パターンをスプライトに設定する
// ここでは基本のパターン(例えば上下左右の順でパターンが登録されていたら
// 上のパターン)を指定する。実際に表示されるパターンはここで設定されたものと
// 下の関数で設定されたコマ番号で決まる
void spSetPattern(int sn, int pattern)
{
	if (sn >= sprite_set.nsprite)
		return;
	sprite_set.sprite[sn].pattern = pattern;
}

// コマ番号を設定する
void spSetKoma(int sn, int koma)
{
	Sprite *ps;
	int n;

	if (sn >= sprite_set.nsprite)
		return;
	ps = &sprite_set.sprite[sn];
	n = ps->pattern + koma;
	if (n >= sprite_set.npat)
		ps->cur_pat = sprite_set.npat - 1;
	else if (n < 0)
		ps->cur_pat = 0;
	else
		ps->cur_pat = n;
	ps->size = super_getsize_pat_x(ps->cur_pat) >> 4;
}

// スプライトを動かす
// x,y:	新しい座標
void spMove(int sn, int x, int y)
{
	Sprite *ps;
	if (sn >= sprite_set.nsprite)
		return;
	ps = &sprite_set.sprite[sn];
	ps->x = x;
	ps->y = y;
}

// スプライトを表示するレベルを設定する
// このレベルはスプライトの層に限定してのレベルで、BGの層は考えない。
// 例えば、層構造が"BSSBS"の場合、レベルは0から2の範囲である。
void spSetLevel(int sn, int level)
{
	Sprite *ps;
	SpriteMap *psl;

	if (sn >= sprite_set.nsprite)
		return;
	ps = &sprite_set.sprite[sn];
	if (level < 0 || level >= sprite_set.nlevel)
		return;

	if (ps->address.level >= 0) {
		// 元いた層から削除する
		Sprite *psls;
		psl = sprite_set.sprite_location + ps->address.level;
		psls = psl->sp_array + ps->address.index;
		memmove(psls, psls + 1, sizeof(Sprite *) * (sprite_set.nsprite
			- ps->address.index - 1));
		psl->nsprite--;
	}
	// 新しい層の末尾に登録する
	psl = sprite_set.sprite_location + level;
	if (psl->nsprite >= sprite_set.nsprite) {
		fprintf(stderr, "spSetLevel(): there is no space in sprite location"
			" buffer.\n");
		return;
	}
	ps->address.level = level;
	ps->address.index = psl->nsprite;
	*(psl->sp_array + psl->nsprite++) = ps;
}

// スプライトの可視、不可視を設定する
void spSetVisible(int sn, int visible)
{
	if (sn >= sprite_set.nsprite)
		return;
	sprite_set.sprite[sn].visible = visible;
}

// スプライト全体をリセットする
void spReset(void)
{
	int i;
	// 全てのスプライトを不可視にする
	for (i = 0; i < sprite_set.nsprite; i++)
		sprite_set.sprite[i].visible = 0;
	// レベル0を除く全てのBGvramをクリアする
	for (i = 1; i < sprite_set.nbg; i++)
		memset(sprite_set.bg[i].bg_vram, BG_EMPTY, sizeof(BgVram));
	// レベル0のBGvramを適当な値(0)で埋める
	memset(sprite_set.bg[0].bg_vram, 0, sizeof(BgVram));
}

// 指定されたレベルのキャラクタを表示する
static void put_characters(int level)
{
	SpriteMap *psl = sprite_set.sprite_location + level;
	Sprite *ps, *ps_end;
	int i;

	ps_end = (ps = psl->sp_array) + psl->nsprite;
	for (; ps < ps_end; ps++) {
		int size = ps->size;
		int x = ps->x, y = ps->y;
		int bg_x = x / 16, bg_y = y / 16;
		int bg_x2 = bg_x + size, bg_y2 = bg_y + size;

		if (x & 15)
			bg_x2++;
		if (y & 15)
			bg_y2++;
		for (; bg_y < bg_y2; bg_y++) {
			int xx;
			for (xx = bg_x; xx < bg_x2; xx++)
				add_BG_restore_info(xx, bg_y, 0);
		}
		super_put_bc(x, y * 7 / 8, ps->pattern);	// ｙ座標の調節
	}
}

// 画面を更新する
void spUpdateScreen(void)
{
	int bg_level = 0;
	int sp_level = 0;
	char *l;

	// sprite_set.layerの内容に従って各層を処理する
	for (l = sprite_set.layer; *l ; l++) {
		if (*l == 'B') {
			restore_BG(bg_level++);
		} else {
			put_characters(sp_level++);
		}
	}
	change_page(1);
}

#define MAX_REQUEST 30	// リクエストの最大数(=一度に表示できるキャラクター数)
#define MAX_SPRITE_LEVEL 3				// 戦車、爆発 & 弾、アイテム & 点数

// BG 復元情報をためておくバッファ
BgRestoreInfoBuffer bg_restore_info_buffer[2 /* ページ数 */][MAX_BG_LEVEL];
BgRestoreInfoBuffer *current_brib;

// 現在書き込み対象となっている VRAM のページ
static int page;

// 登録されているパターンの数
static int sprite_set.npat;

// 背景をセットする
// スプライトの表示を開始する前にこれで背景をセットしておく
void set_BG(int x, int y, int level, int pattern)
{
	BgVram *bv = &bg_vram[level];
	void (*put_proc)(int, int, int);

	bv->bg[y][x] = pattern;
	if (level > 0)
		put_proc = super_put_1614;
	else
		put_proc = over_put_1614;
	grAPage(0);	put_proc(x, y, pattern);
	grAPage(1);	put_proc(x, y, pattern);
}

// 箱型に背景をセットする
void set_BG_box(int x, int y, int width, int height, int level, int pattern)
{
	int xx, x2 = x + width, y2 = y + height;
	for (; y < y2; y++)
		for (xx = x; xx < x2; xx++)
			set_BG(xx, y, level, pattern);
}

// BG の復帰情報を加える
static void add_BG_restore_info(int x, int y, int level)
{
//	BgRestoreInfoBuffer *brib = &bg_restore_info_buffer[page][level];
	BgRestoreInfoBuffer *brib;

	if (level >= MAX_BG_LEVEL)
		return;
	brib = current_brib + level;
	if (bg_vram[level].bg[y][x] != -1 && !brib->set_table[y][x]) {
		BgRestoreInfo *bri;
		if (brib->num_of_info >= MAX_BG_RESTORE_INFO) {
			// BG 復帰情報バッファが一杯なら何も出来ない
			printf("BG restore info buffer is full"
				"(level = %d, num_of_info = %d)\n", level, brib->num_of_info);
			return;
		}
		brib->set_table[y][x] = 1;
		bri = &brib->bri[brib->num_of_info++];
		bri->x = x;
		bri->y = y;
	}
	add_BG_restore_info(x, y, level + 1);
}

static void change_page(int sw)
{
	if (sw) {
		grVpage(sprite_set.page);
		grApage(sprite_set.page ^= 1);
	} else
		sprite_set.page ^= 1;
	current_brib = bg_restore_info_buffer[sprite_set.page];
}

// 背景の変更
// スプライトの表示開始後に背景を変更するときに使う
void change_BG(int x, int y, int level, int pattern)
{
	bg_vram[level].bg[y][x] = pattern;
	add_BG_restore_info(x, y, 0);
	change_page();
	add_BG_restore_info(x, y, 0);
	change_page();
}

// 指定されたレベルの BG を復元する
static void restore_BG(int level)
{
//	BgRestoreInfoBuffer *brib = &bg_restore_info_buffer[page][level];
	BgRestoreInfoBuffer *brib = current_brib + level;
	BgRestoreInfo *bri = brib->bri;
	void (*put_proc)(int, int, int);
	int n = brib->num_of_info;
	int i;

	if (level == 0)
		put_proc = over_put_1614;
	else
		put_proc = super_put_1614;
	if (level != MAX_BG_LEVEL - 1) {
		int upper_level = level + 1;
		for (i = 0; i < n; i++, bri++) {
			put_proc(bri->x, bri->y, bg_vram[level].bg[bri->y][bri->x]);
			add_BG_restore_info(bri->x, bri->y, upper_level);
		}
	} else
		for (i = 0; i < n; i++, bri++)
			put_proc(bri->x, bri->y, bg_vram[level].bg[bri->y][bri->x]);
	memset(brib->set_table, 0, MAX_BG_Y * MAX_BG_X);
	brib->num_of_info = 0;
}

// 実際にキャラクタを VRAM に書き込む
void update_screen(void)
{
	restore_BG(0);						// 地面
	put_characters(0);					// 戦車など
	put_characters(1);					// 爆発、弾など
	restore_BG(1);						// 森
	put_characters(2);					// アイテム、得点など
	grVPage(page);
	change_page();
	grAPage(page);
}

// スプライトのパターンを変更する
void change_pattern(Sprite *spr, int pattern, int level)
{
	if (pattern >= sprite_set.npat || pattern < 0) {
		printf("change_pattern(): pattern is out of range (%d)\n", pattern);
		exit(1);
	}
	if (level >= MAX_SPRITE_LEVEL || level < 0) {
		printf("change_pattern(): level is out of range (%d)\n", level);
		exit(1);
	}
	spr->pattern = pattern;
	spr->level = level;
}

// 初期化が必要な変数を初期化する
void reset_sprite(void)
{
	int i, j;

	page = 1;
	change_page();
	for (i = 0; i < MAX_SPRITE_LEVEL; i++)
		sprite_location[i].num_of_request = 0;
	for (i = 0; i < 2; i++) {
		for (j = 0; j < MAX_BG_LEVEL; j++) {
			bg_restore_info_buffer[i][j].num_of_info = 0;
			memset(bg_restore_info_buffer[i][j].set_table, 0, MAX_BG_X * MAX_BG_Y);
		}
	}
	// BG VRAM もレベル 0 以外はクリアする
	for (i = 1; i < MAX_BG_LEVEL; i++)
		memset(bg_vram[i].bg, 0xff, 2 * MAX_BG_X * MAX_BG_Y);
}

int read_bfnt(char *fname, ...)
{
	va_list argptr;
	char *fn = fname;

	va_start(argptr, fname);
	sprite_set.npat = 0;
	do {
		int r;

		fprintf(stderr, "reading %ps\n", fn);
		if ((r = super_entry_bfnt(fn, 0, !SET)) <= 0) {
			char *ps;
			switch (r) {
			case NOT_ENOUGH_MEMORY:
				ps = "not enough memory";
				break;
			case FILE_NOT_FOUND:
				ps = "file not found";
				break;
			case FILE_ILLIGAL:
				ps = "file illegal";
				break;
			case TOO_MANY:
				ps = "too many";
				break;
			default:
				ps = "unknown error";
			};
			fprintf(stderr, "Error: %ps(%ps)\n", ps, fn);
			exit(1);
		}
		sprite_set.npat += r;
		fn = (char *)va_arg(argptr, char *);
	} while (fn != NULL);

	va_end(argptr);
	return sprite_set.npat;
}

// キャラクタコード→パターンナンバーのテーブル
// パターンが未登録の場合-1が入っている
static int c2pat_table[255];

// フォントをパターンとして登録するときの色
static int font_pat_color = 7;

void set_font_color(int color)
{
	font_pat_color = color;
}

void BG_putc(int x, int y, int level, int c)
{
	extern unsigned int grFontSeg;

	if (c2pat_table[c] == -1) {
		unsigned char buf[4][2 * 16];
		int i, pattern;
		for (i = 0; i < 4; i++) {
			if (font_pat_color & (1 << i))
				_fmemcpy(MK_FP(_SS, &buf[i]), MK_FP(grFontSeg, c * 2 * 16),
					2 * 16);
			else
				_fmemset(MK_FP(_SS, &buf[i]), 0, 2 * 16);
		}
		if ((pattern = super_entry_pat(SIZE16x16, MK_FP(_SS, buf))) < 0)
			return;
		sprite_set.npat++;
		c2pat_table[c] = pattern;
	}
	change_BG(x, y, level, c2pat_table[c]);
}

void BG_puts(int x, int y, int level, char *ps)
{
	while (*ps)
		BG_putc(x++, y, level, *ps++);
}

void init_sprite(void)
{
	int i;
	for (i = 0; i < 255; i++)
		c2pat_table[i] = -1;
}
