public class Base64Test {

	public static void main(String[] args) {
		byte[] data = new byte[10];
		for (int i = 0; i < data.length; i++) {
			data[i] = (byte) (i & 0xff);
		}
		String s = encode(data);
		System.out.printf("encode result = [%s]\n", s);
		// s = encode2(data);
		// System.out.printf("encode result = [%s]\n", s);
	}

	// 変換表
	private static final String[] table = { "A", "B", "C", "D", "E", "F", "G",
			"H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
			"U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g",
			"h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
			"u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6",
			"7", "8", "9", "+", "/" };

	/**
	 * バイト配列をBASE64エンコードします。
	 * 
	 * @param bytes
	 *            エンコード対象のバイト配列
	 * @return エンコード後の文字列
	 */
	private static String encode(byte[] bytes) {

		// バイト配列をビットパターンに変換します。
		StringBuffer bitPattern = new StringBuffer();
		for (int i = 0; i < bytes.length; ++i) {
			int b = bytes[i];
			if (b < 0) {
				b += 256;
			}
			String tmp = Integer.toBinaryString(b);
			while (tmp.length() < 8) {
				tmp = "0" + tmp;
			}
			bitPattern.append(tmp);
		}

		// ビットパターンのビット数が6の倍数にするため、末尾に0を追加します。
		while (bitPattern.length() % 6 != 0) {
			bitPattern.append("0");
		}

		// 変換表を利用して、ビットパターンを4ビットずつ文字に変換します。
		StringBuffer encoded = new StringBuffer();
		for (int i = 0; i < bitPattern.length(); i += 6) {
			String tmp = bitPattern.substring(i, i + 6);
			int index = Integer.parseInt(tmp, 2);
			encoded.append(table[index]);
		}

		// 変換後の文字数を4の倍数にするため、末尾に=を追加します。
		while (encoded.length() % 4 != 0) {
			encoded.append("=");
		}

		return encoded.toString();
	}

	// /**
	// * バイト配列をBASE64エンコードします。
	// *
	// * @param bytes
	// * エンコード対象のバイト配列
	// * @return エンコード後の文字列
	// */
	// private static String encode2(byte[] bytes) {
	// StringBuffer encoded = new StringBuffer();
	//
	// for (int i = 2; i < bytes.length; i += 3) {
	// int b1 = bytes[i - 2] & 0xff;
	// int b2 = bytes[i - 1] & 0xff;
	// int b3 = bytes[i] & 0xff;
	// int c1 = b1 >> 2;
	// int c2 = ((b1 & 0x03) << 4) | (b2 >> 4);
	// int c3 = ((b2 & 0x0f) << 4) | (b3 >> 6);
	// int c4 = b3 & 0x3f;
	// String b = Integer.toBinaryString(b1 | 0x100) + "."
	// + Integer.toBinaryString(b2 | 0x100) + ","
	// + Integer.toBinaryString(b3 | 0x100);
	// String c = Integer.toBinaryString(c1 | 0x100) + "."
	// + Integer.toBinaryString(c2 | 0x100) + ","
	// + Integer.toBinaryString(c3 | 0x100) + ","
	// + Integer.toBinaryString(c4 | 0x100);
	// System.out.println(b);
	// System.out.println(c);
	//
	// encoded.append(table[c1]);
	// encoded.append(table[c2]);
	// encoded.append(table[c3]);
	// encoded.append(table[c4]);
	// }
	//
	// switch (bytes.length % 3) {
	// case 0:
	// break;
	// case 1:
	// encoded.append(table[bytes[bytes.length -1] & 0x3f]);
	// break;
	// case 2:
	// encoded.append(table[bytes[bytes.length -2] & 0x3f]);
	// encoded.append(table[(bytes[bytes.length -2] & 0x03) << 4) |
	// ((bytes[bytes.length - 1] & 0xf0)>> 4)]);
	// break;
	// }
	//
	// // バイト配列をビットパターンに変換します。
	// StringBuffer bitPattern = new StringBuffer();
	// for (int i = 0; i < bytes.length; ++i) {
	// int b = bytes[i];
	// if (b < 0) {
	// b += 256;
	// }
	// String tmp = Integer.toBinaryString(b);
	// while (tmp.length() < 8) {
	// tmp = "0" + tmp;
	// }
	// bitPattern.append(tmp);
	// }
	//
	// // ビットパターンのビット数が6の倍数にするため、末尾に0を追加します。
	// while (bitPattern.length() % 6 != 0) {
	// bitPattern.append("0");
	// }
	//
	// // 変換表を利用して、ビットパターンを4ビットずつ文字に変換します。
	// StringBuffer encoded = new StringBuffer();
	// for (int i = 0; i < bitPattern.length(); i += 6) {
	// String tmp = bitPattern.substring(i, i + 6);
	// int index = Integer.parseInt(tmp, 2);
	// encoded.append(table[index]);
	// }
	//
	// // 変換後の文字数を4の倍数にするため、末尾に=を追加します。
	// while (encoded.length() % 4 != 0) {
	// encoded.append("=");
	// }
	//
	// return encoded.toString();
	// }
}
