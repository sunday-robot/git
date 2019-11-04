package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * 
 * @author akiyama
 * 
 */
public class SpecificationPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	// 画面が狭いのでフッタは省略
	PageRegion header = new PageRegion(60, 60, 50, 0, 50);
	PageRegion body = new PageRegion(160, 160, 170, 1450, 2230);
	// 60 1458 1630
	PageLayout originalPageLayout = new PageLayout(header,
		body, null);

	java.util.Arrays.sort(args);
	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 150, 220, false);
	}
    }

}
