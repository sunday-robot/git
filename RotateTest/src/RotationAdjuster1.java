import java.util.ArrayList;
import java.util.List;

/**
 * Rotation�p��Adjuster
 * 
 * @author satoshi_ouchi
 * 
 */
public class RotationAdjuster1 implements IRotationAdjuster {

    /**
     * ���t�@�����X�摜����͂ݏo���Ă��܂���]�p�x�͈͂̃��X�g
     */
    private List<Range> errorRangeList;

    @Override
    public final void initialize(RectangleD target, RectangleD area) {
	List<Range> ranges = new ArrayList<Range>();

	PointD center = target.getCenter();

	// target��4�̒��_�̋ɍ��W(r, ��)�����߂�i���_��target�̒��S�j
	double r;
	double[] thetas = new double[4];
	{
	    double dx = target.size.x / 2.0;
	    double dy = target.size.y / 2.0;

	    r = Math.sqrt(dx * dx + dy * dy);

	    Double theta = Math.atan2(dy, dx);
	    thetas[0] = canonicalAngle(theta); // �E��
	    thetas[1] = canonicalAngle(Math.PI - theta); // ����
	    thetas[2] = canonicalAngle(Math.PI + theta); // ����
	    thetas[3] = canonicalAngle(2 * Math.PI - theta); // �E��
	}

	// ��]�G���[�͈͂����߂�
	double radian1;
	double radian2;

	radian2 = Math.acos(((area.position.x + area.size.x) - center.x) / r);
	if (!Double.isNaN(radian2)) {
	    // ��`�̈�̉E���ɂ͂ݏo��\��������ꍇ
	    radian1 = 2 * Math.PI - radian2;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	radian1 = Math.asin((area.position.y + area.size.y - center.y) / r);
	if (!Double.isNaN(radian1)) {
	    // ��`�̈�̉����ɂ͂ݏo��\��������ꍇ
	    radian2 = Math.PI - radian1;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	radian1 = Math.acos((area.position.x - center.x) / r);
	if (!Double.isNaN(radian1)) {
	    // ��`�̈�̍����ɂ͂ݏo��\��������ꍇ
	    radian2 = 2 * Math.PI - radian1;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	radian2 = Math.asin((area.position.y - center.y) / r);
	if (!Double.isNaN(radian2)) {
	    // ��`�̈�̏㑤�ɂ͂ݏo��\��������ꍇ
	    radian1 = Math.PI - radian2;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	// errorRangeList = eliminateCrossover(ranges);
	errorRangeList = ranges;

	printErrorRangeList(errorRangeList);
    }

    private static List<Range> addRange(List<Range> ranges, double from,
	    double to) {
	// System.out.printf("addRange(, %f, %f)\n", from, to);
	from = Range.getCanonicalAngle(from);
	to = Range.getCanonicalAngle(to);
	if ((to == 0) || (from > to)) {
	    return addRange(addRange(ranges, new Range(0, to)), new Range(from,
		    2 * Math.PI));
	} else {
	    return addRange(ranges, new Range(from, to));
	}
    }

    private static List<Range> addRange(List<Range> ranges, Range newRange) {
	// System.out.printf("addRange(, %s)\n", newRange.toString());
	List<Range> newRanges = new ArrayList<Range>();
	for (Range range : ranges) {
	    if (newRange == null) {
		newRanges.add(range);
		continue;
	    }
	    if (range.getTo() < newRange.getFrom()) {
		newRanges.add(range);
		continue;
	    }
	    if (range.getFrom() > newRange.getTo()) {
		newRanges.add(newRange);
		newRanges.add(range);
		newRange = null;
		continue;
	    }
	    newRange = new Range(Math.min(range.getFrom(), newRange.getFrom()),
		    Math.max(range.getTo(), newRange.getTo()));
	}
	if (newRange != null)
	    newRanges.add(newRange);
	return newRanges;
    }

    /**
     * 
     * @param ranges
     *            �͈͂̃��X�g
     */
    public static void printErrorRangeList(List<Range> ranges) {
	StringBuffer sb = new StringBuffer();
	for (Range r : ranges) {
	    sb.append(r.toString());
	    sb.append(", ");
	}
	System.out.println(sb);
    }

    /**
     * ��]�p�x��␳����B
     * 
     * @param currentAngle
     *            ���O�̉�]�p�x
     * @param newAngle
     *            ���␳�̐V���ȉ�]�p�x
     * @return �␳���ꂽ��]�p�x
     */
    @Override
    public final double adjustRotation(double currentAngle, double newAngle) {
	// 0 �` 2PI�ɂ���
	double ret = newAngle % (2 * Math.PI);
	if (ret < 0) {
	    ret += 2 * Math.PI;
	}

	// true�̎��A�����̉�]
	boolean positive;

	double delta = ret - currentAngle;
	positive = delta > 0.0;
	if (Math.abs(delta) > Math.PI) {
	    positive = !positive;
	}

	// currentAngle���ǂ̃G���[�͈͂̊Ԃɑ��݂��邩���ׂ�B
	Range positiveRange = null;
	Range negativeRange = errorRangeList.get(errorRangeList.size() - 1);
	for (Range range : errorRangeList) {
	    if (range.getFrom() > currentAngle) {
		positiveRange = range;
		break;
	    }
	    if (range.getTo() >= currentAngle) {
		return currentAngle;
	    }
	    negativeRange = range;
	}
	if (positiveRange == null) {
	    positiveRange = errorRangeList.get(0);
	}

	for (Range range : errorRangeList) {
	    // �G���[�͈͂ɑ��݂��邩�H
	    if (range.contains(ret)) {
		if (range.contains(currentAngle)) {
		    return currentAngle;
		}
		if (positive) {
		    return range.getFrom();
		} else {
		    return range.getTo();
		}
	    }
	}

	return ret;
    }

    /**
     * ���K�����ꂽ�p�x��Ԃ��B
     * 
     * @param a
     *            �Ώۂ̊p�x
     * @return ���K�����ꂽ�p�x
     */
    private static double canonicalAngle(double a) {
	return a >= 0 ? a : a + 2 * Math.PI;
    }

}

/**
 * �͈͂����N���X
 * 
 * @author sugimoto
 * 
 */
class Range {

    /** From */
    private final double from;

    /** To */
    private final double to;

    /**
     * �R���X�g���N�^
     * 
     * @param from
     *            From
     * @param to
     *            To
     */
    public Range(double from, double to) {
	this.from = from;
	if (to == 0) {
	    this.to = 2 * Math.PI;

	} else {
	    this.to = to;
	}
	assert this.from < this.to;
    }

    /**
     * ���K�����ꂽ�p�x��Ԃ��B
     * 
     * @param a
     *            ���K���Ώۂ̊p�x
     * @return ���K�����ꂽ�p�x
     */
    public static double getCanonicalAngle(double a) {
	a %= 2 * Math.PI;
	if (a < 0)
	    return a + 2 * Math.PI;
	else
	    return a;
    }

    /**
     * �A�N�Z�b�T
     * 
     * @return From
     */
    public double getFrom() {
	return from;
    }

    /**
     * �A�N�Z�b�T
     * 
     * @return To
     */
    public double getTo() {
	return to;
    }

    /**
     * �w�肳�ꂽ�p�x���܂ނ��ǂ�����Ԃ��B
     * 
     * @param a
     *            �p�x
     * @return �܂ނ��ǂ���
     */
    public boolean contains(double a) {
	a = getCanonicalAngle(a);
	if (from > to) {
	    return a > from || a < to;
	} else {
	    return a > from && a < to;
	}
    }

    /**
     * ���W�A���P�ʂ̊p�x��x�P�ʂɕϊ�����B
     * 
     * @param rad
     *            ���W�A���P�ʂ̊p�x
     * @return �x�P�ʂ̊p�x
     */
    private static double toDegree(double rad) {
	return (int) (rad / Math.PI * 180);
    }

    @Override
    public String toString() {
	return "Range:(" + toDegree(from) + ", " + toDegree(to) + ")";
    }

}
