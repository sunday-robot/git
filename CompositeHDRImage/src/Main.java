import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.imageio.ImageIO;

public final class Main {
	public static void main(String[] args) {
		try {
			List<BufferedImage> images = new ArrayList<>();
			images.add(ImageIO.read(new File(args[0])));
			images.add(ImageIO.read(new File(args[1])));
			images.add(ImageIO.read(new File(args[2])));
			images.add(ImageIO.read(new File(args[3])));
			images.add(ImageIO.read(new File(args[4])));
			images.add(ImageIO.read(new File(args[5])));
			images.add(ImageIO.read(new File(args[6])));
			compositeHDRImage(images, 2);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	/**
	 * 
	 * @param images
	 *            元画像のリスト
	 * @param evPitch
	 *            露出補正値のピッチ
	 */
	private static void compositeHDRImage(List<BufferedImage> images, int evPitch) {
		for (int y = 0; y < images.get(0).getHeight(); y++) {
			for (int x = 0; x < images.get(0).getWidth(); x++) {
				int r = getHDRValue(images, evPitch, x, y, 0);
				int g = getHDRValue(images, evPitch, x, y, 1);
				int b = getHDRValue(images, evPitch, x, y, 2);
				System.out.printf("(%d, %d), (%d, %d, %d)\n", x, y, r, g, b);
			}
		}
	}

	private static int getHDRValue(List<BufferedImage> images, int evPitch, int x, int y, int channel) {
		int value = 0;
		int level;
		for (level = 0; level < images.size(); level++) {
			int rgb = images.get(level).getRGB(x, y);
			value = (rgb >> (16 - channel * 8)) & 0xff;
			if (value != 255)
				break;
		}
		int bias = (256 << (level * 8 * evPitch)) - 1;
		return value * bias / 255;
	}
}
