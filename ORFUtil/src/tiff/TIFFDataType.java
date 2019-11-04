package tiff;

import java.util.HashMap;
import java.util.Map;

/**
 * 
 */
public enum TIFFDataType {
	/** 1, 8bit unsigned integer */
	UNSIGNED_BYTE(1, 1),

	/** 6, 8bit signed integer */
	SIGNED_BTYE(6, 1),

	/** 3, 16bit unsigned integer */
	UNSIGNED_SHORT(3, 2),

	/** 8, 16bit signed integer */
	SIGNED_SHORT(8, 2),

	/** 4, 32bit unsigned integer */
	UNSIGNED_LONG(4, 4),

	/** 9, 32bit signed integer */
	SIGNED_LONG(9, 4),

	/** 11, 32bit real */
	FLOAT(11, 4),

	/** 12, 64bit real */
	DOUBLE(12, 8),

	/** 5 */
	UNSIGNED_RATIONAL(5, 8),

	/** 10 */
	SIGNED_RATIONAL(10, 8),

	/** value=2, length=1 */
	ASCII(2, 1),

	/** 7 */
	UNDEFINED(7, 1);

	/** */
	private static Map<Integer, TIFFDataType> map;

	static {
		map = new HashMap<Integer, TIFFDataType>();
		putMap(UNSIGNED_BYTE);
		putMap(SIGNED_BTYE);
		putMap(UNSIGNED_SHORT);
		putMap(SIGNED_SHORT);
		putMap(UNSIGNED_LONG);
		putMap(SIGNED_LONG);
		putMap(FLOAT);
		putMap(DOUBLE);
		putMap(UNSIGNED_RATIONAL);
		putMap(SIGNED_RATIONAL);
		putMap(ASCII);
		putMap(UNDEFINED);
	}

	/** */
	private int value;

	/** */
	private int size;

	/**
	 * @param value
	 *            :
	 * @param size
	 *            :
	 */
	TIFFDataType(int value, int size) {
		this.value = value;
		this.size = size;
	}

	/**
	 * @param value
	 *            :
	 * @return :
	 */
	public static TIFFDataType get(int value) {
		return map.get(value);
	}

	/**
	 * @param tiffDataType
	 *            :
	 */
	private static void putMap(TIFFDataType tiffDataType) {
		map.put(tiffDataType.value, tiffDataType);
	}

	/**
	 * @return :
	 */
	public int getValue() {
		return value;
	}

	/**
	 * @return バイト数
	 */
	public int getSize() {
		return size;
	}
}
