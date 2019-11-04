package lib.imageoperator;

import static lib.imageoperator.RGBUtility.blue;
import static lib.imageoperator.RGBUtility.green;
import static lib.imageoperator.RGBUtility.red;

import java.awt.image.BufferedImage;

/**
 */
public final class Saido {
	/**
	 */
	private Saido() {
	}

	/**
	 * Ê“x‰æ‘œ‚É•ÏŠ·‚·‚éB
	 * 
	 * @param image
	 *            ˆ—‘ÎÛ‚Ì‰æ‘œ
	 * @return •ÔŠÒŒã‚Ì‰æ‘œ
	 */
	public static BufferedImage execute(BufferedImage image) {
		BufferedImage newImage = new BufferedImage(image.getWidth(),
				image.getHeight(), BufferedImage.TYPE_BYTE_GRAY);
		for (int y = 0; y < image.getHeight(); y++) {
			for (int x = 0; x < image.getWidth(); x++) {
				int rgb = image.getRGB(x, y);
				int r = red(rgb);
				int g = green(rgb);
				int b = blue(rgb);
				HSV hsv = HSV.createFromRGB(r, g, b);
				int s = (int) (hsv.s * 255);
				newImage.setRGB(x, y, s + (s << 8) + (s << 16));
			}
		}
		return newImage;
	}

}
