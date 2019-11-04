package lib.imageoperator;

/**
 * フィルタで使用されるカーネルと呼ばれるデータ
 */
public final class Kernel extends GrayImage {
	/**
	 * @param width
	 *            カーネルの幅
	 * @param height
	 *            カーネルの高さ
	 */
	public Kernel(int width, int height) {
		super(width, height);
		for (int y = 0; y < height; y++)
			for (int x = 0; x < width; x++)
				v[y][x] = 1;
	}

	/**
	 * @param width
	 *            カーネルの幅
	 * @param height
	 *            カーネルの高さ
	 * @param v
	 *            カーネルの値
	 */
	public Kernel(int width, int height, double[] v) {
		super(width, height);
		int index = 0;
		for (int row = 0; row < height; row++) {
			for (int column = 0; column < width; column++) {
				this.v[row][column] = v[index++];
			}
		}
	}

	/**
	 * @param width
	 *            カーネルの幅
	 * @param height
	 *            カーネルの高さ
	 * @param v
	 *            カーネルの値
	 */
	public Kernel(int width, int height, double[][] v) {
		super(width, height);
		for (int row = 0; row < height; row++) {
			for (int column = 0; column < width; column++) {
				this.v[row][column] = v[row][column];
			}
		}
	}

	/**
	 * グレイスケール画像にカーネルを適用する
	 * 
	 * @param source
	 *            原画像
	 * @return 出力画像
	 */
	public GrayImage apply(GrayImage source) {
		GrayImage destination = new GrayImage(source.width, source.height);
		return apply(source, destination);
	}

	/**
	 * グレイスケール画像にカーネルを適用する
	 * 
	 * @param source
	 *            原画像
	 * @param destination
	 *            出力画像
	 * @return 出力画像
	 */
	public GrayImage apply(GrayImage source, GrayImage destination) {
		int cx = width / 2;
		int cy = height / 2;
		double weightSum = getWeightSum();

		// 画像上部
		for (int iy = 0; iy < cy; iy++)
			for (int ix = 0; ix < source.width; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);

		for (int iy = cy; iy < source.height - cy; iy++) {
			// 画像左部
			for (int ix = 0; ix < cx; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);

			// 画像中央部
			for (int ix = cx; ix < source.width - cx; ix++) {
				double r = 0;
				for (int ky = 0; ky < height; ky++)
					for (int kx = 0; kx < width; kx++)
						r += source.v[iy + ky - cy][ix + kx - cx] * v[ky][kx];
				destination.v[iy][ix] = r / weightSum;
			}

			// 画像右部
			for (int ix = source.width - cx; ix < source.width; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);
		}

		// 画像下部のカーネル適用できない部分はカーネル適用せず、現画像をそのまま出力する
		for (int iy = source.height - cy; iy < source.height; iy++)
			for (int ix = 0; ix < source.width; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);

		return destination;
	}

	/**
	 * カラー画像にカーネルを適用する
	 * 
	 * @param source
	 *            原画像
	 * @return 出力画像
	 */
	public ColorImage apply(ColorImage source) {
		ColorImage destination = new ColorImage(source.width, source.height);
		return apply(source, destination);
	}

	/**
	 * カラー画像にカーネルを適用する
	 * 
	 * @param source
	 *            原画像
	 * @param destination
	 *            出力画像
	 * @return 出力画像
	 */
	public ColorImage apply(ColorImage source, ColorImage destination) {
		int cx = width / 2;
		int cy = height / 2;
		double weightSum = getWeightSum();

		// 画像上部
		for (int iy = 0; iy < cy; iy++)
			for (int ix = 0; ix < source.width; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);

		for (int iy = cy; iy < source.height - cy; iy++) {
			// 画像左部
			for (int ix = 0; ix < cx; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);

			// 画像中央部
			double[] r = new double[3];
			for (int ix = cx; ix < source.width - cx; ix++) {
				for (int c = 0; c < 3; c++)
					r[c] = 0;
				for (int ky = 0; ky < height; ky++)
					for (int kx = 0; kx < width; kx++)
						for (int c = 0; c < 3; c++)
							r[c] += source.v[iy + ky - cy][ix + kx - cx][c]
									* v[ky][kx];
				for (int c = 0; c < 3; c++)
					destination.v[iy][ix][c] = r[c] / weightSum;
			}

			// 画像右部
			for (int ix = source.width - cx; ix < source.width; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);
		}

		// 画像下部
		for (int iy = source.height - cy; iy < source.height; iy++)
			for (int ix = 0; ix < source.width; ix++)
				apply(ix, iy, source, destination, cx, cy, weightSum);

		return destination;
	}

	/**
	 * @return カーネル全体の重み
	 */
	private double getWeightSum() {
		double sum = 0;
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				sum += v[y][x];
			}
		}
		return sum;
	}

	/**
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param source
	 *            原画像
	 * @param destination
	 *            出力画像
	 * @param cx
	 *            カーネルの中心座標
	 * @param cy
	 *            カーネルの中心座標
	 * @param weightSum
	 *            カーネル全体の重さ
	 */
	private void apply(final int x, final int y, GrayImage source,
			GrayImage destination, int cx, int cy, double weightSum) {
		double r = 0;
		for (int ky = 0; ky < height; ky++) {
			int yy = correct(y + ky - cy, source.height);
			for (int kx = 0; kx < width; kx++) {
				int xx = correct(x + kx - cx, source.width);
				r += source.v[yy][xx] * v[ky][kx];
			}
		}
		destination.v[y][x] = r / weightSum;
	}

	/**
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param source
	 *            原画像
	 * @param destination
	 *            出力画像
	 * @param cx
	 *            カーネルの中心座標
	 * @param cy
	 *            カーネルの中心座標
	 * @param weightSum
	 *            カーネル全体の重さ
	 */
	private void apply(int x, int y, ColorImage source, ColorImage destination,
			int cx, int cy, double weightSum) {
		double[] rgb = new double[3];
		for (int ky = 0; ky < height; ky++) {
			int yy = correct(y + ky - cy, source.height);
			for (int kx = 0; kx < width; kx++) {
				int xx = correct(x + kx - cx, source.width);
				for (int c = 0; c < 3; c++)
					rgb[c] += source.v[yy][xx][c] * v[ky][ky];
			}
		}
		for (int c = 0; c < 3; c++)
			destination.v[y][x][c] = rgb[c] / weightSum;
	}

	/**
	 * 座標値の補正を行う
	 * 
	 * @param value
	 *            補正前の座標値
	 * @param max
	 *            座標値の最大値の+1
	 * @return 補正後の座標値
	 */
	private static int correct(int value, int max) {
		if (value < 0)
			return 0;
		if (value >= max)
			return max - 1;
		return value;
	}

}
