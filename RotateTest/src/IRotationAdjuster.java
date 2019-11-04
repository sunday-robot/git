/**
 * 
 * @author akiyama
 * 
 */
public interface IRotationAdjuster {

    /**
     * アジャスターの初期化
     * 
     * @param target
     *            回転させる矩形（ROIなど）
     * @param area
     *            矩形が属する領域
     */
    void initialize(RectangleD target, RectangleD area);

    /**
     * 回転角度を補正する。
     * 
     * @param previousAngle
     *            直前の回転角度
     * @param newAngle
     *            未補正の新たな回転角度
     * @return 補正された回転角度
     */
    double adjustRotation(double previousAngle, double newAngle);
}
