package tiff;

import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 
 */
public final class TIFFDataUnsignedByte extends TiffDataArrayType {
	/** データ */
	private byte[] values;

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
	public TIFFDataUnsignedByte(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		values = new byte[dataCount];
		raf.readFully(values);
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.UNSIGNED_BYTE;
	}

	@Override
	public int getDataCount() {
		return values.length;
	}

	@Override
	protected String dataToString(int index) {
		return String.format("%d", values[index]);
	}
}
