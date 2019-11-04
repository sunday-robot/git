package battlecity.view;

import java.util.HashMap;
import java.util.Map;

import org.eclipse.swt.graphics.GC;

import battlecity.view.resource.BG;

/**
 * レンガのBGを使用してバナーを描くもの
 */
public final class Banner {
	/** フォントデータ */
	static final Map<Character, byte[]> FONT_DATA;

	/**  */
	private static final int[] PAT_NO_TO_INDEX = { //
			0b0000, // 0b0000
			0b0010, // 0b0001
			0b0001, // 0b0010
			0b0011, // 0b0011
			0b1000, // 0b0100
			0b1010, // 0b0101
			0b1001, // 0b0110
			0b1011, // 0b0111
			0b0100, // 0b1000
			0b0110, // 0b1001
			0b0101, // 0b1010
			0b0111, // 0b1011
			0b1100, // 0b1100
			0b1110, // 0b1101
			0b1101, // 0b1110
			0b1111, // 0b1111
	};

	/***/
	private Banner() {
	}

	static {
		FONT_DATA = new HashMap<>();
		FONT_DATA.put('A', new byte[] { (byte) 0b00111000, (byte) 0b01101100, (byte) 0b11000110, (byte) 0b11000110,
				(byte) 0b11111110, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b00000000 });
		FONT_DATA.put('B', new byte[] { (byte) 0b11111100, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b11111100,
				(byte) 0b11000110, (byte) 0b11000110, (byte) 0b11111100, (byte) 0b00000000 });
		FONT_DATA.put('C', new byte[] { (byte) 0b00111100, (byte) 0b01100110, (byte) 0b11000000, (byte) 0b11000000,
				(byte) 0b11000000, (byte) 0b01100110, (byte) 0b00111100, (byte) 0b00000000 });
		FONT_DATA.put('E', new byte[] { (byte) 0b11111100, (byte) 0b11000000, (byte) 0b11000000, (byte) 0b11111000,
				(byte) 0b11000000, (byte) 0b11000000, (byte) 0b11111100, (byte) 0b00000000 });
		FONT_DATA.put('G', new byte[] { (byte) 0b00111110, (byte) 0b01100000, (byte) 0b11000000, (byte) 0b11001110,
				(byte) 0b11000110, (byte) 0b01100110, (byte) 0b00111110, (byte) 0b00000000 });
		FONT_DATA.put('I', new byte[] { (byte) 0b11111100, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000,
				(byte) 0b00110000, (byte) 0b00110000, (byte) 0b11111100, (byte) 0b00000000 });
		FONT_DATA.put('L', new byte[] { (byte) 0b11000000, (byte) 0b11000000, (byte) 0b11000000, (byte) 0b11000000,
				(byte) 0b11000000, (byte) 0b11000000, (byte) 0b11111100, (byte) 0b00000000 });
		FONT_DATA.put('M', new byte[] { (byte) 0b11000110, (byte) 0b11101110, (byte) 0b11111110, (byte) 0b11111110,
				(byte) 0b11010110, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b00000000 });
		FONT_DATA.put('O', new byte[] { (byte) 0b01111100, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b11000110,
				(byte) 0b11000110, (byte) 0b11000110, (byte) 0b01111100, (byte) 0b00000000 });
		FONT_DATA.put('R', new byte[] { (byte) 0b11111100, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b11001110,
				(byte) 0b11111000, (byte) 0b11011100, (byte) 0b11001110, (byte) 0b00000000 });
		FONT_DATA.put('T', new byte[] { (byte) 0b11111100, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000,
				(byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00000000 });
		FONT_DATA.put('V', new byte[] { (byte) 0b11000110, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b11101110,
				(byte) 0b01111100, (byte) 0b00111000, (byte) 0b00010000, (byte) 0b00000000 });
		FONT_DATA.put('Y', new byte[] { (byte) 0b11001100, (byte) 0b11001100, (byte) 0b11001100, (byte) 0b01111000,
				(byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00000000 });
	}

	/**
	 * 指定位置にバナーを描く
	 * 
	 * @param gc
	 *            GC
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param text
	 *            文字列
	 */
	public static void draw(GC gc, int x, int y, String text) {
		for (int i = 0; i < text.length(); i++) {
			drawCharacter(gc, x + i * 4, y, text.charAt(i));
		}
	}

	/**
	 * バナー文字を1文字描く
	 * 
	 * @param gc
	 *            GC
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param c
	 *            文字
	 */
	private static void drawCharacter(GC gc, int x, int y, char c) {
		byte[] data = FONT_DATA.get(c);
		for (int yy = 0; yy < 8; yy += 2) {
			int patNo;
			patNo = ((data[yy] >> 6) & 0b11) | ((data[yy + 1] >> 4) & 0b1100);
			BG.draw(gc, x, y + yy / 2, PAT_NO_TO_INDEX[patNo]);
			patNo = ((data[yy] >> 4) & 0b11) | ((data[yy + 1] >> 2) & 0b1100);
			BG.draw(gc, x + 1, y + yy / 2, PAT_NO_TO_INDEX[patNo]);
			patNo = ((data[yy] >> 2) & 0b11) | ((data[yy + 1]) & 0b1100);
			BG.draw(gc, x + 2, y + yy / 2, PAT_NO_TO_INDEX[patNo]);
			patNo = ((data[yy]) & 0b11) | ((data[yy + 1] << 2) & 0b1100);
			BG.draw(gc, x + 3, y + yy / 2, PAT_NO_TO_INDEX[patNo]);
		}
	}
}
