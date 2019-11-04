package minilext.data;

/**
 * アプリケーションの状態
 */
public enum ApplicationState {
	/** 起動中 */
	STARTING,

	/** 終了中 */
	TERMINATING,

	/** IDLE */
	IDLE,

	/** 撮影中 */
	ACQUISITIONING,

	/** 撮影結果画像表示中 */
	RESULT_VIEWING,
}
