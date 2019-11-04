package io;

import org.opencv.core.Core;
import org.opencv.core.CvType;
import org.opencv.core.Mat;
import org.opencv.highgui.Highgui;

/**
 * 輝度値が0.0～1.0のdouble型の画像を8bit画像に変換しファイルにセーブする。
 */
public class Saver {
    static {
	System.loadLibrary(Core.NATIVE_LIBRARY_NAME);
    }

    /**
     * @param m
     *            double型画像データ
     * @param filePath
     *            ファイルパス
     */
    public static void execute(Mat m, String filePath) {
	Mat bm = new Mat();
	m.convertTo(bm, CvType.CV_8U, 255);
	Highgui.imwrite(filePath, bm);
    }
}
