import org.opencv.core.Core;
import org.opencv.core.CvType;
import org.opencv.core.Mat;
import org.opencv.core.MatOfPoint2f;
import org.opencv.core.Point;
import org.opencv.core.Scalar;
import org.opencv.core.Size;
import org.opencv.highgui.Highgui;
import org.opencv.imgproc.Imgproc;

public class Main {
	public static void main(String[] args) {
		System.loadLibrary(Core.NATIVE_LIBRARY_NAME);
		// aaa();
		zzz();
	}

	private static void zzz() {
		// Mat m = Mat.eye(3, 3, CvType.CV_8UC1);
		// System.out.println("m = " + m.dump());
		Mat a = Highgui.imread("test.png");
		if (true) {
			zoomTest(a, 1.1);
			zoomTest(a, 1.2);
			zoomTest(a, 1.3);
			zoomTest(a, 1.4);
			zoomTest(a, 1.5);
			zoomTest(a, 1.6);
			zoomTest(a, 1.7);
			zoomTest(a, 1.8);
			zoomTest(a, 1.9);
		}
		zoomTest(a, 2);
		if (true) {
			zoomTest(a, 3);
			zoomTest(a, 4);
			zoomTest(a, 5);
			zoomTest(a, 7);
			zoomTest(a, 8);
		}
	}

	static void zoomTest(Mat srcImage, double zoomRatio) {
		{
			Mat destImage = zoomByResizeMethod(srcImage, zoomRatio);
			String fileName = String.format("test%d.png",
					(int) (zoomRatio * 10));
			Highgui.imwrite(fileName, destImage);
			destImage.release();
		}
		// Mat destImage = zoom2(srcImage, zoomRatio);
		{
			Mat destImage = zoomByAffineTransform(srcImage, zoomRatio);
			String fileName = String.format("test%d_5.png",
					(int) (zoomRatio * 10));
			Highgui.imwrite(fileName, destImage);
			destImage.release();
		}
	}

	/**
	 * 原画像の中央部分をズームした画像を生成する。
	 * 
	 * @param srcImage
	 *            原画像
	 * @param zoomRatio
	 *            ズーム倍率(1.0～)
	 * @return ズーム画像(幅、高さは原画像と同じ)
	 */
	private static Mat zoomByResizeMethod(Mat srcImage, double zoomRatio) {
		long start = System.nanoTime();
		int w = srcImage.width();
		int h = srcImage.height();
		int sw = (int) (w / zoomRatio);
		int sh = (int) (h / zoomRatio);
		int x1 = (w - sw) / 2;
		int y1 = (h - sh) / 2;

		Mat subImage = srcImage.submat(y1, y1 + sh - 1, x1, x1 + sw - 1);
		Mat destImage = new Mat(h, w, srcImage.type());
		Imgproc.resize(subImage, destImage, destImage.size());
		long end = System.nanoTime();
		System.out.printf("resize = %d ns\n", end - start);
		return destImage;
	}

	/**
	 * 原画像の中央部分をズームした画像を生成する。
	 * 
	 * @param srcImage
	 *            原画像
	 * @param zoomRatio
	 *            ズーム倍率(1.0～)
	 * @return ズーム画像(幅、高さは原画像と同じ)
	 */
	private static Mat zoomByAffineTransform(Mat srcImage, double zoomRatio) {
		long start = System.nanoTime();

		// 入力画像および出力画像のサイズ
		int w = srcImage.width();
		int h = srcImage.height();

		// 変換用の行列の生成
		double scx = (w - 1) / 2.0;
		double scy = (h - 1) / 2.0;
		double dcx = (w - 1) / 2.0; // 出力画像の中心位置
		double dcy = (h - 1) / 2.0;
		MatOfPoint2f srcPoints = new MatOfPoint2f(new Point(scx, scy),
				new Point(scx, scy + 1), new Point(scx + 1, scy));
		MatOfPoint2f dstPoints = new MatOfPoint2f(new Point(dcx, dcy),
				new Point(dcx, dcy + zoomRatio),
				new Point(dcx + zoomRatio, dcy));
		Mat m = Imgproc.getAffineTransform(srcPoints, dstPoints);

		// 出力画像(用のメモリ)の生成
		Mat destImage = new Mat(h, w, srcImage.type());

		// ズーム
		Imgproc.warpAffine(srcImage, destImage, m, destImage.size());
		// Imgproc.warpAffine(srcImage, destImage, m, destImage.size(),
		// Imgproc.INTER_LINEAR/* NEAREST */);

		long end = System.nanoTime();
		System.out.printf("affine = %d ns\n", end - start);
		return destImage;
	}

	/**
	 * 原画像の中央部分をズームした画像を生成する。
	 * 
	 * @param srcImage
	 *            原画像
	 * @param zoomRatio
	 *            ズーム倍率(1.0～)
	 * @return ズーム画像(幅、高さは原画像と同じ)
	 */
	private static Mat zoom2(Mat srcImage, double zoomRatio) {
		long start = System.nanoTime();
		int w = srcImage.width();
		int h = srcImage.height();

		Mat destImage = new Mat(h, w, srcImage.type());
		Imgproc.getRectSubPix(srcImage, new Size(w / zoomRatio, h / zoomRatio),
				new Point(w / 2 + 0.5, h / 2 + 0.5), destImage);
		// 上の関数の使いどころがわからない。切り出すだけでリサイズなどはしない。

		long end = System.nanoTime();
		System.out.printf("%d ns\n", end - start);
		System.out.printf("image type = %s\n", srcImage.toString());
		return destImage;
	}

	private static void aaa() {
		Mat m = new Mat(1024, 1024, CvType.CV_8UC3); // 8bit RGB
		byte[] pixel = new byte[3];
		m.get(0, 0, pixel);
		pixel[0] = (byte) 255;
		pixel[1] = (byte) 255;
		pixel[2] = (byte) 255;
		m.put(1, 1, pixel);
		m.get(1, 1, pixel);
		Core.line(m, new Point(0, 0), new Point(1023, 1023), new Scalar(255,
				100, 100), 10);
		m.getNativeObjAddr(); // このメソッドの存在理由(使用目的)が全く分からない。返すのはbyte配列などではなく、OpenCVの画像(行列)のデータを示すアドレス64bit整数で何に使えるのか全く不明。OpenCVのJavaラッパーのデバッグ用か何かだろうか?
		Highgui.imwrite("aaa.png", m);
	}
}