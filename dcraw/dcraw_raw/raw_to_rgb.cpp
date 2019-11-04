#include "raw_to_rgb.h"
#include <stdlib.h>
#include "BlackLevel.h"
#include "ColorMatrix.h"
#include "WbRbLevels.h"

#define MIN(a,b) ((a) < (b) ? (a) : (b))
#define MAX(a,b) ((a) > (b) ? (a) : (b))
#define LIM(x,min,max) MAX(min,MIN(x,max))
#define CLIP(x) LIM((int)(x),0,65535)
#define RAW(row,col) \
	raw_image[(row)*width+(col)]

// �w�肳�ꂽ��f���W����ACFA�̃C���f�b�N�X(0����3)��Ԃ��B
int fcol(int row, int col, const int exif_cfa[4])
{
	int r = row & 1;
	int c = col & 1;
	return exif_cfa[r * 2 + c];
}

// RAW�摜���A�S���⊮������RGB�摜�ɕϊ�����(�e�s�N�Z���ŋP�x�l���s��(��Ԃ��K�v��)�`�����l���ɂ��Ă�0�Ƃ���)
// R,G
// G,B
// ��
// R00, 0G0
// 0G0, 00B
void crop_masked_pixels(const unsigned short *raw_image, int width, int height, unsigned short(*image)[3])
{
	for (int row = 0; row < height; row += 2)
		for (int col = 0; col < width; col += 2) {
			image[row * width + col][0] = RAW(row, col);
			image[row * width + col + 1][1] = RAW(row, col + 1);
			image[(row + 1) * width + col][1] = RAW(row + 1, col);
			image[(row + 1) * width + col + 1][2] = RAW(row + 1, col + 1);
		}
}

//// �e�`�����l���̋P�x�l��0�`65535�ɕϊ�����
//// ���̎��A�P���ɕϊ�����̂ł͂Ȃ��A�e�`�����l���̃u���b�N���x���̓K�p�ƁApre_mul�̓K�p���s���B
//// preMul�́A�e�`�����l�����ƂɁA�L���Ȓl�悪�قȂ�(�Z���T�[�̊��x��G�ɍ��킹�Ă��邽�߂��A
//// R�͔������x�AB��2/3���x�̒l��ƂȂ��Ă���)�̂ŁA��������킹�邽�߂̌W���B
//void scale_colors(
//	unsigned short(*image)[3],				// RGB�摜(�������A�܂����Ԗ��߂����Ă��Ȃ����)
//	int width,								// �摜�̕�
//	int height,								// �摜�̍���
//	const struct RgbCoefficient *rgbCoefficient,	// RGB�e�P�x�l��0�`65535�ɐ��K�����邽�߂̌W������1
//	const struct BlackLevel *blackLevel)	// RGB�e�P�x�l��0�`65535�ɐ��K�����邽�߂̌W������2
//{
//	double kr;
//	double kg;
//	double kb;
//	{
//		kg = 65535.0 / (4095 - blackLevel->green);
//		kr = kg * rgbCoefficient->r / rgbCoefficient->g;
//		kb = kg * rgbCoefficient->b / rgbCoefficient->g;
//	}
//
//	int size = height * width;
//
//	for (int i = 0; i < size; i++) {
//		int v = image[i][0];
//		if (v != 0) {
//			v = (int)((v - blackLevel->red) * kr);
//			image[i][0] = CLIP(v);
//		}
//		v = image[i][1];
//		if (v != 0) {
//			v = (int)((v - blackLevel->green) * kg);
//			image[i][1] = CLIP(v);
//		}
//		v = image[i][2];
//		if (v != 0) {
//			v = (int)((v - blackLevel->blue) * kb);
//			image[i][2] = CLIP(v);
//		}
//	}
//}

void image_set_value(unsigned short(*image)[3], int width, int row, int col, int channel, int value) {
	int index = row * width + col;
	image[index][channel] = value;
}

int image_get_value(unsigned short(*image)[3], int width, int row, int col, int channel) {
	int index = row * width + col;
	int value = image[index][channel];
	return value;
}

