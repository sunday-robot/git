#pragma once

// GameModelは、以下に示す、プログラムの大枠となる状態を制御する。
// ・プログラム起動時の初期化処理
// ・タイトル画面
// ・ステージセレクト画面
// ・ステージプレイ画面
// ・ゲームオーバー画面
// ・ハイスコア画面
// GameModelは、UIは持たない。UIを担当するのは本クラスのユーザーであるGameViewが担当する。

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
	// プログラム実行中保持しておかなければならないデータ
	int highScore;

	// ゲーム中(startボタンで開始してからゲームオーバーになるまで)保持しておかなければならないデータ
	bool _is2pMode;	// 2Pモードか否(1Pモード)か
	int scores[2];	// 各プレイヤーのスコア

	// 1ステージ中保持しておかなければならないデータ
	int end_flg;
	int end_count;
	int player_destroyed;
	EndCode end_code;
	PlayerTank playerTanks[2];

	ComputerTank computerTanks[20];	// 20も必要ない
	Tank *tanks[20];	// これはプレイヤー戦車、コンピューター戦車のリストだが、必要ないか、見直しが必要

	int computerTankCount;		// 現在ステージに登場しているコンピューターの戦車の数)
	int nextComputerTankIndex;	// 次に登場するコンピューター戦車のインデックス

	int comp_tank_generate_interval;	// 敵戦車の出現間隔のカウンタ
	int comp_tanks[20];			// 敵戦車の登場スケジュール
//	ComputerTankAppearanceOrder 

	int maximumTankCount() {	// ステージ上に登場する戦車(プレイヤー+コンピューター)の最大数(1Pモードと2Pモードで異なっている。)
		if (_is2pMode)
			return 4;	// 数はデタラメ
		else
			return 3;	// 数はデタラメ
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

	// ゲームを開始する
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
			this->playerTanks[1].initialize(false);	// 2P側をGameOver状態
			////			set_joy_assign(JA_1P);
		}
	}

	// 1ステージを開始する
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
					// 死んでいて、残りがあるなら、戦車を登場させる
					t->spawn(
						player_tank_position[i].x,
						player_tank_position[i].y, 2,
						*(t->getTankType()));
					t->leftTankCount--;
					//						print_rest_player_tank(i, );
				}
				break;
			case DEAD3:			// 今死んだところ
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
			default:			// その他
				printf("game():	control_tank()の戻り値が異常です"
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
				// コンピューターの戦車の場合
				if (nextComputerTankIndex < 20 && comp_tank_generate_interval >= GENERATE_INTERVAL) {
					// 死んでいて、控えの戦車があり、前のを登場させてから
					// 充分な時間が経っていたら、登場させる
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
			case DEAD3:			// 今死んだところ
				if (--computerTankCount == 0) {
					if (nextComputerTankIndex == 20) {
						// 終了カウンタをスタートさせる
						end_count++;
					}
				}
				break;
			default:			// その他
				printf("game():	control_tank()の戻り値が異常です"
					" i = %d, r = %d\n", i, r);
			}
		}
		comp_tank_generate_interval++;
		ComputerTank::control_comp_tank_pararize_timer();
		// アイテム、司令部の処理
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
		// PAUSE の処理
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
				} else if (get_quit_key()) {	// 'q'キーが押されたら強制終了
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

#if 0	// ステージ開始時の処理の一部
	// 戦車のリセット（みんな死んだ状態にする）
	reset_tanks();
#endif

#if 0 // ゲーム開始時の処理の一部
	// 撃墜数の初期化
	for (i = 0; i < 2; i++)
		for (j = 0; j < 5; j ++)
			hits[i].num[j] = 0;
#endif

};
