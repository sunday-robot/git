package lib.imageoperator;

/**
 * 画像の輝度値の和を計算する。
 */
public final class Add {
	/***/
	private Add() {
	}

	/**
	 * 二つの画像の輝度値を足した画像を生成する
	 * 
	 * @param image1
	 *            画像1
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
				image3.v[y][x] = image1.v[y][x] + image2.v[y][x];
			}
		}
		return image3;
	}

	/**
	 * 画像に指定された輝度値を足した画像を生成する
	 * 
	 * @param image
	 *            画像
	 * @param d
	 *            加算する輝度値
	 * @return 結果画像
	 */
	public static GrayImage execute(GrayImage image, double d) {
		int w = image.width;
		int h = image.height;
		GrayImage image2 = new GrayImage(w, h);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				image2.v[y][x] = image.v[y][x] + d;
			}
		}
		return image2;
	}
}
