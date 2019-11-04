#include <cv.h>
#include <highgui.h>
#include <stdio.h>
#include <tchar.h>

// �摜���Y�[������B
// ���܂茵���Ȃ��̂ł͂Ȃ��B
// srcImage...���摜
// dstImage...�o�͉摜(�c���̉�f���͌��摜�Ɠ���)
// zoomRate...�Y�[���{��(1.0�ȏ�)
void zoom(IplImage *srcImage, IplImage *dstImage, double zoomRate) {

	// ���摜�ł̃Y�[���Ώۗ̈�����߂�(�Ώۗ̈�͐������W�A�����T�C�Y�Ȃ̂Ō����ȃY�[�������Ƃ͌����Ȃ�)
	CvRect zoomRect;
	zoomRect.width = (int) (srcImage->width / zoomRate);
	zoomRect.height = (int) (srcImage->height / zoomRate);
	zoomRect.x = (srcImage->width - zoomRect.width) / 2;
	zoomRect.y = (srcImage->height - zoomRect.height) / 2;
	CvMat subImage;
	cvGetSubRect(srcImage, &subImage, zoomRect);

	// �Y�[������
	cvResize(&subImage, dstImage);
}

// �摜���ڂ����B
// srcImage...���摜
// dstImage...�o�͉摜(�c���̉�f���͌��摜�Ɠ���)
// level...���x��(0�ȏ�B0�̏ꍇ�A�ϊ����s��Ȃ��B)
void unsharp(IplImage *srcImage, IplImage *dstImage, double level) {
	// �J�[�l�������
	CvMat *kernel = cvCreateMat(3, 3, CV_64F);
	double a = 1 + (8 * level) / 9;	// ���S��f�̏d��
	double b = -level / 9;	// ���Ӊ�f�̏d��
	double kernelData[3 * 3] = {b, b, b, b, a, b, b, b, b};
	cvSetData(kernel, kernelData, 3 * sizeof(double));

	// �J�[�l���K�p
	cvFilter2D(srcImage, dstImage, kernel);

	cvReleaseMat(&kernel);
}

// �K���}�␳���s��
// srcImage...���摜
// dstImage...�o�͉摜(�c���̉�f���͌��摜�Ɠ���)
// gamma...�K���}�l(0�̏ꍇ�A�ϊ����s��Ȃ��B)
void gammaCorrection(IplImage *srcImage, IplImage *dstImage, double gamma) {
	// �K���}�␳�p��LUT�����
	CvMat *lut = cvCreateMat(1, 256, CV_8UC1);
	double gm = 1 / gamma;
	for (int i = 0; i < 256; i++) {
		lut->data.ptr[i] = (unsigned char) (pow(i / 255.0, gm) * 255);
	}

	// LUT��K�p
	cvLUT(srcImage, dstImage, lut);

	cvReleaseMat(&lut);
}

void cameraFilter(IplImage *srcImage, double zoomRate, double sharpnessLevel, double contrastLevel, double gamma) {
	// ��Ɨp�摜�̏���
	CvSize cvSize = {srcImage->width, srcImage->height};
	IplImage *work = cvCreateImage(cvSize, srcImage->depth, srcImage->nChannels);

	zoom(srcImage, work, zoomRate);

	unsharp(work, srcImage, sharpnessLevel);

	gammaCorrection(srcImage, work, gamma);

	// ��Ɨp�摜�����摜�ɏ㏑��
	cvCopy(work, srcImage);

	cvReleaseImage(&work);
}

// �O���C�X�P�[���摜�𐶐�����B
// srcImage...���摜
// dstImage...�o�͉摜(�c���̉�f���͌��摜�Ɠ���)
void createGrayImage(IplImage *srcImage, IplImage *dstImage) {
	IplImage *grayImage = cvCreateImage(cvSize(srcImage->width, srcImage->height), 8, 1);
	cvConvertImage(srcImage, grayImage);
}

void test() {
	IplImage *colorImage = cvLoadImage("test.png");

	cameraFilter(colorImage, 1.0, 1.0, 0, 1);

	cvSaveImage("colorfiltered.png", colorImage);

	cvReleaseImage(&colorImage);
}

//#define L 11
//
//void p(unsigned char *buf, int width, int height) {
//	for (int y = 0; y < height; y++) {
//		for (int x = 0; x < width; x++) {
//			printf("%02x ", buf[x + width * y]);
//		}
//		printf("\n");
//	}
//	printf("\n");
//}
//
//void test2() {
//	unsigned char *buf = (unsigned char *) calloc(L * L, 1);
//	for (int i = 0; i < L; i++) {
//		buf[i + i *L] = 255 * i / (L - 1);
//	}
//	p(buf, L, L);
//	cameraFilter(buf, L, L, 1, 0, 1, 2);
//	p(buf, L, L);
//	getchar();
//}

int _tmain(int argc, _TCHAR* argv[]) {
	test();

	return 0;
}