// ��������P�x�l���A8�ߖT�̉�f�̋P�x�l�̕��ϒl�ɂ���Ƃ����A���ɒP���ȕ�Ԃ��s���B
// ���̕��@�ł́A�G�b�W�����ŐF��������Ƃ�����肪����B
void rggb_lin_interpolate(unsigned short(*image)[3], int width, int height)
{
	// bgbg
	// gRGr
	// bGBg
	// grgr

	// ____
	// _R_r
	// ____
	// _r_r

	// _g_g
	// g_G_
	// _G_g
	// g_g_

	// b_b_
	// ____
	// b_B_
	// ____
	for (int row = 2; row < height - 2; row += 2) {
		for (int col = 2; col < width - 2; col += 2) {
			int r;
			int g;
			int b;
			// (0, 0) Red�̋P�x�l�����Ȃ���f
			// Green�̒l�͏㉺���E�ɑ��݂���Green�݂̂̉�f�l�̕��ϒl���Z�b�g����B
			g = (image_get_value(image, width, row - 1, col, 1)			// N
				+ image_get_value(image, width, row, col - 1, 1)		// W
				+ image_get_value(image, width, row, col + 1, 1)		// E
				+ image_get_value(image, width, row + 1, col, 1)) / 4;	// S
			image_set_value(image, width, row, col, 1, g);
			// Blue�̒l�͎΂߂ɗאڂ���Blue�݂̂̉�f�̋P�x�l�̕��ϒl���Z�b�g����B
			b = (image_get_value(image, width, row - 1, col - 1, 2)			// NW
				+ image_get_value(image, width, row - 1, col + 1, 2)		// NE
				+ image_get_value(image, width, row + 1, col - 1, 2)		// SW
				+ image_get_value(image, width, row + 1, col + 1, 2)) / 4;	// SE
			image_set_value(image, width, row, col, 2, b);

			// (0, 1) Green�̋P�x�l�����Ȃ���f
			// Red�̒l�́A���E��Red�݂̂̉�f�̋P�x�l�̕��ϒl���Z�b�g����B
			r = (image_get_value(image, width, row, col, 0)					// W
				+ image_get_value(image, width, row, col + 2, 0)) / 2;		// E
			image_set_value(image, width, row, col + 1, 0, r);
			// Blue�̒l�͏㉺��Blue�݂̂̉�f�̋P�x�l�̕��ϒl���Z�b�g����B
			b = (image_get_value(image, width, row - 1, col + 1, 2)			// N
				+ image_get_value(image, width, row + 1, col + 1, 2)) / 2;	// S
			image_set_value(image, width, row, col + 1, 2, b);

			// (1, 0) Green�̋P�x�l�����Ȃ���f
			// Red�̒l�́A�㉺��Red�݂̂̉�f�̋P�x�l�̕��ϒl���Z�b�g����B
			r = (image_get_value(image, width, row, col, 0)					// N
				+ image_get_value(image, width, row + 2, col, 0)) / 2;		// S
			image_set_value(image, width, row + 1, col, 0, r);
			// Blue�̒l�͍��E��Blue�݂̂̉�f�̋P�x�l�̕��ϒl���Z�b�g����B
			b = (image_get_value(image, width, row + 1, col - 1, 2)			// W
				+ image_get_value(image, width, row + 1, col + 1, 2)) / 2;	// E
			image_set_value(image, width, row + 1, col, 2, b);

			// (1, 1) Blue�̋P�x�l�����Ȃ���f
			// Red�̒l�͎΂߂ɗאڂ���Red�݂̂̉�f�̋P�x�l�̕��ϒl���Z�b�g����B
			r = (image_get_value(image, width, row, col, 0)					// NW
				+ image_get_value(image, width, row, col + 2, 0)			// NE
				+ image_get_value(image, width, row + 2, col, 0)			// SW
				+ image_get_value(image, width, row + 2, col + 2, 0)) / 4;	// SE
			image_set_value(image, width, row + 1, col + 1, 0, r);
			// Green�̒l�͏㉺���E�ɑ��݂���Green�݂̂̉�f�l�̕��ϒl���Z�b�g����B
			g = (image_get_value(image, width, row, col + 1, 1)				// N
				+ image_get_value(image, width, row + 1, col, 1)			// W
				+ image_get_value(image, width, row + 1, col + 2, 1)		// E
				+ image_get_value(image, width, row + 2, col + 1, 1)) / 4;	// S
			image_set_value(image, width, row + 1, col + 1, 1, g);
		}
	}
}

