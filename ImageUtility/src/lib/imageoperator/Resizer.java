package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 */
public final class Resizer {
	/**
	 */
	private Resizer() {
	}

	/**
	 * 画像を指定されたサイズに縮小/拡大する。
	 * 
	 * @param image
	 *            原画像
	 * @param width
	 *            新しい幅
	 * @param height
	 *            新しい高さ
	 * @return リサイズ後の画像
	 */
	public static BufferedImage execute(BufferedImage image, int width,
			int height) {
		BufferedImage dest = new BufferedImage(width, height, image.getType());
		int srcWidth = image.getWidth();
		int srcHeight = image.getHeight();

		int dy;
		int gy;
		for (dy = 0, gy = 0; dy < height; dy++, gy += srcHeight) {
			// 左、右端部分の縮小元画像の画素の座標と、グローバル座標における
			// 高さ
			int sy1 = gy / height;
			int sh1 = height - gy % height;
			int sy2 = (gy + srcHeight - 1) / height;
			int sh2 = (gy + srcHeight - 1) % height + 1;

			int dx;
			int gx;
			for (dx = 0, gx = 0; dx < width; dx++, gx += srcWidth) {
				int sx1 = gx / width;
				int sw1 = width - gx % width;
				int sx2 = (gx + srcWidth - 1) / width;
				int sw2 = (gx + srcWidth - 1) % width + 1;

				// 重みつき画素値
				WRGB wrgb = new WRGB();

				// 上辺部分の重みつき画素値を計算
				wrgb.add(calculateRow(sx1, sw1, width, sx2, sw2, sy1, sh1,
						image));

				// 中央部分の重みつき画素値を計算
				int y;
				for (y = sy1 + 1; y < sy2; y++) {
					wrgb.add(calculateRow(sx1, sw1, width, sx2, sw2, y, height,
							image));
				}

				// 下辺部分の重みつき画素値を計算
				if (sy2 > sy1) {
					wrgb.add(calculateRow(sx1, sw1, width, sx2, sw2, sy2, sh2,
							image));
				}

				// 縮小先画像に画素値をセット
				dest.setRGB(dx, dy, wrgb.getColor());
			}
		}

		return dest;
	}

	/**
	 * 1ライン分の重み付き画素値を計算する
	 * 
	 * @param sx1
	 *            SX1
	 * @param sw1
	 *            SW1
	 * @param width
	 *            幅
	 * @param sx2
	 *            SX2
	 * @param sw2
	 *            SW2
	 * @param y
	 *            Y
	 * @param height
	 *            高さ
	 * @param image
	 *            BufferedImage
	 * @return WRGB
	 */
	private static WRGB calculateRow(int sx1, int sw1, int width, int sx2,
			int sw2, int y, int height, BufferedImage image) {
		WRGB wrgb = new WRGB();

		// 左端の重みつき画素値を計算
		wrgb.add(sw1 * height, image.getRGB(sx1, y));

		// 中央部の重みつき画素値を計算
		int x;
		for (x = sx1 + 1; x < sx2; x++) {
			wrgb.add(width * height, image.getRGB(x, y));
		}

		// 右辺部分の重みつき画素値を計算
		if (sx2 > sx1) {
			wrgb.add(sw2 * height, image.getRGB(sx2, y));
		}

		return wrgb;
	}

}
