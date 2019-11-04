package lib.imageoperator;

/**
 * 重み付き画素値
 * 
 * @author akiyama
 * 
 */
public class WRGB {
    /** weight */
    public long w;
    /** weighted red */
    public long r;
    /** weighted green */
    public long g;
    /** weighted blue */
    public long b;

    /**
     * コンストラクタ
     */
    public WRGB() {
	set(0, 0, 0, 0);
    }

    /**
     * コンストラクタ
     * 
     * @param w
     *            重み
     * @param r
     *            Red
     * @param g
     *            Green
     * @param b
     *            Blue
     */
    public WRGB(int w, int r, int g, int b) {
	set(w, r, g, b);
    }

    /**
     * コンストラクタ
     * 
     * @param w
     *            重み
     * @param color
     *            色(RGB)
     */
    public WRGB(int w, int color) {
	set(w, color);
    }

    /**
     * セッター
     * 
     * @param w
     *            重み
     * @param r
     *            Red
     * @param g
     *            Green
     * @param b
     *            Blue
     * @return WRGB
     */
    public final WRGB set(int w, int r, int g, int b) {
	this.w = w;
	this.r = r * w;
	this.g = g * w;
	this.b = b * w;
	return this;
    }

    /**
     * セッター
     * 
     * @param w
     *            重み
     * @param color
     *            色(RGB)
     * @return WRGB
     */
    public final WRGB set(int w, int color) {
	return set(w, (color >> 16) & 255, (color >> 8) & 255, color & 255);
    }

    /**
     * 重み付きRGB値を加算する
     * 
     * @param w
     *            重み
     * @param r
     *            Red
     * @param g
     *            Green
     * @param b
     *            Blue
     * @return WRGB
     */
    public final WRGB add(int w, int r, int g, int b) {
	this.w += w;
	this.r += r * w;
	this.g += g * w;
	this.b += b * w;
	return this;
    }

    /**
     * 重み付きRGB値を加算する
     * 
     * @param w
     *            重み
     * @param color
     *            色(RGB)
     * @return WRGB
     */
    public final WRGB add(int w, int color) {
	return add(w, (color >> 16) & 255, (color >> 8) & 255, color & 255);
    }

    /**
     * 重み付きRGB値を加算する
     * 
     * @param v
     *            WRGB
     * @return WRGB
     */
    public final WRGB add(WRGB v) {
	w += v.w;
	r += v.r;
	g += v.g;
	b += v.b;
	return this;
    }

    /**
     * 重みのない通常のRGB値を返す。
     * 
     * @return RGB
     */
    public final int getColor() {
	if (w == 0)
	    return 0;
	return (int) ((r / w << 16) + (g / w << 8) + b / w);
    }

    @Override
    public final String toString() {
	return "(" + w + "," + r + "," + g + "," + b + ")";
    }
}
