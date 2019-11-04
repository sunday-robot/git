//
// "GAME OVER" ‚Ì•¶š‚ğ‰æ–Ê‚¢‚Á‚Ï‚¢‚É•\¦‚·‚éA‚»‚ê‚¾‚¯
//
#include <stdio.h>
#include <string.h>
#include <conio.h>

#if !defined(PROF)
	#include "bgmopn.h"
#endif
#include "gr.h"
#include "mylib.h"

#include "bcty.h"
#include "bcvtimer.h"
#include "key.h"
#include "palet.h"

typedef struct {
	char *str1, *str2;
	int color1, color2;
	int zoom_rate;
	int bgm_number;
	int flash_flg;
	char fl_pal[3];
} BigStringInfo;

static BigStringInfo big_string_info[2] = {
	{ "GAME", "OVER", 2, 10, 10, BGM_GAME_OVER, 0, { 0, 0, 0 } },
	{ "HIGH", "SCORE", 1, 15, 8, BGM_HIGH_SCORE, 1, { 14, 14, 15} }
};

void flash(void)
{
	WaitVsync();
	flash_palet();
}

static void disp_big_string(BigStringInfo *bsi)
{
	fade_out(0, 0, 0);
	txtCls();
	grVPage(0);
	grAPage(0);
	grCls();
	gf_zoom_center_puts(200 - 16 * bsi->zoom_rate, bsi->zoom_rate, bsi->color1,
						bsi->color2, bsi->str1);
	gf_zoom_center_puts(200, bsi->zoom_rate, bsi->color1, bsi->color2,
						bsi->str2);
	if (bsi->flash_flg)
		set_flash_palet(bsi->color1, bsi->fl_pal);
	fade_in();
#if !defined(PROF)
	music_play(bsi->bgm_number);
#endif
	if (bsi->flash_flg)
		wait_button2_or_bgm(flash);
	else
		wait_button2_or_bgm(NULL);
#if !defined(PROF)
	music_fadeout();
	msuic_stop();
#endif
}

void game_over_screen()
{
	set_key_mode(KM_SELECT);
	disp_big_string(&big_string_info[0]);
//	if (is_high_score_updated)
//		disp_big_string(&big_string_info[1]);
}
