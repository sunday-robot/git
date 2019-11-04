package app.pagecompactor;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.imageoperator.Gamma;
import lib.imageoperator.Resizer;
import lib.imageoperator.Thickener;
import lib.misc.SaveOutputImage;
import lib.pagecompactor.ImageConvertOption;
import lib.pagecompactor.PageCompactor;
import lib.pagecompactor.PageCompactorParams;
import lib.pagecompactor.PageCompactorParamsLoader;

/**
 */
public class PageCompactorApp {
	/**
	 * main
	 * 
	 * @param args
	 *            [0]...PageCompactorParamsのプロパティファイル<br/>
	 *            [1]以降...画像ファイルのパス名
	 * @throws Exception
	 *             入出力エラーなど
	 */
	public static void main(String[] args) throws Exception {
		PageCompactorParams pageCompactorParams = PageCompactorParamsLoader
				.load(args[0]);
		for (int i = 1; i < args.length; i++) {
			optimizePage(args[i], i, pageCompactorParams);
		}
	}

	/**
	 * 
	 * 
	 * @param fileName
	 *            ページの画像ファイル
	 * @param pageNumber
	 *            ページ番号(1～)
	 * @param pageCompactorParams
	 *            ページのレイアウト定義情報や、画像変換指示情報
	 * @throws IOException
	 *             入出力エラー
	 */
	private static void optimizePage(String fileName, int pageNumber,
			PageCompactorParams pageCompactorParams) throws IOException {
		BufferedImage image = ImageIO.read(new File(fileName));
		System.out.printf("%s, %d, %d\n", fileName, image.getWidth(),
				image.getHeight());

		if (pageCompactorParams.isRightToLeft() ^ (pageNumber % 2 == 0)) {
			System.out.printf("left page\n");
			image = PageCompactor.getLeftPage(image,
					pageCompactorParams.getPageLayout());
		} else {
			System.out.printf("right page\n");
			image = PageCompactor.getRightPage(image,
					pageCompactorParams.getPageLayout());
		}

		ImageConvertOption imageConvertOption = pageCompactorParams
				.getImageConvertOption();

		int[] emphasizeRange = imageConvertOption.getEmphasizeRange();
		if (emphasizeRange != null) {
			System.out.printf("emphasizing %d - %d\n", emphasizeRange[0],
					emphasizeRange[1]);
			image = Emphasizer.execute(image, emphasizeRange[0],
					emphasizeRange[1]);
		}

		double gamma = imageConvertOption.getGamma();
		if (gamma != 0) {
			System.out.printf("gamma correcting [%f]\n", gamma);
			image = Gamma.execute(image, gamma);
		}

		if (imageConvertOption.isThicken()) {
			System.out.printf("thickening\n");
			image = Thickener.execute(image);
		}

		int[] size = imageConvertOption.getSize();
		if (size != null) {
			int w = size[0];
			int h = size[1];
			if (imageConvertOption.isKeepAspectRatio()) {
				if (image.getWidth() * h > w * image.getHeight()) {
					// 指定された画像サイズに比べ、横長の画像の場合、高さを調整する
					h = w * image.getHeight() / image.getWidth();
				} else {
					// 指定された画像サイズに比べ、縦長の画像の場合、幅を調整する
					w = h * image.getWidth() / image.getHeight();
				}
			}
			System.out.printf("resizing (%d, %d)\n", w, h);
			image = Resizer.execute(image, w, h);
		} else {
			double zoomRate = imageConvertOption.getZoomRate();
			if (zoomRate > 0) {
				System.out.printf("zooming %f %%\n", zoomRate * 100);
				int w = (int) (image.getWidth() * zoomRate);
				int h = (int) (image.getHeight() * zoomRate);
				image = Resizer.execute(image, w, h);
			}
		}
		// if (imageConvertOption.monochrome16) {
		// System.out.printf("converting to monochrome 16\n");
		// image = Gray16.execute(image);
		// }

		System.out.printf("saving\n");
		if (imageConvertOption.isJpegOutput()) {
			SaveOutputImage.execute(image, fileName, "jpeg");
		} else {
			SaveOutputImage.execute(image, fileName, "png");
		}
	}
}
