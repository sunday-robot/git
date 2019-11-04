import java.util.List;

/**
 * 
 * @author akiyama
 * 
 */
public class RotationAdjuster2 implements IRotationAdjuster {
    /***/
    RectangleD target;

    /***/
    RectangleD area;

    @Override
    public final void initialize(RectangleD target, RectangleD area) {
	this.target = target;
	this.area = area;
    }

    /**
     * 
     * @param a
     *            double
     * @param b
     *            double
     * @return ???
     */
    private static double absMin(double a, double b) {
	if ((a == Double.NaN) || (b == Double.NaN))
	    return Double.NaN;
	if (a < 0) {
	    return (a < b) ? b : a;
	}
	return (a > b) ? b : a;
    }

    // 指定された矩形を、現在の角度から、指定された角度に回転させる。
    // 回転の過程で、指定された矩形領域をはみ出てしまう場合は、そこで回転を止め、その時の角度を返す。
    // (現在の角度ですでにはみ出ているケースについては考慮しない。)
    @Override
    public final double adjustRotation(double currentAngle, double newAngle) {
	// 各頂点を現在の回転角度から指定された角度に回転させると描かれる円弧と、矩形領域の各辺との交点を求める。
	// この交点から、角度を求める。
	// 上記で得られた角度から最も現在の角度に近いものを返す。
	// もし一つも交点がない場合は、指定された角度をそのまま返す。
	double adjustedAngle = newAngle;

	PointD c = this.target.getCenter();
	List<PointD> vs = this.target.rotate(currentAngle);
	double rot = newAngle - currentAngle;

	for (int i = 0; i < 4; i++) {
	    adjustedAngle = absMin(adjustedAngle,
		    adjustedAngle(vs.get(i), c, currentAngle, rot));
	}
	return adjustedAngle;
    }

    /**
     * 指定されたY座標の水平線と、円の交点を求める。
     * 
     * @param c
     *            中心点の座標
     * @param r
     *            円の半径
     * @param y
     *            水平線の座標
     * @return 交点
     */
    static PointD calculateCrossPointH(PointD c, double r, double y) {
	double dy = y - c.y;
	double px = Math.sqrt(r * r - dy * dy) + c.x;
	PointD p = new PointD(px, y);
	return p;
    }

    /**
     * 点vを、点ｃを中心にrotだけ回転させた際に描かれる弧と、y座標がbの水平線と交差する点の回転角を返す
     * 
     * @param v
     *            回転対称の点の座標
     * @param c
     *            回転の中心点の座標
     * @param rot
     *            回転角度
     * @param b
     *            水平線のY座標
     * @return 回転角度
     */
    static double adjustedAngle(PointD v, PointD c, double rot, double b) {
	PointD d = new PointD(v.x - c.x, v.y - c.y);

	// vを、cを中心とした極座標に変換
	double r = Math.sqrt(d.x * d.x + d.y * d.y);
	if (r <= Math.abs(b - c.y))
	    return Double.NaN; // 交差し得ない場合(と、1点で接触する場合)はこの段階で終了する。
	double theta = Math.atan2(d.x, d.y);

	// 交点の座標を求める。(ただしここではｃを中心とした場合の極座標の角度成分のみ)
	Angle cpa1;
	Angle cpa2;
	{
	    double a = Math.asin((b - c.y) / r); // 一つ目の交点(Xが大きい方)
	    if (a > 0) {
		cpa1 = new Angle(a);
		cpa2 = new Angle(Math.PI - a);
	    } else {
		cpa1 = new Angle(Math.PI - a);
		cpa2 = new Angle(2 * Math.PI + a);
	    }
	}

	// 2つの交点から1つを選択する。選択の条件は、"thetaとtheta + rotの間にあるもの。"である。(どちらも含まれるのであれば、thetaに使い方を選択する。)
	Angle t = new Angle(theta);
	AngleRange ar = new AngleRange(t, rot);
	if (rot > 0) {
	    if (ar.contains(cpa1)) {
		return cpa1.sub(t);
	    }
	    if (ar.contains(cpa2)) {
		return cpa2.sub(t);
	    }
	} else {
	    if (ar.contains(cpa2)) {
		return cpa2.sub(t);
	    }
	    if (ar.contains(cpa1)) {
		return cpa1.sub(t);
	    }
	}
	return Double.NaN;

	// 弧を表す関数arc(t)(tは0～1)
	// arc(t) = (r, theta + rot * t) + c

	// 以下を満たすtの小さい方を求める(以下の式を満たすtは0～1の間には存在しない、1つ存在する、2つ存在するの3パターンある)
	// arc(t).y = b

	// arc(t).yを展開する。
	// arc(t).y = r * sin(theta + rot * t) + c.y

	// tを求める。
	// r * sin(theta + rot * t) + c.y = b
	// r * sin(theta + rot * t) = b - c.y
	// sin(theta + rot * t) = (b - c.y) / r
	// theta + rot * t = asin((b - c.y) / r)
	// rot * t = asin((b - c.y) / r) - theta
	// t = ((asin((b - c.y) / r) - theta) / rot
	// t = ((asin((b - c.y) / r) - atan2(d.x, d.y)) / rot
	//

	// arc(t).y = y
	// si * r + c.y = y
	// si = (y - c.y) / r
	// theta + rot * t = asin((y - c.y) / r)
	// rot * t = asin((y - c.y) / r) - theta
	// t = (asin((y - c.y) / r) - theta) / rot
	// t = (asin((y - c.y) / r) - atan2(d.x, d.y)) / rot
    }

}
