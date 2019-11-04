package guiapp;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

import org.eclipse.swt.graphics.Color;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Rectangle;

/**
 * PageLayout�́A�e�̈�i�w�b�_�[�A�{���A�t�b�^�[�j��`�����́B
 * 
 * @author akiyama
 */
public class PageLayoutDrawer {
    /**
     * PageLayout�́A�e�̈�i�w�b�_�[�A�{���A�t�b�^�[�j��`���B
     * 
     * @param pageLayout
     *            PageLayout
     * @param gc
     *            GC
     * @param isRightPage
     *            �E�y�[�W���ۂ��i�������̖{�ł͊�y�[�W���E�A�c�����̖{�ł͋����y�[�W���E�j
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
