package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class ScalaPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion header = new PageRegion(230, 230, 130, 0, 70);
	PageRegion body = new PageRegion(230, 230, 320, 1650, 2340);
	PageLayout originalPageLayout = new PageLayout(header,
		body, null);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 150, 230, false);
	}
    }
}
