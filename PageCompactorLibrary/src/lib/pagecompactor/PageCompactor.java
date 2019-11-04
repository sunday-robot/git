package lib.pagecompactor;

import java.awt.Rectangle;
import java.awt.image.BufferedImage;

import lib.imageoperator.Paste;

/**
 * ページレイアウト定義情報に従い、コンパクトにレイアウトした画像を生成するクラス。
 * 
 * @author akiyama
 * 
 */
public class PageCompactor {
    /**
     * 右ページ(奇数ページ)の処理<br/>
     * 
     * @param image
     *            BufferedImage
     * @param inputPage
     *            ページのレイアウト定義情報
     * @return 処理された画像
     */
    public static BufferedImage getRightPage(BufferedImage image,
	    PageLayout inputPage) {
	final int iw = image.getWidth();
	final int ih = image.getHeight();

	int y;
	int h;

	Rectangle br = inputPage.getRightPageBodyRegion(iw, ih);

	Rectangle hr = inputPage.getRightPageHeaderRegion(iw, ih);
	if (hr != null) {
	    y = br.y - hr.height;
	    h = hr.height + br.height;
	    int destX = br.x + br.width - hr.width;
	    int destY = br.y - hr.height;
	    image = copyRegion(image, hr.x, hr.y, hr.width, hr.height, destX,
		    destY);
	} else {
	    y = br.y;
	    h = br.height;
	}

	Rectangle fr = inputPage.getRightPageFooterRegion(iw, ih);
	if (fr != null) {
	    int destX = br.x + br.width - fr.width;
	    int destY = br.y + br.height;
	    h += fr.height;
	    image = copyRegion(image, fr.x, fr.y, fr.width, fr.height, destX,
		    destY);
	}

	return image.getSubimage(br.x, y, br.width, h);
    }

    /**
     * 左ページ(偶数ページ)の処理<br/>
     * 
     * @param image
     *            BufferedImage
     * @param inputPage
     *            ページのレイアウト定義情報
     * @return 処理された画像
     */
    public static BufferedImage getLeftPage(BufferedImage image,
	    PageLayout inputPage) {
	final int iw = image.getWidth();
	final int ih = image.getHeight();

	int y;
	int h;

	Rectangle br = inputPage.getLeftPageBodyRegion(iw, ih);

	Rectangle hr = inputPage.getLeftPageHeaderRegion(iw, ih);
	if (hr != null) {
	    y = br.y - hr.height;
	    h = br.height + hr.height;
	    image = copyRegion(image, hr.x, hr.y, hr.width, hr.height, br.x, y);
	} else {
	    y = br.y;
	    h = br.height;
	}

	Rectangle fr = inputPage.getLeftPageFooterRegion(iw, ih);
	if (fr != null) {
	    h += fr.height;
	    image = copyRegion(image, fr.x, fr.y, fr.width, fr.height, br.x,
		    br.y + br.height);
	}

	return image.getSubimage(br.x, y, br.width, h);
    }

    /**
     * 指定された領域を指定された場所にコピーする。
     * 
     * @param image
     *            原画像
     * @param sx
     *            コピー元領域
     * @param sy
     *            (同上)
     * @param w
     *            (同上)
     * @param h
     *            (同上)
     * @param dx
     *            コピー先
     * @param dy
     *            (同上)
     * @return 生成された画像
     */
    private static BufferedImage copyRegion(BufferedImage image, int sx,
	    int sy, int w, int h, int dx, int dy) {
	if ((w == 0) || (h == 0))
	    return image;
	BufferedImage subImage = image.getSubimage(sx, sy, w, h);
	return Paste.execute(image, dx, dy, subImage);
    }

}
