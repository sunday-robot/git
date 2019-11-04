package app.pagecompactor;

import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * Beautiful Code�̃y�[�W���R���p�N�g�ɂ���B
 * 
 * @author akiyama
 * 
 */
public class BeautifulCodePageCompactor {
    /**
     * 
     * @param args
     *            �摜�t�@�C����
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(250, 250, 150, 1650, 2450);
	PageLayout pageLayout = new PageLayout(null, body, null);

	PageCompactorApp.compactPages(args, pageLayout);
    }
}
