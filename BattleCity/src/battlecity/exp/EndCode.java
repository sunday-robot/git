package battlecity.exp;

/**
 * ステージの終了コード
 */
public enum EndCode {
	/** ステージをクリアした */
	STAGE_CLEAR,
	/** ゲームオーバーでステージが終了した */
	GAME_OVER,
	/** ユーザーが終了指示をした */
	EXIT_GAME,
	/** デモが終了した */
	DEMO_END
}
