#pragma once

// GameModel�́A�ȉ��Ɏ����A�v���O�����̑�g�ƂȂ��Ԃ𐧌䂷��B
// �E�v���O�����N�����̏���������
// �E�^�C�g�����
// �E�X�e�[�W�Z���N�g���
// �E�X�e�[�W�v���C���
// �E�Q�[���I�[�o�[���
// �E�n�C�X�R�A���
// GameModel�́AUI�͎����Ȃ��BUI��S������͖̂{�N���X�̃��[�U�[�ł���GameView���S������B

#include "TANK.H"
#include "PlayerTank.h"
#include "ComputerTank.h"
#include "PILOT.H"
#include "TankType.h"

#include <ctype.h>

enum EndCode {STAGE_CLEAR, GAME_OVER, EXIT_GAME, DEMO_END};

extern Point player_tank_position[2];
extern Point init_comp_tank_position[3];

class GameModel {
private:
	// �v���O�������s���ێ����Ă����Ȃ���΂Ȃ�Ȃ��f�[�^
	int highScore;

	// �Q�[����(start�{�^���ŊJ�n���Ă���Q�[���I�[�o�[�ɂȂ�܂�)�ێ����Ă����Ȃ���΂Ȃ�Ȃ��f�[�^
	bool _is2pMode;	// 2P���[�h����(1P���[�h)��
	int scores[2];	// �e�v���C���[�̃X�R�A

	// 1�X�e�[�W���ێ����Ă����Ȃ���΂Ȃ�Ȃ��f�[�^
	int end_flg;
	int end_count;
	int player_destroyed;
	EndCode end_code;
	PlayerTank playerTanks[2];

	ComputerTank computerTanks[20];	// 20���K�v�Ȃ�
	Tank *tanks[20];	// ����̓v���C���[��ԁA�R���s���[�^�[��Ԃ̃��X�g�����A�K�v�Ȃ����A���������K�v

	int computerTankCount;		// ���݃X�e�[�W�ɓo�ꂵ�Ă���R���s���[�^�[�̐�Ԃ̐�)
	int nextComputerTankIndex;	// ���ɓo�ꂷ��R���s���[�^�[��Ԃ̃C���f�b�N�X

	int comp_tank_generate_interval;	// �G��Ԃ̏o���Ԋu�̃J�E���^
	int comp_tanks[20];			// �G��Ԃ̓o��X�P�W���[��
//	ComputerTankAppearanceOrder 

	int maximumTankCount() {	// �X�e�[�W��ɓo�ꂷ����(�v���C���[+�R���s���[�^�[)�̍ő吔(1P���[�h��2P���[�h�ňقȂ��Ă���B)
		if (_is2pMode)
			return 4;	// ���̓f�^����
		else
			return 3;	// ���̓f�^����
	}

public:
	GameModel() {
		highScore = 0;

		tanks[0] = (Tank *) &playerTanks[0];
		tanks[1] = (Tank *) &playerTanks[1];
		for (int i = 0; i < 20; i++) {
			tanks[2 + i] = (Tank *) &computerTanks[i];
		}
	}

	// �Q�[�����J�n����
	void startGame(const bool is2pMode) {
		_is2pMode = is2pMode;
		scores[0] = 0;
		scores[1] = 0;

		if (this->_is2pMode) {
			this->playerTanks[0].initialize(true);
			this->playerTanks[1].initialize(true);
			////			set_joy_assign(JA_2P);
		} else {
			this->playerTanks[0].initialize(true);
			this->playerTanks[1].initialize(false);	// 2P����GameOver���
			////			set_joy_assign(JA_1P);
		}
	}

	// 1�X�e�[�W���J�n����
	void startStage(const int stageNumber) {
		computerTankCount = 0;
		nextComputerTankIndex = 0;
		comp_tank_generate_interval = GENERATE_INTERVAL / 2;
		end_code = STAGE_CLEAR;
		end_flg = 0;
		end_count = 0;
	}

	bool is2pMode() const {return _is2pMode;}

	int getHighScore() {
		return highScore;
	}

	int getMaximumStageNumber() {
		return 10;
	}

	int getLeftComputerTankCount() const {
		return 20 - nextComputerTankIndex;
	}

	static void getComputerTankTypeAndItemFlag(int computerTankSymbol, const ComputerTankType **computerTankType, bool *hasItem) {
		int type = tolower(computerTankSymbol);
		*hasItem = isupper(computerTankSymbol) ? true : false;
		switch (type) {
		case 'A':
			*computerTankType = &computerTankTypeA;
			break;
		case 'B':
			*computerTankType = &computerTankTypeB;
			break;
		case 'C':
			*computerTankType = &computerTankTypeC;
			break;
		default:
			*computerTankType = &computerTankTypeD;
		}
	}

