package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * �O���[�X�P�[���摜�̈Â���������������B
 * 
 * @author akiyama
 * 
 */
public final class DarkFilter {
	/**
	 */
	private DarkFilter() {
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

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				int myLuminance = image.getRGB(x, y) & 255;
				wrgb.set(0, 0);
				wrgb.add(getWRGB(image, x - 1, y - 1, myLuminance, 14));
				wrgb.add(getWRGB(image, x + 0, y - 1, myLuminance, 10));
				wrgb.add(getWRGB(image, x + 1, y - 1, myLuminance, 14));
				wrgb.add(getWRGB(image, x - 1, y + 0, myLuminance, 10));
				wrgb.add(getWRGB(image, x + 0, y + 0, myLuminance, 0));
				wrgb.add(getWRGB(image, x + 1, y + 0, myLuminance, 10));
				wrgb.add(getWRGB(image, x - 1, y + 1, myLuminance, 14));
				wrgb.add(getWRGB(image, x + 0, y + 1, myLuminance, 10));
				wrgb.add(getWRGB(image, x + 1, y + 1, myLuminance, 14));
				outImage.setRGB(x, y, wrgb.getColor());
			}
		}
		return outImage;
	}

	/**
	 * �d�ݕt��RGB�l���擾����B
	 * 
	 * @param image
	 *            �摜
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param centerLuminance
	 *            ���S�̖��x
	 * @param distance
	 *            ����
	 * @return �d�ݕt��RGB�l
	 */
	private static WRGB getWRGB(BufferedImage image, int x, int y,
			int centerLuminance, int distance) {
		int rgb = image.getRGB(x, y);
		int luminanceDifference = (rgb & 255) - centerLuminance;
		int w = getWeight(luminanceDifference, distance);
		return new WRGB(w, rgb);
	}

	/**
	 * 
	 * @param luminanceDifference
	 *            ??
	 * @param distance
	 *            ??
	 * @return ??
	 */
	private static int getWeight(int luminanceDifference, int distance) {
		int w1;
		if (luminanceDifference >= 0)
			w1 = 0;
		else
			w1 = -luminanceDifference;
		int w2 = 100 / (1 + distance);
		return w1 + w2;
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
		image = DarkFilter.execute(image);
		image = DarkFilter.execute(image);
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
