package lib.pagecompactor;

import java.awt.Rectangle;
import java.awt.image.BufferedImage;

import lib.imageoperator.Paste;

/**
 * �y�[�W���C�A�E�g��`���ɏ]���A�R���p�N�g�Ƀ��C�A�E�g�����摜�𐶐�����N���X�B
 * 
 * @author akiyama
 * 
 */
public class PageCompactor {
    /**
     * �E�y�[�W(��y�[�W)�̏���<br/>
     * 
     * @param image
     *            BufferedImage
     * @param inputPage
     *            �y�[�W�̃��C�A�E�g��`���
     * @return �������ꂽ�摜
     */
    public static BufferedImage getRightPage(BufferedImage image,
	    PageLayout inputPage) {
	final int iw = image.getWidth();
	final int ih = image.getHeight();

	int y;
	int h;

	Rectangle br = inputPage.getRightPageBodyRegion(iw, ih);

	Rectangle hr = inputPage.getRightPageHeaderRegion(iw, ih);
	if (hr != null) {
	    y = br.y - hr.height;
	    h = hr.height + br.height;
	    int destX = br.x + br.width - hr.width;
	    int destY = br.y - hr.height;
	    image = copyRegion(image, hr.x, hr.y, hr.width, hr.height, destX,
		    destY);
	} else {
	    y = br.y;
	    h = br.height;
	}

	Rectangle fr = inputPage.getRightPageFooterRegion(iw, ih);
	if (fr != null) {
	    int destX = br.x + br.width - fr.width;
	    int destY = br.y + br.height;
	    h += fr.height;
	    image = copyRegion(image, fr.x, fr.y, fr.width, fr.height, destX,
		    destY);
	}

	return image.getSubimage(br.x, y, br.width, h);
    }

    /**
     * ���y�[�W(�����y�[�W)�̏���<br/>
     * 
     * @param image
     *            BufferedImage
     * @param inputPage
     *            �y�[�W�̃��C�A�E�g��`���
     * @return �������ꂽ�摜
     */
    public static BufferedImage getLeftPage(BufferedImage image,
	    PageLayout inputPage) {
	final int iw = image.getWidth();
	final int ih = image.getHeight();

	int y;
	int h;

	Rectangle br = inputPage.getLeftPageBodyRegion(iw, ih);

	Rectangle hr = inputPage.getLeftPageHeaderRegion(iw, ih);
	if (hr != null) {
	    y = br.y - hr.height;
	    h = br.height + hr.height;
	    image = copyRegion(image, hr.x, hr.y, hr.width, hr.height, br.x, y);
	} else {
	    y = br.y;
	    h = br.height;
	}

	Rectangle fr = inputPage.getLeftPageFooterRegion(iw, ih);
	if (fr != null) {
	    h += fr.height;
	    image = copyRegion(image, fr.x, fr.y, fr.width, fr.height, br.x,
		    br.y + br.height);
	}

	return image.getSubimage(br.x, y, br.width, h);
    }

    /**
     * �w�肳�ꂽ�̈���w�肳�ꂽ�ꏊ�ɃR�s�[����B
     * 
     * @param image
     *            ���摜
     * @param sx
     *            �R�s�[���̈�
     * @param sy
     *            (����)
     * @param w
     *            (����)
     * @param h
     *            (����)
     * @param dx
     *            �R�s�[��
     * @param dy
     *            (����)
     * @return �������ꂽ�摜
     */
    private static BufferedImage copyRegion(BufferedImage image, int sx,
	    int sy, int w, int h, int dx, int dy) {
	if ((w == 0) || (h == 0))
	    return image;
	BufferedImage subImage = image.getSubimage(sx, sy, w, h);
	return Paste.execute(image, dx, dy, subImage);
    }

}
