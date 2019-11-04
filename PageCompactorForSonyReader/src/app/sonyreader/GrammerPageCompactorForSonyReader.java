package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class GrammerPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	// PageRegion header = new PageRegion(80, 80, 90, 0, 60);
	PageRegion body = new PageRegion(80, 80, 90, 1400, 2230);
	PageRegion footer = new PageRegion(0, 0, 2380, 0, 60);
	PageLayout originalPageLayout = new PageLayout(null,
		body, footer);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 10, 230, false);
	}
    }
}
