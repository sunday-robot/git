package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * �Â���������������B
 * 
 * @author akiyama
 * 
 */
public final class DarkFilter2 {
	/**
	 */
	private DarkFilter2() {
	}

	/**
	 * �w�肳�ꂽ�摜�̈Â���������苭�������摜��Ԃ��B
	 * 
	 * @param image
	 *            ���͉摜
	 * @return �o�͉摜
	 */
	public static BufferedImage execute(BufferedImage image) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		int x;
		int y;
		WRGB wrgb = new WRGB();
		int w0 = 10;
		int w1 = 7;
		int w2 = 5;

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				wrgb.set(0, 0);
				wrgb.add(getWrgb(image, x - 1, y - 1, w2));
				wrgb.add(getWrgb(image, x, y - 1, w1));
				wrgb.add(getWrgb(image, x + 1, y - 1, w2));
				wrgb.add(getWrgb(image, x - 1, y, w1));
				wrgb.add(getWrgb(image, x, y, w0));
				wrgb.add(getWrgb(image, x + 1, y, w1));
				wrgb.add(getWrgb(image, x - 1, y + 1, w2));
				wrgb.add(getWrgb(image, x, y + 1, w1));
				wrgb.add(getWrgb(image, x + 1, y + 1, w2));
				int rgb = image.getRGB(x, y);
				int newRgb = wrgb.getColor();
				if (RGBUtility.luminance(rgb) < RGBUtility.luminance(newRgb)) {
					newRgb = rgb;
				}
				outImage.setRGB(x, y, newRgb);
			}
		}
		return outImage;
	}

	/**
	 * �d�ݕtRGB�l��Ԃ��B
	 * 
	 * @param image
	 *            �摜
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param w
	 *            �d��
	 * @return WRGB�l
	 */
	private static WRGB getWrgb(BufferedImage image, int x, int y, int w) {
		int rgb = image.getRGB(x, y);
		int l = RGBUtility.luminance(rgb);
		return new WRGB((384 - l) * w, rgb);
	}

	/**
	 * �e�X�g���\�b�h
	 * 
	 * @param fileName
	 *            �t�@�C����
	 * @throws IOException
	 *             IOException
	 */
	public static void test(String fileName) throws IOException {
		BufferedImage image = ImageIO.read(new File(fileName));
		image = DarkFilter2.execute(image);
		SaveOutputImage.execute(image, fileName, "png");
	}

	/**
	 * �e�X�g�p�̃��C���֐�
	 * 
	 * @param args
	 *            �R�}���h���C�������͎g�p���Ȃ�
	 * @throws IOException
	 *             IOException
	 */
	public static void main(String[] args) throws IOException {
		test("testdata/darkfilter.bmp");
		test("testdata/honbun (008)_mini.jpg");
	}
}
