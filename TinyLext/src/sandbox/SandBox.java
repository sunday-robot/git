package sandbox;

import java.awt.Point;

/** */
public final class SandBox {

	/***/
	private SandBox() {
	}

	/**
	 * @param h0
	 *            X軸の負の側の点
	 * @param h1
	 *            X軸の正の側の点
	 * @param v
	 *            Y軸上の点
	 */
	static void set(Point h0, Point h1, Point v) {
		// Point c; // 交点
		// Point h = new Point(h1.x - h0.x, h1.y - h0.y);
		// double h2 = h.x * h.x + h.y * h.y;
		// double absH = Math.sqrt(h2);
		// double zero;
		// c = v + (h.y, -h.x) * t

		// double t = 0;
		// cross(h0 - c, h1 - c) = 0
		// zero = (h0.x - c.x) * (h1.y - c.y) - (h0.y - c.y) * (h1.x - c.x);
		// zero = (h0.x - (v + (h.y, -h.x) * t).x) * (h1.y - (v + (h.y, -h.x) *
		// t).y) -
		// (h0.y - (v + (h.y, -h.x) * t).y) * (h1.x - (v + (h.y, -h.x) * t).x);
		// zero = (h0.x - (v.x + (h.y) * t)) * (h1.y - (v.y + (-h.x) * t))
		// - (h0.y - (v.y + (-h.x) * t)) * (h1.x - (v.x + (h.y) * t));
		// zero = (h0.x - (v.x + h.y * t)) * (h1.y - (v.y - h.x * t)) - (h0.y -
		// (v.y - h.x * t))
		// * (h1.x - (v.x + h.y * t));
		// zero = (h0.x - v.x - h.y * t) * (h1.y - v.y + h.x * t) - (h0.y - v.y
		// + h.x * t)
		// * (h1.x - v.x - h.y * t);
		// zero = ((h0.x - v.x - h.y * t) * h1.y - (h0.x - v.x - h.y * t) * v.y
		// + (h0.x - v.x - h.y
		// * t)
		// * h.x * t)
		// - ((h0.y - v.y + h.x * t) * h1.x - (h0.y - v.y + h.x * t) * v.x -
		// (h0.y - v.y + h.x
		// * t)
		// * h.y * t);
		// zero = //
		// h0.x * h1.y //
		// - v.x * h1.y //
		// - h0.x * v.y //
		// + v.x * v.y //
		// - h0.y * h1.x //
		// + v.y * h1.x //
		// - h0.y * v.x //
		// + v.y * v.x //
		// + h.y * v.y * t //
		// + h0.x * h.x * t //
		// - v.x * h.x * t //
		// - h.x * v.x * t //
		// - h0.y * h.y * t //
		// + v.y * h.y * t //
		// - h.y * h1.y * t //
		// - h.x * h1.x * t //
		// - h.x * h.y * t * t//
		// - h.y * h.x * t * t //
		// ;
		// zero = //
		// h0.x * h1.y //
		// - v.x * h1.y //
		// - h0.x * v.y //
		// + v.x * v.y //
		// - h0.y * h1.x //
		// + v.y * h1.x //
		// - h0.y * v.x //
		// + v.y * v.x //
		// + (h1.y * v.y * t - h0.y * v.y * t) //
		// + h0.x * (h1.x * t - h0.x * t) //
		// - v.x * (h1.x * t - h0.x * t) //
		// - (h1.x * v.x * t - h0.x * v.x * t) //
		// - h0.y * (h1.y * t - h0.y * t) //
		// + v.y * (h1.y * t - h0.y * t) //
		// - (h1.y * h1.y * t - h0.y * h1.y * t) //
		// - (h1.x * h1.x * t - h0.x * h1.x * t) //
		//
		// - h.x * h.y * t * t//
		// - h.y * h.x * t * t //
		// ;
		// zero = //
		// h0.x * h1.y //
		// - v.x * h1.y //
		// - h0.x * v.y //
		// + v.x * v.y //
		// - h0.y * h1.x //
		// + v.y * h1.x //
		// - h0.y * v.x //
		// + v.y * v.x //
		//
		// + ((h1.y * v.y - h0.y * v.y) //
		// + (h0.x * h1.x - h0.x * h0.x) //
		// - (v.x * h1.x - v.x * h0.x) //
		// - (h1.x * v.x - h0.x * v.x) //
		// - (h0.y * h1.y - h0.y * h0.y) //
		// + (v.y * h1.y - v.y * h0.y) //
		// - (h1.y * h1.y - h0.y * h1.y) //
		// - (h1.x * h1.x - h0.x * h1.x)) * t //
		//
		// - h.x * h.y * t * t//
		// - h.y * h.x * t * t //
		// ;
		// zero = //
		// h0.x * h1.y //
		// - v.x * h1.y //
		// - h0.x * v.y //
		// + v.x * v.y //
		// - h0.y * h1.x //
		// + v.y * h1.x //
		// - h0.y * v.x //
		// + v.y * v.x //
		//
		// + (//
		// h1.y * v.y //
		// - h0.y * v.y //
		// - v.x * h1.x //
		// + v.x * h0.x //
		// - h1.x * v.x //
		// + h0.x * v.x //
		// + v.y * h1.y //
		// - v.y * h0.y //
		//
		// - h0.x * h0.x //
		// + h0.y * h0.y //
		//
		// + h0.x * h1.x //
		// - h0.y * h1.y //
		// + h0.x * h1.x//
		// + h0.y * h1.y //
		//
		// - h1.x * h1.x //
		// - h1.y * h1.y //
		// ) * t //
		//
		// - h.x * h.y * t * t//
		// - h.y * h.x * t * t //
		// ;
	}

