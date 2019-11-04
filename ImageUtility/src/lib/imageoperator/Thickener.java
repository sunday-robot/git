package lib.imageoperator;

import static java.lang.Math.min;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * グレースケール画像の暗い部分の面積を増やす。(文字を太くする。)
 */
public final class Thickener {
	/**
	 */
	private Thickener() {
	}

	/**
	 * 指定された画像の暗い部分をより強調した画像を返す。
	 * 
	 * @param image
	 *            入力画像
	 * @return 出力画像
	 */
	public static BufferedImage executeX(BufferedImage image) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		int x;
		int y;

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				int luminance = image.getRGB(x - 1, y - 1);
				luminance = Math.min(luminance, image.getRGB(x + 0, y - 1));
				luminance = Math.min(luminance, image.getRGB(x + 1, y - 1));
				luminance = Math.min(luminance, image.getRGB(x - 1, y + 0));
				luminance = Math.min(luminance, image.getRGB(x + 0, y + 0));
				luminance = Math.min(luminance, image.getRGB(x + 1, y + 0));
				luminance = Math.min(luminance, image.getRGB(x - 1, y + 1));
				luminance = Math.min(luminance, image.getRGB(x + 0, y + 1));
				luminance = Math.min(luminance, image.getRGB(x + 1, y + 1));
				outImage.setRGB(x, y, luminance);
			}
		}
		return outImage;
	}

	/**
	 * @param mono
	 *            グレイスケール値
	 * @return RGB値
	 */
	private static int monoToRGB(int mono) {
		return (mono << 16) | (mono << 8) | mono;
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

		int[][] hDark = new int[][] { new int[image.getWidth()],
				new int[image.getWidth()] };
		int[][] vDark = new int[][] { new int[image.getWidth()],
				new int[image.getWidth()] };

		getHorizonDarkPixels(image, 0, hDark[0]);
		getHorizonDarkPixels(image, 1, hDark[1]);
		getVerticalDarkPixels(hDark, vDark[1]);
		setDarkPixels(outImage, 0, vDark[1]);

		int h = image.getHeight();
		for (int y = 2; y < h; y++) {
			getHorizonDarkPixels(image, y, hDark[y % 2]);
			getVerticalDarkPixels(hDark, vDark[y % 2]);
			setDarkPixels(outImage, y - 1, vDark);
		}

		setDarkPixels(outImage, h - 1, vDark[(h - 1) % 2]);

		return outImage;
	}

	/**
	 * 
	 * @param image
	 *            ???
	 * @param y
	 *            ???
	 * @param dark
	 *            ???
	 */
	private static void setDarkPixels(BufferedImage image, int y, int[] dark) {
		for (int x = 0; x < image.getWidth(); x++) {
			image.setRGB(x, y, monoToRGB(dark[x]));
		}
	}

	/**
	 * 
	 * @param image
	 *            ???
	 * @param y
	 *            ???
	 * @param dark
	 *            ???
	 */
	private static void setDarkPixels(BufferedImage image, int y, int[][] dark) {
		for (int x = 0; x < image.getWidth(); x++) {
			image.setRGB(x, y, monoToRGB(min(dark[0][x], dark[1][x])));
		}
	}

	/**
	 * ???
	 * 
	 * @param darkestLine
	 *            ???
	 * @param darkestLine2
	 *            ???
	 */
	private static void getVerticalDarkPixels(int[][] darkestLine,
			int[] darkestLine2) {
		int w = darkestLine[0].length;
		for (int i = 0; i < w; i++) {
			darkestLine2[i] = min(darkestLine[0][i], darkestLine[1][i]);
		}
	}

	/**
	 * 指定された行(Y座標）について、左右2近傍で最も暗い画素値を配列にセットする。
	 * 
	 * @param image
	 *            対象画像
	 * @param y
	 *            業
	 * @param darkest
	 *            最も位が措置を設定する配列
	 */
	private static void getHorizonDarkPixels(BufferedImage image, int y,
			int[] darkest) {
		int[] p = new int[2];
		int[] mp = new int[2];
		p[1] = image.getRGB(1, y) & 255;
		mp[1] = min(image.getRGB(0, y) & 255, p[1]);
		darkest[0] = mp[1];

		int w = image.getWidth();
		for (int x = 2; x < w; x++) {
			p[x % 2] = image.getRGB(x, y) & 255;
			mp[x % 2] = min(p[0], p[1]);
			darkest[x - 1] = min(mp[0], mp[1]);
		}
		darkest[w - 1] = mp[(w - 1) % 2];
	}

	/**
	 * テスト用関数
	 * 
	 * @param fileName
	 *            ファイル名
	 * @throws IOException
	 *             IOException
	 */
	public static void test(String fileName) throws IOException {
		BufferedImage image = ImageIO.read(new File(fileName));
		image = Monochrome.execute(image);
		image = Thickener.execute(image);
		SaveOutputImage.execute(image, fileName, "png");
	}

	/**
	 * テスト用メイン関数
	 * 
	 * @param args
	 *            コマンドライン引数は使用しない
	 * @throws IOException
	 *             IOException
	 */
	public static void main(String[] args) throws IOException {
		test("testdata/darkfilter.bmp");
		test("testdata/honbun (008)_mini.jpg");
		test("testdata/a.png");
	}
}