/*

*/
void rggb_interpolate2(unsigned short(*image)[3], int width, int height)
{
	for (int row = 0; row < height; row += 2) {
		for (int col = 0; col < width; col += 2) {
			int r = image_get_value(image, width, row, col, 0);
			int g1 = image_get_value(image, width, row, col + 1, 1);
			int g2 = image_get_value(image, width, row + 1, col, 1);
			int b = image_get_value(image, width, row + 1, col + 1, 2);

			image_set_value(image, width, row, col, 1, g1);
			image_set_value(image, width, row, col, 2, b);

			image_set_value(image, width, row, col + 1, 0, r);
			image_set_value(image, width, row, col + 1, 2, b);

			image_set_value(image, width, row + 1, col, 0, r);
			image_set_value(image, width, row + 1, col, 2, b);

			image_set_value(image, width, row + 1, col + 1, 0, r);
			image_set_value(image, width, row + 1, col + 1, 1, g2);
		}
	}
}

void matrix_vector_multiply(const double m[3][3], const unsigned short v[3], double w[3]) {
	for (int i = 0; i < 3; i++) {
		double x = 0;
		for (int j = 0; j < 3; j++) {
			x += m[i][j] * v[j];
		}
		w[i] = x;
	}
}

void convert_to_rgb(unsigned short(*image)[3], int width, int height, const ColorMatrix *colorMatrix)
{
	unsigned short *img;

	img = image[0];
	for (int row = 0; row < height; row++)
		for (int col = 0; col < width; col++, img += 3) {
			colorMatrix->transForm(img);
		}
}

void normalizeIntensity(unsigned short *intensity, int k0, double k1) {
	if (*intensity <= k0) {
		*intensity = 0;
	} else {
		int v = (int)((*intensity - k0) * k1);
		if (v > 65535) {
			*intensity = 65535;
		} else {
			*intensity = v;
		}
	}
}

// �P�x�l�𐳋K��(0-65535��)����
void normalizeIntensity(
	unsigned short *raw_image,
	int width,
	int height,
	const struct BlackLevel *blackLevel,
	double kr,
	double kb) {
	double kr2 = kr * 65535.0 / (4095 - blackLevel->red);
	double kg2 = 65535.0 / (4095 - blackLevel->green);
	double kb2 = kb * 65535.0 / (4095 - blackLevel->blue);
	for (int row = 0; row < height; row += 2) {
		for (int col = 0; col < width; col += 2) {
			normalizeIntensity(&raw_image[row * width + col], blackLevel->red, kr2);
			normalizeIntensity(&raw_image[row * width + col + 1], blackLevel->green, kg2);
			normalizeIntensity(&raw_image[(row + 1) * width + col], blackLevel->green2, kg2);
			normalizeIntensity(&raw_image[(row + 1) * width + col + 1], blackLevel->blue, kb2);
		}
	}
}

void convertRawToRgbImage(
	unsigned short *rawImage,				// RAW�摜�f�[�^
	int width,								// �摜�̕�
	int height,								// �摜�̍���
	const struct BlackLevel *blackLevel,	// 
	const ColorMatrix *colorMatrix,
	unsigned short(**rgbImage)[3]) {		// out RGB�摜�f�[�^
	*rgbImage = (unsigned short(*)[3]) calloc(height * width, sizeof(unsigned short[3]));

	// normalizeIntensity(rawImage, width, height, blackLevel, 2, 1.5);
	normalizeIntensity(rawImage, width, height, blackLevel, 1.5, 1.25);

	crop_masked_pixels(rawImage, width, height, *rgbImage);
	// scale_colors(*rgbImage, width, height, rgbCoefficient, blackLevel);
	// rggb_lin_interpolate(*rgbImage, width, height);
	rggb_interpolate2(*rgbImage, width, height);
	convert_to_rgb(*rgbImage, width, height, colorMatrix);
}
