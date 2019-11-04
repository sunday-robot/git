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
	 * 画像Aの指定された座標に、画像Bをペースト(上書きコピー)した画像を生成し、返す。<br/>
	 * 画像Bの、画像Aからはみ出す部分は無視される。
	 * 
	 * @param a
	 *            ペースト先の画像
	 * @param x
	 *            ペースト先の座標
	 * @param y
	 *            (同上)
	 * @param b
	 *            ペーストする画像
	 * @return ペーストされた画像(ペースト先の画像とは同じ大きさだが別インスタンス)
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
