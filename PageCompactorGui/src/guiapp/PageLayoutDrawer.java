package guiapp;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

import org.eclipse.swt.graphics.Color;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Rectangle;

/**
 * PageLayoutの、各領域（ヘッダー、本文、フッター）を描くもの。
 * 
 * @author akiyama
 */
public class PageLayoutDrawer {
    /**
     * PageLayoutの、各領域（ヘッダー、本文、フッター）を描く。
     * 
     * @param pageLayout
     *            PageLayout
     * @param gc
     *            GC
     * @param isRightPage
     *            右ページか否か（横書きの本では奇数ページが右、縦書きの本では偶数ページが右）
     */
    public static void draw(PageLayout pageLayout, GC gc, boolean isRightPage) {
	if (pageLayout == null)
	    return;
	drawPageRegion(pageLayout.getHeader(), gc, isRightPage);
	drawPageRegion(pageLayout.getBody(), gc, isRightPage);
	drawPageRegion(pageLayout.getFooter(), gc, isRightPage);
    }

    private static void drawPageRegion(PageRegion pageRegion, GC gc,
	    boolean isRightPage) {
	if (pageRegion == null)
	    return;
	int x = isRightPage ? pageRegion.getRightPageSideMargin() : pageRegion
		.getLeftPageSideMargin();
	int w = pageRegion.getWidth();
	int h = pageRegion.getHeight();
	int y = pageRegion.getY();
	Color color = new Color(gc.getDevice(), 255, 0, 0);
	gc.setForeground(color);
	Rectangle rectangle = new Rectangle(x, y, w, h);
	gc.drawRectangle(rectangle);
	color.dispose();
    }
}
