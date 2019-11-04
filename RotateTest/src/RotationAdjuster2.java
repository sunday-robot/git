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

    // �w�肳�ꂽ��`���A���݂̊p�x����A�w�肳�ꂽ�p�x�ɉ�]������B
    // ��]�̉ߒ��ŁA�w�肳�ꂽ��`�̈���͂ݏo�Ă��܂��ꍇ�́A�����ŉ�]���~�߁A���̎��̊p�x��Ԃ��B
    // (���݂̊p�x�ł��łɂ͂ݏo�Ă���P�[�X�ɂ��Ă͍l�����Ȃ��B)
    @Override
    public final double adjustRotation(double currentAngle, double newAngle) {
	// �e���_�����݂̉�]�p�x����w�肳�ꂽ�p�x�ɉ�]������ƕ`�����~�ʂƁA��`�̈�̊e�ӂƂ̌�_�����߂�B
	// ���̌�_����A�p�x�����߂�B
	// ��L�œ���ꂽ�p�x����ł����݂̊p�x�ɋ߂����̂�Ԃ��B
	// ���������_���Ȃ��ꍇ�́A�w�肳�ꂽ�p�x�����̂܂ܕԂ��B
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
     * �w�肳�ꂽY���W�̐������ƁA�~�̌�_�����߂�B
     * 
     * @param c
     *            ���S�_�̍��W
     * @param r
     *            �~�̔��a
     * @param y
     *            �������̍��W
     * @return ��_
     */
    static PointD calculateCrossPointH(PointD c, double r, double y) {
	double dy = y - c.y;
	double px = Math.sqrt(r * r - dy * dy) + c.x;
	PointD p = new PointD(px, y);
	return p;
    }

    /**
     * �_v���A�_���𒆐S��rot������]�������ۂɕ`�����ʂƁAy���W��b�̐������ƌ�������_�̉�]�p��Ԃ�
     * 
     * @param v
     *            ��]�Ώ̂̓_�̍��W
     * @param c
     *            ��]�̒��S�_�̍��W
     * @param rot
     *            ��]�p�x
     * @param b
     *            ��������Y���W
     * @return ��]�p�x
     */
    static double adjustedAngle(PointD v, PointD c, double rot, double b) {
	PointD d = new PointD(v.x - c.x, v.y - c.y);

	// v���Ac�𒆐S�Ƃ����ɍ��W�ɕϊ�
	double r = Math.sqrt(d.x * d.x + d.y * d.y);
	if (r <= Math.abs(b - c.y))
	    return Double.NaN; // ���������Ȃ��ꍇ(�ƁA1�_�ŐڐG����ꍇ)�͂��̒i�K�ŏI������B
	double theta = Math.atan2(d.x, d.y);

	// ��_�̍��W�����߂�B(�����������ł͂��𒆐S�Ƃ����ꍇ�̋ɍ��W�̊p�x�����̂�)
	Angle cpa1;
	Angle cpa2;
	{
	    double a = Math.asin((b - c.y) / r); // ��ڂ̌�_(X���傫����)
	    if (a > 0) {
		cpa1 = new Angle(a);
		cpa2 = new Angle(Math.PI - a);
	    } else {
		cpa1 = new Angle(Math.PI - a);
		cpa2 = new Angle(2 * Math.PI + a);
	    }
	}

	// 2�̌�_����1��I������B�I���̏����́A"theta��theta + rot�̊Ԃɂ�����́B"�ł���B(�ǂ�����܂܂��̂ł���΁Atheta�Ɏg������I������B)
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

	// �ʂ�\���֐�arc(t)(t��0�`1)
	// arc(t) = (r, theta + rot * t) + c

	// �ȉ��𖞂���t�̏������������߂�(�ȉ��̎��𖞂���t��0�`1�̊Ԃɂ͑��݂��Ȃ��A1���݂���A2���݂����3�p�^�[������)
	// arc(t).y = b

	// arc(t).y��W�J����B
	// arc(t).y = r * sin(theta + rot * t) + c.y

	// t�����߂�B
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
