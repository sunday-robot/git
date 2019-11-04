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
	 * ���ω摜�ƁA�΍��摜��Ԃ��B<br/>
	 * (�����p�̂��̂ŁA���p�ړI�͂Ȃ��B)<br/>
	 * 
	 * @param image
	 *            ���͉摜
	 * @param range
	 *            ���ς��Ƃ�͈�(�^�e���R�̉�f�����A2*range+1�̐����`�̈�)
	 * @return ���ϔZ�x�l�摜�ƕ΍��摜
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
				int r2Sum = 0; // �摜�S�̂ł͂Ȃ��A�����ꕔ�Ȃ̂ŁAlong�łȂ��ėǂ��B
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
