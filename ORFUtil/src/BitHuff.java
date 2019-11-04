
/**
 * 
 */
public final class BitHuff {
	/** よくわからない */
	private static int[] huffTable;

	/** データ */
	private byte[] data;

	/** データの現在位置(バイト単位、0～data.length-1) */
	private int byteIndex;

	/** データの現在位置(ビット単位、0～7) */
	private int bitIndex;

	// private long bitBuffer = 0; // 32個のbitのバッファ。
	// private int bitBufferLength = 0;// bitBufferの長さ

	// b7 b6 b5 b4 b3 b2 b1 b0 | b7 b6 b5 b4 b3 b2 b1 b0 |

	static {
		huffTable = new int[4096];
		huffTable[0] = 0xc0c;
		int n = 1;
		for (int i = 12; i > 0; i--)
			for (int c = 0; c < 2048 >> i; c++)
				huffTable[n++] = (i + 1) << 8 | i;
	}

	/**
	 * @param data
	 *            データ
	 */
	public BitHuff(byte[] data) {
		this.data = data;
		byteIndex = 0;
	}

	/**
	 * 指定ビット数消費する(=ビットポインターを指定ビット数分進める)。
	 * 
	 * @param bitCount
	 *            ビット数
	 */
	private void consumeBits(int bitCount) {
		int bi = bitIndex + bitCount;
		bitIndex = bi & 7;
		byteIndex += (bi >> 3);
	}

	/**
	 * 指定されたビット数のデータを取得し、返す。
	 * 
	 * @param bitCount
	 *            ビット数(最大32)
	 * @return データ
	 */
	public int getBits(int bitCount) {
		int c = fetchBits(bitCount);
		consumeBits(bitCount);
		return c;
	}

	/**
	 * 試しに指定されたビット数のデータを取得し、返す。(getBits()と違い、ポインターは進めない。)
	 * 
	 * @param bitCount
	 *            ビット数(最大32)
	 * @return データ
	 */
	private int fetchBits(int bitCount) {
		if (bitCount <= 8 - bitIndex) {
			// 現在のバイト位置にすべて収まっている場合
			return ((data[byteIndex] << bitIndex) & 0xff) >> (8 - (bitIndex + bitCount));
		}

		int c0 = ((data[byteIndex] << bitIndex) & 0xff) >> bitIndex;
		if (bitCount <= 16 - bitIndex) {
			// 2バイト目までで足りる場合
			c0 <<= (bitCount + bitIndex - 8);
			int c1 = data[byteIndex + 1] >> (16 - (bitCount + bitIndex));
			return c0 | c1;
		}
		int c1 = data[byteIndex + 1];
		bitCount -= (8 - bitIndex);
		if (bitCount <= 8) {
			// 3バイト目までで足りる場合
			c0 <<= (16 - bitCount);
			c1 <<= (8 - bitCount);
			int c2 = data[byteIndex + 2] >> (8 - bitCount);
			return c0 | c1 | c2;
		}
		return 0;
	}

	public int getbithuff(int bitCount) {
		int c = fetchBits(bitCount);
		consumeBits(huffTable[c] >> 8);
		return huffTable[c];
	}

	public static class SignAndLow {
		public int sign;
		public int low;
	}

	public SignAndLow getSignAndLow() {
		int b3 = getBits(3);
		SignAndLow sl = new SignAndLow();
		sl.sign = b3 >> 2;
		sl.low = b3 & 3;
		return sl;
	}

}
