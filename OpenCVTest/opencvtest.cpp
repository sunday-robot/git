#include <cv.h>
#include <highgui.h>
#include <stdio.h>
#include <tchar.h>

// 画像をズームする。
// あまり厳密なものではない。
// srcImage...原画像
// dstImage...出力画像(縦横の画素数は原画像と同じ)
// zoomRate...ズーム倍率(1.0以上)
void zoom(IplImage *srcImage, IplImage *dstImage, double zoomRate) {

	// 原画像でのズーム対象領域を求める(対象領域は整数座標、整数サイズなので厳密なズーム処理とは言えない)
	CvRect zoomRect;
	zoomRect.width = (int) (srcImage->width / zoomRate);
	zoomRect.height = (int) (srcImage->height / zoomRate);
	zoomRect.x = (srcImage->width - zoomRect.width) / 2;
	zoomRect.y = (srcImage->height - zoomRect.height) / 2;
	CvMat subImage;
	cvGetSubRect(srcImage, &subImage, zoomRect);

	// ズーム処理
	cvResize(&subImage, dstImage);
}

// 画像をぼかす。
// srcImage...原画像
// dstImage...出力画像(縦横の画素数は原画像と同じ)
// level...レベル(0以上。0の場合、変換を行わない。)
void unsharp(IplImage *srcImage, IplImage *dstImage, double level) {
	// カーネルを作る
	CvMat *kernel = cvCreateMat(3, 3, CV_64F);
	double a = 1 + (8 * level) / 9;	// 中心画素の重み
	double b = -level / 9;	// 周辺画素の重み
	double kernelData[3 * 3] = {b, b, b, b, a, b, b, b, b};
	cvSetData(kernel, kernelData, 3 * sizeof(double));

	// カーネル適用
	cvFilter2D(srcImage, dstImage, kernel);

	cvReleaseMat(&kernel);
}

// ガンマ補正を行う
// srcImage...原画像
// dstImage...出力画像(縦横の画素数は原画像と同じ)
// gamma...ガンマ値(0の場合、変換を行わない。)
void gammaCorrection(IplImage *srcImage, IplImage *dstImage, double gamma) {
	// ガンマ補正用のLUTを作る
	CvMat *lut = cvCreateMat(1, 256, CV_8UC1);
	double gm = 1 / gamma;
	for (int i = 0; i < 256; i++) {
		lut->data.ptr[i] = (unsigned char) (pow(i / 255.0, gm) * 255);
	}

	// LUTを適用
	cvLUT(srcImage, dstImage, lut);

	cvReleaseMat(&lut);
}

void cameraFilter(IplImage *srcImage, double zoomRate, double sharpnessLevel, double contrastLevel, double gamma) {
	// 作業用画像の準備
	CvSize cvSize = {srcImage->width, srcImage->height};
	IplImage *work = cvCreateImage(cvSize, srcImage->depth, srcImage->nChannels);

	zoom(srcImage, work, zoomRate);

	unsharp(work, srcImage, sharpnessLevel);

	gammaCorrection(srcImage, work, gamma);

	// 作業用画像を原画像に上書き
	cvCopy(work, srcImage);

	cvReleaseImage(&work);
}

// グレイスケール画像を生成する。
// srcImage...原画像
// dstImage...出力画像(縦横の画素数は原画像と同じ)
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
