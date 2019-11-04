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
     * 彩度を強調する。
     * 
     * RGBからHSVに変換し、Sに指定された係数を乗じてから、RGBに変換することで彩度を強調する。
     * 
     * @param mat
     *            原画像
     * @param kh
     *            H用の強調係数(1.0よりも大きいと強調)
     * @param ks
     *            S用の強調係数(1.0よりも大きいと強調)。ただし、Sについては1.0以外を使用することはないと思われる。
     * @param kv
     *            V用の強調係数(1.0よりも大きいと強調)
     * @return 変換後の画像
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
     * 彩度を強調する。
     * 
     * RGBからHSVに変換し、Sに指定された係数を乗じてから、RGBに変換することで彩度を強調する。
     * 
     * @param mat
     *            原画像
     * @param hLUT
     *            H用のLUT
     * @param sLUT
     *            S用のLUT
     * @param vLUT
     *            V用のLUT
     * @return 変換後の画像
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
