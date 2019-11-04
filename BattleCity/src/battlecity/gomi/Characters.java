package battlecity.gomi;

import org.eclipse.swt.graphics.Device;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Image;

/**
 * フォントデータかな???
 */
public class Characters {
	/** フォントデータ */
	private Image[] fonts;

	/**
	 * コンストラクタ
	 * 
	 * @param device
	 *            Device
	 * @param fileNameFormat
	 *            String
	 */
	public Characters(Device device, String fileNameFormat) {
		fonts = new Image[256];
		int i;
		for (i = 0; i < 256; i++) {
			String fileName = String.format(fileNameFormat, i);
			fonts[i] = new Image(device, fileName);
		}
	}

	/**
	 * 文字列を描く
	 * 
	 * @param gc
	 *            GC
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param s
	 *            文字列
	 */
	public final void drawString(GC gc, int x, int y, String s) {
		int i;
		for (i = 0; i < s.length(); i++) {
			int charCode = s.charAt(i);
			gc.drawImage(fonts[charCode], x, y);
			x += 16;
		}
	}
}
