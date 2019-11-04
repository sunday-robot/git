import io.Loader;
import io.Saver;

import org.opencv.core.Core;
import org.opencv.core.CvType;
import org.opencv.core.Mat;
import org.opencv.highgui.Highgui;

/**
 */
public class LoadSaveTest {
    static {
	System.loadLibrary(Core.NATIVE_LIBRARY_NAME);
    }

    /**
     */
    public static void execute8() {
	Mat m8 = Loader.execute("test8bit.png");
	Saver.execute(m8, "result8to8.png");
	save16(m8, "result8to16.png");
	m8.release();
    }

    /**
     */
    public static void execute16() {
	Mat m16 = Loader.execute("test16bit.png");
	Saver.execute(m16, "result16to8.png");
	save16(m16, "result16to16.png");
	m16.release();
    }

    /**
     * 指定されたdouble画像を、 16bit画像に変換し、ファイルに保存する。
     * 
     * @param m
     *            double画像
     * @param filePath
     *            ファイルパス
     */
    private static void save16(Mat m, String filePath) {
	Mat bm = new Mat();
	m.convertTo(bm, CvType.CV_16U, 65535);
	Highgui.imwrite(filePath, bm);
    }

}
