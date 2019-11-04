package lib.imageoperator;

import java.awt.image.BufferedImage;

import junit.framework.Assert;

import org.junit.Test;

/**
 */
public class AverageTest {

    /**
     */
    @Test
    public static void execute1x1Test() {
	BufferedImage srcImage = new BufferedImage(1, 1,
		BufferedImage.TYPE_INT_RGB);
	srcImage.setRGB(0, 0, 0x123456);
	BufferedImage destImage = Average.execute(srcImage, 0);
	Assert.assertEquals(0x123456, destImage.getRGB(0, 0) & 0xffffff);
    }

    /**
     */
    @Test
    public static void execute2x2r1Test() {
	BufferedImage srcImage = new BufferedImage(2, 2,
		BufferedImage.TYPE_INT_RGB);
	srcImage.setRGB(0, 0, 0x123456);
	srcImage.setRGB(1, 0, 0x345678);
	srcImage.setRGB(0, 1, 0x567890);
	srcImage.setRGB(1, 1, 0x789012);
	BufferedImage expectedImage = new BufferedImage(2, 2,
		BufferedImage.TYPE_INT_RGB);
	expectedImage.setRGB(0, 0, 0x45645c);
	expectedImage.setRGB(1, 0, 0x45645c);
	expectedImage.setRGB(0, 1, 0x45645c);
	expectedImage.setRGB(1, 1, 0x45645c);

	BufferedImage destImage = Average.execute(srcImage, 1);

	Assert.assertEquals(0x45645c, destImage.getRGB(0, 0) & 0xffffff);
	Assert.assertEquals(expectedImage, destImage);
    }

}
