//#define USEOPNDRV
#if !defined(USEOPNDRV)
	#include "bgmlib.h"
	#define music_init(buf_size) bgm_init(buf_size)
	#define music_terminate() bgm_finish()
	#define music_load(fname) music_load_bgm(fname)
	#define music_play(bgm_num, repeat_flg) \
		(bgm_select_music(bgm_num),\
		bgm_start_play(),\
		repeat_flg ? bgm_repeat_on() : bgm_repeat_off())
	#define music_stop() bgm_stop_play()
	#define music_fadeout()
	#define sound_load(fname) music_load_efs(fname)
	#define sound_out(sound_num) bgm_sound(sound_num)
    int music_load_bgm(char *);
    int music_load_efs(char *);
#else
	#include "opndrv.h"
	#define music_init(buf_size) opn_open(buf_size)
	#define music_terminate() opn_close();
	#define music_load(fname) music_load_opn_list(fname)
	#define music_play(bgm_num, repeat_flg) opn_play(bgm_num)
	#define music_stop() opn_mend()
	#define music_fadeout() opn_mfade(50, 50)
	#define sound_load(fname) (opn_seload(fname) != OPN_ERROR)
	#define sound_out(sound_num) opn_se(sound_num)
	int music_load_opn_list(char *);
#endif
