package tiff;

import java.util.ArrayList;
import java.util.List;

/**
 * TIFFファイルの内容(以下の三つ)を保持するもの<br>
 * バイトオーダー<br>
 * バージョン<br>
 * IFDのリスト<br>
 */
public final class TiffFile {
	/** バイトオーダー */
	private final int byteOrder;

	/** バージョン(実際にはTIFFの派生バージョンが多く、どの派生なのかを示すものらしい) */
	private final int version;

	/** IFDのリスト */
	private final List<TiffIfd> ifds;

	/**
	 * @param byteOrder
	 *            バイトオーダー(0x4949("II"、リトルエンディアン) or 0x4d4d("MM"、ビッグエンディアン)
	 * @param version
	 *            バージョン(u16、実際にはバージョンというよりは、TIFFを基盤とした様々なファイルフォーマットがあり、
	 *            どのファイルフォーマットなのかを示すものとして使われているらしい)
	 * @param ifds
	 *            IFDのリスト
	 */
	public TiffFile(int byteOrder, int version, List<TiffIfd> ifds) {
		this.byteOrder = byteOrder;
		this.version = version;
		this.ifds = new ArrayList<>(ifds);
	}

	/**
	 * @return バイトオーダー
	 */
	public int getByteOrder() {
		return byteOrder;
	}

	/**
	 * @return バージョン
	 */
	public int getVersion() {
		return version;
	}

	/**
	 * @return IFDのリスト
	 */
	public List<TiffIfd> getIfds() {
		return ifds;
	}
}
