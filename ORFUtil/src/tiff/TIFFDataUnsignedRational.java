package tiff;

import java.io.DataInput;
import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 32bit符号なし整数の分子と分母
 */
public final class TIFFDataUnsignedRational extends TiffDataArrayType {
	/**
	 */
	static class Fraction {

		/** 分子 */
		private final long numerator;

		/** 分母 */
		private final long denominator;

		/**
		 * @param numerator
		 *            分子
		 * @param denominator
		 *            分母
		 */
		public Fraction(long numerator, long denominator) {
			this.numerator = numerator;
			this.denominator = denominator;
		}

		@Override
		public String toString() {
			return String.format("%d/%d", numerator, denominator);
		}
	}

	/**  */
	private Fraction[] values;

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
	public TIFFDataUnsignedRational(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		values = new Fraction[dataCount];
		for (int i = 0; i < dataCount; i++) {
			long numerator = getU32(raf);
			long denominator = getU32(raf);
			values[i] = new Fraction(numerator, denominator);
		}
	}

	/**
	 * @param di
	 *            {@link DataInput}
	 * @return long(0～2^32-1)
	 * @throws IOException
	 *             :
	 */
	private static long getU32(DataInput di) throws IOException {
		byte[] data = new byte[4];
		di.readFully(data);
		long r = (data[0] & 0xff) | ((data[1] & 0xff) << 8) | ((data[2] & 0xff) << 16) | ((data[3] & 0xff) << 24);
		return r;
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.UNSIGNED_RATIONAL;
	}

	@Override
	public int getDataCount() {
		return values.length;
	}

	@Override
	protected String dataToString(int index) {
		return values[index].toString();
	}
}
