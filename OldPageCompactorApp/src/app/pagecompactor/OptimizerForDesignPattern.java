package app.pagecompactor;

import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * フッタ部分(ページ番号が含まれる)を中央＆少し上に移動させ、上下左右の余分を切り取る。
 * 
 * @author akiyama
 * 
 */
public class OptimizerForDesignPattern {
    /**
     * 
     * @param args
     *            画像ファイル名
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(200, 200, 200, 0, 2580);
	PageRegion footer = new PageRegion(130, 130, 2840, 0, 160);
	PageLayout pageLayout = new PageLayout(null, body, footer);

	PageCompactorApp.compactPages(args, pageLayout);
    }
}
