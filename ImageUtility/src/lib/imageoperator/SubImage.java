package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 * 
 */
public final class SubImage {
	/**
	 */
	private SubImage() {
	}

	/**
	 * �����摜�𐶐�����B <br/>
	 * getSubImage()�́A���摜�̃f�[�^���R�s�[���Ȃ�(�炵��)���A�{�N���X�̃��\�b�h�ł̓f�[�^���R�s�[����B
	 * 
	 * @param img
	 *            ���摜
	 * @param x
	 *            �����摜�̍�����W
	 * @param y
	 *            (����)
	 * @param width
	 *            �����摜�̕�(0�ȉ��̏ꍇ�́A���摜����؂�o����ő啝����A���̒l���������������̂𕔕��摜�̕��Ƃ���)
	 * @param height
	 *            �����摜�̍���(0�ȉ��̏ꍇ�́A���摜����؂�o����ő卂������A���̒l���������������̂𕔕��摜�̍����Ƃ���)
	 * @return �����摜(���摜�ɑ΂��A�����摜�̍��W��T�C�Y�w��ɖ�肪����؂�o���Ȃ��ꍇ��null��Ԃ��B)
	 */
	public static BufferedImage execute(BufferedImage img, final int x,
			final int y, final int width, final int height) {
		int w = calculateSize(x, width, img.getWidth());
		if (w <= 0) {
			return null;
		}
		int h = calculateSize(x, height, img.getHeight());
		if (h <= 0) {
			return null;
		}

		BufferedImage subImage = new BufferedImage(w, h,
				BufferedImage.TYPE_INT_RGB);
		for (int yy = 0; yy < h; yy++) {
			for (int xx = 0; xx < w; xx++) {
				subImage.setRGB(xx, yy, img.getRGB(x + xx, y + yy));
			}
		}
		return subImage;
	}

	/**
	 * ���ۂ̃T�C�Y��Ԃ��B
	 * 
	 * @param position
	 *            �؂�o���J�n���W
	 * @param specifiedSize
	 *            �؂�o�������T�C�Y�A0�ȉ��̏ꍇ�͌��摜����؂�o����ő啝���炱�̒l����������������
	 * @param originalImageSize
	 *            ���摜�̃T�C�Y
	 * @return ���ۂɐ؂�o���T�C�Y(0���������蓾��B���̏ꍇ�͐؂�o�����ł��Ȃ����Ƃ��Ӗ�����B)
	 */
	static int calculateSize(int position, int specifiedSize,
			int originalImageSize) {
		int v = originalImageSize - position;
		if (specifiedSize <= 0) {
			return v + specifiedSize;
		} else {
			return Math.min(specifiedSize, v);
		}
	}
}
