package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class KiokuryokuWoTsuyokusuruForSonyReader {
    /**
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(110, 110, 120, 1050, 1800);
	PageLayout originalPageLayout = new PageLayout(null, body, null);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 != 0,
		    originalPageLayout, 0, 255, false);
	}
    }
}
