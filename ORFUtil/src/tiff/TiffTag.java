package tiff;

import static tiff.TiffUtil.getDataTypeName;

/**
 * TIFFのタグ。<br>
 * 以下の情報から成る(データそのものは含まず、代わりにその開始位置を持っていることに注意)<br>
 * タグの種類(u16)<br>
 * データの型(u16)<br>
 * データの個数(u32)<br>
 * データの開始位置(u32)<br>
 */
public final class TiffTag {
	/** タグの位置(u32)デバッグ用) */
	private final long position;

	/** タグの種類(u16) */
	private final int tagType;

	/** データの型(u16) */
	private final int dataType;

	/** データの個数(u32) */
	private final int dataCount;

	/** データの開始位置(u32) */
	private final long dataPosition;

	/**
	 * @param position
	 *            タグの位置(デバッグ用)
	 * @param tagType
	 *            タグの種類
	 * @param dataType
	 *            データの型
	 * @param dataCount
	 *            データの個数
	 * @param dataPosition
	 *            データの開始位置
	 */
	public TiffTag(long position, int tagType, int dataType, int dataCount, long dataPosition) {
		this.position = position;
		this.tagType = tagType;
		this.dataType = dataType;
		this.dataCount = dataCount;
		this.dataPosition = dataPosition;
	}

	/**
	 * @return タグの位置(デバッグ用)
	 */
	public long getPosition() {
		return position;
	}

	/**
	 * @return タグの種類
	 */
	public int getTagType() {
		return tagType;
	}

	/**
	 * @return データの型
	 */
	public int getDataType() {
		return dataType;
	}

	/**
	 * @return データの個数
	 */
	public int getDataCount() {
		return dataCount;
	}

	/**
	 * @return データの開始位置
	 */
	public long getDataPosition() {
		return dataPosition;
	}

	@Override
	public String toString() {
		return String.format("%08x(%10d): %5d %s[%d]@%08x", position, position, tagType, getDataTypeName(dataType),
				dataCount, dataPosition);
	}
}
