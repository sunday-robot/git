package lib.pagecompactor;

/**
 * PageCompactorの各種パラメータ
 */
public class PageCompactorParams {
    /** ページが右から左か（縦書きかどうか） */
    private boolean rightToLeft;

    /** ページのレイアウト{PageLayout} */
    private PageLayout pageLayout;

    /** 画像変換に関するパラメータ */
    private ImageConvertOption imageConvertOption;

    /**
     * @return ページが右から左か（縦書きかどうか）
     */
    public boolean isRightToLeft() {
	return rightToLeft;
    }

    /**
     * @param rightToLeft
     *            ページが右から左か（縦書きかどうか）
     */
    public void setRightToLeft(boolean rightToLeft) {
	this.rightToLeft = rightToLeft;
    }

    /**
     * @return PageLayout
     */
    public PageLayout getPageLayout() {
	return pageLayout;
    }

    /**
     * @param pageLayout
     *            PageLayout
     */
    public void setPageLayout(PageLayout pageLayout) {
	this.pageLayout = pageLayout;
    }

    /**
     * @return ImageConvertOption
     */
    public ImageConvertOption getImageConvertOption() {
	return imageConvertOption;
    }

    /**
     * @param imageConvertOption
     *            ImageConvertOption
     */
    public void setImageConvertOption(ImageConvertOption imageConvertOption) {
	this.imageConvertOption = imageConvertOption;
    }

}
