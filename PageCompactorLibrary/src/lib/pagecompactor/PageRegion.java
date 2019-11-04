package lib.pagecompactor;

/**
 * �y�[�W���́A�w�b�_�[�A�{���A�t�b�^�[�̊e�̈�̒�`���(immutable)
 * 
 * @author akiyama
 * 
 */
public class PageRegion {
    /** �E�y�[�W�̕���(�܂�E��)�̃}�[�W�� */
    private int rightPageSideMargin;
    /** ���y�[�W�̕���(�܂荶��)�̃}�[�W�� */
    private int leftPageSideMargin;
    /** �J�n�ʒu��Y���W */
    private int y;
    /** �̈�̕� */
    private int width;
    /** �̈�̍��� */
    private int height;

    /**
     * @return �E�y�[�W�̕���(�܂�E��)�̃}�[�W��
     */
    public int getRightPageSideMargin() {
	return rightPageSideMargin;
    }

    /**
     * @param rightPageSideMargin
     *            �E�y�[�W�̕���(�܂�E��)�̃}�[�W��
     */
    public void setRightPageSideMargin(int rightPageSideMargin) {
	this.rightPageSideMargin = rightPageSideMargin;
    }

    /**
     * @return ���y�[�W�̕���(�܂荶��)�̃}�[�W��
     */
    public int getLeftPageSideMargin() {
	return leftPageSideMargin;
    }

    /**
     * @param leftPageSideMargin
     *            ���y�[�W�̕���(�܂荶��)�̃}�[�W��
     */
    public void setLeftPageSideMargin(int leftPageSideMargin) {
	this.leftPageSideMargin = leftPageSideMargin;
    }

    /**
     * @return �J�n�ʒu��Y���W
     */
    public int getY() {
	return y;
    }

    /**
     * @param y
     *            �J�n�ʒu��Y���W
     */
    public void setY(int y) {
	this.y = y;
    }

    /**
     * @return �̈�̕�
     */
    public int getWidth() {
	return width;
    }

    /**
     * @param width
     *            �̈�̕�
     */
    public void setWidth(int width) {
	this.width = width;
    }

    /**
     * @return �̈�̍���
     */
    public int getHeight() {
	return height;
    }

    /**
     * @param height
     *            �̈�̍���
     */
    public void setHeight(int height) {
	this.height = height;
    }

    /**
     */
    public PageRegion() {
    }

    /**
     * @param rightPageSideMergine
     *            �E�y�[�W�̉�(�܂荶��)�̃}�[�W��
     * @param leftPageSideMergine
     *            ���y�[�W�̉�(�܂�E��)�̃}�[�W��
     * @param y
     *            �J�n�ʒu��Y���W
     * @param width
     *            �̈�̕�
     * @param height
     *            �̈�̍���
     */
    public PageRegion(int rightPageSideMergine, int leftPageSideMergine, int y,
	    int width, int height) {
	this.rightPageSideMargin = rightPageSideMergine;
	this.leftPageSideMargin = leftPageSideMergine;
	this.y = y;
	this.width = width;
	this.height = height;
    }

}
