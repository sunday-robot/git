package lib.imageoperator;

/**
 * RGB���ȒP�Ɉ������߂̊֐��Q(�N���X�ł͖���)�B
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
	 * RGB�l��Ԃ��B
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
	 * RGB�l����Red������Ԃ��B
	 * 
	 * @param rgb
	 *            RGB
	 * @return Red����
	 */
	public static int red(int rgb) {
		return (rgb >> 16) & 0xff;
	}

	/**
	 * RGB�l����Green������Ԃ��B
	 * 
	 * @param rgb
	 *            RGB
	 * @return Green����
	 */
	public static int green(int rgb) {
		return (rgb >> 8) & 0xff;
	}

	/**
	 * RGB�l����Blue������Ԃ��B
	 * 
	 * @param rgb
	 *            RGB
	 * @return Blue����
	 */
	public static int blue(int rgb) {
		return rgb & 0xff;
	}

	/**
	 * RGB�l�����m�N��������B(YUV��Y�ɂ���)
	 * 
	 * @param rgb
	 *            RGB
	 * @return �P�x�l
	 */
	public static int luminance(int rgb) {
		return (red(rgb) * 299 + green(rgb) * 587 + blue(rgb) * 114) / 1000;
	}

}
