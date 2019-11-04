package tiff;

import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 
 */
public final class TIFFDataUndefined extends TiffDataArrayType {
	/** データ */
	private byte[] values;

	/**
	 * @param pointer
	 *            データ開始位置(デバッグ用)
	 * @param bytes
	 *            バイト配列
	 */
	public TIFFDataUndefined(long pointer, byte[] bytes) {
		super(pointer);
		this.values = bytes;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param pointer
	 *            データ開始位置(デバッグ用)
	 * @param dataCount
	 *            データ数
	 * @throws IOException
	 *             :
	 */
	public TIFFDataUndefined(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		values = new byte[dataCount];
		raf.readFully(values);
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.UNDEFINED;
	}

	@Override
	public int getDataCount() {
		return values.length;
	}

	@Override
	protected String dataToString(int index) {
		return String.format("%02X", values[index]);
	}
}
