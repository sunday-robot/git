package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

/**
 * 輝度値がdoubleのカラー画像データ(幅、高さ、RGBの最小限の情報しか持たないもの)
 */
public class GrayImage extends AbstractImage {
	/** 輝度値 */
	public final double[][] v;

	/**
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 */
	public GrayImage(int width, int height) {
		super(width, height);
		v = new double[height][width];
	}

	/**
	 * @param bufferedImage
	 *            BufferedImage
	 * @param gamma
	 *            ガンマ補正値
	 */
	public GrayImage(BufferedImage bufferedImage, double gamma) {
		super(bufferedImage, gamma);
		v = new double[height][width];
		double[] g = createGammaCancelTable(gamma);
		for (int y = 0; y < bufferedImage.getHeight(); y++) {
			for (int x = 0; x < bufferedImage.getWidth(); x++) {
				int rgb = bufferedImage.getRGB(x, y);
				v[y][x] = g[rgb & 0xff];
			}
		}
	}

	/**
	 * ファイルをロードし、GrayImageを生成する。
	 * 
	 * @param filePath
	 *            ファイルパス
	 * @param gamma
	 *            ガンマ補正値
	 * @return GrayImage
	 * @throws IOException
	 *             入出力エラー
	 */
	public static final GrayImage load(String filePath, double gamma)
			throws IOException {
		BufferedImage bufferedImage = ImageIO.read(new File(filePath));
		return new GrayImage(bufferedImage, gamma);
	}

	/**
	 * ファイルをロードし、GrayImageを生成する。
	 * 
	 * @param filePath
	 *            ファイルパス
	 * @return GrayImage
	 * @throws IOException
	 *             入出力エラー
	 */
	public static final GrayImage load(String filePath) throws IOException {
		return load(filePath, DEFAULT_GAMMA);
	}

	@Override
	public final BufferedImage createBufferedImage(double gamma) {
		BufferedImage bufferedImage = new BufferedImage(width, height,
				BufferedImage.TYPE_INT_RGB); // TYPE_BYTE_GRAYは、setRGBでガンマ補正などを行ってしまい使いづらいので、余計なことをしないTYPE_INT_RGBを使用する。
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				int r = g(v[y][x], gamma);
				int rgb = r << 16 | r << 8 | r;
				bufferedImage.setRGB(x, y, rgb);
				// int a = bufferedImage.getRGB(x, y);
				// System.out.printf("%08x, %08x\n", rgb, a);
			}
		}
		return bufferedImage;
	}

	@Override
	public final void save(String filePath, String formatName, double gamma)
			throws IOException {
		BufferedImage bufferedImage = createBufferedImage(gamma);
		ImageIO.write(bufferedImage, formatName, new File(filePath));
	}
}
