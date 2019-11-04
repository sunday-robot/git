import java.awt.image.BufferedImage;

public class ImageScaler {
	static BufferedImage scale(BufferedImage src, // ソースイメージ
			int dest_width, // デスティネーションイメージの幅
			int dest_height) { // 同じく高さ

		System.out.println("ImageScaler::scale(, " + dest_width + ","
				+ dest_height + ")");

		int src_width = src.getWidth();
		int src_height = src.getHeight();

		System.out.println("src_width = " + src_width + ", src_height = "
				+ src_height);

		WRGBImage wrgb_image = new WRGBImage(dest_width, dest_height,
				src_width, src_height);

		int sx, sy;
		for (sy = 0; sy < src_height; sy++) {
			for (sx = 0; sx < src_width; sx++) {
				int rgb = src.getRGB(sx, sy);
				wrgb_image.drawPoint(sx, sy, rgb);
			}
			// System.out.println(sy);
		}
		return wrgb_image.getBufferedImage();
	}
}
