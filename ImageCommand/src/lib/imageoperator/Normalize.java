package lib.imageoperator;

/**
 * 輝度値の範囲を調整する。
 */
public final class Normalize {
	/***/
	private Normalize() {
	}

	/**
	 * @param image
	 *            {@link GrayImage}任意の輝度値範囲の画像
	 * @return 輝度値が0～1に変換された画像
	 */
	public static GrayImage normalize(GrayImage image) {
		double min = Statictics.getMin(image);
		double max = Statictics.getMax(image);
		return normalize(image, min, max);
	}

	/**
	 * @param image
	 *            {@link GrayImage}任意の輝度値範囲の画像
	 * @param min
	 *            最低輝度値
	 * @param max
	 *            最高輝度値
	 * @return 輝度値が0～1に変換された画像
	 */
	private static GrayImage normalize(GrayImage image, double min, double max) {
		GrayImage dest = new GrayImage(image.width, image.height);
		double k = 1 / (max - min);
		for (int y = 0; y < image.height; y++) {
			for (int x = 0; x < image.width; x++) {
				dest.v[y][x] = Math.min(Math.max((image.v[y][x] - min) * k, 0),
						1.0);
			}
		}
		return dest;
	}
}
