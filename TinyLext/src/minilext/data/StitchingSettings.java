package minilext.data;

/**
 * 貼り合わせ撮影設定(多点測定の貼り合わせ設定とは別)
 */
public class StitchingSettings {

	/** 基本形状 */
	enum BaseForm {
		/** 矩形 */
		RECTANGLE,

		/** 円 */
		CIRCLE,

		/** 同心円 */
		DONUTS,
	}

	/** 個別画像保存を行うかどうか */
	public boolean isSavePerArea;
}
