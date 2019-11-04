package tiff;

import java.io.DataInput;
import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 32bit符号なし整数の配列(64bitではない)
 */
public final class TIFFDataUnsignedLong extends TiffDataArrayType {
	/** */
	private long[] values;

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
	public TIFFDataUnsignedLong(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		values = new long[dataCount];
		for (int i = 0; i < dataCount; i++) {
			values[i] = getU32(raf);
		}
	}

	/**
	 * @param di
	 *            {@link DataInput}
	 * @return 符号なし32ビット整数
	 * @throws IOException
	 *             :
	 */
	private static long getU32(DataInput di) throws IOException {
		byte[] data = new byte[4];
		di.readFully(data);
		long r = (data[0] & 0xff) | ((data[1] & 0xff) << 8) | ((data[2] & 0xff) << 16) | ((data[3] & 0xff) << 24);
		return r;
	}

	/**
	 * @return :
	 */
	public long[] getValues() {
		return values;
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.UNSIGNED_LONG;
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
