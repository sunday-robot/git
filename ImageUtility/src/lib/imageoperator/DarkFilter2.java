package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * 暗い部分を強調する。
 * 
 * @author akiyama
 * 
 */
public final class DarkFilter2 {
	/**
	 */
	private DarkFilter2() {
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
		int w0 = 10;
		int w1 = 7;
		int w2 = 5;

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				wrgb.set(0, 0);
				wrgb.add(getWrgb(image, x - 1, y - 1, w2));
				wrgb.add(getWrgb(image, x, y - 1, w1));
				wrgb.add(getWrgb(image, x + 1, y - 1, w2));
				wrgb.add(getWrgb(image, x - 1, y, w1));
				wrgb.add(getWrgb(image, x, y, w0));
				wrgb.add(getWrgb(image, x + 1, y, w1));
				wrgb.add(getWrgb(image, x - 1, y + 1, w2));
				wrgb.add(getWrgb(image, x, y + 1, w1));
				wrgb.add(getWrgb(image, x + 1, y + 1, w2));
				int rgb = image.getRGB(x, y);
				int newRgb = wrgb.getColor();
				if (RGBUtility.luminance(rgb) < RGBUtility.luminance(newRgb)) {
					newRgb = rgb;
				}
				outImage.setRGB(x, y, newRgb);
			}
		}
		return outImage;
	}

	/**
	 * 重み付RGB値を返す。
	 * 
	 * @param image
	 *            画像
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param w
	 *            重み
	 * @return WRGB値
	 */
	private static WRGB getWrgb(BufferedImage image, int x, int y, int w) {
		int rgb = image.getRGB(x, y);
		int l = RGBUtility.luminance(rgb);
		return new WRGB((384 - l) * w, rgb);
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
		image = DarkFilter2.execute(image);
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
