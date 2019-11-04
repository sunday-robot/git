package lib.imageoperator;

/**
 * RGBを簡単に扱うための関数群(クラスでは無い)。
 * 
 * @author akiyama
 * 
 */
public final class RGBUtility {
	/**
	 */
	private RGBUtility() {
	}

	/**
	 * RGB値を返す。
	 * 
	 * @param r
	 *            Red
	 * @param g
	 *            Green
	 * @param b
	 *            Blue
	 * @return RGB
	 */
	public static int rgb(int r, int g, int b) {
		return (r << 16) | (g << 8) | b;
	}

	/**
	 * RGB値からRed成分を返す。
	 * 
	 * @param rgb
	 *            RGB
	 * @return Red成分
	 */
	public static int red(int rgb) {
		return (rgb >> 16) & 0xff;
	}

	/**
	 * RGB値からGreen成分を返す。
	 * 
	 * @param rgb
	 *            RGB
	 * @return Green成分
	 */
	public static int green(int rgb) {
		return (rgb >> 8) & 0xff;
	}

	/**
	 * RGB値からBlue成分を返す。
	 * 
	 * @param rgb
	 *            RGB
	 * @return Blue成分
	 */
	public static int blue(int rgb) {
		return rgb & 0xff;
	}

	/**
	 * RGB値をモノクロ化する。(YUVのYにする)
	 * 
	 * @param rgb
	 *            RGB
	 * @return 輝度値
	 */
	public static int luminance(int rgb) {
		return (red(rgb) * 299 + green(rgb) * 587 + blue(rgb) * 114) / 1000;
	}

}
