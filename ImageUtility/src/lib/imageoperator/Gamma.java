/**
 * 
 */
package lib.imageoperator;

import static lib.imageoperator.RGBUtility.blue;
import static lib.imageoperator.RGBUtility.green;
import static lib.imageoperator.RGBUtility.red;
import static lib.imageoperator.RGBUtility.rgb;

import java.awt.image.BufferedImage;

/**
 */
public final class Gamma {
	/**
	 */
	private Gamma() {
	}

	/**
	 * ガンマ変換を行う。
	 * 
	 * 一般的(Windows、Mac、テレビ放送など)には、ガンマ値は2.2が使用されているらしい。<br>
	 * このため、JPEGファイルでの輝度値も、ガンマ値2.2となっている。<br>
	 * 本来の輝度値に戻すには、ガンマ値1/2.2で変換を行う必要がある。
	 * 
	 * @param image
	 *            入力画像
	 * @param gamma
	 *            ガンマ値
	 * @return 変換後の画像
	 */
	public static BufferedImage execute(BufferedImage image, double gamma) {
		int[] gammaTable = createGammaTable(gamma);
		if (image.getType() == BufferedImage.TYPE_BYTE_GRAY) {
			return executeGrayImage(image, gammaTable);
		} else {
			return executeColorImage(image, gammaTable, gammaTable, gammaTable);
		}
	}

	/**
	 * 輝度値の変換表を生成する
	 * 
	 * @param gamma
	 *            ガンマ値
	 * @return 変換表
	 */
	private static int[] createGammaTable(double gamma) {
		int[] gammaTable = new int[256];
		for (int i = 0; i < 256; i++) {
			gammaTable[i] = (int) (255 * Math.pow(i / 255.0, gamma));
		}
		return gammaTable;
	}

	/**
	 * グレイスケール画像のガンマ変換を行う
	 * 
	 * @param image
	 *            グレイスケール画像
	 * @param gammaTable
	 *            変換表
	 * @return 変換後の画像
	 */
	private static BufferedImage executeGrayImage(BufferedImage image,
			int[] gammaTable) {
		BufferedImage newImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		for (int y = 0; y < image.getHeight(); y++) {
			for (int x = 0; x < image.getWidth(); x++) {
				int rgb = image.getRGB(x, y);
				int v = gammaTable[red(rgb)];
				int newRgb = rgb(v, v, v);
				newImage.setRGB(x, y, newRgb);
			}
		}
		return newImage;
	}

	/**
	 * カラー画像のガンマ変換を行う
	 * 
	 * @param image
	 *            カラー画像
	 * @param gammaTableR
	 *            R変換表
	 * @param gammaTableG
	 *            G変換表
	 * @param gammaTableB
	 *            B変換表
	 * @return 変換後の画像
	 */
	private static BufferedImage executeColorImage(BufferedImage image,
			int[] gammaTableR, int[] gammaTableG, int[] gammaTableB) {
		BufferedImage newImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		for (int y = 0; y < image.getHeight(); y++) {
			for (int x = 0; x < image.getWidth(); x++) {
				int rgb = image.getRGB(x, y);
				int newR = gammaTableR[red(rgb)];
				int newG = gammaTableG[green(rgb)];
				int newB = gammaTableB[blue(rgb)];
				int newRgb = rgb(newR, newG, newB);
				newImage.setRGB(x, y, newRgb);
			}
		}
		return newImage;
	}

}
