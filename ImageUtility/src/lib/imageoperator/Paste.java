package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 * 
 */
public final class Paste {
	/**
	 */
	private Paste() {
	}

	/**
	 * �摜A�̎w�肳�ꂽ���W�ɁA�摜B���y�[�X�g(�㏑���R�s�[)�����摜�𐶐����A�Ԃ��B<br/>
	 * �摜B�́A�摜A����͂ݏo�������͖��������B
	 * 
	 * @param a
	 *            �y�[�X�g��̉摜
	 * @param x
	 *            �y�[�X�g��̍��W
	 * @param y
	 *            (����)
	 * @param b
	 *            �y�[�X�g����摜
	 * @return �y�[�X�g���ꂽ�摜(�y�[�X�g��̉摜�Ƃ͓����傫�������ʃC���X�^���X)
	 */
	public static BufferedImage execute(BufferedImage a, final int x,
			final int y, BufferedImage b) {
		// BufferedImage c = clone(a);
		BufferedImage c = Cloner.execute(a);
		int ax;
		int ay;
		int bx;
		int by;
		if (x < 0) {
			ax = 0;
			bx = -x;
		} else {
			ax = x;
			bx = 0;
		}
		if (y < 0) {
			ay = 0;
			by = -y;
		} else {
			ay = y;
			by = 0;
		}
		int w = Math.min(b.getWidth(), a.getWidth() - x) - bx;
		int h = Math.min(b.getHeight(), a.getHeight() - y) - by;
		for (int yy = 0; yy < h; yy++) {
			for (int xx = 0; xx < w; xx++) {
				c.setRGB(ax + xx, ay + yy, b.getRGB(bx + xx, by + yy));
			}
		}
		return c;
	}

	// /**
	// *
	// * @param a
	// * @return
	// */
	// static BufferedImage clone(BufferedImage a) {
	// BufferedImage b = new BufferedImage(a.getWidth(), a.getHeight(),
	// a.getType());
	// for (int y = 0; y < a.getHeight(); y++) {
	// for (int x = 0; x < a.getWidth(); x++) {
	// b.setRGB(x, y, a.getRGB(x, y));
	// }
	// }
	// return b;
	// }
}
