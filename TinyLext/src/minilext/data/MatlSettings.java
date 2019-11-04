package minilext.data;

/** 貼り合わせ、多点測定で共有する設定項目 */
public final class MatlSettings {

	/**
	 * (自動3D時のみ有意)自動3Dのプレスキャンで特定されたLSM明るさ値を使用せず、
	 * MATL撮影開始時点のLSM明るさ値を使用して本スキャンを行うかどうか<br>
	 * 
	 * これは仕様としての完成度が低い。
	 * このフラグがtrueなら、プレスキャンはZ範囲の特定のためにだけ使用されることになるので、通常のプレスキャンよりはリトライ回数が減る(明るさの
	 */
	public boolean isIgnoreAutoExtendBrightness;

	/** 基準位置 */
	enum BasePosition {
		/***/
		TOP_LEFT,

		/***/
		TOP,

		/***/
		TOP_RIGHT,

		/***/
		LEFT,

		/***/
		CENTER,

		/***/
		RIGHT,

		/***/
		BOTTOM_LEFT,

		/***/
		BOTTOM,

		/***/
		BOTTOM_RIGHT
	}

	/** 基準位置 */
	public BasePosition basePosition;

	/** 重なり幅[%] */
	public int overlapPercentage;
}