	bool tick() {
		int r;
		int i;
		for (i = 0; i < 2; i++) {
			PlayerTank *t = &playerTanks[i];
			r = t->control_tank();
			switch (r) {
			case BORN:
			case ALIVE:
			case BURST:
			case DISP_POINT:
			case DEAD2:
				break;
			case DEAD:
				if (t->leftTankCount > 0) {
					// ����ł��āA�c�肪����Ȃ�A��Ԃ�o�ꂳ����
					t->spawn(
						player_tank_position[i].x,
						player_tank_position[i].y, 2,
						*(t->getTankType()));
					t->leftTankCount--;
					//						print_rest_player_tank(i, );
				}
				break;
			case DEAD3:			// �����񂾂Ƃ���
				if (t->leftTankCount == 0) {
					player_destroyed |= 1 << i;
					if (player_destroyed == 3) {
////						game_over_message(3);
						end_code = GAME_OVER;
						end_count++;
					} ////else
////						game_over_message(1 << i);
				}
				break;
			default:			// ���̑�
				printf("game():	control_tank()�̖߂�l���ُ�ł�"
					" i = %d, r = %d\n", i, r);
			}
		}
			
		for (int i = 0; i < 20; i++) {
			ComputerTank *t = &computerTanks[i];
			r = t->control_tank();
			switch (r) {
			case BORN:
			case ALIVE:
			case BURST:
			case DISP_POINT:
			case DEAD2:
				break;
			case DEAD:
				// �R���s���[�^�[�̐�Ԃ̏ꍇ
				if (nextComputerTankIndex < 20 && comp_tank_generate_interval >= GENERATE_INTERVAL) {
					// ����ł��āA�T���̐�Ԃ�����A�O�̂�o�ꂳ���Ă���
					// �[���Ȏ��Ԃ��o���Ă�����A�o�ꂳ����
					const ComputerTankType *ctt;
					bool hasItem;
					getComputerTankTypeAndItemFlag(comp_tanks[nextComputerTankIndex], &ctt, &hasItem);
					t->spawn(
						init_comp_tank_position[nextComputerTankIndex % 3].x,
						init_comp_tank_position[nextComputerTankIndex % 3].y,
						0,
						*ctt, hasItem);
					nextComputerTankIndex++;
					//						print_rest_comp_tank(20 - ++comp_tank_index);
					comp_tank_generate_interval = 0;
				}
				break;
			case DEAD3:			// �����񂾂Ƃ���
				if (--computerTankCount == 0) {
					if (nextComputerTankIndex == 20) {
						// �I���J�E���^���X�^�[�g������
						end_count++;
					}
				}
				break;
			default:			// ���̑�
				printf("game():	control_tank()�̖߂�l���ُ�ł�"
					" i = %d, r = %d\n", i, r);
			}
		}
		comp_tank_generate_interval++;
		ComputerTank::control_comp_tank_pararize_timer();
		// �A�C�e���A�i�ߕ��̏���
		item.control_item();
		if (base.control_base() == DEAD3) {
////			game_over_message(3);
			end_code = GAME_OVER;
			end_count++;
		}
////		ctrl_game_over_message();

		if (end_count) {
			if (++end_count > MAX_END_COUNT)
				end_flg = 1;
		}
		// PAUSE �̏���
#if 0
		if (get_esc_key()) {
#if !defined(PROF)
			sound_out(EFS_PAUSE);
#endif
			pause_message(1);
			while (1) {
				if (get_esc_key()) {
#if !defined(PROF)
					sound_out(EFS_PAUSE);
#endif
					break;
				} else if (get_quit_key()) {	// 'q'�L�[�������ꂽ�狭���I��
					end_flg = 1;
					end_code = EXIT_GAME;
					break;
				}
			}
			pause_message(0);
		}
#endif
		return end_flg != 0;
	}

	int getLeftTankCount(int playerIndex) const {
		return this->playerTanks[playerIndex].leftTankCount;
	}

	void getLastScores(int ls[2]) const {
		ls[0] = scores[0];
		ls[1] = scores[1];
	}

	EndCode getEndCode() {
		return end_code;
	}

#if 0	// �X�e�[�W�J�n���̏����̈ꕔ
	// ��Ԃ̃��Z�b�g�i�݂�Ȏ��񂾏�Ԃɂ���j
	reset_tanks();
#endif

#if 0 // �Q�[���J�n���̏����̈ꕔ
	// ���Đ��̏�����
	for (i = 0; i < 2; i++)
		for (j = 0; j < 5; j ++)
			hits[i].num[j] = 0;
#endif

};
