package app.sonyreader;

import java.awt.Point;
import java.awt.image.BufferedImage;

import lib.imageoperator.Resizer;

/**
 * @author akiyama
 */
public class ResizerForSonyReader {
    /**
     * Sony Reader�̉�ʃT�C�Y<br>
     * �i���m�ɂ�Sony Reader�̃R���e���c�\���̈�̃T�C�Y�ŁA�]���̕�������ʃT�C�Y(600x800)��菭���������j
     */
    private static final Point SONY_READER_SIZE = new Point(584, 754);

    /**
     * �w�肳�ꂽ�摜��Sony Reader�p�ɕϊ�(���T�C�Y�Ȃ�)�����摜��Ԃ�
     * 
     * @param image
     *            �ϊ��O�̉摜
     * @param keepAspectRatio
     *            �c������ێ����邩�ǂ����ifalse�̏ꍇ�ASonyReader�̉�ʂƓ����T�C�Y�ɂ���B�j
     * @return �ϊ���̉摜
     */
    public static BufferedImage execute(BufferedImage image,
	    boolean keepAspectRatio) {
	Point newSize;
	if (keepAspectRatio)
	    newSize = getJustSize(image.getWidth(), image.getHeight());
	else
	    newSize = SONY_READER_SIZE;
	BufferedImage destImage = Resizer.execute(image, newSize.x, newSize.y);
	return destImage;
    }

    /**
     * ���摜�̏c�����ς��Ȃ��ŁASony Reader�p�̕����邢�͍��������x�悢�摜�T�C�Y��Ԃ��B
     * 
     * @param width
     *            ���摜�̕�(��f��)
     * @param height
     *            ���摜�̍���(��f��)
     * @return Sony Reader�ɒ��x�悢�摜�T�C�Y
     */
    private static Point getJustSize(int width, int height) {
	if (width * SONY_READER_SIZE.y > SONY_READER_SIZE.x * height) {
	    // Sony Reader�ɔ�ׁA�����̉摜�̏ꍇ�A������������������
	    int h = SONY_READER_SIZE.x * height / width;
	    return new Point(SONY_READER_SIZE.x, h);
	} else {
	    // Sony Reader�ɔ�ׁA�c���̉摜�̏ꍇ�A����������������
	    int w = SONY_READER_SIZE.y * width / height;
	    return new Point(w, SONY_READER_SIZE.y);
	}
    }
}
