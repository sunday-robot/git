import java.util.ArrayList;
import java.util.List;

/**
 * Rotation用のAdjuster
 * 
 * @author satoshi_ouchi
 * 
 */
public class RotationAdjuster1 implements IRotationAdjuster {

    /**
     * リファレンス画像からはみ出してしまう回転角度範囲のリスト
     */
    private List<Range> errorRangeList;

    @Override
    public final void initialize(RectangleD target, RectangleD area) {
	List<Range> ranges = new ArrayList<Range>();

	PointD center = target.getCenter();

	// targetの4つの頂点の極座標(r, θ)を求める（原点はtargetの中心）
	double r;
	double[] thetas = new double[4];
	{
	    double dx = target.size.x / 2.0;
	    double dy = target.size.y / 2.0;

	    r = Math.sqrt(dx * dx + dy * dy);

	    Double theta = Math.atan2(dy, dx);
	    thetas[0] = canonicalAngle(theta); // 右下
	    thetas[1] = canonicalAngle(Math.PI - theta); // 左下
	    thetas[2] = canonicalAngle(Math.PI + theta); // 左上
	    thetas[3] = canonicalAngle(2 * Math.PI - theta); // 右上
	}

	// 回転エラー範囲を求める
	double radian1;
	double radian2;

	radian2 = Math.acos(((area.position.x + area.size.x) - center.x) / r);
	if (!Double.isNaN(radian2)) {
	    // 矩形領域の右側にはみ出る可能性がある場合
	    radian1 = 2 * Math.PI - radian2;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	radian1 = Math.asin((area.position.y + area.size.y - center.y) / r);
	if (!Double.isNaN(radian1)) {
	    // 矩形領域の下側にはみ出る可能性がある場合
	    radian2 = Math.PI - radian1;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	radian1 = Math.acos((area.position.x - center.x) / r);
	if (!Double.isNaN(radian1)) {
	    // 矩形領域の左側にはみ出る可能性がある場合
	    radian2 = 2 * Math.PI - radian1;

	    for (double rad : thetas) {
		ranges = addRange(ranges, radian1 - rad, radian2 - rad);
		// printErrorRangeList(ranges);
	    }
	}

	radian2 = Math.asin((area.position.y - center.y) / r);
	if (!Double.isNaN(radian2)) {
	    // 矩形領域の上側にはみ出る可能性がある場合
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
     *            範囲のリスト
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
     * 回転角度を補正する。
     * 
     * @param currentAngle
     *            直前の回転角度
     * @param newAngle
     *            未補正の新たな回転角度
     * @return 補正された回転角度
     */
    @Override
    public final double adjustRotation(double currentAngle, double newAngle) {
	// 0 ～ 2PIにする
	double ret = newAngle % (2 * Math.PI);
	if (ret < 0) {
	    ret += 2 * Math.PI;
	}

	// trueの時、左回りの回転
	boolean positive;

	double delta = ret - currentAngle;
	positive = delta > 0.0;
	if (Math.abs(delta) > Math.PI) {
	    positive = !positive;
	}

	// currentAngleがどのエラー範囲の間に存在するか調べる。
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
	    // エラー範囲に存在するか？
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
     * 正規化された角度を返す。
     * 
     * @param a
     *            対象の角度
     * @return 正規化された角度
     */
    private static double canonicalAngle(double a) {
	return a >= 0 ? a : a + 2 * Math.PI;
    }

}

/**
 * 範囲を持つクラス
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
     * コンストラクタ
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
     * 正規化された角度を返す。
     * 
     * @param a
     *            正規化対象の角度
     * @return 正規化された角度
     */
    public static double getCanonicalAngle(double a) {
	a %= 2 * Math.PI;
	if (a < 0)
	    return a + 2 * Math.PI;
	else
	    return a;
    }

    /**
     * アクセッサ
     * 
     * @return From
     */
    public double getFrom() {
	return from;
    }

    /**
     * アクセッサ
     * 
     * @return To
     */
    public double getTo() {
	return to;
    }

    /**
     * 指定された角度を含むかどうかを返す。
     * 
     * @param a
     *            角度
     * @return 含むかどうか
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
     * ラジアン単位の角度を度単位に変換する。
     * 
     * @param rad
     *            ラジアン単位の角度
     * @return 度単位の角度
     */
    private static double toDegree(double rad) {
	return (int) (rad / Math.PI * 180);
    }

    @Override
    public String toString() {
	return "Range:(" + toDegree(from) + ", " + toDegree(to) + ")";
    }

}
