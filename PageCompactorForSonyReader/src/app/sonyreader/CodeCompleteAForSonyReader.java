package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class CodeCompleteAForSonyReader {
    /**
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion header = new PageRegion(160, 160, 100, 0, 90);
	PageRegion body = new PageRegion(160, 550, 250, 1340, 2350);
	PageLayout originalPageLayout = new PageLayout(header,
		body, null);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 150, 230, false);
	}
    }
}
