/**
 * 重み付き画素値
 */
public final class WRGB {
	/** 重み */
	private long w; // weight

	/** 重み付Red */
	private long r; // weighted red

	/** 重み付Green */
	private long g; // weighted green

	/** 重み付Blue */
	private long b; // weighted blue

	/**
	 */
	public WRGB() {
		w = 0;
		r = 0;
		g = 0;
		b = 0;
	}

	public WRGB add(int w, int r, int g, int b) {
		this.w += w;
		this.r += (long) r * w;
		this.g += (long) g * w;
		this.b += (long) b * w;
		return this;
	}

	public WRGB add(int w, int color) {
		return add(w, (color >> 16) & 255, (color >> 8) & 255, color & 255);
	}

	/**
	 * 重みとRGB値を加算する
	 * 
	 * @param v
	 *            WRGB
	 */
	public void add(WRGB v) {
		this.w += v.w;
		this.r += v.r;
		this.g += v.g;
		this.b += v.b;
	}

	/**
	 * @return RGB値
	 */
	public int getColor() {
		if (w == 0)
			return 0;
		return (int) ((r / w << 16) + (g / w << 8) + b / w);
	}

	@Override
	public String toString() {
		return "(" + w + "," + r + "," + g + "," + b + ")";
	}
}
