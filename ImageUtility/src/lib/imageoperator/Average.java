package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 */
public final class Average {
	/**
	 */
	private Average() {
	}

	/**
	 * ���Ӊ�f�̕��ϔZ�x�l�摜��Ԃ��B
	 * 
	 * @param image
	 *            ���͉摜
	 * @param range
	 *            ���ς��Ƃ�͈�(�^�e���R�̉�f�����A2*range+1�̐����`�̈�)
	 * @return ���ϔZ�x�l�摜
	 */
	public static BufferedImage execute(BufferedImage image, int range) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());

		for (int y = 0; y < image.getHeight(); y++) {
			int y1 = Math.max(y - range, 0);
			int y2 = Math.min(y + range, image.getHeight() - 1);
			for (int x = 0; x < image.getWidth(); x++) {
				int x1 = Math.max(x - range, 0);
				int x2 = Math.min(x + range, image.getWidth() - 1);
				WRGB wrgb = new WRGB();

				for (int yy = y1; yy <= y2; yy++) {
					for (int xx = x1; xx <= x2; xx++) {
						wrgb.add(1, image.getRGB(xx, yy));
					}
				}

				outImage.setRGB(x, y, wrgb.getColor());
			}
		}

		return outImage;
	}
}
