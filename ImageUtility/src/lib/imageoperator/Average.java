package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 */
public final class Average {
	/**
	 */
	private Average() {
	}

	/**
	 * 周辺画素の平均濃度値画像を返す。
	 * 
	 * @param image
	 *            入力画像
	 * @param range
	 *            平均をとる範囲(タテヨコの画素数が、2*range+1の正方形領域)
	 * @return 平均濃度値画像
	 */
	public static BufferedImage execute(BufferedImage image, int range) {
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());

		for (int y = 0; y < image.getHeight(); y++) {
			int y1 = Math.max(y - range, 0);
			int y2 = Math.min(y + range, image.getHeight() - 1);
			for (int x = 0; x < image.getWidth(); x++) {
				int x1 = Math.max(x - range, 0);
				int x2 = Math.min(x + range, image.getWidth() - 1);
				WRGB wrgb = new WRGB();

				for (int yy = y1; yy <= y2; yy++) {
					for (int xx = x1; xx <= x2; xx++) {
						wrgb.add(1, image.getRGB(xx, yy));
					}
				}

				outImage.setRGB(x, y, wrgb.getColor());
			}
		}

		return outImage;
	}
}
