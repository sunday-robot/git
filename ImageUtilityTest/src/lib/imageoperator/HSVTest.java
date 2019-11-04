package lib.imageoperator;

import junit.framework.Assert;

import org.junit.Test;

/**
 */
public class HSVTest {
    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void createFromRGBTest000000() {
	createFromRGBTestSub(0, 0, 0, 0, 0, 0);
	createFromRGBTestSub(1, 1, 1, 0, 0, 1);
	createFromRGBTestSub(1, 0, 0, 0, 1, 1);
	createFromRGBTestSub(1, 1, 0, 1.0 / 6, 1, 1);
	createFromRGBTestSub(0, 1, 0, 2.0 / 6, 1, 1);
	createFromRGBTestSub(0, 1, 1, 3.0 / 6, 1, 1);
	createFromRGBTestSub(0, 0, 1, 4.0 / 6, 1, 1);
	createFromRGBTestSub(1, 0, 1, 5.0 / 6, 1, 1);
    }

    /**
     * @param r
     *            R
     * @param g
     *            G
     * @param b
     *            B
     * @param h
     *            H
     * @param s
     *            S
     * @param v
     *            V
     */
    private static void createFromRGBTestSub(double r, double g, double b,
	    double h, double s, double v) {
	HSV hsv = HSV.createFromRGB(r, g, b);
	Assert.assertEquals(h, hsv.h);
	Assert.assertEquals(s, hsv.s);
	Assert.assertEquals(v, hsv.v);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestBlack() {
	toRGBTestSub(0, 0, 0);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestWhite() {
	toRGBTestSub(1, 1, 1);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestRed() {
	toRGBTestSub(1, 0, 0);
	toRGBTestSub(1, 0.9, 0);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestYellow() {
	toRGBTestSub(1, 1, 0);
	toRGBTestSub(0.1, 1, 0);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestGreen() {
	toRGBTestSub(0, 1, 0);
	toRGBTestSub(0, 1, 0.9);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestCyan() {
	toRGBTestSub(0, 1, 1);
	toRGBTestSub(0, 0.1, 1);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestBlue() {
	toRGBTestSub(0, 0, 1);
	toRGBTestSub(0.9, 0, 1);
    }

    /**
     */
    @SuppressWarnings("static-method")
    @Test
    public void toRGBTestMagenda() {
	toRGBTestSub(1, 0, 1);
	toRGBTestSub(1, 0, 0.1);
    }

    /**
     * @param r
     *            R
     * @param g
     *            G
     * @param b
     *            B
     */
    private static void toRGBTestSub(double r, double g, double b) {
	HSV hsv = HSV.createFromRGB(r, g, b);
	RGB rgb = hsv.toRGB();
	Assert.assertTrue(hobo(r, rgb.r));
	Assert.assertTrue(hobo(g, rgb.g));
	Assert.assertTrue(hobo(b, rgb.b));
    }

    /**
     * @param a
     *            double
     * @param b
     *            double
     * @return a‚Æb‚ª‚Ù‚Úˆê’v‚·‚é‚©‚Ç‚¤‚©
     */
    private static boolean hobo(double a, double b) {
	double aa = Math.abs(a);
	double ab = Math.abs(b);
	double diff = Math.abs(a - b);
	double min = Math.min(aa, ab);

	double ad;
	if (min == 0) {
	    ad = diff;
	} else {
	    ad = diff / min;
	}
	return ad < 0.000001;
    }
}
