//#define TEST
#include <stdio.h>
#include <string.h>
#include <stdarg.h>
#include <mem.h>
#include <dos.h>
#include "bgmopn.h"
#include <gr.h>
#include <mylib.h>

#include "bcty.h"
#include "palet.h"
#include "key.h"
#include <super.h>

#define HS_COLUMN 2
#define HS_STRING_ROW 2
#define HS_SEPARATE_BAR_ROW (HS_STRING_ROW + 1)
#define HS_ROW (HS_SEPARATE_BAR_ROW + 1)
#define HS_MESSAGE_ROW (HS_ROW + 12)
#define HS_SELECT_ROW (HS_MESSAGE_ROW + 2)

typedef struct {
	char name[9];
	int mode;
	int score;
/*
	int stage_from;
	int stage_to;
*/
	struct date date;
	struct time time;
} HighScore;

static HighScore hi_score[10];

static int changed_flg = 0;

typedef char HsString[5+2+1 +2+1 +8+1 +2+1+2+1+2+1 +2+1+2+1+2+1];
//-                   score mode name date         time

static char hs_head_str[] = " SCORE MODE  NAME     DATE     TIME  ";
static char hs_line_str[] = "-------------------------------------";
static char message_string[] = "INPUT YOUR NAME";

static void hs2str(HighScore *hs, HsString hsstr)
{
	sprintf(hsstr, "%05d00 %cP %-8s %02d/%02d/%02d %02d:%02d:%02d",
		hs->score, hs->mode ? '2' : '1', hs->name,
		hs->date.da_year % 100, hs->date.da_mon, hs->date.da_day,
		hs->time.ti_hour, hs->time.ti_min, hs->time.ti_sec);
}

static void disp_hi_score(void)
{
	int i;
	gfDisp(HS_STRING_ROW, HS_COLUMN, TXT_WHITE, hs_head_str);
	gfDisp(HS_SEPARATE_BAR_ROW, HS_COLUMN, TXT_WHITE, hs_line_str);
	for (i = 0; i < 10; i++) {
		HsString hsstr;
		hs2str(&hi_score[i], hsstr);
		gfDisp(i * 2 + HS_ROW, HS_COLUMN, TXT_WHITE, hsstr);
	}
}

#define CHAR_FIRST 0x20		// 最初の文字(スペース)
#define CHAR_BS (0x20 + 3 * 32 - 2)	// バックスペース
#define CHAR_END (0x20 + 3 * 32 - 1)	// リターン
#define NE_X 24
#define NE_Y HS_ROW
#define NE_WIDTH 8

typedef enum {ncDisp, ncPutC} NmCommand;

static int name(NmCommand nc, ...)
{
	va_list vl;
	int r = 0;
	static int csr;
	static int row;
	static char *name_buffer;

	va_start(vl, nc);

	switch (nc) {
	case ncDisp:
		name_buffer = va_arg(vl, char *);
		csr = 0;
		gfDisp(row = va_arg(vl, int) + NE_Y, NE_X, TXT_YELLOW, "________");
		break;
	case ncPutC:
		{
			char c = va_arg(vl, char);
			switch (c) {
			case CHAR_BS:
				if (csr != 0)
					gfDispChr(row, --csr * 2 + NE_X, TXT_YELLOW, '_');
				break;
			case CHAR_END:
				name_buffer[csr] = '\0';
				r = 1;
				break;
			default:
				gfDispChr(row, csr * 2 + NE_X, TXT_WHITE, c);
				name_buffer[csr++] = c;
				if (csr >= 8) {
					name_buffer[8] = '\0';
					r = 1;
				}
			}
		}
	}
	return r;
}

// CT...Character Table
#define CT_X 8
#define CT_Y HS_SELECT_ROW
#define CT_WIDTH 32
#define CT_HEIGHT 3

typedef enum {ctcsrDisp, ctcsrMove, ctcsrGetC} CtCsrCommand;

static void change_attribute(int x, int y, int attribute, int sw)
{
#if 0
	unsigned int /*far*/ *tv_attr = MK_FP(0xa200, CT_X * 2 + x * 4 + (CT_Y + y) * 160);
	if (sw) {
		*tv_attr |= attribute;
		*(tv_attr + 1) |= attribute;
	} else {
		*tv_attr &= ~attribute;
		*(tv_attr + 1) &= ~attribute;
	}
#endif
}

