/**
 * 座標がdouble型のPoint
 * 
 * @author akiyama
 * 
 */
public class PointD {
    /** X */
    public final double x;
    /** Y */
    public final double y;

    /**
     * コンストラクタ
     * 
     * @param x
     *            X
     * @param y
     *            Y
     */
    public PointD(double x, double y) {
	this.x = x;
	this.y = y;
    }

    @Override
    public final String toString() {
	return "(" + Double.toString(x) + ", " + Double.toString(y) + ")";
    }

    /**
     * 点Cを中心にangleだけ回転させた座標を返す。
     * 
     * @param c
     *            中心
     * @param angle
     *            回転角度
     * @return 回転後の座標
     */
    public final PointD rotate(PointD c, double angle) {
	double si = Math.sin(angle);
	double co = Math.cos(angle);
	PointD d = this.sub(c);
	return new PointD(co * d.x - si * d.y + c.x, si * d.x + co * d.y + c.y);
    }

    /**
     * 加算する
     * 
     * @param p
     *            PointD
     * @return 加算後の値
     */
    public final PointD add(PointD p) {
	return new PointD(x + p.x, y + p.y);
    }

    /**
     * 減算する
     * 
     * @param p
     *            PointD
     * @return 減算後の値
     */
    public final PointD sub(PointD p) {
	return new PointD(x - p.x, y - p.y);
    }

}
