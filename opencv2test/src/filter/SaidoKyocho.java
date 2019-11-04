package filter;

import org.opencv.core.Core;
import org.opencv.core.Mat;

import colorspace.HSV;

/**
 */
public class SaidoKyocho {
    static {
	System.loadLibrary(Core.NATIVE_LIBRARY_NAME);
    }

    /**
     * �ʓx����������B
     * 
     * RGB����HSV�ɕϊ����AS�Ɏw�肳�ꂽ�W�����悶�Ă���ARGB�ɕϊ����邱�Ƃōʓx����������B
     * 
     * @param mat
     *            ���摜
     * @param k
     *            �����W��(1.0�����傫���Ƌ���)
     * @return �ϊ���̉摜
     */
    public static Mat execute(Mat mat, double k) {
	int rowCount = mat.rows();
	int columnCount = mat.cols();
	Mat hsvMat = new Mat(rowCount, columnCount, mat.type());
	double[] rgb = new double[3];
	double[] rgb2 = new double[3];
	for (int y = 0; y < rowCount; y++) {
	    for (int x = 0; x < columnCount; x++) {
		mat.get(y, x, rgb);
		HSV hsv = HSV.createFromRGB(rgb);
		HSV hsv2 = new HSV(hsv.h, hsv.s * k, hsv.v);
		hsv2.toRGB(rgb2);
		hsvMat.put(y, x, rgb2);
	    }
	}
	return hsvMat;
	// double s = (max - min) / max;
	// (max - min2) / max = (max - min) / max * k
	// (max - min2) = (max - min) * k
	// max = min2 + (max - min) * k
	// max - (max - min) * k = min2
	// newMin = max - (max - min) * k
	// h = (x + y / (max - min)) / 6
	// y / (max - min) = newY / (max - newMin)
	// y / (max - min) * (max - newMin) = newY
	// (mid - min) / (max - min) * (max - newMin) = (newMid - newMin)
	// (mid - min) / (max - min) * (max - newMin) + newMin = newMid

    }

}
