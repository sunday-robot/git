package lib.imageoperator;

/**
 * 画像の輝度値の差を計算する。
 */
public final class Subtract {
	/***/
	private Subtract() {
	}

	/**
	 * @param image1
	 *            　画像1
	 * @param image2
	 *            画像2
	 * @return 画像1-画像2
	 */
	public static GrayImage execute(GrayImage image1, GrayImage image2) {
		int w = image1.width;
		int h = image1.height;
		GrayImage image3 = new GrayImage(w, h);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				image3.v[y][x] = image1.v[y][x] - image2.v[y][x];
			}
		}
		return image3;
	}
}
