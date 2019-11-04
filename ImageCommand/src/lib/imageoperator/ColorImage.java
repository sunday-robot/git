package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

/**
 * 輝度値がdoubleのカラー画像データ(幅、高さ、RGBの最小限の情報しか持たないもの)
 */
public final class ColorImage extends AbstractImage {

	/** 輝度値 */
	public final double[][][] v;

	/**
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 */
	public ColorImage(int width, int height) {
		super(width, height);
		v = new double[height][width][3];
	}

	/**
	 * BufferedImageから生成する。この時BufferedImageのガンマ補正を解除する。
	 * 
	 * @param bufferedImage
	 *            BufferedImage
	 * @param gamma
	 *            bufferedImageのガンマ補正値(Windowsで扱う画像データの場合は大抵2.2)
	 */
	public ColorImage(BufferedImage bufferedImage, double gamma) {
		this(bufferedImage.getWidth(), bufferedImage.getHeight());
		double[] g = createGammaCancelTable(gamma);
		for (int y = 0; y < bufferedImage.getHeight(); y++) {
			for (int x = 0; x < bufferedImage.getWidth(); x++) {
				int rgb = bufferedImage.getRGB(x, y);
				v[y][x][0] = g[(rgb >> 16) & 0xff];
				v[y][x][1] = g[(rgb >> 8) & 0xff];
				v[y][x][2] = g[rgb & 0xff];
			}
		}
	}

	/**
	 * @param grayImage
	 *            {@link GrayImage}
	 */
	public ColorImage(GrayImage grayImage) {
		this(grayImage.width, grayImage.height);
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				double i = grayImage.v[y][x];
				v[y][x][0] = i;
				v[y][x][1] = i;
				v[y][x][2] = i;
			}
		}
	}

	/**
	 * ファイルをロードし、ColorImageを生成する。
	 * 
	 * @param filePath
	 *            ファイルパス
	 * @param gamma
	 *            ガンマ補正値
	 * @return ColorImage
	 * @throws IOException
	 *             入出力エラー
	 */
	public static ColorImage load(String filePath, double gamma)
			throws IOException {
		BufferedImage bufferedImage = ImageIO.read(new File(filePath));
		return new ColorImage(bufferedImage, gamma);
	}

	/**
	 * ファイルをロードし、ColorImageを生成する。
	 * 
	 * @param filePath
	 *            ファイルパス
	 * @return ColorImage
	 * @throws IOException
	 *             入出力エラー
	 */
	public static ColorImage load(String filePath) throws IOException {
		return load(filePath, DEFAULT_GAMMA);
	}

	@Override
	public BufferedImage createBufferedImage(double gamma) {
		BufferedImage bufferedImage = new BufferedImage(width, height,
				BufferedImage.TYPE_INT_RGB);
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				int r = g(v[y][x][0], gamma);
				int g = g(v[y][x][1], gamma);
				int b = g(v[y][x][2], gamma);
				bufferedImage.setRGB(x, y, r << 16 | g << 8 | b);
			}
		}
		return bufferedImage;
	}

	@Override
	public void save(String filePath, String formatName, double gamma)
			throws IOException {
		BufferedImage bufferedImage = createBufferedImage(gamma);
		ImageIO.write(bufferedImage, formatName, new File(filePath));
	}
}
