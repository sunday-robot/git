package io;

import org.opencv.core.Core;
import org.opencv.core.CvType;
import org.opencv.core.Mat;
import org.opencv.highgui.Highgui;

/**
 */
public class Loader {
    static {
	System.loadLibrary(Core.NATIVE_LIBRARY_NAME);
    }

    /**
     * �摜�t�@�C�������[�h���Adouble�摜�ɕϊ����A�Ԃ��B
     * 
     * �o�O���<br>
     * PNG�ɂ��āA�A���t�@�`�����l���͖��������炵���iRGBA�ł͂Ȃ��ARGB�Ƃ���Mat�����������j<br>
     * ������PNG�ɂ��āARGB�̊e�`�����l����16�r�b�g�̃t�@�C�����ǂ߂邪�A8bit�ɕϊ����Ă��܂��炵���B
     * 
     * @param filePath
     *            �t�@�C���p�X
     * @return double�摜�f�[�^
     */
    public static Mat execute(String filePath) {
	// �摜�f�[�^��ǂݍ���
	Mat m = Highgui.imread(filePath);
	if (m.empty()) {
	    m.release();
	    return null;
	}

	// "���K��"����i�e�v�f�̌^��double�A�l���0.0�`1.0�ɂ���j
	// int d = m.depth(); // �e�`�����l����16bit�̉摜��ǂ�ł�6�ł͂Ȃ��A3���Ԃ��Ă���c
	// long es1 = m.elemSize1(); // �e�`�����l����16bit�̉摜��ǂ�ł�2�ł͂Ȃ��A1���Ԃ��Ă���c
	Mat dm = new Mat();
	m.convertTo(dm, CvType.CV_64F, 1.0 / 255); // 16bitPNG�t�@�C����ǂ�ł����d�l�Ō��ʂ�8�r�b�g�ɂȂ��Ă��܂��̂ŁA���255�Ŋ���΂悢�c
	m.release(); // Java��GC��m�i���w���Ă���C���X�^���X�j���J������O�ɁA���炩�ɕs�v�ȃ������͊J������ق����ǂ��Ǝv���B

	return dm;
    }
}
