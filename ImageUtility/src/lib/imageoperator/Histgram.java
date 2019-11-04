package lib.imageoperator;

import static lib.imageoperator.RGBUtility.luminance;

import java.awt.image.BufferedImage;

/**
 * 
 * @author akiyama
 * 
 */
public final class Histgram {
    /**
     * utility class
     */
    private Histgram() {
    }

    /**
     * ���͉摜�̋P�x�l�̃q�X�g�O������Ԃ��B
     * 
     * @param image
     *            ���͉摜
     * @return �P�x�l�̃q�X�g�O����(�v�f��256��int�z��)
     */
    public static int[] makeHistogram(final BufferedImage image) {
	switch (image.getType()) {
	case BufferedImage.TYPE_INT_RGB:
	case BufferedImage.TYPE_INT_ARGB:
	    return makeHistgramRGB(image);
	case BufferedImage.TYPE_BYTE_GRAY:
	    return makeHistgramMonochrome(image);
	default:
	    throw new Error("Unsupported Image Type");
	}
    }

    /**
     * 
     * @param image
     *            ���͉摜
     * @return �P�x�l�̃q�X�g�O����(�v�f��256��int�z��)
     */
    private static int[] makeHistgramRGB(final BufferedImage image) {
	final int[] histogram = new int[256];
	for (int y = 0; y < image.getHeight(); y++) {
	    for (int x = 0; x < image.getWidth(); x++) {
		final int rgb = image.getRGB(x, y);
		final int l = luminance(rgb);
		histogram[l]++;
	    }
	}
	return histogram;
    }

    /**
     * 
     * @param image
     *            ���͉摜
     * @return �P�x�l�̃q�X�g�O����(�v�f��256��int�z��)
     */
    private static int[] makeHistgramMonochrome(final BufferedImage image) {
	final int[] histogram = new int[256];
	for (int y = 0; y < image.getHeight(); y++) {
	    for (int x = 0; x < image.getWidth(); x++) {
		final int rgb = image.getRGB(x, y) & 0xff;
		histogram[rgb]++;
	    }
	}
	return histogram;
    }

}
