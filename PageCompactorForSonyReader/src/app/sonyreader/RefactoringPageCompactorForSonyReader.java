package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class RefactoringPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion header = new PageRegion(240, 240, 160, 0, 70);
	PageRegion body = new PageRegion(240, 240, 300, 2200, 3370);
	PageLayout originalPageLayout = new PageLayout(header,
		body, null);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 140, 220, false);
	}
    }
}
