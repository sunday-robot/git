package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.awt.image.ColorModel;
import java.awt.image.WritableRaster;

/**
 * BufferedImage�𕡐����郆�[�e�B���e�B�N���X�B
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
	 *            ���摜
	 * @return ���摜�̕���
	 */
	public static BufferedImage execute(BufferedImage image) {
		ColorModel cm = image.getColorModel();
		boolean isAlphaPremultiplied = cm.isAlphaPremultiplied();
		WritableRaster raster = image.copyData(null);
		return new BufferedImage(cm, raster, isAlphaPremultiplied, null);
	}
}
