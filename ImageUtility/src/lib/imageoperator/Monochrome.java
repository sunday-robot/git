package lib.imageoperator;

import static lib.imageoperator.RGBUtility.luminance;

import java.awt.image.BufferedImage;

/**
 * w’è‚³‚ê‚½‰æ‘œ‚ğƒ‚ƒmƒNƒ‰»‚·‚é
 */
public final class Monochrome {
	/**
	 */
	private Monochrome() {
	}

	/**
	 * @param image
	 *            BufferedImage
	 * @return •ÏŠ·Œã‚Ì‰æ‘œ
	 */
	public static BufferedImage execute(BufferedImage image) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), BufferedImage.TYPE_BYTE_GRAY);
		for (int y = 0; y < image.getHeight(); y++)
			for (int x = 0; x < image.getWidth(); x++) {
				int rgb = image.getRGB(x, y);
				int l = luminance(rgb);
				outImage.setRGB(x, y, l + (l << 8) + (l << 16));
			}
		return outImage;
	}

}
