/**
 * 絶対角度(0度からの角度)を示すクラス<br>
 * 相対角度は単純なdoubleで扱うことを想定している。<br>
 * 絶対角度なので、絶対角度同士の加算はないが、相対角度を加算することはある。<br>
 * 絶対角度同士の減算はあるが、結果は相対角度なので、double型である。
 * 
 * @author akiyama
 */
public class Angle {
    /** 角度（値域は???） */
    private double angle;

    /**
     * コンストラクタ
     * 
     * @param a
     *            角度
     */
    public Angle(double a) {
	angle = canonicalize(a);
    }

    /**
     * 角度を返す
     * 
     * @return 角度
     */
    public final double getAngle() {
	return angle;
    }

    /**
     * 角度を加算し、新たなインスタンスを返す。
     * 
     * @param a
     *            加算する角度
     * @return 新しいインスタンス
     */
    public final Angle add(double a) {
	return new Angle(angle + a);
    }

    /**
     * 指定された角度からの相対角度を返す。
     * 
     * @param a
     *            角度
     * @return 相対角度(-π ～ π)
     */
    public final double sub(Angle a) {
	double b = angle - a.angle;
	if (b > Math.PI)
	    return b - 2 * Math.PI;
	if (b < -Math.PI)
	    return b + 2 * Math.PI;
	return b;
    }

    /**
     * 角度を正規化(0~2πに)する。
     * 
     * @param a
     *            角度
     * @return 正規化された角度
     */
    private static double canonicalize(double a) {
	if (a > 0) {
	    return a % (2 * Math.PI);
	} else {
	    return a % (2 * Math.PI) + 2 * Math.PI;
	}
    }

}
