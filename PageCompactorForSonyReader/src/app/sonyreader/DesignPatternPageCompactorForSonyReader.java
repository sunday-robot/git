package app.sonyreader;

import java.io.IOException;

import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageRegion;

/**
 * �t�b�^����(�y�[�W�ԍ����܂܂��)�𒆉���������Ɉړ������A�㉺���E�̗]����؂���B
 * 
 * @author akiyama
 * 
 */
public class DesignPatternPageCompactorForSonyReader {
    /**
     * 
     * @param args
     *            �摜�t�@�C����
     * @throws IOException
     *             ���o�̓G���[
     */
    public static void main(String[] args) throws IOException {
	// ��ʂ������̂Ńt�b�^�͏ȗ�
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
