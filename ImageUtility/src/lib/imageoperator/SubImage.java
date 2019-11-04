package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 * 
 */
public final class SubImage {
	/**
	 */
	private SubImage() {
	}

	/**
	 * 部分画像を生成する。 <br/>
	 * getSubImage()は、元画像のデータをコピーしない(らしい)が、本クラスのメソッドではデータをコピーする。
	 * 
	 * @param img
	 *            原画像
	 * @param x
	 *            部分画像の左上座標
	 * @param y
	 *            (同上)
	 * @param width
	 *            部分画像の幅(0以下の場合は、原画像から切り出せる最大幅から、この値を差し引いたものを部分画像の幅とする)
	 * @param height
	 *            部分画像の高さ(0以下の場合は、原画像から切り出せる最大高さから、この値を差し引いたものを部分画像の高さとする)
	 * @return 部分画像(原画像に対し、部分画像の座標やサイズ指定に問題があり切り出せない場合はnullを返す。)
	 */
	public static BufferedImage execute(BufferedImage img, final int x,
			final int y, final int width, final int height) {
		int w = calculateSize(x, width, img.getWidth());
		if (w <= 0) {
			return null;
		}
		int h = calculateSize(x, height, img.getHeight());
		if (h <= 0) {
			return null;
		}

		BufferedImage subImage = new BufferedImage(w, h,
				BufferedImage.TYPE_INT_RGB);
		for (int yy = 0; yy < h; yy++) {
			for (int xx = 0; xx < w; xx++) {
				subImage.setRGB(xx, yy, img.getRGB(x + xx, y + yy));
			}
		}
		return subImage;
	}

	/**
	 * 実際のサイズを返す。
	 * 
	 * @param position
	 *            切り出し開始座標
	 * @param specifiedSize
	 *            切り出したいサイズ、0以下の場合は原画像から切り出せる最大幅からこの値を差し引いたもの
	 * @param originalImageSize
	 *            原画像のサイズ
	 * @return 実際に切り出すサイズ(0未満もあり得る。この場合は切り出しができないことを意味する。)
	 */
	static int calculateSize(int position, int specifiedSize,
			int originalImageSize) {
		int v = originalImageSize - position;
		if (specifiedSize <= 0) {
			return v + specifiedSize;
		} else {
			return Math.min(specifiedSize, v);
		}
	}
}
