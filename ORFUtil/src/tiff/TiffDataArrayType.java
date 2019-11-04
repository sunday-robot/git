package tiff;

/**
 * 配列形式のTIFF Data
 */
public abstract class TiffDataArrayType extends TIFFData {
	/**
	 * @param pointer
	 *            データ開始位置(デバッグ用)
	 */
	protected TiffDataArrayType(long pointer) {
		super(pointer);
	}

	@Override
	public final String toString() {
		StringBuffer sb = new StringBuffer();
		sb.append(String.format("(@%08x)", getPointer()));
		if (getDataCount() > 200) {
			sb.append("(too many data)");
			return sb.toString();
		}
		sb.append(String.format("[%d]{", getDataCount()));
		for (int i = 0; i < getDataCount(); i++) {
			sb.append(String.format("%s, ", dataToString(i)));
		}
		if (getDataCount() > 0)
			sb.setLength(sb.length() - 2);
		sb.append("}");
		return sb.toString();
	}
}
