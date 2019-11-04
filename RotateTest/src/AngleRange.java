/**
 * �p�x�͈�
 * 
 * @author akiyama
 */
public class AngleRange {
    /** From */
    private Angle from;

    /** To */
    private double range;

    /**
     * �R���X�g���N�^
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
     * �w�肳�ꂽ�p�x���͈͓��ɂ��邩�ǂ�����Ԃ��B
     * 
     * @param a
     *            �p�x
     * @return �w�肳�ꂽ�p�x���͈͓��ɂ��邩�ǂ���
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
