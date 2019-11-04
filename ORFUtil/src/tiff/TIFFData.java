package tiff;

/**
 * 
 */
public abstract class TIFFData {
	/** データ開始位置(デバッグ用) */
	private final long pointer;

	/**
	 * @param pointer
	 *            データ開始位置(デバッグ用)
	 */
	protected TIFFData(long pointer) {
		this.pointer = pointer;
	}

	/**
	 * byte配列の指定個所のみを符号なし16ビット整数として取り出す。
	 * 
	 * @param bytes
	 *            byte配列
	 * @param index
	 *            配列のインデックス
	 * @return 符号なし16ビット整数
	 */
	public static int bytesToUnsignedShort(byte[] bytes, int index) {
		int r = (bytes[index] & 0xff) | ((bytes[index + 1] & 0xff) << 8);
		return r;
	}

	/**
	 * byte配列の1バイト目と2バイト目を符号なし16ビット整数として取り出す。
	 * 
	 * @param bytes
	 *            byte配列
	 * @return 符号なし16ビット整数
	 */
	public static int bytesToUnsignedShort(byte[] bytes) {
		return bytesToUnsignedShort(bytes, 0);
	}

	/**
	 * @param bytes
	 *            byte配列
	 * @param index
	 *            インデックス
	 * @return 符号なし32ビット整数
	 */
	public static long bytesToUnsignedLong(byte[] bytes, int index) {
		long r = (bytes[index] & 0xff) | ((bytes[index + 1] & 0xff) << 8) | ((bytes[index + 2] & 0xff) << 16)
				| ((bytes[index + 3] & 0xff) << 24);
		return r;
	}

	/**
	 * @param bytes
	 *            byte配列
	 * @param index
	 *            インデックス
	 * @return 符号あり32ビット整数
	 */
	public static int bytesSsignedLong(byte[] bytes, int index) {
		int r = (bytes[index] & 0xff) | ((bytes[index + 1] & 0xff) << 8) | ((bytes[index + 2] & 0xff) << 16)
				| ((bytes[index + 3] & 0xff) << 24);
		return r;
	}

	/**
	 * @param bytes
	 *            byte配列
	 * @return 符号なし32ビット整数
	 */
	public static long bytesToUnsignedLong(byte[] bytes) {
		return bytesToUnsignedLong(bytes, 0);
	}

	/**
	 * @return TIFFデータ型
	 */
	public abstract TIFFDataType getTIFFDataType();

	/**
	 * @return データの個数
	 */
	public abstract int getDataCount();

	/**
	 * 指定されたインデックスのデータを文字列化する。(toString()メソッドのためのもの)
	 * 
	 * @param index
	 *            インデックス
	 * @return 文字列
	 */
	protected abstract String dataToString(int index);

	/**
	 * @return データ開始位置(デバッグ用)
	 */
	public final long getPointer() {
		return pointer;
	}
}
