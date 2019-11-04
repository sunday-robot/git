package filter;

/**
 * ���`��Ԃ��s���P����LUT
 */
public class LinearLUT implements LUT {
    /**  */
    private double[] values;

    /**
     * �R���X�g���N�^
     * 
     * @param values
     *            �l�̃��X�g
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
