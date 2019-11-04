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
     *            �摜�t�@�C����
     * @throws IOException
     *             ���o�̓G���[
     */
    public static void main(String[] args) throws IOException {
	// ��ʂ������̂Ńt�b�^�͏ȗ�
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
