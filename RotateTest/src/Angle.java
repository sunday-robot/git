/**
 * ��Ίp�x(0�x����̊p�x)�������N���X<br>
 * ���Ίp�x�͒P����double�ň������Ƃ�z�肵�Ă���B<br>
 * ��Ίp�x�Ȃ̂ŁA��Ίp�x���m�̉��Z�͂Ȃ����A���Ίp�x�����Z���邱�Ƃ͂���B<br>
 * ��Ίp�x���m�̌��Z�͂��邪�A���ʂ͑��Ίp�x�Ȃ̂ŁAdouble�^�ł���B
 * 
 * @author akiyama
 */
public class Angle {
    /** �p�x�i�l���???�j */
    private double angle;

    /**
     * �R���X�g���N�^
     * 
     * @param a
     *            �p�x
     */
    public Angle(double a) {
	angle = canonicalize(a);
    }

    /**
     * �p�x��Ԃ�
     * 
     * @return �p�x
     */
    public final double getAngle() {
	return angle;
    }

    /**
     * �p�x�����Z���A�V���ȃC���X�^���X��Ԃ��B
     * 
     * @param a
     *            ���Z����p�x
     * @return �V�����C���X�^���X
     */
    public final Angle add(double a) {
	return new Angle(angle + a);
    }

    /**
     * �w�肳�ꂽ�p�x����̑��Ίp�x��Ԃ��B
     * 
     * @param a
     *            �p�x
     * @return ���Ίp�x(-�� �` ��)
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
     * �p�x�𐳋K��(0~2�΂�)����B
     * 
     * @param a
     *            �p�x
     * @return ���K�����ꂽ�p�x
     */
    private static double canonicalize(double a) {
	if (a > 0) {
	    return a % (2 * Math.PI);
	} else {
	    return a % (2 * Math.PI) + 2 * Math.PI;
	}
    }

}
