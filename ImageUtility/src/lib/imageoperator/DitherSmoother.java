package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 */
public final class DitherSmoother {
	/**
	 */
	private DitherSmoother() {
	}

	/**
	 * 印刷物をスキャンした画像などのディザー画像をできるだけ本来のスムーズな画像に変換する。
	 * (変換後の画像のほうが、JPEGやPNG圧縮が効きやすいはず。)
	 * 
	 * @param image
	 *            入力画像
	 * @return 変換後の画像
	 */
	public static BufferedImage execute(BufferedImage image) {
		// 各画素毎に周辺の平均濃度値と、分散を計算する。(分散はRGBそれぞれで求める。RGBまとめたものとなると、共分散など難解なものが出てくるが、そのようなものを持ち出す必要は多分ない。）

		// 各画素のディザー領域らしさを計算する。

		// 各画素の濃度値を、ディザー領域らしさに応じて計算する
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		return outImage;
	}
}
