package filter;

public interface LUT3 {
    /**
     * RGB��HSV�Ȃǂ�3�v�f�̕ϊ�
     * 
     * @param v1
     *            V1
     * @param v2
     *            V2
     * @param v3
     *            V3
     * @return �ϊ����3�v�f
     */
    double[] convert(double v1, double v2, double v3);

}
