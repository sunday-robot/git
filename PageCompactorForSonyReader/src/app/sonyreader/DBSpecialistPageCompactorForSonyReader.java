package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class DBSpecialistPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	// PageRegion header = new PageRegion(0, 0, 50, 0, 60);
	PageRegion body = new PageRegion(140, 130, 70, 1420, 2390);
	PageLayout originalPageLayout = new PageLayout(null,
		body, null);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 100, 230, false);
	}
    }
}
