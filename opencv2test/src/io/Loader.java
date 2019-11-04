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
     * 画像ファイルをロードし、double画像に変換し、返す。
     * 
     * バグ情報<br>
     * PNGについて、アルファチャンネルは無視されるらしい（RGBAではなく、RGBとしてMatが生成される）<br>
     * 同じくPNGについて、RGBの各チャンネルが16ビットのファイルも読めるが、8bitに変換してしまうらしい。
     * 
     * @param filePath
     *            ファイルパス
     * @return double画像データ
     */
    public static Mat execute(String filePath) {
	// 画像データを読み込む
	Mat m = Highgui.imread(filePath);
	if (m.empty()) {
	    m.release();
	    return null;
	}

	// "正規化"する（各要素の型をdouble、値域を0.0～1.0にする）
	// int d = m.depth(); // 各チャンネルが16bitの画像を読んでも6ではなく、3が返ってくる…
	// long es1 = m.elemSize1(); // 各チャンネルが16bitの画像を読んでも2ではなく、1が返ってくる…
	Mat dm = new Mat();
	m.convertTo(dm, CvType.CV_64F, 1.0 / 255); // 16bitPNGファイルを読んでも糞仕様で結果は8ビットになってしまうので、常に255で割ればよい…
	m.release(); // JavaのGCがm（が指しているインスタンス）を開放する前に、明らかに不要なメモリは開放するほうが良いと思う。

	return dm;
    }
}
