package app.sonyreader;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.imageoperator.Thickener;
import lib.misc.SaveOutputImage;
import lib.pagecompactor.PageCompactor;
import lib.pagecompactor.PageLayout;

/**
 * @author akiyama
 */
public class PageCompactorForSonyReader {
    /**
     * �y�[�W(�摜)��ϊ�����
     * 
     * @param fileName
     *            �ϊ��Ώۂ̉摜�t�@�C����
     * @param isRightPage
     *            �E�̃y�[�W���ǂ����i�������̏ꍇ�͊�y�[�W�A�c�����̏ꍇ�͋����y�[�W�j
     * @param originalPageLayout
     *            �ϊ��Ώۂ̉摜�̃��C�A�E�g���
     * @param darkestLuminance
     *            ���̒l�𖾓x0�ɕϊ�����B
     * @param lightestLuminance
     *            ���̒l�𖾓x255�ɕϊ�����B
     * @param keepAspectRatio
     *            �c������ێ����邩�ǂ���
     * @throws IOException
     *             ���o�̓G���[
     */
    public static void execute(String fileName, boolean isRightPage,
	    PageLayout originalPageLayout, int darkestLuminance,
	    int lightestLuminance, boolean keepAspectRatio) throws IOException {
	BufferedImage image;
	image = ImageIO.read(new File(fileName));
	System.out.printf("%s, %d, %d\n", fileName, image.getWidth(),
		image.getHeight());
	if (isRightPage) {
	    image = PageCompactor.getRightPage(image, originalPageLayout);
	} else {
	    image = PageCompactor.getLeftPage(image, originalPageLayout);
	}
	image = Emphasizer.execute(image, darkestLuminance, lightestLuminance);
	image = Thickener.execute(image);
	if (keepAspectRatio)
	    image = ResizerForSonyReader.execute(image, true);
	else
	    image = ResizerForSonyReader.execute(image, false);
	SaveOutputImage.execute(image, fileName, "png");
    }
}
