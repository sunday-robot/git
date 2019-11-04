/**
 * ���W��double�^��Point
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
     * �R���X�g���N�^
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
     * �_C�𒆐S��angle������]���������W��Ԃ��B
     * 
     * @param c
     *            ���S
     * @param angle
     *            ��]�p�x
     * @return ��]��̍��W
     */
    public final PointD rotate(PointD c, double angle) {
	double si = Math.sin(angle);
	double co = Math.cos(angle);
	PointD d = this.sub(c);
	return new PointD(co * d.x - si * d.y + c.x, si * d.x + co * d.y + c.y);
    }

    /**
     * ���Z����
     * 
     * @param p
     *            PointD
     * @return ���Z��̒l
     */
    public final PointD add(PointD p) {
	return new PointD(x + p.x, y + p.y);
    }

    /**
     * ���Z����
     * 
     * @param p
     *            PointD
     * @return ���Z��̒l
     */
    public final PointD sub(PointD p) {
	return new PointD(x - p.x, y - p.y);
    }

}
