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
	 * 上下左右をカットした画像を返す。
	 * 
	 * @param image
	 *            原画像
	 * @param left
	 *            左側のドット数
	 * @param right
	 *            (同上)
	 * @param top
	 *            (同上)
	 * @param bottom
	 *            (同上)
	 * @return 上下左右がカットされた画像
	 */
	public static BufferedImage execute(BufferedImage image, int left,
			int right, int top, int bottom) {
		return image.getSubimage(top, left, image.getHeight() - top - bottom
				- 1, image.getWidth() - left - right - 1);
	}
}
