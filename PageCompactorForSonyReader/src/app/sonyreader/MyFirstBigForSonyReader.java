package app.sonyreader;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.misc.SaveOutputImage;
import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageCompactor;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class MyFirstBigForSonyReader {
    /**
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(130, 130, 160, 1250, 2030 - 160);
	PageLayout originalPageLayout = new PageLayout(null,
		body, null);

	for (int i = 0; i < args.length; i++) {
	    execute(args[i], i % 2 == 1, originalPageLayout, 150, 230);
	}
    }

    /**
     * ページ(画像)を変換する
     * 
     * @param fileName
     *            変換対象の画像ファイル名
     * @param isRightPage
     *            右のページかどうか（横書きの場合は奇数ページ、縦書きの場合は偶数ページ）
     * @param originalPageLayout
     *            変換対象の画像のレイアウト情報
     * @param darkestLuminance
     *            この値を明度0に変換する。
     * @param lightestLuminance
     *            この値を明度255に変換する。
     * @throws IOException
     *             入出力エラー
     */
    public static void execute(String fileName, boolean isRightPage,
	    PageLayout originalPageLayout, int darkestLuminance,
	    int lightestLuminance) throws IOException {
	BufferedImage image;
	image = ImageIO.read(new File(fileName));
	System.out.printf("%s, %d, %d\n", fileName, image.getWidth(),
		image.getHeight());
	if (isRightPage) {
	    image = PageCompactor.getRightPage(image, originalPageLayout);
	} else {
	    image = PageCompactor.getLeftPage(image, originalPageLayout);
	}
	image = Emphasizer.execute(image, darkestLuminance, lightestLuminance);
	image = ResizerForSonyReader.execute(image, true);
	SaveOutputImage.execute(image, fileName, "png");
    }
}
