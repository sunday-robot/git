package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 */
public final class Trim {
	/**
	 */
	private Trim() {
	}

	/**
	 * �㉺���E���J�b�g�����摜��Ԃ��B
	 * 
	 * @param image
	 *            ���摜
	 * @param left
	 *            �����̃h�b�g��
	 * @param right
	 *            (����)
	 * @param top
	 *            (����)
	 * @param bottom
	 *            (����)
	 * @return �㉺���E���J�b�g���ꂽ�摜
	 */
	public static BufferedImage execute(BufferedImage image, int left,
			int right, int top, int bottom) {
		return image.getSubimage(top, left, image.getHeight() - top - bottom
				- 1, image.getWidth() - left - right - 1);
	}
}
