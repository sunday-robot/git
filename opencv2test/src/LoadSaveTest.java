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
     * �w�肳�ꂽdouble�摜���A 16bit�摜�ɕϊ����A�t�@�C���ɕۑ�����B
     * 
     * @param m
     *            double�摜
     * @param filePath
     *            �t�@�C���p�X
     */
    private static void save16(Mat m, String filePath) {
	Mat bm = new Mat();
	m.convertTo(bm, CvType.CV_16U, 65535);
	Highgui.imwrite(filePath, bm);
    }

}
