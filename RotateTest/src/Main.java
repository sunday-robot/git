import java.util.List;

import org.junit.Test;

/**
 * �e�X�g
 * 
 * @author akiyama
 */
public class Main {

    /**
     * @param args
     *            x, y, w, h, amgle
     */
    public static void main(String[] args) {
	int x = Integer.parseInt(args[0]);
	int y = Integer.parseInt(args[1]);
	int w = Integer.parseInt(args[2]);
	int h = Integer.parseInt(args[3]);
	double currentAngle = Double.parseDouble(args[4]) / 180 * Math.PI;
	double newAngle = Double.parseDouble(args[5]) / 180 * Math.PI;

	testAdjustRotation(x, y, w, h, currentAngle, newAngle);
    }

    /**
     * ��]�����������Ȃ��P�[�X
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test1() {
	testAdjustRotation(100, 100, 100, 100, 0, Math.PI / 3);
    }

    /**
     * ��̕ӂɂ������Ă���P�[�X
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test2() {
	testAdjustRotation(100, 0, 100, 100, 0, Math.PI / 3);
	testAdjustRotation(100, 0, 100, 100, Math.PI / 2, Math.PI / 2 + Math.PI
		/ 3);
    }

    /**
     * 
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test3() {
	// ���̕ӂɂ������Ă���P�[�X
	testAdjustRotation(0, 100, 100, 100, 0, Math.PI / 3);
    }

    /**
     * 
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test4() {
	// ����ɂ������Ă���P�[�X
	testAdjustRotation(0, 0, 100, 100, 0, Math.PI / 3);
    }

    /**
     * ��̕ӂ���1�h�b�g���ɂ���P�[�X
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test5() {
	testAdjustRotation(100, 1, 100, 100, 0, Math.PI / 3);
    }

    /**
     * ���W�A���P�ʂ̊p�x��x�̒P�ʂɕϊ�����
     * 
     * @param r
     *            ���W�A���P�ʂ̊p�x
     * @return �x�̒P�ʂ̊p�x
     */
    private static double rad2deg(double r) {
	return r / Math.PI * 180;
    }

    /**
     * 
     * @param x
     *            double
     * @param y
     *            double
     * @param w
     *            double
     * @param h
     *            double
     * @param currentAngle
     *            double
     * @param newAngle
     *            double
     */
    public static void testAdjustRotation(int x, int y, int w, int h,
	    double currentAngle, double newAngle) {

	System.out.printf(
		"testAdjustRotation(x:%d, y:%d, w:%d, h:%d, from:%f, to:%f)\n",
		x, y, w, h, rad2deg(currentAngle), rad2deg(newAngle));

	RectangleD rect = new RectangleD(x, y, w, h);
	IRotationAdjuster ra = new RotationAdjuster1();

	ra.initialize(rect, new RectangleD(0, 0, 512, 512));

	double adjustedNewAngle = ra.adjustRotation(currentAngle, newAngle);
	List<PointD> rotatedRectangle = rect.rotate(adjustedNewAngle);

	System.out.printf("adjusted rotation angle = %f\n",
		rad2deg(adjustedNewAngle));
	System.out.printf("rotated rectangle vertexes = (%s, %s, %s, %s)\n\n",
		rotatedRectangle.get(0).toString(), rotatedRectangle.get(1)
			.toString(), rotatedRectangle.get(2).toString(),
		rotatedRectangle.get(3).toString());
    }
}
