#include "bcty.h"
#include "pat.h"
#include "TankType.h"

/* 1.戦車のスピード
 * 2.戦車の堅さ(何発弾が当たったら破壊されるか?)
 * 3.撃てる弾の数
 * 4.弾のスピード
 * 5.弾の威力(0なら通常,1なら威力があってブロックを一発で壊せる)
 * 6.戦車のグラフィックパターンのナンバー
 * 7.プレイヤーの戦車なら次の戦車の種類,敵なら点数
 * 8.敵戦車が弾を撃つ確率
 * 9.敵戦車が方向を変更する確率(の逆数)3つ(進行方向に何もない、レンガ、
 *   コンクリートの壁あるいは川)
 */

// プレイヤー１
PlayerTankType player1Tank4(3, 1, 2, 8, 1, PAT_PLAYER1_TANK + 12, 0);
PlayerTankType player1Tank3(3, 1, 2, 8, 0, PAT_PLAYER1_TANK + 8, &player1Tank4);
PlayerTankType player1Tank2(3, 1, 1, 8, 0, PAT_PLAYER1_TANK + 4, &player1Tank3);
PlayerTankType player1Tank1(3, 1, 1, 4, 0, PAT_PLAYER1_TANK, &player1Tank2);

// プレイヤー２
PlayerTankType player2Tank4(3, 1, 2, 8, 1, PAT_PLAYER2_TANK + 12, 0);
PlayerTankType player2Tank3(3, 1, 2, 8, 0, PAT_PLAYER2_TANK + 8, &player2Tank4);
PlayerTankType player2Tank2(3, 1, 1, 8, 0, PAT_PLAYER2_TANK + 4, &player2Tank3);
PlayerTankType player2Tank1(3, 1, 1, 4, 0, PAT_PLAYER2_TANK, &player2Tank2);

// コンピュータ
static int dirChangeRate[] = {128, 16, 2};
ComputerTankType computerTankTypeA(2, 1, 1, 4, 0, PAT_COMP_TANK, 0, 32, dirChangeRate);
ComputerTankType computerTankTypeB(4, 1, 1, 4, 0, PAT_COMP_TANK + 8, 1, 32, dirChangeRate);
ComputerTankType computerTankTypeC(2, 1, 1, 8, 0, PAT_COMP_TANK + 16, 2, 16, dirChangeRate);
ComputerTankType computerTankTypeD(2, 4, 1, 4, 0, PAT_COMP_TANK + 24, 3, 32, dirChangeRate);
