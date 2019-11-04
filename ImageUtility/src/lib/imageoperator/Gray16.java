package lib.imageoperator;

import static lib.imageoperator.RGBUtility.luminance;

import java.awt.image.BufferedImage;

/**
 * �w�肳�ꂽ�摜��16�K�����m�N��������
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
	 * �Z�x�l����������B
	 * 
	 * @param image
	 *            BufferedImage
	 * @return �ϊ���̉摜
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
