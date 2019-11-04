package minilext.type;

/**
 * 対物レンズ及びズーム倍率のための倍率型
 */
public final class Magnification {

	/**
	 * 倍率*10
	 */
	private int valueX10;

	/**
	 * @param value
	 *            整数部
	 * @param decimalPartValue
	 *            小数部(0~9)
	 */
	public Magnification(int value, int decimalPartValue) {
		valueX10 = value * 10 + decimalPartValue;
	}

	/**
	 * @return 倍率*10
	 */
	public int getValueX10() {
		return valueX10;
	}

	/**
	 * @return 倍率
	 */
	public double getValue() {
		return valueX10 / 10.0;
	}
}
