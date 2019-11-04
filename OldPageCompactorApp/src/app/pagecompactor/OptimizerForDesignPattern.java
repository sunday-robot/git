package app.pagecompactor;

import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * �t�b�^����(�y�[�W�ԍ����܂܂��)�𒆉���������Ɉړ������A�㉺���E�̗]����؂���B
 * 
 * @author akiyama
 * 
 */
public class OptimizerForDesignPattern {
    /**
     * 
     * @param args
     *            �摜�t�@�C����
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(200, 200, 200, 0, 2580);
	PageRegion footer = new PageRegion(130, 130, 2840, 0, 160);
	PageLayout pageLayout = new PageLayout(null, body, footer);

	PageCompactorApp.compactPages(args, pageLayout);
    }
}
