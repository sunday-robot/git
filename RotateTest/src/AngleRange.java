/**
 * 角度範囲
 * 
 * @author akiyama
 */
public class AngleRange {
    /** From */
    private Angle from;

    /** To */
    private double range;

    /**
     * コンストラクタ
     * 
     * @param from
     *            Angle
     * @param range
     *            double
     */
    public AngleRange(Angle from, double range) {
	this.from = from;
	if ((range >= 2 * Math.PI) || (range <= -2 * Math.PI))
	    this.range = Double.NaN;
	else
	    this.range = range;
    }

    /**
     * 指定された角度が範囲内にあるかどうかを返す。
     * 
     * @param a
     *            角度
     * @return 指定された角度が範囲内にあるかどうか
     */
    public final boolean contains(Angle a) {
	if (range == Double.NaN)
	    return true;
	double b = a.sub(from);
	if (range > 0) {
	    return b <= range;
	} else {
	    return b >= range;
	}
    }
}
