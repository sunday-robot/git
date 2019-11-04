#if !defined(BGMLIB_H)
#define BGMLIB_H

#include <dummy_library.h>

#define bgm_read_sdata int_char_p
#define bgm_init int_int
#define bgm_finish void_void
#define bgm_select_music int_int
#define bgm_start_play int_void
#define bgm_repeat_on int_void
#define bgm_repeat_off int_void
#define bgm_stop_play void_void
#define bgm_sound (void)

#define BGM_COMPLETE 0
#define BGM_STAT_PLAY 1
typedef struct {
	int play;
} BSTAT;
int bgm_read_status(BSTAT *bstat);

#endif
