package lib.imageoperator;

/**
 * 色とのブレンドを行った画像を元に戻す
 * 
 * blended = original * (1 - k) + color * k
 * 
 * original = (blended - color * k) / (1 - k)
 */
public final class SeparateFromColor {
	/***/
	private SeparateFromColor() {
	}

	/**
	 * @param image
	 *            入力画像
	 * @param color
	 *            ブレンドする色
	 * @param k
	 *            ブレンド率(0.0～1.0。0がブレンドしない、1は原画像を残さない)
	 * @return 出力画像
	 */
	public static ColorImage execute(ColorImage image, RGB color, double k) {
		double k1 = 1 / (1 - k);
		double k2 = k / (1 - k);
		int w = image.width;
		int h = image.height;
		ColorImage image2 = new ColorImage(w, h);
		double r = k2 * color.r;
		double g = k2 * color.g;
		double b = k2 * color.b;
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				image2.v[y][x][0] = k1 * image.v[y][x][0] - r;
				image2.v[y][x][1] = k1 * image.v[y][x][1] - g;
				image2.v[y][x][2] = k1 * image.v[y][x][2] - b;
			}
		}
		return image2;
	}
}
