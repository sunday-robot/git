#pragma once

#include "BCTY.H"

struct VvramCell {
	unsigned char type;
	unsigned char pat;	// �����K���L�̂��̂ł���B�����K�̏ꍇ�A��Ԃ̖C�e�Ŕj�󂷂邱�Ƃ��ł��邪�A1�̉�(16x16�h�b�g)����x�ɉ���̂ł͂Ȃ��A����1/4�̍X�ɏ����ȉ�(8x8�h�b�g)������P�ʂɂȂ��Ă���B���̏����ȉ򂪂ǂ̒��x�c���Ă���̂��������r�b�g�}�b�v�ɂȂ��Ă���B���オ1�A�E�オ2�A������4�A�E����8�ł���B
};

struct Vvram {
	VvramCell cells[STAGE_SIZE][STAGE_SIZE];
};

