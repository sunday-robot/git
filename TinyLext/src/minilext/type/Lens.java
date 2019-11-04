package minilext.type;

/**
 * (Mutable)<br>
 * 対物レンズの情報。 以下の情報からなる。<br>
 * ・対物レンズのスペック{@link LensSpecification}<br>
 * ・X軸方向の調整値(この値をスペックの倍率に乗じることで、実際の倍率になる)<br>
 * ・Y軸方向の調整値(同上)
 */
public class Lens {
    /** 対物レンズのスペック */
    public final LensSpecification specification;

    /** X軸方向の調整値 */
    public final double calibrationX;

    /** X軸方向の調整値 */
    public final double calibrationY;

    /**
     * @param lensSpecification
     *            :
     * @param calibrationX
     *            :
     * @param calibrationY
     *            :
     */
    public Lens(LensSpecification lensSpecification, double calibrationX, double calibrationY) {
	this.specification = lensSpecification;
	this.calibrationX = calibrationX;
	this.calibrationY = calibrationY;
    }
}
