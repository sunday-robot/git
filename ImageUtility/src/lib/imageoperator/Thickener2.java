package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * グレースケール画像の暗い部分の面積を増やす。(文字を太くする。)
 */
public final class Thickener2 {
	/**
	 */
	private Thickener2() {
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

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				int luminance = image.getRGB(x - 1, y - 1) & 255;
				luminance = Math.min(luminance,
						image.getRGB(x + 0, y - 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 1, y - 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x - 1, y + 0) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 0, y + 0) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 1, y + 0) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x - 1, y + 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 0, y + 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 1, y + 1) & 255);
				int w = 255 - luminance;
				int myLuminance = image.getRGB(x, y) & 255;
				int myW = 128;
				int newLuminance = (myW * myLuminance + w * luminance)
						/ (myW + w);
				outImage.setRGB(x, y, (newLuminance << 16)
						| (newLuminance << 8) | myLuminance);
			}
		}
		return outImage;
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
		image = Thickener2.execute(image);
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
