package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class EclipsePageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(360, 280, 160, 1550, 2360);
	PageRegion footer = new PageRegion(0, 0, 2600, 0, 60);
	PageLayout originalPageLayout = new PageLayout(null,
		body, footer);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 150, 230, false);
	}
    }
}
