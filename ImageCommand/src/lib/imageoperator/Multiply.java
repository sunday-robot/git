package lib.imageoperator;

/**
 * 画像の輝度値に係数を乗じる。
 */
public final class Multiply {
	/***/
	private Multiply() {
	}

	/**
	 * @param image
	 *            　画像1
	 * @param k
	 *            掛ける数
	 * @return 画像*k
	 */
	public static GrayImage execute(GrayImage image, double k) {
		int w = image.width;
		int h = image.height;
		GrayImage image2 = new GrayImage(w, h);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				image2.v[y][x] = image.v[y][x] * k;
			}
		}
		return image2;
	}
}