static int ct_cursor(CtCsrCommand ccc, ...)
{
	static int x, y;
	int r;
	va_list vl;

	va_start(vl, ccc);
	switch (ccc) {
	case ctcsrMove:
		change_attribute(x, y, TXT_REVERSE, 0);
		switch (va_arg(vl, KeyCode)) {
		case K_DOWN:
			if (++y >= CT_HEIGHT)
				y = 0;
			break;
		case K_RIGHT:
			x = (x + 1) & (CT_WIDTH - 1);	break;
		case K_UP:
			if (--y < 0)
				y = CT_HEIGHT - 1;
			break;
		case K_LEFT:
			x = (x - 1) & (CT_WIDTH - 1);	break;
		}
		change_attribute(x, y, TXT_REVERSE, 1);
		break;
	case ctcsrDisp:
		x = y = 0;
		change_attribute(0, 0, TXT_REVERSE, 1);
		break;
	case ctcsrGetC:
		r = CHAR_FIRST + x + y * CT_WIDTH;
		break;
	}
	return r;
}

static void disp_char_table(void)
{
	int x, y;
	for (y = 0; y < CT_HEIGHT; y++)
		for (x = 0; x < CT_WIDTH; x++)
			gfDispChr(y + CT_Y, x * 2 + CT_X, TXT_WHITE,
				CHAR_FIRST + x + y * CT_WIDTH);
	ct_cursor(ctcsrDisp);
}

static void draw_high_score_string(void)
{
	change_tone(0);
	txtCls();
	grVPage(0);
	grAPage(0);
	grCls();
	gf_zoom_center_puts(200 - 16 * 8, 8, 1, 15, "HIGH");
	gf_zoom_center_puts(200, 8, 1, 15, "SCORE");
	change_tone(64);
}

void input_high_score(int score, int game_mode, int player_number)
{
	int i, rank;
	KeyCode kc;

	draw_high_score_string();
#if !defined(TEST)
	music_play(BGM_HIGH_SCORE, 1);
#endif

	// トップ10に入るかチェック
	for (i = 0; i < 10; i++) {
		if (score >= hi_score[i].score) {
			memmove(&hi_score[i + 1], &hi_score[i],
				sizeof(HighScore) * (9 - i));
			hi_score[i].score = score;
			hi_score[i].mode = game_mode;
			hi_score[i].name[0] = '\0';
			getdate(&hi_score[i].date);
			gettime(&hi_score[i].time);
			break;
		}
	}
	if ((rank = i) != 10) {
		int end = 0;

		gfDisp(HS_STRING_ROW, HS_COLUMN, TXT_WHITE, hs_head_str);
		gfDisp(HS_SEPARATE_BAR_ROW, HS_COLUMN, TXT_WHITE, hs_line_str);
		for (i = 0; i < 10; i++) {
			HsString hsstr;
			hs2str(&hi_score[i], hsstr);
			gfDisp(i + HS_ROW, HS_COLUMN, (i == rank) ? TXT_YELLOW : TXT_WHITE,
				hsstr);
		}
		gfDisp(HS_MESSAGE_ROW, 40 - sizeof(message_string) + 1,
			TXT_RED | TXT_BLINK, message_string);
		disp_char_table();
		// 名前の入力
		name(ncDisp, hi_score[rank].name, rank);
		set_key_mode(KM_SELECT);
		if (player_number)
			player_number = K_P2;
		while (!end) {
			while (!kq_deq(&kc))
				;
////			if ((kc ^= player_number) & K_P2)
////				continue;
			if (kc < K_A)
				ct_cursor(ctcsrMove, kc);
			else if (kc == K_A || kc == K_B)
				end = name(ncPutC, ct_cursor(ctcsrGetC));
		}
		changed_flg = 1;		// スコアの更新がされた事を示す
	}
	txtCls();
	disp_hi_score();
	set_key_mode(KM_SELECT);	// キーリピートを止めるため
	while (!kq_deq(&kc))
		;
#if !defined(TEST)
	music_fadeout();
	music_stop();
#endif
}

void read_hi_score(char *fname)
{
	FILE *f;

	if ((f = fopen(fname, "rb")) != NULL) {
		fread(hi_score, sizeof(HighScore), 10, f);
		fclose(f);
	} else
		memset(hi_score, 0, sizeof(HighScore) * 10);
}

void write_hi_score(char *fname)
{
	FILE *f;

	if (!changed_flg)
		return;
	if ((f = fopen(fname, "wb")) != NULL) {
		fwrite(hi_score, sizeof(HighScore), 10, f);
		fclose(f);
	}
}

int get_high_score(void)
{
	return hi_score[0].score;
}

#if defined(TEST)

void main()
{
	gfLoad("bcty.bft", 0);
	DisableKeyBeep();
	timeStart();
	init_key();
	read_hi_score("bcty.scr");
//	disp_hi_score();
	set_joy_assign(JA_2P);
	input_high_score(200, 0, 0);
	input_high_score(100, 1, 1);
	write_hi_score("bcty.scr");
	finish_key();
	timeStop();
	gfRestore();
	dos_clear_key_buffer();
}

#endif
