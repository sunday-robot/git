import java.util.ArrayList;
import java.util.List;

/**
 * ���W�A�傫����double�^�̋�`
 * 
 * @author akiyama
 * 
 */
public class RectangleD {
    /** ����̒��_�̍��W */
    public PointD position;
    /** ���ƍ��� */
    public PointD size;

    /**
     * �R���X�g���N�^
     * 
     * @param x
     *            ����̒��_�̍��W
     * @param y
     *            ����̒��_�̍��W
     * @param width
     *            ��
     * @param height
     *            ����
     */
    public RectangleD(double x, double y, double width, double height) {
	position = new PointD(x, y);
	size = new PointD(width, height);
    }

    /**
     * ���S�_�̍��W��Ԃ��B
     * 
     * @return ���S�_�̍��W
     */
    public final PointD getCenter() {
	return new PointD(position.x + size.x / 2, position.y + size.y / 2);
    }

    /**
     * ��]��������̒��_�̍��W���X�g��Ԃ��B
     * 
     * @param angle
     *            ��]�p�x
     * @return ��]��̒��_�̍��W���X�g
     */
    public final List<PointD> rotate(double angle) {
	List<PointD> list = new ArrayList<PointD>();
	PointD c = getCenter();
	list.add(position.rotate(c, angle));
	list.add(new PointD(position.x + size.x, position.y).rotate(c, angle));
	list.add(new PointD(position.x, position.y + size.y).rotate(c, angle));
	list.add(new PointD(position.x + size.x, position.y + size.y).rotate(c,
		angle));
	return list;
    }

}
