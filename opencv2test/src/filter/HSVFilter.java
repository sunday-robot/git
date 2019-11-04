package filter;

import org.opencv.core.Core;
import org.opencv.core.Mat;

import colorspace.HSV;

/**
 */
public class HSVFilter {
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
     * @param kh
     *            H�p�̋����W��(1.0�����傫���Ƌ���)
     * @param ks
     *            S�p�̋����W��(1.0�����傫���Ƌ���)�B�������AS�ɂ��Ă�1.0�ȊO���g�p���邱�Ƃ͂Ȃ��Ǝv����B
     * @param kv
     *            V�p�̋����W��(1.0�����傫���Ƌ���)
     * @return �ϊ���̉摜
     */
    public static Mat execute(Mat mat, double kh, double ks, double kv) {
	int rowCount = mat.rows();
	int columnCount = mat.cols();
	Mat hsvMat = new Mat(rowCount, columnCount, mat.type());
	double[] rgb = new double[3];
	double[] rgb2 = new double[3];
	for (int y = 0; y < rowCount; y++) {
	    for (int x = 0; x < columnCount; x++) {
		mat.get(y, x, rgb);
		HSV hsv = HSV.createFromRGB(rgb);
		HSV hsv2 = new HSV(hsv.h * kh, hsv.s * ks, hsv.v * kv);
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

    /**
     * �ʓx����������B
     * 
     * RGB����HSV�ɕϊ����AS�Ɏw�肳�ꂽ�W�����悶�Ă���ARGB�ɕϊ����邱�Ƃōʓx����������B
     * 
     * @param mat
     *            ���摜
     * @param hLUT
     *            H�p��LUT
     * @param sLUT
     *            S�p��LUT
     * @param vLUT
     *            V�p��LUT
     * @return �ϊ���̉摜
     */
    public static Mat execute(Mat mat, LUT hLUT, LUT sLUT, LUT vLUT) {
	int rowCount = mat.rows();
	int columnCount = mat.cols();
	Mat hsvMat = new Mat(rowCount, columnCount, mat.type());
	double[] rgb = new double[3];
	double[] rgb2 = new double[3];
	for (int y = 0; y < rowCount; y++) {
	    for (int x = 0; x < columnCount; x++) {
		mat.get(y, x, rgb);
		HSV hsv = HSV.createFromRGB(rgb);
		double h = hLUT.convert(hsv.h);
		double s = sLUT.convert(hsv.s);
		double v = vLUT.convert(hsv.v);
		HSV hsv2 = new HSV(h, s, v);
		hsv2.toRGB(rgb2);
		hsvMat.put(y, x, rgb2);
	    }
	}
	return hsvMat;
    }
}
