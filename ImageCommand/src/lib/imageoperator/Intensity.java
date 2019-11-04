package lib.imageoperator;

/**
 * カラー画像から輝度値画像(HSVのV画像)を生成する。
 */
public final class Intensity {
	/***/
	private Intensity() {
	}

	/**
	 * @param image
	 *            入力画像
	 * @return 出力画像
	 */
	public static GrayImage execute(ColorImage image) {
		GrayImage image2 = new GrayImage(image.width, image.height);
		int w = image.width;
		int h = image.height;
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				double r = image.v[y][x][0];
				double g = image.v[y][x][1];
				double b = image.v[y][x][2];
				double intensity = Math.max(r, Math.max(g, b));
				image2.v[y][x] = intensity;
			}
		}
		return image2;
	}
}
