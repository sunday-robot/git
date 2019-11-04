package lib.imageoperator;

import static lib.imageoperator.RGBUtility.blue;
import static lib.imageoperator.RGBUtility.green;
import static lib.imageoperator.RGBUtility.red;
import static lib.imageoperator.RGBUtility.rgb;

import java.awt.image.BufferedImage;

/**
 */
public final class Deviation {
	/**
	 */
	private Deviation() {
	}

	/**
	 * 平均画像と、偏差画像を返す。<br/>
	 * (実験用のもので、実用目的はない。)<br/>
	 * 
	 * @param image
	 *            入力画像
	 * @param range
	 *            平均をとる範囲(タテヨコの画素数が、2*range+1の正方形領域)
	 * @return 平均濃度値画像と偏差画像
	 */
	public static BufferedImage[] execute(BufferedImage image, int range) {
		BufferedImage averageImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		BufferedImage distoributionImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());

		for (int y = 0; y < image.getHeight(); y++) {
			int y1 = Math.max(y - range, 0);
			int y2 = Math.min(y + range, image.getHeight() - 1);
			for (int x = 0; x < image.getWidth(); x++) {
				int x1 = Math.max(x - range, 0);
				int x2 = Math.min(x + range, image.getWidth() - 1);
				int rSum = 0;
				int gSum = 0;
				int bSum = 0;
				int r2Sum = 0; // 画像全体ではなく、ごく一部なので、longでなくて良い。
				int g2Sum = 0;
				int b2Sum = 0;

				for (int yy = y1; yy <= y2; yy++) {
					for (int xx = x1; xx <= x2; xx++) {
						int rgb = image.getRGB(xx, yy);
						int r = red(rgb);
						int g = green(rgb);
						int b = blue(rgb);
						rSum += r;
						gSum += g;
						bSum += b;
						r2Sum += r * r;
						g2Sum += g * g;
						b2Sum += b * b;
					}
				}
				int count = (x2 - x1 + 1) * (y2 - y1 + 1);
				int count2 = count * count;
				int rDistoribution = (int) Math.sqrt((r2Sum * count - rSum
						* rSum)
						/ count2);
				int gDistoribution = (int) Math.sqrt((g2Sum * count - gSum
						* gSum)
						/ count2);
				int bDistoribution = (int) Math.sqrt((b2Sum * count - bSum
						* bSum)
						/ count2);
				averageImage.setRGB(x, y,
						rgb(rSum / count, gSum / count, gSum / count));
				distoributionImage.setRGB(x, y,
						rgb(rDistoribution, gDistoribution, bDistoribution));
			}
		}

		return new BufferedImage[] { averageImage, distoributionImage };
	}
}
