package app.pagecompactor;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageCompactorApp;
import lib.pagecompactor.PageRegion;

/**
 * �t�b�^����(�y�[�W�ԍ����܂܂��)�𒆉���������Ɉړ������A�㉺���E�̗]����؂���B
 * 
 * @author akiyama
 * 
 */
public class OptimizerForEclipse {
    /**
     * 
     * @param args
     *            �摜�t�@�C����
     */
    public static void main(String[] args) {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(390, 240, 170, 1600, 2400);
	PageRegion footer = new PageRegion(70, 60, 2580, 0, 100);
	PageLayout inputPage = new PageLayout(null, body, footer);

	PageCompactorApp.compactPages(args, inputPage);
    }
}
