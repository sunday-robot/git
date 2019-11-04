package lib.imageoperator;

/**
 * 簡単な統計情報を取得する
 */
public final class Statictics {
	/***/
	private Statictics() {
	}

	/**
	 * @param image
	 *            {@link GrayImage}
	 * @return 最低輝度値
	 */
	public static double getMin(GrayImage image) {
		double r = Double.MAX_VALUE;
		for (int y = 0; y < image.height; y++)
			for (int x = 0; x < image.width; x++)
				r = Math.min(image.v[y][x], r);
		return r;
	}

	/**
	 * @param image
	 *            {@link GrayImage}
	 * @return 最高輝度値
	 */
	public static double getMax(GrayImage image) {
		double r = Double.MIN_VALUE;
		for (int y = 0; y < image.height; y++)
			for (int x = 0; x < image.width; x++)
				r = Math.max(image.v[y][x], r);
		return r;
	}
}
