package tiff;

import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * {@link TIFFDataType#ASCII}
 */
public final class TIFFDataASCII extends TIFFData {
	/** */
	private String value;

	/**
	 * @param pointer
	 *            データ開始位置(デバッグ用)
	 * @param bytes
	 *            文字列
	 */
	public TIFFDataASCII(long pointer, byte[] bytes) {
		super(pointer);
		value = bytesToString(bytes);
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
	public TIFFDataASCII(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		byte[] bytes = new byte[dataCount];
		raf.readFully(bytes);
		value = bytesToString(bytes);
	}

	/**
	 * @return 文字列
	 */
	public String getValue() {
		return value;
	}

	/**
	 * @param bytes
	 *            byte配列
	 * @return 文字列
	 */
	private static String bytesToString(byte[] bytes) {
		int index;
		for (index = bytes.length - 1; index >= 0; index--)
			if (bytes[index] != 0)
				break;
		return new String(bytes, 0, index + 1);
	}

	@Override
	public String toString() {
		return String.format("(@%08x)\"%s\"", getPointer(), value);
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.ASCII;
	}

	@Override
	public int getDataCount() {
		return 0;
	}

	@Override
	protected String dataToString(int index) {
		return null;
	}

}
