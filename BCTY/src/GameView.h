#pragma once

// GameViewクラス
// GameViewは、GameModelに対応するViewである。
// 詳細はGameModelのコメントを参照のこと。

#include "GameModel.h"

#include <dir.h>

class GameView {
private:
	GameModel *model;

public:
	GameView(void) {
		model = new GameModel();
	}

	~GameView(void) {
		delete model;
	}

	void main(const char *argv0) {

		// 初期化
		initialize(argv0);

		// メインループ(無限ループ)
		for (;;) {
			int gameMode;	// 0:デモ、1:一人プレイ、2:二人プレイ
			int stageNumber;
			int endCode;
			for (;;) {
				// タイトル画面
				gameMode = showTitleScreen();
				if (gameMode != 0)
					break;
				model->startGame(gameMode == 2);
				// デモ画面の場合はステージ番号画面は表示しない
				stageNumber = (rand() % model->getMaximumStageNumber()) + 1;
				model->startStage(stageNumber);
				while (model->tick() == 0)
					showStageScreen();	// ステージ画面のヒトコマ(60FPS)を描く
			}
			switch (gameMode) {
			case 1:
			case 2:
				stageNumber = showStageNumberScreen(1);
				break;
			default:
				return;	// プログラム終了が選択された
			}

			for (;;) {
				model->startStage(stageNumber);
				while ((endCode = model->tick()) == 0)
					showStageScreen();	// ステージ画面のヒトコマ(60FPS)を描く
				if (endCode != STAGE_CLEAR) {
					break;
				}
				showStageResultScreen();	// ステージクリア画面
				stageNumber = showStageNumberScreen(stageNumber++);
			}
			switch (endCode) {
			case EXIT_GAME:
				return;	// ゲーム(プログラム)終了
			case GAME_OVER:
				showStageResultScreen();	// ステージクリア画面
				showGameOverScreen();	// ゲームオーバー画面(画面に大きく"GAME OVER"と書かれているだけの画面)
				break;
			}
		}
	}

private:
	void initialize(const char *argv0) {
		char drive[MAXDRIVE], dir[MAXDIR], file[MAXFILE], ext[MAXEXT];

		fnsplit(argv0, drive, dir, file, ext);

#if 00
		// 終了時関数の登録
		atexit(finish);
		{	// フォントの読み込み
			char font_file[MAXPATH];
			int r;

			fnmerge(font_file, drive, dir, file, ".bft");
			fprintf(stderr, "reading %s\n", font_file);
			if ((r = gfLoad(font_file, 0)) != OK) {
				fprintf(stderr, "initilize(): font ファイルが読み込めません %s\n",
					font_file);
				exit(1);
			}
		}
		{
			char fn_bc16[MAXPATH];
			char fn_bc32_1[MAXPATH], fn_bc32_2[MAXPATH];
			char fn_bc64[MAXPATH];

			make_data_file_name(fn_bc16, drive, dir, file, ".bft", "16");
			make_data_file_name(fn_bc32_1, drive, dir, file, ".bft", "32_1");
			make_data_file_name(fn_bc32_2, drive, dir, file, ".bft", "32_2");
			make_data_file_name(fn_bc64, drive, dir, file, ".bft", "64");
			// キャラクタデータの読み込み
			read_bfnt(fn_bc16, fn_bc32_1, fn_bc32_2, fn_bc64, NULL);
			// b-fontファイルからパレットデータを読む
			read_bfnt_palet(fn_bc16);
		}
#endif
		//	init_sprite();
		{	// ステージデータファイルのオープン(読み込みはその時々に応じて行う)
			char stage_file[MAXPATH];

			fnmerge(stage_file, drive, dir, file, ".stg");
			//		open_stage_file(stage_file);
		}
#if 00
		{
			char bgm_file[MAXPATH];

			fnmerge(bgm_file, drive, dir, file, "");
			fprintf(stderr, "reading music file(%s)\n", bgm_file);
			if (!music_load(bgm_file))
				fprintf(stderr, "initialize(): BGMファイルが読み込めません(%s)\n",
				bgm_file);
			fnmerge(bgm_file, drive, dir, file, "");
			fprintf(stderr, "reading sound file(%s)\n", bgm_file);
			if (!sound_load(bgm_file))
				fprintf(stderr, "initialize(): 効果音ファイルが読み込めません(%s)"
				"\n", bgm_file);
		}
#endif
		//	fnmerge(hi_score_file, drive, dir, file, ".scr");
		//	read_hi_score(hi_score_file);
	}



	// タイトル画面を表示する。
	// 戻り値：
	// 0:タイムアウト(デモに進む)
	// 1:1Pゲームが選択された
	// 2:2Pゲームが選択された
	// -1:プログラム終了が選択された
	int showTitleScreen();

	// ステージ番号選択画面
	// 戻り値：
	// 1～最終ステージ番号
	int showStageNumberScreen(const int stageNumber) {
		return 1;
	}

	// ステージ画面のヒトコマ(60FPS)を描く
	void showStageScreen() {
	}

	// ステージ終了後の結果画面を表示する
	void showStageResultScreen();

	// ゲームオーバー画面(画面に大きく"GAME OVER"と書かれているだけの画面)
	void showGameOverScreen() {
	}
};

