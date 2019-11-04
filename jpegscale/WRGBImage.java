import java.awt.image.BufferedImage;

public final class WRGBImage {
	long[] data;
	int width;
	int height;
	int sourceWidth;
	int sourceHeight;

	private void draw_point(int px, int py, int w, int r, int g, int b) {
		int idx = (px + py * width) * 4;
		data[idx] += r * w;
		data[idx + 1] += g * w;
		data[idx + 2] += b * w;
		data[idx + 3] += w;
	}

	private void draw_hline(int ix1, int ix2, int py, int ih, int r, int g,
			int b) {
		int px1 = ix1 / sourceWidth;
		int px2 = ix2 / sourceWidth;
		if (px1 == px2) {
			draw_point(px1, py, (ix2 - ix1 + 1) * ih, r, g, b);
		} else {
			draw_point(px1, py, (sourceWidth - (ix1 % sourceWidth)) * ih, r, g,
					b);
			int px;
			for (px = px1 + 1; px < px2; px++) {
				draw_point(px, py, sourceWidth * ih, r, g, b);
			}
			draw_point(px2, py, ((ix2 % sourceWidth) + 1) * ih, r, g, b);
		}
	}

	public void drawPoint(int sx, int sy, int rgb) {
		int r = (rgb >> 16) & 0xff;
		int g = (rgb >> 8) & 0xff;
		int b = rgb & 0xff;

		int ix1 = sx * width;
		int iy1 = sy * height;
		int ix2 = sx * width + width - 1;
		int iy2 = sy * height + height - 1;

		int py1 = iy1 / sourceHeight;
		int py2 = iy2 / sourceHeight;

		if (py1 == py2) {
			draw_hline(ix1, ix2, py1, iy2 - iy1 + 1, r, g, b);
		} else {
			draw_hline(ix1, ix2, py1, sourceHeight - (iy1 % sourceHeight), r,
					g, b);
			int py;
			for (py = py1 + 1; py < py2; py++) {
				draw_hline(ix1, ix2, py1, sourceHeight, r, g, b);
			}
			draw_hline(ix1, ix2, py2, (iy2 % sourceHeight) + 1, r, g, b);
		}
	}

	public BufferedImage getBufferedImage() {
		BufferedImage bi = new BufferedImage(width, height,
				BufferedImage.TYPE_INT_RGB);
		System.out.println(width + "," + height);
		int i, j;
		for (i = 0; i < height; i++) {
			// System.out.println("i = " + i);
			for (j = 0; j < width; j++) {
				// System.out.println("j = " + j);
				int idx = i * width * 4 + j * 4;
				long w = data[idx + 3];
				if (w == 0) {
					System.out.println(i + "," + j);
					System.exit(1);
				}
				int r = (int) (data[idx] / w);
				int g = (int) (data[idx + 1] / w);
				int b = (int) (data[idx + 2] / w);
				bi.setRGB(j, i, (r << 16) | (g << 8) | b);
			}
		}
		return bi;
	}

	public WRGBImage(int w, int h, int sw, int sh) {
		width = w;
		height = h;
		sourceWidth = sw;
		sourceHeight = sh;
		data = new long[4 * width * height];
	}
}
