package lib.imageoperator;

/**
 * RGBカラー画像とHSV画像との相互変換を行うもの。
 */
public final class HSVUtil {
	/***/
	private HSVUtil() {
	}

	/**
	 * RGBのカラー画像を、HSVのグレースケール画像三つを生成する。
	 * 
	 * @param src
	 *            {@link ColorImage}
	 * @return [0]HSVのHチャンネル画像, [1]HSVのSチャンネル画像、[2]HSVのVチャンネル画像
	 */
	public static GrayImage[] divide(ColorImage src) {
		GrayImage h = new GrayImage(src.width, src.height);
		GrayImage s = new GrayImage(src.width, src.height);
		GrayImage v = new GrayImage(src.width, src.height);
		for (int y = 0; y < src.height; y++) {
			for (int x = 0; x < src.width; x++) {
				HSV hsv = HSV.createFromRGB(src.v[y][x]);
				h.v[y][x] = hsv.h;
				s.v[y][x] = hsv.s;
				v.v[y][x] = hsv.v;
			}
		}
		return new GrayImage[] { h, s, v };
	}

	/**
	 * HSVのHチャンネル画像、 HSVのSチャンネル画像、HSVのVチャンネル画像から、RGB画像を生成する。
	 * 
	 * @param src
	 *            [0]HSVのHチャンネル画像, [1]HSVのSチャンネル画像、[2]HSVのVチャンネル画像
	 * @return {@link ColorImage}
	 */
	public static ColorImage merge(GrayImage[] src) {
		return merge(src[0], src[1], src[2]);
	}

	/**
	 * HSVのHチャンネル画像、 HSVのSチャンネル画像、HSVのVチャンネル画像から、RGB画像を生成する。
	 * 
	 * @param h
	 *            HSVのHチャンネル画像
	 * @param s
	 *            HSVのSチャンネル画像
	 * @param v
	 *            HSVのVチャンネル画像
	 * @return {@link ColorImage}
	 */
	public static ColorImage merge(GrayImage h, GrayImage s, GrayImage v) {
		ColorImage dest = new ColorImage(h.width, h.height);
		for (int y = 0; y < h.height; y++) {
			for (int x = 0; x < h.width; x++) {
				HSV hsv = new HSV(h.v[y][x], s.v[y][x], v.v[y][x]);
				hsv.toRGB(dest.v[y][x]);
			}
		}
		return dest;
	}
}
