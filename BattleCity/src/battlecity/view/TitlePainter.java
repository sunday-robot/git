package battlecity.view;

import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.graphics.GC;

import battlecity.view.resource.BG;
import battlecity.view.resource.Font;
import battlecity.view.resource.Sprite;

/**
 * タイトル画面を描くもの
 */
public final class TitlePainter implements PaintListener {
	@Override
	public void paintControl(PaintEvent e) {
		int player1HighScore;
		int player2HighScore;
		int highScore;

		player1HighScore = 0;
		player2HighScore = -1;
		highScore = 2000;

		GC gc = e.gc;
		String s;
		s = String.format("I-%5d0", player1HighScore);
		Font.drawString(gc, 16 * 2, 16 * 3, s);

		s = String.format("HI-%5d0", highScore);
		Font.drawString(gc, 16 * 11, 16 * 3, s);

		if (player2HighScore > 0) {
			s = String.format("II-%5d0", player2HighScore);
			Font.drawString(gc, 16 * 20, 16 * 3, s);
		}

		Font.drawString(gc, 16 * 11, 16 * 17, "1 PLAYER");
		Font.drawString(gc, 16 * 11, 16 * 19, "2 PLAYERS");
		Font.drawString(gc, 16 * 11, 16 * 21, "CONSTRUCTION");
		Font.drawString(gc, 16 * 11, 16 * 23, "(namcot)");
		Font.drawString(gc, 16 * 4, 16 * 25, "c 1980 1985 NAMCO LTD.");
		Font.drawString(gc, 16 * 6, 16 * 27, "ALL RIGHT RESERVED");

		// レンガのBGを使用した"BATTLE CITY"
		drawBannerWidthRengaBG(gc, 4, 6, bBanner);
		drawBannerWidthRengaBG(gc, 8, 6, aBanner);
		drawBannerWidthRengaBG(gc, 12, 6, tBanner);
		drawBannerWidthRengaBG(gc, 16, 6, tBanner);
		drawBannerWidthRengaBG(gc, 20, 6, lBanner);
		drawBannerWidthRengaBG(gc, 24, 6, eBanner);
		drawBannerWidthRengaBG(gc, 8, 11, cBanner);
		drawBannerWidthRengaBG(gc, 12, 11, iBanner);
		drawBannerWidthRengaBG(gc, 16, 11, tBanner);
		drawBannerWidthRengaBG(gc, 20, 11, yBanner);

		// カーソル役の戦車
		Sprite.draw(gc, 128, 264, 1);
		Sprite.draw(gc, 128, 296, 1);
		Sprite.draw(gc, 128, 328, 1);
	}

	/** A */
	private static byte[] aBanner = { (byte) 0b00111000, (byte) 0b01101100, (byte) 0b11000110, (byte) 0b11000110,
			(byte) 0b11111110, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b00000000 };
	/** B */
	private static byte[] bBanner = { (byte) 0b11111100, (byte) 0b11000110, (byte) 0b11000110, (byte) 0b11111100,
			(byte) 0b11000110, (byte) 0b11000110, (byte) 0b11111100, (byte) 0b00000000 };
	/** C */
	private static byte[] cBanner = { (byte) 0b00111100, (byte) 0b01100110, (byte) 0b11000000, (byte) 0b11000000,
			(byte) 0b11000000, (byte) 0b01100110, (byte) 0b00111100, (byte) 0b00000000 };
	/** E */
	private static byte[] eBanner = { (byte) 0b11111100, (byte) 0b11000000, (byte) 0b11000000, (byte) 0b11111000,
			(byte) 0b11000000, (byte) 0b11000000, (byte) 0b11111100, (byte) 0b00000000 };
	/** I */
	private static byte[] iBanner = { (byte) 0b11111100, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000,
			(byte) 0b00110000, (byte) 0b00110000, (byte) 0b11111100, (byte) 0b00000000 };
	/** L */
	private static byte[] lBanner = { (byte) 0b11000000, (byte) 0b11000000, (byte) 0b11000000, (byte) 0b11000000,
			(byte) 0b11000000, (byte) 0b11000000, (byte) 0b11111100, (byte) 0b00000000 };
	/** T */
	private static byte[] tBanner = { (byte) 0b11111100, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000,
			(byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00000000 };
	/** Y */
	private static byte[] yBanner = { (byte) 0b11001100, (byte) 0b11001100, (byte) 0b11001100, (byte) 0b01111000,
			(byte) 0b00110000, (byte) 0b00110000, (byte) 0b00110000, (byte) 0b00000000 };

	private static void drawBannerWidthRengaBG(GC gc, int x, int y, byte[] data) {
		for (int yy = 0; yy < 8; yy += 2) {
			int patNo;
			patNo = ((data[yy] >> 6) & 0b11) | ((data[yy + 1] >> 4) & 0b1100);
			BG.draw(gc, x, y + yy / 2, patNoToIndex[patNo]);
			patNo = ((data[yy] >> 4) & 0b11) | ((data[yy + 1] >> 2) & 0b1100);
			BG.draw(gc, x + 1, y + yy / 2, patNoToIndex[patNo]);
			patNo = ((data[yy] >> 2) & 0b11) | ((data[yy + 1]) & 0b1100);
			BG.draw(gc, x + 2, y + yy / 2, patNoToIndex[patNo]);
			patNo = ((data[yy]) & 0b11) | ((data[yy + 1] << 2) & 0b1100);
			BG.draw(gc, x + 3, y + yy / 2, patNoToIndex[patNo]);
		}
	}

	private static int[] patNoToIndex = { 0b0000, // 0b0000
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
			0b1111,// 0b1111
	};

	/**
	 * 1Pのハイスコアを表示する。
	 * 
	 * @param gc
	 *            GC
	 * @param score
	 *            ハイスコア
	 */
	private void draw1pHighScore(GC gc, int score) {
	}
}
