package tiff;

import java.io.DataInput;
import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 16bit符号なし整数の配列
 */
public final class TIFFDataUnsignedShort extends TiffDataArrayType {
	/** */
	private int[] values;

	/**
	 * @param pointer
	 *            データ開始位置(デバッグ用)
	 * @param bytes
	 *            :
	 */
	public TIFFDataUnsignedShort(long pointer, byte[] bytes) {
		super(pointer);
		int count = bytes.length / 2;
		values = new int[count];
		for (int i = 0; i < count; i += 2) {
			int r = (bytes[i * 2] & 0xff) | ((bytes[i * 2 + 1] & 0xff) << 8);
			values[i] = r;
		}
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
	public TIFFDataUnsignedShort(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		values = new int[dataCount];
		for (int i = 0; i < dataCount; i++) {
			values[i] = getU16(raf);
		}
	}

	/**
	 * @return :
	 */
	public int[] getValues() {
		return values;
	}

	/**
	 * @param di
	 *            {@link DataInput}
	 * @return int
	 * @throws IOException
	 *             :
	 */
	private static int getU16(DataInput di) throws IOException {
		byte[] data = new byte[2];
		di.readFully(data);
		int r = (data[0] & 0xff) | ((data[1] & 0xff) << 8);
		return r;
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.UNSIGNED_SHORT;
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
