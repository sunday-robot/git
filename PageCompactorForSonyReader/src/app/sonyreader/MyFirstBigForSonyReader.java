package app.sonyreader;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.misc.SaveOutputImage;
import lib.pagecompactor.PageLayout;
import lib.pagecompactor.PageCompactor;
import lib.pagecompactor.PageRegion;

/**
 * @author akiyama
 */
public class MyFirstBigForSonyReader {
    /**
     * @param args
     *            �摜�t�@�C����
     * @throws IOException
     *             ���o�̓G���[
     */
    public static void main(String[] args) throws IOException {
	java.util.Arrays.sort(args);

	PageRegion body = new PageRegion(130, 130, 160, 1250, 2030 - 160);
	PageLayout originalPageLayout = new PageLayout(null,
		body, null);

	for (int i = 0; i < args.length; i++) {
	    execute(args[i], i % 2 == 1, originalPageLayout, 150, 230);
	}
    }

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
     * @throws IOException
     *             ���o�̓G���[
     */
    public static void execute(String fileName, boolean isRightPage,
	    PageLayout originalPageLayout, int darkestLuminance,
	    int lightestLuminance) throws IOException {
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
	image = ResizerForSonyReader.execute(image, true);
	SaveOutputImage.execute(image, fileName, "png");
    }
}
