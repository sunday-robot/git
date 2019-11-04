package minilext.model;

/**
 * 撮影ボタン押下時の処理を行うもの。
 */
public abstract class AcquisitionExecutor {
    /** M */
    protected final Model model;

    /**
     * @param model
     *            M
     */
    public AcquisitionExecutor(Model model) {
	this.model = model;
    }

    /** 入力チェック及び撮影処理を開始する。 */
    public abstract void start();
}
