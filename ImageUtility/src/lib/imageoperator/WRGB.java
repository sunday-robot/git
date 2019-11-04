package lib.imageoperator;

/**
 * �d�ݕt����f�l
 * 
 * @author akiyama
 * 
 */
public class WRGB {
    /** weight */
    public long w;
    /** weighted red */
    public long r;
    /** weighted green */
    public long g;
    /** weighted blue */
    public long b;

    /**
     * �R���X�g���N�^
     */
    public WRGB() {
	set(0, 0, 0, 0);
    }

    /**
     * �R���X�g���N�^
     * 
     * @param w
     *            �d��
     * @param r
     *            Red
     * @param g
     *            Green
     * @param b
     *            Blue
     */
    public WRGB(int w, int r, int g, int b) {
	set(w, r, g, b);
    }

    /**
     * �R���X�g���N�^
     * 
     * @param w
     *            �d��
     * @param color
     *            �F(RGB)
     */
    public WRGB(int w, int color) {
	set(w, color);
    }

    /**
     * �Z�b�^�[
     * 
     * @param w
     *            �d��
     * @param r
     *            Red
     * @param g
     *            Green
     * @param b
     *            Blue
     * @return WRGB
     */
    public final WRGB set(int w, int r, int g, int b) {
	this.w = w;
	this.r = r * w;
	this.g = g * w;
	this.b = b * w;
	return this;
    }

    /**
     * �Z�b�^�[
     * 
     * @param w
     *            �d��
     * @param color
     *            �F(RGB)
     * @return WRGB
     */
    public final WRGB set(int w, int color) {
	return set(w, (color >> 16) & 255, (color >> 8) & 255, color & 255);
    }

    /**
     * �d�ݕt��RGB�l�����Z����
     * 
     * @param w
     *            �d��
     * @param r
     *            Red
     * @param g
     *            Green
     * @param b
     *            Blue
     * @return WRGB
     */
    public final WRGB add(int w, int r, int g, int b) {
	this.w += w;
	this.r += r * w;
	this.g += g * w;
	this.b += b * w;
	return this;
    }

    /**
     * �d�ݕt��RGB�l�����Z����
     * 
     * @param w
     *            �d��
     * @param color
     *            �F(RGB)
     * @return WRGB
     */
    public final WRGB add(int w, int color) {
	return add(w, (color >> 16) & 255, (color >> 8) & 255, color & 255);
    }

    /**
     * �d�ݕt��RGB�l�����Z����
     * 
     * @param v
     *            WRGB
     * @return WRGB
     */
    public final WRGB add(WRGB v) {
	w += v.w;
	r += v.r;
	g += v.g;
	b += v.b;
	return this;
    }

    /**
     * �d�݂̂Ȃ��ʏ��RGB�l��Ԃ��B
     * 
     * @return RGB
     */
    public final int getColor() {
	if (w == 0)
	    return 0;
	return (int) ((r / w << 16) + (g / w << 8) + b / w);
    }

    @Override
    public final String toString() {
	return "(" + w + "," + r + "," + g + "," + b + ")";
    }
}
