package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.IOException;

/**
 * カラー画像およびグレイスケール画像の基底クラス
 */
public abstract class AbstractImage {

	/** BufferedImageと相互変換する際に行うガンマ補正およびその逆の処理で使用するガンマ値のデフォルト値 */
	public static final double DEFAULT_GAMMA = 2.2;

	/** 幅 */
	public final int width;

	/** 高さ */
	public final int height;

	/**
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 */
	public AbstractImage(int width, int height) {
		this.width = width;
		this.height = height;
	}

	/**
	 * @param bufferedImage
	 *            {@link BufferedImage}
	 * @param gamma
	 *            ガンマ補正値
	 */
	public AbstractImage(BufferedImage bufferedImage, double gamma) {
		width = bufferedImage.getWidth();
		height = bufferedImage.getWidth();
	}

	/**
	 * @param bufferedImage
	 *            {@link BufferedImage}
	 */
	public AbstractImage(BufferedImage bufferedImage) {
		this(bufferedImage, DEFAULT_GAMMA);
	}

	/**
	 * @param gamma
	 *            ガンマ補正値
	 * @return BufferedImage
	 */
	public abstract BufferedImage createBufferedImage(double gamma);

	/**
	 * @return BufferedImage
	 */
	public final BufferedImage createBufferedImage() {
		return createBufferedImage(DEFAULT_GAMMA);
	};

	/**
	 * 8bit画像に変換し、ファイルにセーブする。
	 * 
	 * @param filePath
	 *            ファイルパス
	 * @param formatName
	 *            出力ファイルのフォーマット名("jpeg", "png"など)
	 * @param gamma
	 *            ガンマ補正値
	 * @throws IOException
	 *             入出力エラー
	 */
	public abstract void save(String filePath, String formatName, double gamma)
			throws IOException;

	/**
	 * 8bit画像に変換し、ファイルにセーブする。
	 * 
	 * @param filePath
	 *            ファイルパス
	 * @param formatName
	 *            出力ファイルのフォーマット名("jpeg", "png"など)
	 * @throws IOException
	 *             入出力エラー
	 */
	public final void save(String filePath, String formatName)
			throws IOException {
		save(filePath, formatName, DEFAULT_GAMMA);
	}

	/**
	 * ガンマ補正を解除するためのテーブルを作成する。
	 * 
	 * @param gamma
	 *            ガンマ補正値
	 * @return ガンマ補正を解除するためのテーブル
	 */
	protected static double[] createGammaCancelTable(double gamma) {
		double[] g = new double[256];
		for (int i = 0; i < 256; i++) {
			g[i] = Math.pow(i / 255.0, 1 / gamma);
		}
		return g;
	}

	/**
	 * 輝度値を0～1に補正する。
	 * 
	 * @param value
	 *            輝度値
	 * @return 補正された輝度値
	 */
	protected static double correct(double value) {
		if (value > 1)
			return 1;
		if (value < 0)
			return 0;
		return value;
	}

	/**
	 * 定義域補正、ガンマ補正、8bit変換を行う。
	 * 
	 * @param v
	 *            輝度値
	 * @param gamma
	 *            ガンマ補正値
	 * @return 変換後の値
	 */
	protected static int g(double v, double gamma) {
		double vv = correct(v);
		double vvv = Math.pow(vv, gamma);
		return (int) Math.round(vvv * 255);
	}
}
