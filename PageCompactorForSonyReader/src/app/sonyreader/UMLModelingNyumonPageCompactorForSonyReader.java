package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class UMLModelingNyumonPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion header = new PageRegion(140, 140, 110, 0, 50);
	PageRegion body = new PageRegion(150, 150, 180, 1390, 2190);
	PageRegion footer = new PageRegion(0, 0, 2360, 0, 60);
	PageLayout originalPageLayout = new PageLayout(header,
		body, footer);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 120, 230, false);
	}
    }
}
