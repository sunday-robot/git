// プログラムのスタートアップルーチンだが、GameViewのインスタンスを生成し、main()メソッドを呼ぶだけ。

#include "GameView.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <dir.h>
#include <conio.h>
#include <pc98.h>

#include "gr.h"
#include "mylib.h"

#include "hi_score.h"
#include "key.h"
#include "palet.h"
#include "sprite_t.h"
#include "sprite.h"
#include "stage.h"
#include "title.h"

static char hi_score_file[MAXPATH];

// 終了時関数
void finish() {
	write_hi_score(hi_score_file);
}

static void *make_data_file_name(char bfn[], char drive[], char dir[],
								 char file[], char ext[], char add_file[])
{
	char file2[MAXFILE];
	int file_len = strlen(file), add_file_len = strlen(add_file);

	strcpy(file2, file);
	if (file_len + add_file_len > MAXFILE - 1)
		file2[MAXFILE - add_file_len - 1] = '\0';
	strcat(file2, add_file);
	fnmerge(bfn, drive, dir, file2, ext);
	return bfn;
}

void main(int argc, char *argv[]) {
	GameView gameView;
	gameView.main(argv[0]);
}
