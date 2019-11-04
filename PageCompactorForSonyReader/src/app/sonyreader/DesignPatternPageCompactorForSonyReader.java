package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * フッタ部分(ページ番号が含まれる)を中央＆少し上に移動させ、上下左右の余分を切り取る。
 * 
 * @author akiyama
 * 
 */
public class DesignPatternPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            画像ファイル名
     * @throws IOException
     *             入出力エラー
     */
    public static void main(String[] args) throws IOException {
	// 画面が狭いのでフッタは省略
	PageRegion body = new PageRegion(40, 40, 330, 0, 2600 - 330);
	PageLayout originalPageLayout = new PageLayout(null,
		body, null);

	java.util.Arrays.sort(args);
	for (int i = 0; i < args.length; i++) {
	    PageCompactorForSonyReader.execute(args[i], i % 2 == 0,
		    originalPageLayout, 150, 220, false);
	}
    }

}
