package app.sonyreader;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.imageoperator.Thickener;
import lib.misc.SaveOutputImage;
import lib.pagecompactor.PageCompactor;
import lib.pagecompactor.PageLayout;

/**
 * @author akiyama
 */
public class PageCompactorForSonyReader {
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
     * @param keepAspectRatio
     *            縦横比を維持するかどうか
     * @throws IOException
     *             入出力エラー
     */
    public static void execute(String fileName, boolean isRightPage,
	    PageLayout originalPageLayout, int darkestLuminance,
	    int lightestLuminance, boolean keepAspectRatio) throws IOException {
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
	image = Thickener.execute(image);
	if (keepAspectRatio)
	    image = ResizerForSonyReader.execute(image, true);
	else
	    image = ResizerForSonyReader.execute(image, false);
	SaveOutputImage.execute(image, fileName, "png");
    }
}
