package app.pagecompactor;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageRegion;


/**
 * 
 * @author akiyama
 * 
 */
public class RefactoringPageCompactor {
    /**
     * 
     * @param args
     *            ‰æ‘œƒtƒ@ƒCƒ‹–¼
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(200, 200, 140, 2250, 3360);
	PageLayout inputPage = new PageLayout(null, body, null);

	PageCompactorApp.compactPages(args, inputPage);
    }
}
