package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class UMLHaShudanPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion header = new PageRegion(80, 100, 110, 0, 80);
	PageRegion body = new PageRegion(80, 100, 230, 1050, 1570);
	PageRegion footer = new PageRegion(80, 100, 1890, 0, 40);
	PageLayout originalPageLayout = new PageLayout(header,
		body, footer);

	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 1,
		    originalPageLayout, 150, 230, false);
	}
    }
}
