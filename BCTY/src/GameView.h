#pragma once

// GameView�N���X
// GameView�́AGameModel�ɑΉ�����View�ł���B
// �ڍׂ�GameModel�̃R�����g���Q�Ƃ̂��ƁB

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

		// ������
		initialize(argv0);

		// ���C�����[�v(�������[�v)
		for (;;) {
			int gameMode;	// 0:�f���A1:��l�v���C�A2:��l�v���C
			int stageNumber;
			int endCode;
			for (;;) {
				// �^�C�g�����
				gameMode = showTitleScreen();
				if (gameMode != 0)
					break;
				model->startGame(gameMode == 2);
				// �f����ʂ̏ꍇ�̓X�e�[�W�ԍ���ʂ͕\�����Ȃ�
				stageNumber = (rand() % model->getMaximumStageNumber()) + 1;
				model->startStage(stageNumber);
				while (model->tick() == 0)
					showStageScreen();	// �X�e�[�W��ʂ̃q�g�R�}(60FPS)��`��
			}
			switch (gameMode) {
			case 1:
			case 2:
				stageNumber = showStageNumberScreen(1);
				break;
			default:
				return;	// �v���O�����I�����I�����ꂽ
			}

			for (;;) {
				model->startStage(stageNumber);
				while ((endCode = model->tick()) == 0)
					showStageScreen();	// �X�e�[�W��ʂ̃q�g�R�}(60FPS)��`��
				if (endCode != STAGE_CLEAR) {
					break;
				}
				showStageResultScreen();	// �X�e�[�W�N���A���
				stageNumber = showStageNumberScreen(stageNumber++);
			}
			switch (endCode) {
			case EXIT_GAME:
				return;	// �Q�[��(�v���O����)�I��
			case GAME_OVER:
				showStageResultScreen();	// �X�e�[�W�N���A���
				showGameOverScreen();	// �Q�[���I�[�o�[���(��ʂɑ傫��"GAME OVER"�Ə�����Ă��邾���̉��)
				break;
			}
		}
	}

private:
	void initialize(const char *argv0) {
		char drive[MAXDRIVE], dir[MAXDIR], file[MAXFILE], ext[MAXEXT];

		fnsplit(argv0, drive, dir, file, ext);

#if 00
		// �I�����֐��̓o�^
		atexit(finish);
		{	// �t�H���g�̓ǂݍ���
			char font_file[MAXPATH];
			int r;

			fnmerge(font_file, drive, dir, file, ".bft");
			fprintf(stderr, "reading %s\n", font_file);
			if ((r = gfLoad(font_file, 0)) != OK) {
				fprintf(stderr, "initilize(): font �t�@�C�����ǂݍ��߂܂��� %s\n",
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
			// �L�����N�^�f�[�^�̓ǂݍ���
			read_bfnt(fn_bc16, fn_bc32_1, fn_bc32_2, fn_bc64, NULL);
			// b-font�t�@�C������p���b�g�f�[�^��ǂ�
			read_bfnt_palet(fn_bc16);
		}
#endif
		//	init_sprite();
		{	// �X�e�[�W�f�[�^�t�@�C���̃I�[�v��(�ǂݍ��݂͂��̎��X�ɉ����čs��)
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
				fprintf(stderr, "initialize(): BGM�t�@�C�����ǂݍ��߂܂���(%s)\n",
				bgm_file);
			fnmerge(bgm_file, drive, dir, file, "");
			fprintf(stderr, "reading sound file(%s)\n", bgm_file);
			if (!sound_load(bgm_file))
				fprintf(stderr, "initialize(): ���ʉ��t�@�C�����ǂݍ��߂܂���(%s)"
				"\n", bgm_file);
		}
#endif
		//	fnmerge(hi_score_file, drive, dir, file, ".scr");
		//	read_hi_score(hi_score_file);
	}



	// �^�C�g����ʂ�\������B
	// �߂�l�F
	// 0:�^�C���A�E�g(�f���ɐi��)
	// 1:1P�Q�[�����I�����ꂽ
	// 2:2P�Q�[�����I�����ꂽ
	// -1:�v���O�����I�����I�����ꂽ
	int showTitleScreen();

	// �X�e�[�W�ԍ��I�����
	// �߂�l�F
	// 1�`�ŏI�X�e�[�W�ԍ�
	int showStageNumberScreen(const int stageNumber) {
		return 1;
	}

	// �X�e�[�W��ʂ̃q�g�R�}(60FPS)��`��
	void showStageScreen() {
	}

	// �X�e�[�W�I����̌��ʉ�ʂ�\������
	void showStageResultScreen();

	// �Q�[���I�[�o�[���(��ʂɑ傫��"GAME OVER"�Ə�����Ă��邾���̉��)
	void showGameOverScreen() {
	}
};

