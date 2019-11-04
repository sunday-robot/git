package lib.imageoperator;

import static lib.imageoperator.RGBUtility.blue;
import static lib.imageoperator.RGBUtility.green;
import static lib.imageoperator.RGBUtility.red;
import static lib.imageoperator.RGBUtility.rgb;

import java.awt.image.BufferedImage;
import java.awt.image.Raster;

/**
 * 画像の輝度を強調する。
 * 
 * @author akiyama
 */
public final class Emphasizer {
    /** utility class */
    private Emphasizer() {
    }

    /**
     * 濃度値を強調する。
     * 
     * @param image
     *            BufferedImage
     * @param mininumIntensity
     *            最小輝度値
     * @param maximumIntensity
     *            最大輝度値
     * @return 変換後の画像
     */
    public static BufferedImage execute(BufferedImage image,
	    int mininumIntensity, int maximumIntensity) {
	if (image.getType() == BufferedImage.TYPE_BYTE_GRAY) {
	    return executeGrayImage(image, mininumIntensity, maximumIntensity);
	}

	BufferedImage emphasizedImage = new BufferedImage(image.getWidth(),
		image.getHeight(), BufferedImage.TYPE_INT_RGB);
	for (int y = 0; y < image.getHeight(); y++) {
	    // System.out.printf("y = %d\n", y);
	    for (int x = 0; x < image.getWidth(); x++) {
		int rgb = image.getRGB(x, y);
		int ergb = emphasizeRGB(rgb, mininumIntensity, maximumIntensity);
		emphasizedImage.setRGB(x, y, ergb);
	    }
	}
	return emphasizedImage;
    }

    /**
     * 
     * @param image
     *            ???
     * @param mininumIntensity
     *            ??
     * @param maximumIntensity
     *            ??
     * @return ??
     */
    private static BufferedImage executeGrayImage(BufferedImage image,
	    int mininumIntensity, int maximumIntensity) {
	Raster raster = image.getData();
	int[] pixels = new int[image.getWidth()];

	BufferedImage emphasizedImage = new BufferedImage(image.getWidth(),
		image.getHeight(), BufferedImage.TYPE_BYTE_GRAY);
	for (int y = 0; y < image.getHeight(); y++) {
	    raster.getPixels(0, y, image.getWidth(), 1, pixels);
	    for (int x = 0; x < image.getWidth(); x++) {
		int v = emphasize(pixels[x], mininumIntensity, maximumIntensity);
		emphasizedImage.setRGB(x, y, rgb(v, v, v));
	    }
	}
	return emphasizedImage;
    }

    // private static BufferedImage executeColorImage(BufferedImage image,
    // int mininumIntensity, int maximumIntensity) {
    // Raster raster = image.getData();
    // int[] pixels = new int[image.getWidth() * 4];
    //
    // BufferedImage emphasizedImage = new BufferedImage(image.getWidth(),
    // image.getHeight(), BufferedImage.TYPE_INT_RGB);
    // for (int y = 0; y < image.getHeight(); y++) {
    // raster.getPixels(0, y, image.getWidth(), 1, pixels);
    // for (int x = 0; x < image.getWidth(); x++) {
    // int r = emphasize(pixels[x * 4], mininumIntensity,
    // maximumIntensity);
    // int g = emphasize(pixels[x * 4 + 1], mininumIntensity,
    // maximumIntensity);
    // int b = emphasize(pixels[x * 4 + 2], mininumIntensity,
    // maximumIntensity);
    // emphasizedImage.setRGB(x, y, rgb(r, g, b));
    // }
    // }
    // return emphasizedImage;
    // }

    /**
     * 指定された色(RGB)を強調する
     * 
     * @param rgb
     *            強調する色
     * @param min
     *            下限値
     * @param max
     *            上限値
     * @return 強調された色
     */
    private static int emphasizeRGB(int rgb, int min, int max) {
	int er = emphasize(red(rgb), min, max);
	int eg = emphasize(green(rgb), min, max);
	int eb = emphasize(blue(rgb), min, max);

	return rgb(er, eg, eb);
    }

    /**
     * 入力値を強調する
     * 
     * @param a
     *            入力値
     * @param min
     *            下限値
     * @param max
     *            上限値
     * @return 強調された値
     */
    private static int emphasize(int a, int min, int max) {
	if (a <= min) {
	    return 0;
	}
	if (a >= max) {
	    return 255;
	}
	int c = (a - min) * 255 / (max - min);
	return c;
    }

}
