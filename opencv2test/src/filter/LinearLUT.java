package filter;

/**
 * 線形補間を行う単純なLUT
 */
public class LinearLUT implements LUT {
    /**  */
    private double[] values;

    /**
     * コンストラクタ
     * 
     * @param values
     *            値のリスト
     */
    public LinearLUT(double[] values) {
	this.values = values.clone();
    }

    @Override
    public double convert(double v) {
	double x = v * (values.length - 1);
	int index = (int) x;
	double a = x - index;
	double b = 1 - a;
	double nv = (a * values[index] + b * values[index + 1]);
	return nv;
    }
}
