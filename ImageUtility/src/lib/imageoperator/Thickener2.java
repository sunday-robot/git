package lib.imageoperator;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.misc.SaveOutputImage;

/**
 * �O���[�X�P�[���摜�̈Â������̖ʐς𑝂₷�B(�����𑾂�����B)
 */
public final class Thickener2 {
	/**
	 */
	private Thickener2() {
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

		for (y = 1; y < image.getHeight() - 1; y++) {
			for (x = 1; x < image.getWidth() - 1; x++) {
				int luminance = image.getRGB(x - 1, y - 1) & 255;
				luminance = Math.min(luminance,
						image.getRGB(x + 0, y - 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 1, y - 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x - 1, y + 0) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 0, y + 0) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 1, y + 0) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x - 1, y + 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 0, y + 1) & 255);
				luminance = Math.min(luminance,
						image.getRGB(x + 1, y + 1) & 255);
				int w = 255 - luminance;
				int myLuminance = image.getRGB(x, y) & 255;
				int myW = 128;
				int newLuminance = (myW * myLuminance + w * luminance)
						/ (myW + w);
				outImage.setRGB(x, y, (newLuminance << 16)
						| (newLuminance << 8) | myLuminance);
			}
		}
		return outImage;
	}

	/**
	 * �e�X�g�p�֐�
	 * 
	 * @param fileName
	 *            �t�@�C����
	 * @throws IOException
	 *             IOException
	 */
	public static void test(String fileName) throws IOException {
		BufferedImage image = ImageIO.read(new File(fileName));
		image = Monochrome.execute(image);
		image = Thickener2.execute(image);
		SaveOutputImage.execute(image, fileName, "png");
	}

	/**
	 * �e�X�g�p���C���֐�
	 * 
	 * @param args
	 *            �R�}���h���C�������͎g�p���Ȃ�
	 * @throws IOException
	 *             IOException
	 */
	public static void main(String[] args) throws IOException {
		test("testdata/darkfilter.bmp");
		test("testdata/honbun (008)_mini.jpg");
		test("testdata/a.png");
	}
}
