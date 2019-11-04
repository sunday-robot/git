package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * グレースケール画像の暗い部分を強調する。
 * 
 * @author akiyama
 * 
 */
public final class DarkFilter {
	/**
	 */
	private DarkFilter() {
	}

	/**
	 * 指定された画像の暗い部分をより強調した画像を返す。
	 * 
	 * @param image
	 *            入力画像
	 * @return 出力画像
	 */
	public static BufferedImage execute(BufferedImage image) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		int x;
		int y;
		WRGB wrgb = new WRGB();

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				int myLuminance = image.getRGB(x, y) & 255;
				wrgb.set(0, 0);
				wrgb.add(getWRGB(image, x - 1, y - 1, myLuminance, 14));
				wrgb.add(getWRGB(image, x + 0, y - 1, myLuminance, 10));
				wrgb.add(getWRGB(image, x + 1, y - 1, myLuminance, 14));
				wrgb.add(getWRGB(image, x - 1, y + 0, myLuminance, 10));
				wrgb.add(getWRGB(image, x + 0, y + 0, myLuminance, 0));
				wrgb.add(getWRGB(image, x + 1, y + 0, myLuminance, 10));
				wrgb.add(getWRGB(image, x - 1, y + 1, myLuminance, 14));
				wrgb.add(getWRGB(image, x + 0, y + 1, myLuminance, 10));
				wrgb.add(getWRGB(image, x + 1, y + 1, myLuminance, 14));
				outImage.setRGB(x, y, wrgb.getColor());
			}
		}
		return outImage;
	}

	/**
	 * 重み付きRGB値を取得する。
	 * 
	 * @param image
	 *            画像
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param centerLuminance
	 *            中心の明度
	 * @param distance
	 *            距離
	 * @return 重み付きRGB値
	 */
	private static WRGB getWRGB(BufferedImage image, int x, int y,
			int centerLuminance, int distance) {
		int rgb = image.getRGB(x, y);
		int luminanceDifference = (rgb & 255) - centerLuminance;
		int w = getWeight(luminanceDifference, distance);
		return new WRGB(w, rgb);
	}

	/**
	 * 
	 * @param luminanceDifference
	 *            ??
	 * @param distance
	 *            ??
	 * @return ??
	 */
	private static int getWeight(int luminanceDifference, int distance) {
		int w1;
		if (luminanceDifference >= 0)
			w1 = 0;
		else
			w1 = -luminanceDifference;
		int w2 = 100 / (1 + distance);
		return w1 + w2;
	}

	/**
	 * テストメソッド
	 * 
	 * @param fileName
	 *            ファイル名
	 * @throws IOException
	 *             IOException
	 */
	public static void test(String fileName) throws IOException {
		BufferedImage image = ImageIO.read(new File(fileName));
		image = DarkFilter.execute(image);
		image = DarkFilter.execute(image);
		SaveOutputImage.execute(image, fileName, "png");
	}

	/**
	 * テスト用のメイン関数
	 * 
	 * @param args
	 *            コマンドライン引数は使用しない
	 * @throws IOException
	 *             IOException
	 */
	public static void main(String[] args) throws IOException {
		test("testdata/darkfilter.bmp");
		test("testdata/honbun (008)_mini.jpg");
	}
}
