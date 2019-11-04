import java.util.List;

import org.junit.Test;

/**
 * テスト
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
     * 回転制限が何もないケース
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test1() {
	testAdjustRotation(100, 100, 100, 100, 0, Math.PI / 3);
    }

    /**
     * 上の辺にくっついているケース
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
	// 左の辺にくっついているケース
	testAdjustRotation(0, 100, 100, 100, 0, Math.PI / 3);
    }

    /**
     * 
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test4() {
	// 左上にくっついているケース
	testAdjustRotation(0, 0, 100, 100, 0, Math.PI / 3);
    }

    /**
     * 上の辺から1ドット下にあるケース
     */
    @SuppressWarnings("static-method")
    @Test
    public final void test5() {
	testAdjustRotation(100, 1, 100, 100, 0, Math.PI / 3);
    }

    /**
     * ラジアン単位の角度を度の単位に変換する
     * 
     * @param r
     *            ラジアン単位の角度
     * @return 度の単位の角度
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
