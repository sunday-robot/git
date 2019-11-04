package io;

import org.opencv.core.Core;
import org.opencv.core.CvType;
import org.opencv.core.Mat;
import org.opencv.highgui.Highgui;

/**
 * �P�x�l��0.0�`1.0��double�^�̉摜��8bit�摜�ɕϊ����t�@�C���ɃZ�[�u����B
 */
public class Saver {
    static {
	System.loadLibrary(Core.NATIVE_LIBRARY_NAME);
    }

    /**
     * @param m
     *            double�^�摜�f�[�^
     * @param filePath
     *            �t�@�C���p�X
     */
    public static void execute(Mat m, String filePath) {
	Mat bm = new Mat();
	m.convertTo(bm, CvType.CV_8U, 255);
	Highgui.imwrite(filePath, bm);
    }
}
