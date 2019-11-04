import java.awt.image.BufferedImage;

public class jpegtest {
    static void main(String args[]) throws Exception {
	BufferedImage src = JPEGFile.load(args[0]);

	BufferedImage dest = getScaledImage(src, 300, 480);
//	BufferedImage dest = get_scaled_image(src, 600, 960);

	JPEGFile.save(dest, "out.jpg");

	System.exit(0);
    }

    static BufferedImage getScaledImage(
	BufferedImage src,	// ソースイメージ
	int dest_width,		// デスティネーションイメージの幅
	int dest_height) {	// 同じく高さ
	BufferedImage dest = new BufferedImage(dest_width, dest_height,
					       BufferedImage.TYPE_INT_RGB);
	int src_width = src.getWidth();
	int src_height = src.getHeight();

	int dy, gy;
	for (dy = 0, gy = 0; dy < dest_height; dy++, gy += src_height) {
	    // 左、右端部分の縮小元画像の画素の座標と、グローバル座標における
	    // 高さ
	    int sy1 = gy / dest_height;
	    int sh1 = dest_height - gy % dest_height;
	    int sy2 = (gy + src_height - 1) / dest_height;
	    int sh2 = (gy + src_height - 1) % dest_height + 1;

	    int dx, gx;
	    for (dx = 0, gx = 0; dx < dest_width; dx++, gx += src_width) {
		int sx1 = gx / dest_width;
		int sw1 = dest_width - gx % dest_width;
		int sx2 = (gx + src_width - 1) / dest_width;
		int sw2 = (gx + src_width - 1) % dest_width + 1;

		// 重みつき画素値
		WRGB wrgb = new WRGB();

		// 上辺部分の重みつき画素値を計算
		wrgb.add(calc_row(sx1, sw1, dest_width, sx2, sw2, sy1, sh1,
				  src));

		// 中央部分の重みつき画素値を計算
		int y;
		for (y = sy1 + 1; y < sy2; y++) {
		    wrgb.add(calc_row(sx1, sw1, dest_width, sx2, sw2, y,
				      dest_height, src));
		}
		    
		// 下辺部分の重みつき画素値を計算
		if (sy2 > sy1) {
		    wrgb.add(calc_row(sx1, sw1, dest_width, sx2,
				      sw2, sy2, sh2, src));
		}

		// 縮小先画像に画素値をセット
		dest.setRGB(dx, dy, wrgb.getColor());
	    }
	}

	return dest;
    }

    // 1ライン分の重み付き画素値を計算する
    static WRGB calc_row(int sx1, int sw1,
			 int width,
			 int sx2, int sw2,
			 int y, int height, BufferedImage src) {
	WRGB wrgb = new WRGB();

	// 左端の重みつき画素値を計算
	wrgb.add(sw1 * height, src.getRGB(sx1, y));

	// 中央部の重みつき画素値を計算
	int x;
	for (x = sx1 + 1; x < sx2; x++) {
	    wrgb.add(width * height, src.getRGB(x, y));
	}

	// 右辺部分の重みつき画素値を計算
	if (sx2 > sx1) {
	    wrgb.add(sw2 * height, src.getRGB(sx2, y));
	}

	return wrgb;
    }
}

