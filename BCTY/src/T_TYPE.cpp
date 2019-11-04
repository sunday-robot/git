#include "bcty.h"
#include "pat.h"
#include "TankType.h"

/* 1.��Ԃ̃X�s�[�h
 * 2.��Ԃ̌���(�����e������������j�󂳂�邩?)
 * 3.���Ă�e�̐�
 * 4.�e�̃X�s�[�h
 * 5.�e�̈З�(0�Ȃ�ʏ�,1�Ȃ�З͂������ău���b�N���ꔭ�ŉ󂹂�)
 * 6.��Ԃ̃O���t�B�b�N�p�^�[���̃i���o�[
 * 7.�v���C���[�̐�ԂȂ玟�̐�Ԃ̎��,�G�Ȃ�_��
 * 8.�G��Ԃ��e�����m��
 * 9.�G��Ԃ�������ύX����m��(�̋t��)3��(�i�s�����ɉ����Ȃ��A�����K�A
 *   �R���N���[�g�̕ǂ��邢�͐�)
 */

// �v���C���[�P
PlayerTankType player1Tank4(3, 1, 2, 8, 1, PAT_PLAYER1_TANK + 12, 0);
PlayerTankType player1Tank3(3, 1, 2, 8, 0, PAT_PLAYER1_TANK + 8, &player1Tank4);
PlayerTankType player1Tank2(3, 1, 1, 8, 0, PAT_PLAYER1_TANK + 4, &player1Tank3);
PlayerTankType player1Tank1(3, 1, 1, 4, 0, PAT_PLAYER1_TANK, &player1Tank2);

// �v���C���[�Q
PlayerTankType player2Tank4(3, 1, 2, 8, 1, PAT_PLAYER2_TANK + 12, 0);
PlayerTankType player2Tank3(3, 1, 2, 8, 0, PAT_PLAYER2_TANK + 8, &player2Tank4);
PlayerTankType player2Tank2(3, 1, 1, 8, 0, PAT_PLAYER2_TANK + 4, &player2Tank3);
PlayerTankType player2Tank1(3, 1, 1, 4, 0, PAT_PLAYER2_TANK, &player2Tank2);

// �R���s���[�^
static int dirChangeRate[] = {128, 16, 2};
ComputerTankType computerTankTypeA(2, 1, 1, 4, 0, PAT_COMP_TANK, 0, 32, dirChangeRate);
ComputerTankType computerTankTypeB(4, 1, 1, 4, 0, PAT_COMP_TANK + 8, 1, 32, dirChangeRate);
ComputerTankType computerTankTypeC(2, 1, 1, 8, 0, PAT_COMP_TANK + 16, 2, 16, dirChangeRate);
ComputerTankType computerTankTypeD(2, 4, 1, 4, 0, PAT_COMP_TANK + 24, 3, 32, dirChangeRate);
