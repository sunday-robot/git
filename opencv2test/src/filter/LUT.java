package filter;

/**
 * LUT(Look Up Table)のインターフェイス
 */
public interface LUT {
    /**
     * グレースケールなどの1要素のみの変換
     * 
     * @param v
     *            V
     * @return 変換後のV
     */
    double convert(double v);

}
