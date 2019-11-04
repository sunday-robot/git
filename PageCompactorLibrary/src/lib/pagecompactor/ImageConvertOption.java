package lib.pagecompactor;

/**
 * 画像変換に関する各種パラメータ
 */
public final class ImageConvertOption {

	/** 明暗を強調する。（設定値は最低値と最高値の2要素からなる。） */
	private int[] emphasizeRange = null;

	/** 黒いい部分を太らせる。 */
	private boolean thicken = false;

	/** サイズ変更(1) 拡大（縮小）率 */
	private double zoomRate = 0; // 0はサイズ変更をしないという特別な値

	/** サイズ変更(2) 出力サイズ(幅と高さ）指定 */
	private int[] size = null;

	/** サイズ変更(2-1) 縦横比を維持するかどうか */
	private boolean keepAspectRatio = true;

	/** PNGではなく、JPEG形式で出力する */
	private boolean isJpegOutput = false;

	/** JPEGの圧縮率 0.00(0%)～1.00(100%) */
	private double jpegCompressionRate = 0.75; // 標準の圧縮率はとりあえず75%

	/** モノクロ16階調画像に変換する */
	private boolean monochrome16 = false;

	/** ガンマ補正値 */
	private double gamma = 0; // 0はガンマ補正を行わないという特別な値

	/**
	 * @return 縦横比を維持するかどうか
	 */
	public boolean isKeepAspectRatio() {
		return keepAspectRatio;
	}

	/**
	 * @param keepAspectRatio
	 *            縦横比を維持するかどうか
	 */
	public void setKeepAspectRatio(boolean keepAspectRatio) {
		this.keepAspectRatio = keepAspectRatio;
	}

	/**
	 * @return 明暗を強調する。（最低値と最高値の2要素からなる。）
	 */
	public int[] getEmphasizeRange() {
		return emphasizeRange;
	}

	/**
	 * 輝度値強調の設定
	 * 
	 * @param lowest
	 *            最低輝度値(この輝度値が0になるように変換する)
	 * @param highest
	 *            最大輝度値(この輝度値が255になるように変換する)
	 */
	public void setEmphasizeRange(int lowest, int highest) {
		this.emphasizeRange = new int[] { lowest, highest };
	}

	/**
	 * @return 黒い部分を太らせるかどうか
	 */
	public boolean isThicken() {
		return thicken;
	}

	/**
	 * @param thicken
	 *            黒い部分を太らせるかどうか
	 */
	public void setThicken(boolean thicken) {
		this.thicken = thicken;
	}

	/**
	 * @return ズーム倍率
	 */
	public double getZoomRate() {
		return zoomRate;
	}

	/**
	 * @param zoomRate
	 *            ズーム倍率
	 */
	public void setZoomRate(double zoomRate) {
		this.zoomRate = zoomRate;
	}

	/**
	 * @return JPEG出力するかどうか(JPEGではない場合、PNG)
	 */
	public boolean isJpegOutput() {
		return isJpegOutput;
	}

	/**
	 * @param isJpegOutput
	 *            JPEG出力するかどうか(JPEGではない場合、PNG)
	 */
	public void setJpegOutput(boolean isJpegOutput) {
		this.isJpegOutput = isJpegOutput;
	}

	/**
	 * @return JPEG圧縮レベル
	 */
	public double getJpegCompressionRate() {
		return jpegCompressionRate;
	}

	/**
	 * @param jpegCompressionRate
	 *            JPEG圧縮レベル
	 */
	public void setJpegCompressionRate(double jpegCompressionRate) {
		this.jpegCompressionRate = jpegCompressionRate;
	}

	/**
	 * @return 16階調のグレースケール画像で出力するかどうか
	 */
	public boolean isMonochrome16() {
		return monochrome16;
	}

	/**
	 * @param monochrome16
	 *            16階調のグレースケール画像で出力するかどうか
	 */
	public void setMonochrome16(boolean monochrome16) {
		this.monochrome16 = monochrome16;
	}

	/**
	 * @return ガンマ補正値
	 */
	public double getGamma() {
		return gamma;
	}

	/**
	 * @param gamma
	 *            ガンマ補正値
	 */
	public void setGamma(double gamma) {
		this.gamma = gamma;
	}

	/**
	 * @return 出力サイズ(幅と高さ)
	 */
	public int[] getSize() {
		return size;
	}

	/**
	 * @param width
	 *            出力サイズの幅
	 * @param height
	 *            出力サイズの高さ
	 */
	public void setSize(int width, int height) {
		this.size = new int[] { width, height };
	}

}
