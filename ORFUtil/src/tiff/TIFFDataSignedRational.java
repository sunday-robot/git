package tiff;

import java.io.DataInput;
import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * 32bit符号あり整数の分子と分母
 */
public final class TIFFDataSignedRational extends TiffDataArrayType {
	/**
	 */
	static class Fraction {

		/** 分子 */
		private final int numerator;

		/** 分母 */
		private final int denominator;

		/**
		 * @param numerator
		 *            分子
		 * @param denominator
		 *            分母
		 */
		Fraction(int numerator, int denominator) {
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
	public TIFFDataSignedRational(RandomAccessFile raf, long pointer, int dataCount) throws IOException {
		super(pointer);
		values = new Fraction[dataCount];
		for (int i = 0; i < dataCount; i++) {
			int numerator = getS32(raf);
			int denominator = getS32(raf);
			values[i] = new Fraction(numerator, denominator);
		}
	}

	/**
	 * 
	 * @param di
	 *            :
	 * @return :
	 * @throws IOException
	 *             :
	 */
	private static int getS32(DataInput di) throws IOException {
		byte[] data = new byte[4];
		di.readFully(data);
		int r = (data[0] & 0xff) | ((data[1] & 0xff) << 8) | ((data[2] & 0xff) << 16) | ((data[3] & 0xff) << 24);
		return r;
	}

	@Override
	public TIFFDataType getTIFFDataType() {
		return TIFFDataType.SIGNED_RATIONAL;
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
