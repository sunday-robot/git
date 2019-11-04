package lib.imageoperator;

/**
 * 色とのブレンドを行った画像を生成する
 */
public final class ColorMix {
	/***/
	private ColorMix() {
	}

	/**
	 * @param image
	 *            入力画像
	 * @param color
	 *            ブレンドする色
	 * @param k
	 *            ブレンド率(0がブレンドしない、1は原画像を残さない)
	 * @return 出力画像
	 */
	public static ColorImage execute(ColorImage image, RGB color, double k) {
		double k2 = 1 - k;
		int w = image.width;
		int h = image.height;
		ColorImage image2 = new ColorImage(w, h);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				image2.v[y][x][0] = k2 * image.v[y][x][0] + k * color.r;
				image2.v[y][x][1] = k2 * image.v[y][x][1] + k * color.g;
				image2.v[y][x][2] = k2 * image.v[y][x][2] + k * color.b;
			}
		}
		return image2;
	}
}
