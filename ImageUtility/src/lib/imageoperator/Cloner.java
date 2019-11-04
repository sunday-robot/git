package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.awt.image.ColorModel;
import java.awt.image.WritableRaster;

/**
 * BufferedImageを複製するユーティリティクラス。
 * 
 * @author akiyama
 * 
 */
public final class Cloner {
	/**
	 */
	private Cloner() {
	}

	/**
	 * 
	 * @param image
	 *            原画像
	 * @return 原画像の複製
	 */
	public static BufferedImage execute(BufferedImage image) {
		ColorModel cm = image.getColorModel();
		boolean isAlphaPremultiplied = cm.isAlphaPremultiplied();
		WritableRaster raster = image.copyData(null);
		return new BufferedImage(cm, raster, isAlphaPremultiplied, null);
	}
}