	/**
	 * @param a
	 *            :
	 * @param b
	 *            :
	 * @return 内積
	 */
	private static int dot(Point a, Point b) {
		return a.x * b.x + a.y * b.y;
	}

	/**
	 * @param a
	 *            :
	 * @param b
	 *            :
	 * @return 外積
	 */
	@SuppressWarnings("unused")
	private static int cross(Point a, Point b) {
		return a.x * b.y - a.y * b.x;
	}

	/**
	 * @param a
	 *            :
	 * @param b
	 *            :
	 * @return 差
	 */
	private static Point sub(Point a, Point b) {
		return new Point(a.x - b.x, a.y - b.y);
	}

	/**
	 * @param a
	 *            :
	 * @param b
	 *            :
	 * @return 商
	 */
	@SuppressWarnings("unused")
	private static Point div(Point a, int b) {
		return new Point(a.x / b, a.y / b);
	}

	/**
	 * @param a
	 *            :
	 * @return 自乗
	 */
	private static int square(Point a) {
		return dot(a, a);
	}

	/**
	 * @param a
	 *            :
	 * @return 直交する(正確には90度回転させた)ベクトル
	 */
	@SuppressWarnings("unused")
	private static Point orthogonal(Point a) {
		return new Point(-a.y, a.x);
	}

