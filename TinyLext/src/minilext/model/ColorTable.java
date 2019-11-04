package minilext.model;

import minilext.type.Lut;
import minilext.type.Rgb;

/**
 * 表示用のLUT
 */
public final class ColorTable {

	/** LUTの適用開始輝度値 */
	private final int min;

	/** LUTの適用終了輝度値 */
	private final int max;

	/** LUT */
	private final Rgb[] colorTable;

	/**
	 * @param min
	 *            最小輝度値
	 * @param max
	 *            最大輝度値
	 * @param lut
	 *            LUT
	 */
	public ColorTable(int min, int max, Lut lut) {
		this.min = min;
		this.max = max;
		colorTable = createColorTable(max - min + 1, lut);
	}

	/**
	 * @param size
	 *            カラーテーブルのサイズ
	 * @param lut
	 *            LUT
	 * @return カラーテーブル
	 */
	private static Rgb[] createColorTable(int size, Lut lut) {
		Rgb[] colorTable = new Rgb[size];
		colorTable[0] = lut.rgb[0];
		colorTable[size - 1] = lut.rgb[lut.rgb.length - 1];
		for (int i = 1; i < size - 1; i++) {
			int r = 0;
			int g = 0;
			int b = 0;
			for (int j = 0; j < lut.rgb.length; j++) {
				int index = (i * lut.rgb.length + j) / size;
				Rgb rgb = lut.rgb[index];
				r += rgb.r;
				g += rgb.g;
				b += rgb.b;
			}
			r /= lut.rgb.length;
			g /= lut.rgb.length;
			b /= lut.rgb.length;
			colorTable[i] = new Rgb(r, g, b);
		}
		return colorTable;
	}

	/**
	 * @param v
	 *            輝度値
	 * @return RGB
	 */
	public Rgb getColor(int v) {
		if (v <= min)
			return colorTable[0];
		if (v >= max)
			return colorTable[colorTable.length - 1];
		return colorTable[v - min];
	}
}
