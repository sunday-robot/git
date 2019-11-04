/**
 * 
 * @author akiyama
 * 
 */
public interface IRotationAdjuster {

    /**
     * �A�W���X�^�[�̏�����
     * 
     * @param target
     *            ��]�������`�iROI�Ȃǁj
     * @param area
     *            ��`��������̈�
     */
    void initialize(RectangleD target, RectangleD area);

    /**
     * ��]�p�x��␳����B
     * 
     * @param previousAngle
     *            ���O�̉�]�p�x
     * @param newAngle
     *            ���␳�̐V���ȉ�]�p�x
     * @return �␳���ꂽ��]�p�x
     */
    double adjustRotation(double previousAngle, double newAngle);
}
