package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class UMLEssensePageCompactorForSonyReader {

    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(330, 320, 170, 1530, 2600 - 170);
	PageRegion footer = new PageRegion(50, 50, 2480, 150, 60);
	PageLayout originalPageLayout = new PageLayout(null,
		body, footer);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 140, 220, false);
	}
    }
}
