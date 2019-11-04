package tiff;

import java.io.DataInput;
import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 重要な注意事項<br>
 * リトルエンディアンしか扱えない。
 */
public final class TiffUtil {
	/** */
	private TiffUtil() {
	}

	/**
	 * @param di
	 *            {@link DataInput}
	 * @return 0～2^16-1
	 * @throws IOException
	 *             :
	 */
	public static int getU16(DataInput di) throws IOException {
		byte[] data = new byte[2];
		di.readFully(data);
		int r = (data[0] & 0xff) | ((data[1] & 0xff) << 8);
		return r;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param position
	 *            データの開始位置
	 * @return 0～2^16-1
	 * @throws IOException
	 *             :
	 */
	public static int getU16(RandomAccessFile raf, long position) throws IOException {
		raf.seek(position);
		return getU16(raf);
	}

	/**
	 * @param di
	 *            {@link DataInput}
	 * @return 0～2^32-1
	 * @throws IOException
	 *             :
	 */
	public static long getU32(DataInput di) throws IOException {
		byte[] data = new byte[4];
		di.readFully(data);
		long r = (data[0] & 0xff) | ((data[1] & 0xff) << 8) | ((data[2] & 0xff) << 16) | ((data[3] & 0xff) << 24);
		return r;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param position
	 *            データの開始位置
	 * @return 0～2^32-1
	 * @throws IOException
	 *             :
	 */
	public static long getU32(RandomAccessFile raf, long position) throws IOException {
		raf.seek(position);
		return getU32(raf);
	}

	/**
	 * @param dataType
	 *            データの型
	 * @return データの型の名前(TIFFで定義されている型ではない場合、"?(" + データの型 + ")"を返す。
	 */
	public static String getDataTypeName(int dataType) {
		String dataTypeName;
		TIFFDataType dt = TIFFDataType.get(dataType);
		if (dt == null)
			dataTypeName = "?(" + dataType + ")";
		else
			dataTypeName = dt.toString();
		return dataTypeName;
	}
}