	/**
	 * 
	 * @param h0
	 *            :
	 * @param h1
	 *            :
	 * @param v0
	 *            :
	 */
	static void set2(Point h0, Point h1, Point v0) {
		System.out.printf("h0:%s, h1:%s, v0:%s\n", h0, h1, v0);
		// 求める原点cは、以下を満たすものである。
		// (1) v0を通り、hに直行する直線上の一点である。
		// (2) h0とh1を通る直線上の一点である。

		// (1)
		// C = V0 + V * u
		// V = (-Hy, Hx)
		// (2)
		// C = h0 + H * t
		// H = H1 - H0

		// V0 + V * u = H0 + H * t
		// V0 + (-Hy, Hx) * u = H0 + (H1 - H0) * t
		// V0 + (-Hy, Hx) * u = H0 + H1 * t - H0 * t
		// V0 + (-Hy, Hx) * u = H0 * (1 - t) + H1 * t
		// V0 + (-(H1y - H0y), (H1x - H0x)) * u = H0 * (1 - t) + H1 * t

		// V0x - (H1y - H0y) * u = H0x * (1 - t) + H1x * t
		// V0y + (H1x - H0x) * u = H0y * (1 - t) + H1y * t

		// - (H1y - H0y) * u = H0x * (1 - t) + H1x * t - V0x
		// -u = (H0x * (1 - t) + H1x * t - V0x) / (H1y - H0y)
		// u = - (H0x * (1 - t) + H1x * t - V0x) / (H1y - H0y)

		// V0y + (H1x - H0x) * (- (H0x * (1 - t) + H1x * t - V0x) / (H1y - H0y))
		// = H0y *
		// (1 - t) + H1y * t
		// V0y + (-H1x + H0x) * (H0x * (1 - t) + H1x * t - V0x) / (H1y - H0y) =
		// H0y * (1
		// - t) + H1y * t
		// V0y + (-H1x + H0x) * (H0x - H0x * t + H1x * t - V0x) / (H1y - H0y) =
		// H0y * (1
		// - t) + H1y * t
		// (-H1x + H0x) * (H0x - H0x * t + H1x * t - V0x) / (H1y - H0y) = H0y -
		// H0y * t
		// + H1y * t - V0y
		// ((-H1x + H0x) * H0x - (-H1x + H0x) * H0x * t + (-H1x + H0x) * H1x * t
		// - (-H1x
		// + H0x) * V0x) = (H0y - H0y * t + H1y * t - V0y) * (H1y - H0y)
		// ((-H1x * H0x + H0x * H0x) - (-H1x * H0x * t + H0x * H0x * t )+ (-H1x
		// * H1x *
		// t + H0x * H1x * t )- (-H1x + H0x) * V0x) = (H0y - H0y * t + H1y * t -
		// V0y) *
		// (H1y - H0y)
		// -H1x * H0x + H0x * H0x + H1x * H0x * t - H0x * H0x * t - H1x * H1x *
		// t + H0x
		// * H1x * t + H1x * V0x - H0x * V0x = (H0y - H0y * t + H1y * t - V0y) *
		// (H1y -
		// H0y)
		// H1x * H0x * t - H0x * H0x * t - H1x * H1x * t + H0x * H1x * t = (H0y
		// - H0y *
		// t + H1y * t - V0y) * (H1y - H0y) + H1x * H0x - H0x * H0x - H1x * V0x
		// + H0x *
		// V0x
		// H1x * H0x * t - H0x * H0x * t - H1x * H1x * t + H0x * H1x * t = (H0y
		// * (H1y -
		// H0y) - H0y * t * (H1y - H0y) + H1y * t * (H1y - H0y) - V0y * (H1y -
		// H0y)) +
		// H1x * H0x - H0x * H0x - H1x * V0x + H0x * V0x
		// H1x * H0x * t - H0x * H0x * t - H1x * H1x * t + H0x * H1x * t = (H0y
		// * H1y -
		// H0y * H0y - H0y * t * H1y + H0y * t * H0y + H1y * t * (H1y - H0y) -
		// V0y *
		// (H1y - H0y)) + H1x * H0x - H0x * H0x - H1x * V0x + H0x * V0x
		// (H1x * H0x - H0x * H0x - H1x * H1x + H0x * H1x) * t = H0y * H1y - H0y
		// * H0y -
		// H0y * t * H1y + H0y * t * H0y + H1y * t * H1y - H1y * t * H0y - V0y *
		// H1y +
		// V0y * H0y + H1x * H0x - H0x * H0x - H1x * V0x + H0x * V0x
		// (H1x * H0x - H0x * H0x - H1x * H1x + H0x * H1x + H0y * H1y - H0y *
		// H0y - H1y
		// * H1y) * t = H0y * H1y - H0y * H0y - H1y * t * H0y - V0y * H1y + V0y
		// * H0y +
		// H1x * H0x - H0x * H0x - H1x * V0x + H0x * V0x
		// (H1x * H0x - H0x * H0x - H1x * H1x + H0x * H1x + H0y * H1y - H0y *
		// H0y - H1y
		// * H1y + H1y * H0y) * t = H0y * H1y - H0y * H0y- V0y * H1y + V0y * H0y
		// + H1x *
		// H0x - H0x * H0x - H1x * V0x + H0x * V0x
		// boolean b = (h1.x * h0.x - h0.x * h0.x - h1.x * h1.x + h0.x * h1.x +
		// h0.y *
		// h1.y - h0.y * h0.y - h1.y * h1.y + h1.y * h0.y) * t
		// == h0.y * h1.y - h0.y * h0.y- v0.y * h1.y + v0.y * h0.y + h1.x * h0.x
		// - h0.x
		// * h0.x - h1.x * v0.x + h0.x * v0.x;
		// boolean b = ((h1.x * h0.x- h0.x * h0.x + h0.x * h1.x) - h1.x * h1.x +
		// h0.y *
		// h1.y - h0.y * h0.y - h1.y * h1.y + h1.y * h0.y) * t
		// == h0.y * h1.y - h0.y * h0.y- v0.y * h1.y + v0.y * h0.y + h1.x * h0.x
		// - h0.x
		// * h0.x - h1.x * v0.x + h0.x * v0.x;
		// boolean b = ((2 * h0.x * h1.x) + (2 * h0.y * h1.y) - h0.x * h0.x -
		// h0.y *
		// h0.y - (h1.x * h1.x + h1.y * h1.y)) * t
		// == h0.y * h1.y - h0.y * h0.y- v0.y * h1.y + v0.y * h0.y + h1.x * h0.x
		// - h0.x
		// * h0.x - h1.x * v0.x + h0.x * v0.x;
		// int hx = h1.x - h0.x;
		// int hy = h1.y - h0.y;
		// int t = (hx * (-h0.x + v0.x) - hy * (h0.y + v0.y)) / (hx * hx + hy *
		// hy);
		// C = h0 + H * t
		// H = H1 - H0
		// int cx = h0.x + hx * t;
		// int cy = h0.y + hy * t;
		// int h2 = hx * hx + hy * hy;
		// int cx = (h2 * h0.x + hx * ((-hx * h0.x + hx * v0.x) - (hy * h0.y +
		// hy *
		// v0.y))) / h2;
		// int cx = (h2 * h0.x + hx * (-hx * h0.x + hx * v0.x - hy * h0.y - hy *
		// v0.y))
		// / h2;
		// int cx = (//
		// +hy * hy * h0.x //
		// - hx * hy * h0.y //
		// - hx * hy * v0.y//
		// + hx * hx * v0.x //
		// ) / h2;
		// int cx = (//
		// +(h1.y - h0.y) * (h1.y * h0.x - h0.y * h0.x) //
		// - (h1.x - h0.x) * (h1.y * h0.y - h0.y * h0.y) //
		// - hx * hy * v0.y//
		// + hx * hx * v0.x //
		// ) / h2;
		// int cx = (//
		// h1.y * h1.y * h0.x - h0.y * h1.y * h0.x - h1.y * h0.y * h0.x + h0.y *
		// h0.y *
		// h0.x //
		// - h1.x * h1.y * h0.y + h0.x * h1.y * h0.y + h1.x * h0.y * h0.y - h0.x
		// * h0.y
		// * h0.y //
		// - hx * hy * v0.y//
		// + hx * hx * v0.x //
		// ) / h2;
		// int cx = (0 //
		// - hx * h1.y * h0.y //
		// + h1.x * h0.y * h0.y //
		// - h1.y * h0.x * h0.y //
		// + h1.y * h1.y * h0.x //
		// - h1.y * h0.x * h0.y //
		// - hx * hy * v0.y//
		// + hx * hx * v0.x //
		// ) / h2;

		// Point h = sub(h1, h0);
		Point c = new Point(0, 0); // dummy
		// Point v = sub(v0, c);
		Point ch0 = sub(h0, c);
		Point ch1 = sub(h1, c);
		int x = dot(ch0, ch1); // ch0x * ch1x + ch0y * ch1y
		int ch0s = square(ch0); // ch0x * ch0x + ch0y * ch0y
		int ch1s = square(ch1); // ch1x * ch1x + ch1y * ch1y
		if (ch0s * ch1s == x * x) {
			System.out.printf("%d\n", x);;
		}
		//
		// int dhx2 = dhx * dhx;
		// int dhy2 = dhy * dhy;
		// int vx = v.x;
		// int vy = v.y;
		// int crossH1H0 = h1.x * h0.y - h1.y * h0.x;
		// int ox = (dhx * (vx * dhx + vy * dhy) - dhy * crossH1H0) / (dhx2 +
		// dhy2);
		// int oy = (dhy * (vx * dhx + vy * dhy) + dhx * crossH1H0) / (dhx2 +
		// dhy2);
		// System.out.printf("(%d, %d)-(%d, %d), (%d, %d) -> (%d, %d)\n", h0.x,
		// h0.y, h1.x, h1.y, v.x,
		// v.y, ox, oy);
		// Point c = div(, square(sub(h1, h0));
	}

	/**
	 * 
	 * @param args
	 *            :
	 */
	public static void main(String[] args) {
		set2(new Point(0, 0), new Point(100, 0), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 0), new Point(100, 100));
		set2(new Point(0, 0), new Point(100, 0), new Point(0, -100));
		set2(new Point(0, 0), new Point(100, 10), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 20), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 10), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 20), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 30), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 40), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 50), new Point(0, 100));
		set2(new Point(0, 0), new Point(100, 60), new Point(0, 100));
	}
}
