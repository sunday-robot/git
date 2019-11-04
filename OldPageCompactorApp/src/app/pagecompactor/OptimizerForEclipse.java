package app.pagecompactor;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageRegion;

/**
 * フッタ部分(ページ番号が含まれる)を中央＆少し上に移動させ、上下左右の余分を切り取る。
 * 
 * @author akiyama
 * 
 */
public class OptimizerForEclipse {
    /**
     * 
     * @param args
     *            画像ファイル名
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(390, 240, 170, 1600, 2400);
	PageRegion footer = new PageRegion(70, 60, 2580, 0, 100);
	PageLayout inputPage = new PageLayout(null, body, footer);

	PageCompactorApp.compactPages(args, inputPage);
    }
}
