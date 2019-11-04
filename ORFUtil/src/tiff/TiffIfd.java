package tiff;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * TIFF IFD(Image File Directory)
 * 
 * TIFFファイルの構成要素。TIFF Tagのリストからなる
 */
public final class TiffIfd implements Iterable<TiffTag> {
	/** IFDの開始位置(デバッグ用) */
	private final long position;

	/**
	 * TIFF Tagのリスト
	 */
	private final List<TiffTag> tags;

	/**
	 * 次のTIFF IFDの位置(0は、次のTIFF IFDがないことを示す)
	 */
	private final long nextIfdPosition;

	/**
	 * @param position
	 *            開始位置(デバッグ用)
	 * @param tags
	 *            Tagのリスト
	 * @param nextIfdPosition
	 *            次のTIFF IFDの位置(0は、次のTIFF IFDがないことを示す)
	 */
	public TiffIfd(long position, List<TiffTag> tags, long nextIfdPosition) {
		this.position = position;
		this.tags = new ArrayList<>(tags.size());
		this.tags.addAll(tags);
		this.nextIfdPosition = nextIfdPosition;
	}

	@Override
	public Iterator<TiffTag> iterator() {
		return tags.listIterator();
	}

	@Override
	public String toString() {
		String s = String.format(
				"%08x(%10d): TIFF IFD(Image File Directory) number of tags = %d, next IFD Position = %08x", position,
				position, tags.size(), nextIfdPosition);
		return s;
	}

	/**
	 * @return IFDの開始位置(デバッグ用)
	 */
	public long getPosition() {
		return position;
	}

	/**
	 * @return 次のTIFF IFDの位置(次のTIFF IFDがない場合は0)
	 */
	public long getNextIfdPosition() {
		return nextIfdPosition;
	}

	/**
	 * @param tagType
	 *            タグの種類(u16)
	 * @return 指定されたタグの最初の一つ。なければnull。
	 */
	public TiffTag getTagByTagType(int tagType) {
		for (TiffTag tag : tags)
			if (tag.getTagType() == tagType)
				return tag;
		return null;
	}
}
