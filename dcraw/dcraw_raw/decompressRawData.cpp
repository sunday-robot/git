#include "decompressRawData.h"
#include "HuffBitBuffer.h"
#include "RawDecoder.h"

#define ABS(x) (((int)(x) ^ ((int)(x) >> 31)) - ((int)(x) >> 31))

#define RAW(row,col) \
	raw_image[(row)*width+(col)]


// (row, col)�̉�f�l�̗\���l���A��(row - 2, col)�A����(row -2, col - 2)�A��(row, col -2)�̉�f�l����v�Z����B
static int get_pred(unsigned short *raw_image, int width, int row, int col) {
	if (row < 2) {
		if (col < 2)
			return 0;	// �����2x2�̗̈�ɂ��Ă͎�|���肪�Ȃ��̂�0��Ԃ��B
		return  RAW(row, col - 2);	// ��̉�f�̒l��Ԃ��B
	}
	if (col < 2)
		return RAW(row - 2, col);	// ���̉�f�̒l��Ԃ��B
									// ��A����A���̉�f�̒l����\�z��f�l���v�Z����B
	int nw = RAW(row - 2, col - 2);	// north west, ����
	int n = RAW(row - 2, col);	// north, ��
	int w = RAW(row, col - 2);	// west,��
	int w_minus_nw = w - nw;
	int n_minus_nw = n - nw;
	int abs_w_minus_nw = ABS(w_minus_nw);
	int abs_n_minus_nw = ABS(n_minus_nw);
	if ((w_minus_nw < 0 && n_minus_nw > 0) || (n_minus_nw < 0 && w_minus_nw > 0)) {
		// nw��n��w�̒��Ԃł���ꍇ
		if (abs_w_minus_nw <= 32 && abs_n_minus_nw <= 32)
			return (w + n) / 2;	// 3�҂��߂��ꍇ�́Anw�͎g�p�����An��w�̒l�̕��ϒl��Ԃ��B
		return w + n - nw;	// 3�҂���������Ă���ꍇ�́A���̒l(�����ł����c)��Ԃ��B
	} else {
		// nw����ԑ傫�����A��ԏ������ꍇ�́An��w�̂����Anw�̑΋ɂɂ������Ԃ��B
		if (abs_w_minus_nw > abs_n_minus_nw)
			return  w;
		return n;
	}
}

void decompressRawData(int width, int height, const unsigned char *compressedRawImage, int compressedRawImageSize, unsigned short *decompressedRawImage) {
	HuffBitBuffer huffBitBuffer(compressedRawImage, compressedRawImageSize);
	for (int row = 0; row < height; row++) {
		RawDecoder rawDecoder[2] = { RawDecoder(huffBitBuffer), RawDecoder(huffBitBuffer) };
		for (int col = 0; col < width; col++) {
			int pred = get_pred(decompressedRawImage, width, row, col);	// ����A��A���̉�f�l����̗\���l
			int difference = rawDecoder[col & 1].getValue();	// �\���l�Ƃ̍���
			decompressedRawImage[row * width + col] = pred + difference;
		}
	}
}

