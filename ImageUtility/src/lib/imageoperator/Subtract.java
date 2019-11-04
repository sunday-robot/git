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
	 * �摜A����摜B�̉�f�l���������摜��Ԃ��B<br/>
	 * ��f�l�̉��Z�́AA - B + 128�̌��ʂ�0�`255�Ɋۂ߂����̂ł���B
	 * 
	 * @param a
	 *            �摜A
	 * @param b
	 *            �摜B
	 * @return �������ʂ̉摜
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
	 * �w�肳�ꂽRGB�l�̍���Ԃ��B
	 * 
	 * @param rgb
	 *            �������l
	 * @param rgb2
	 *            �����l
	 * @return �u���v
	 */
	private static int rgbSub(int rgb, int rgb2) {
		int b = subColor(blue(rgb), blue(rgb2));
		int r = subColor(red(rgb), red(rgb2));
		int g = subColor(green(rgb), green(rgb2));
		return rgb(r, g, b);
	}

	/**
	 * 8�r�b�g�̔Z�x�l�́u���v��Ԃ�<br/>
	 * (a - b + 128���A0�`255�͈̔͂Ɋۂ߂����́B)
	 * 
	 * @param a
	 *            �������l
	 * @param b
	 *            �����l
	 * @return �u���v
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
