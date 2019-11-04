package colorspace;

/**
 * HSV
 */
public class HSV {
    /** �F��(0�`1) */
    public final double h;

    /** �ʓx(0�`1) */
    public final double s;

    /** ���邳(0�`(�ő�l�́ARGB�̒�`��ɂ���ĈقȂ�B8bitRGB�Ȃ�A255�����邳�̍ő�l�ƂȂ�))) */
    public final double v;

    /**
     * @param h
     *            H
     * @param s
     *            S
     * @param v
     *            V
     */
    public HSV(double h, double s, double v) {
	this.h = Math.max(Math.min(h, 1), 0);
	this.s = Math.max(Math.min(s, 1), 0);
	this.v = Math.max(v, 0);
    }

    /**
     * {@link HSV#createFromRGB(double, double, double)}�Q��
     * 
     * @param rgb
     *            RGB�z��irgb[0]��R�Argb[1]��G�Argb[2]��B)
     * @return {@link HSV}
     */
    public static HSV createFromRGB(double[] rgb) {
	return createFromRGB(rgb[0], rgb[1], rgb[2]);
    }

    /**
     * �C�ӂ̒�`���RGB�l����AHSV�l�𐶐�����B<br>
     * H�̒l���(0.0�`1.0)�AS�̒l���0.0�`1.0�A V�̒l���RGB�̍ő�l
     * 
     * @param r
     *            R
     * @param g
     *            G
     * @param b
     *            B
     * @return HSV
     */
    public static HSV createFromRGB(double r, double g, double b) {

	if (false) {
	    final double max;
	    final double mid;
	    final double min;
	    final double x;
	    final double y;
	    // 0. R > G >= B
	    // 1. G >= R > B
	    // 2. G > B >= R
	    // 3. B >= G > R
	    // 4. B > R >= G
	    // 5. R >= B > G
	    if (r > g) {
		// 0. R > G >= B
		// 4. B > R >= G
		// 5. R >= B > G
		if (r >= b) {
		    // 0. R > G >= B
		    // 5. R >= B > G
		    max = r;
		    if (g >= b) {
			// 0. R > G >= B
			mid = g;
			min = b;
			x = 0;
			y = mid - min;
		    } else {
			// r > g, r >= b, b > g
			// 5. R >= B > G
			mid = b;
			min = g;
			x = 6;
			y = min - mid;
		    }
		} else {
		    // 4. B > R >= G
		    max = b;
		    mid = r;
		    min = g;
		    x = 4;
		    y = mid - min;
		}
	    } else {
		// 1. G >= R > B
		// 2. G > B >= R
		// 3. B >= G > R
		if (g > b) {
		    // 1. G >= R > B
		    // 2. G > B >= R
		    max = g;
		    x = 2;
		    if (r > b) {
			// 1. G >= R > B
			mid = r;
			min = b;
			y = min - mid;
		    } else {
			// 2. G > B >= R
			mid = b;
			min = r;
			y = mid - min;
		    }
		} else {
		    // 3. B >= G > R
		    max = b;
		    mid = g;
		    min = r;
		    x = 4;
		    y = min - mid;
		}
	    }
	    if (max == min) {
		return new HSV(0, 0, max);
	    }
	    double h = (x + y / (max - min)) / 6;
	    double s = (max - min) / max;
	    double v = max;
	    return new HSV(h, s, v);
	} else {
	    final double v = Math.max(r, Math.max(g, b));
	    final double min = Math.min(r, Math.min(g, b));
	    final double d = v - min;
	    final double h;
	    final int x;
	    final double y;
	    if (d == 0) {
		h = 0;
	    } else {
		if (v == r) {
		    y = g - b;
		    if (y >= 0) {
			x = 0;
		    } else {
			x = 6;
		    }
		} else if (v == g) {
		    x = 2;
		    y = b - r;
		} else {
		    x = 4;
		    y = r - g;
		}
		h = (x + y / d) / 6;
	    }
	    final double s;
	    if (v == 0) {
		s = 0;
	    } else {
		s = (v - min) / v;
	    }
	    return new HSV(h, s, v);
	}
    }

    /**
     * RGB�ɕϊ�����
     * 
     * @return RGB
     */
    public RGB toRGB() {
	if (s == 0)
	    return new RGB(v, v, v);
	if (true) {
	    final double r;
	    final double g;
	    final double b;

	    final double max = v;
	    final double min = v * (1 - s);
	    final double hh = h * 6;

	    switch ((int) (h * 6)) {
	    case 0: // 0�`1
		    // 0. R > G >= B
		r = max;
		g = v * (1 + s * (hh - 1));
		b = min;
		break;
	    case 1: // 1�`2
		    // 1. G >= R > B
		g = max;
		r = v * (1 - s * (hh - 1));
		b = min;
		break;
	    case 2: // 2�`3
		    // 2. G > B >= R
		g = max;
		b = v * (1 + s * (hh - 3));
		r = min;
		break;
	    case 3:
		// 3. B >= G > R
		b = max;
		g = v * (1 - s * (hh - 3));
		r = min;
		break;
	    case 4:
		// 4. B > R >= G
		b = max;
		r = v * (1 + s * (hh - 5));
		g = min;
		break;
	    default:
		// 5. R >= B > G
		r = max;
		b = v * (1 - s * (hh - 5));
		g = min;
	    }

	    return new RGB(r, g, b);
	} else {
	    double r;
	    double g;
	    double b;
	    final double h2 = h * 6;
	    final int i = (int) h2;
	    final double f = h2 - i;
	    switch (i) {
	    default:
	    case 0: // R>G>B
		r = v;
		g = v * (1 - s * (1 - f));
		b = v * (1 - s);
		break;
	    case 1: // G>R>B
		g = v;
		r = v * (1 - s * f);
		b = v * (1 - s);
		break;
	    case 2: // G>B>R
		g = v;
		b = v * (1 - s * (1 - f));
		r = v * (1 - s);
		break;
	    case 3:// B>G>R
		b = v;
		g = v * (1 - s * f);
		r = v * (1 - s);
		break;
	    case 4:// B>R>G
		b = v;
		r = v * (1 - s * (1 - f));
		g = v * (1 - s);
		break;
	    case 5:// R>B>G
		r = v;
		b = v * (1 - s * f);
		g = v * (1 - s);
	    }
	    return new RGB(r, g, b);
	}
    }

    /**
     * @param v
     *            ���͒l
     * @return ���͒lv��0�`255�̐����Ɋۂ߂�����
     */
    private static int roundToByte(double v) {
	if (v < 0)
	    return 0;
	if (v > 255)
	    return 255;
	return (int) v;
    }

    public void toRGB(double[] rgb) {
	RGB rgb2 = toRGB();
	rgb[0] = rgb2.r;
	rgb[1] = rgb2.g;
	rgb[2] = rgb2.b;
    }
}