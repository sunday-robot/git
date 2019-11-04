package lib.imageoperator;

import static lib.imageoperator.RGBUtility.luminance;

import java.awt.image.BufferedImage;

/**
 * 指定された画像を16階調モノクロ化する
 * 
 * @author akiyama
 * 
 */
public final class Gray16 {
	/**
	 */
	private Gray16() {
	}

	/**
	 * 濃度値を強調する。
	 * 
	 * @param image
	 *            BufferedImage
	 * @return 変換後の画像
	 */
	public static BufferedImage execute(BufferedImage image) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), BufferedImage.TYPE_BYTE_GRAY);
		for (int y = 0; y < image.getHeight(); y++)
			for (int x = 0; x < image.getWidth(); x++) {
				int rgb = image.getRGB(x, y);
				int l = luminance(rgb) / 16 * 17;
				outImage.setRGB(x, y, l + (l << 8) + (l << 16));
			}
		return outImage;
	}

}
