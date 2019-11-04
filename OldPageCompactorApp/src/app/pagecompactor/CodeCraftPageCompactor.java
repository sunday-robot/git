package app.pagecompactor;

import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * CodeCraftのページをコンパクトにする。
 * 
 * @author akiyama
 * 
 */
public class CodeCraftPageCompactor {
    /**
     * 
     * @param args
     *            画像ファイル名
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion header = new PageRegion(0, 0, 40, 0, 90);
	PageRegion body = new PageRegion(160, 160, 170, 1790, 2720 - 90);
	PageLayout pageLayout = new PageLayout(header, body, null);

	PageCompactorApp.compactPages(args, pageLayout);
    }
}
