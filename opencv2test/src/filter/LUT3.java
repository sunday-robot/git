package filter;

public interface LUT3 {
    /**
     * RGBやHSVなどの3要素の変換
     * 
     * @param v1
     *            V1
     * @param v2
     *            V2
     * @param v3
     *            V3
     * @return 変換後の3要素
     */
    double[] convert(double v1, double v2, double v3);

}
