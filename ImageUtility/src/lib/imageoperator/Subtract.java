package lib.imageoperator;

import static lib.imageoperator.RGBUtility.blue;
import static lib.imageoperator.RGBUtility.green;
import static lib.imageoperator.RGBUtility.red;
import static lib.imageoperator.RGBUtility.rgb;

import java.awt.image.BufferedImage;

/**
 * 
 */
public final class Subtract {
	/**
	 */
	private Subtract() {
	}

	/**
	 * 画像Aから画像Bの画素値を引いた画像を返す。<br/>
	 * 画素値の演算は、A - B + 128の結果を0～255に丸めたものである。
	 * 
	 * @param a
	 *            画像A
	 * @param b
	 *            画像B
	 * @return 処理結果の画像
	 */
	public static BufferedImage execute(final BufferedImage a, BufferedImage b) {
		final int width = Math.max(a.getWidth(), b.getWidth());
		final int height = Math.max(a.getHeight(), b.getHeight());
		BufferedImage c = new BufferedImage(width, height,
				BufferedImage.TYPE_INT_RGB);

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				int color = rgbSub(a.getRGB(x, y), b.getRGB(x, y));
				c.setRGB(x, y, color);
			}
		}

		return c;
	}

	/**
	 * 指定されたRGB値の差を返す。
	 * 
	 * @param rgb
	 *            引かれる値
	 * @param rgb2
	 *            引く値
	 * @return 「差」
	 */
	private static int rgbSub(int rgb, int rgb2) {
		int b = subColor(blue(rgb), blue(rgb2));
		int r = subColor(red(rgb), red(rgb2));
		int g = subColor(green(rgb), green(rgb2));
		return rgb(r, g, b);
	}

	/**
	 * 8ビットの濃度値の「差」を返す<br/>
	 * (a - b + 128を、0～255の範囲に丸めたもの。)
	 * 
	 * @param a
	 *            引かれる値
	 * @param b
	 *            引く値
	 * @return 「差」
	 */
	private static int subColor(int a, int b) {
		int c = a - b + 128;
		if (c < 0)
			return 0;
		if (c > 255)
			return 255;
		return c;
	}
}
