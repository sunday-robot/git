package lib.imageoperator;

/**
 * 以下のように非常に簡素なボケ画像を生成するもの。
 * 
 * すべて重み1のカーネル
 * 
 * 周辺では原画像そのまま。
 * 
 */
public final class Bokeh {
	/***/
	private Bokeh() {
	}

	/**
	 * @param image
	 *            入力画像
	 * @param kernelSize
	 *            カーネルのサイズ
	 * @return 出力画像
	 */
	public static ColorImage execute(ColorImage image, int kernelSize) {
		Kernel kernel = new Kernel(kernelSize, kernelSize);
		ColorImage bokehImage = kernel.apply(image);
		return bokehImage;
	}

	/**
	 * @param image
	 *            入力画像
	 * @param kernelSize
	 *            カーネルのサイズ
	 * @return 出力画像
	 */
	public static GrayImage execute(GrayImage image, int kernelSize) {
		Kernel kernel = new Kernel(kernelSize, kernelSize);
		GrayImage bokehImage = kernel.apply(image);
		return bokehImage;
	}
}
