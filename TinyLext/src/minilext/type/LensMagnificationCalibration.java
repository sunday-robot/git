package minilext.type;

/**
 * 対物レンズの倍率の補正係数(対物レンズの仕様上の倍率に、本係数を乗ずることで、正しい倍率になる
 */
public final class LensMagnificationCalibration {

	/** X方向の係数 */
	public final double x;
	/** Y方向の係数 */
	public final double y;

	/**
	 * @param x
	 *            :
	 * @param y
	 *            :
	 */
	public LensMagnificationCalibration(double x, double y) {
		this.x = x;
		this.y = y;
	}
}
