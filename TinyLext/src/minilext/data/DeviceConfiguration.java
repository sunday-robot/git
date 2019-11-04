package minilext.data;

import minilext.type.Lens;

/**
 * ハードウェア構成
 */
public class DeviceConfiguration {

	/** 対物レンズ構成(どの穴にどの製品がセットされているのか) */
	public final Lens[] lensList;

	/**
	 * XYステージの種類
	 */
	public enum StageType {
		/** 標準(100x100mm) */
		STANDARD,

		/** 中央精機製(300x300mmなど) */
		CHUO_SEIKI
	}

	/**
	 * XYステージの種類
	 */
	public StageType stageType = StageType.STANDARD;

	/**
	 * @param lensList
	 *            :
	 */
	public DeviceConfiguration(Lens[] lensList) {
		this.lensList = lensList.clone();
	}
}
