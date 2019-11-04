package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 * 彩度を強調（あるいはその逆を）するフィルター
 */
public final class SaidoKyocho {
	/**
	 */
	private SaidoKyocho() {
	}

	/**
	 * 彩度画像に変換する。
	 * 
	 * @param rgbImage
	 *            処理対象の画像
	 * @param k
	 *            強調係数(1より大きいと強調、1より小さいとその逆を行う）
	 * @return 返還後の画像
	 */
	public static BufferedImage execute(BufferedImage rgbImage, double k) {
		int w = rgbImage.getWidth();
		int h = rgbImage.getHeight();
		BufferedImage rgbImage2 = new BufferedImage(w, h,
				BufferedImage.TYPE_INT_RGB);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				int rgb = rgbImage.getRGB(x, y);
				HSV hsv = HSV.createFromRGB(rgb);
				HSV hsv2 = new HSV(hsv.h, hsv.s * k, hsv.v);
				int rgb2 = hsv2.toRGB8();
				rgbImage2.setRGB(x, y, rgb2);
			}
		}

		return rgbImage2;
	}

}
