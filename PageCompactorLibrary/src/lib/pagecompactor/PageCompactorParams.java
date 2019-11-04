package lib.pagecompactor;

/**
 * PageCompactor�̊e��p�����[�^
 */
public class PageCompactorParams {
    /** �y�[�W���E���獶���i�c�������ǂ����j */
    private boolean rightToLeft;

    /** �y�[�W�̃��C�A�E�g{PageLayout} */
    private PageLayout pageLayout;

    /** �摜�ϊ��Ɋւ���p�����[�^ */
    private ImageConvertOption imageConvertOption;

    /**
     * @return �y�[�W���E���獶���i�c�������ǂ����j
     */
    public boolean isRightToLeft() {
	return rightToLeft;
    }

    /**
     * @param rightToLeft
     *            �y�[�W���E���獶���i�c�������ǂ����j
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
