package lib.pagecompactor;

/**
 * ページ内の、ヘッダー、本文、フッターの各領域の定義情報(immutable)
 * 
 * @author akiyama
 * 
 */
public class PageRegion {
    /** 右ページの腹側(つまり右側)のマージン */
    private int rightPageSideMargin;
    /** 左ページの腹側(つまり左側)のマージン */
    private int leftPageSideMargin;
    /** 開始位置のY座標 */
    private int y;
    /** 領域の幅 */
    private int width;
    /** 領域の高さ */
    private int height;

    /**
     * @return 右ページの腹側(つまり右側)のマージン
     */
    public int getRightPageSideMargin() {
	return rightPageSideMargin;
    }

    /**
     * @param rightPageSideMargin
     *            右ページの腹側(つまり右側)のマージン
     */
    public void setRightPageSideMargin(int rightPageSideMargin) {
	this.rightPageSideMargin = rightPageSideMargin;
    }

    /**
     * @return 左ページの腹側(つまり左側)のマージン
     */
    public int getLeftPageSideMargin() {
	return leftPageSideMargin;
    }

    /**
     * @param leftPageSideMargin
     *            左ページの腹側(つまり左側)のマージン
     */
    public void setLeftPageSideMargin(int leftPageSideMargin) {
	this.leftPageSideMargin = leftPageSideMargin;
    }

    /**
     * @return 開始位置のY座標
     */
    public int getY() {
	return y;
    }

    /**
     * @param y
     *            開始位置のY座標
     */
    public void setY(int y) {
	this.y = y;
    }

    /**
     * @return 領域の幅
     */
    public int getWidth() {
	return width;
    }

    /**
     * @param width
     *            領域の幅
     */
    public void setWidth(int width) {
	this.width = width;
    }

    /**
     * @return 領域の高さ
     */
    public int getHeight() {
	return height;
    }

    /**
     * @param height
     *            領域の高さ
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
     *            右ページの横(つまり左側)のマージン
     * @param leftPageSideMergine
     *            左ページの横(つまり右側)のマージン
     * @param y
     *            開始位置のY座標
     * @param width
     *            領域の幅
     * @param height
     *            領域の高さ
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
