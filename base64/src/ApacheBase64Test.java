import org.apache.commons.codec.binary.Base64;

public class ApacheBase64Test {
	public static void main(String[] args) {
		byte[] data = new byte[1024 * 1024];
		for (int i = 0; i < data.length; i++) {
			data[i] = (byte) (i & 0xff);
		}
		// System.out.printf("original = %s\n", bytesToString(data));
		long t0;
		long t1;
		t0 = System.nanoTime();
		String encodedData = Base64.encodeBase64String(data);
		t1 = System.nanoTime();
		System.out.printf("encode time = %d ns\n", t1 - t0);
		// System.out.printf("encoded  = [%s]\n", encodedData);
		t0 = System.nanoTime();
		byte[] decodedData = Base64.decodeBase64(encodedData);
		t1 = System.nanoTime();
		System.out.printf("decode time = %d ns\n", t1 - t0);
		// System.out.printf("decoded  = %s\n", bytesToString(decodedData));
	}

	private static String bytesToString(byte[] array) {
		StringBuffer sb = new StringBuffer(String.format("%4d:[", array.length));
		for (int i = 0; i < array.length; i++) {
			sb.append(String.format("%02x,", array[i]));
		}
		sb.setCharAt(sb.length() - 1, ']');
		return sb.toString();
	}
}
