#include <stdlib.h>
#include <dos.h>

#if !defined(PROF)
	#include "bgmopn.h"
#endif
#include "gr.h"

#include "key.h"

static int wait_count = 0;

void set_wait_count(int w)
{
	wait_count = w;
	timeReset();
}

void wait(void)
{
	while (timeSpent() < wait_count)
		;
	timeReset();
}

void wait_button(void)
{
	while (timeSpent() < wait_count) {
		KeyCode key;
		if (kq_deq(&key))
			wait_count = 0;
	}
	timeReset();
}

// �w�肵�����ԁA�{�^����������Ȃ�����҂�
void wait_button2_or_time(int wait_time)
{
	KeyCode key;
	timeReset2();
	while (!kq_deq(&key) && (timeSpent2() < wait_time))
		;
}

// bgm���I�����邩�A�{�^�����������܂ő҂�
void wait_button2_or_bgm(void)
{
	BSTAT bsp;
	KeyCode key;

	while (!kq_deq(&key)
		&& (bgm_read_status(&bsp), bsp.play == BGM_STAT_PLAY))
		;
}
