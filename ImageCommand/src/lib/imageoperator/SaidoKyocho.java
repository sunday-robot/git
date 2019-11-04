package lib.imageoperator;

/**
 * 彩度を強調（あるいはその逆を）するフィルター
 */
public final class SaidoKyocho {
	/***/
	private SaidoKyocho() {
	}

	/**
	 * @param image
	 *            処理対象の画像
	 * @param k
	 *            彩度に乗じる係数
	 * @param c
	 *            彩度に加算する定数
	 * @return 出力画像
	 */
	public static ColorImage execute(ColorImage image, double k, double c) {
		int w = image.width;
		int h = image.height;
		ColorImage image2 = new ColorImage(w, h);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				HSV hsv = HSV.createFromRGB(image.v[y][x]);
				HSV hsv2 = new HSV(hsv.h, hsv.s * k + c, hsv.v);
				hsv2.toRGB(image2.v[y][x]);
			}
		}
		return image2;
	}
}
