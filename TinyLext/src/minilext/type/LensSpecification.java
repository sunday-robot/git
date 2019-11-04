package minilext.type;

/**
 * (Immutable)<br>
 * 対物レンズの仕様
 */
public final class LensSpecification {

	/** レンズの型番 */
	public final String modelNumber;

	/** 正式名称 */
	public final String name;

	/** 画面表示用の短い名前 */
	public final String displayName;

	/** 倍率*10(倍率2.5倍の場合、25がセットされる) */
	public final Magnification magnification;

	/** 作動距離 */
	public final int workingDistanceNM;

	/**
	 * @param modelNumber
	 *            :
	 * @param name
	 *            :
	 * @param displayName
	 *            :
	 * @param magnification
	 *            :
	 * @param workingDistanceNM
	 *            :
	 */
	public LensSpecification(String modelNumber, String name, String displayName,
			Magnification magnification, int workingDistanceNM) {
		this.modelNumber = modelNumber;
		this.name = name;
		this.displayName = displayName;
		this.magnification = magnification;
		this.workingDistanceNM = workingDistanceNM;
	}
}
