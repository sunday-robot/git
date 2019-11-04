package battlecity.view.resource;

import java.io.FileNotFoundException;

import org.eclipse.swt.SWTException;
import org.eclipse.swt.graphics.Color;
import org.eclipse.swt.graphics.Device;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Image;

/**
 * 文字描画を行うもの。
 * 
 * 本来は、色を描画時に指定できなければならないが、drawImageで文字を描く方法では無理らしい。
 * あらかじめ色付きの文字の画像データを用意すればよいが、馬鹿馬鹿しい。 これ以上SWTで追究する価値があるとは思えないので、諦めた。
 */
public final class Font {
	/** フォントデータ (fontではなく、もっと適切な単語があるような気がする。) */
	private static final Image[] FONT_IMAGES = new Image[256];

	/***/
	private Font() {
	}

	/**
	 * 文字の画像データをロードする。
	 * 
	 * @param device
	 *            Device
	 * @param fileNameFormat
	 *            画像ファイルのパス名のフォーマット文字列(例:"c:/font/font_%d.png")
	 */
	public static void load(Device device, String fileNameFormat) {
		int i;
		for (i = 0; i < 256; i++) {
			String fileName = String.format(fileNameFormat, i);
			FONT_IMAGES[i] = loadImage(device, fileName);
		}
	}

	/**
	 * 文字列を描く
	 * 
	 * @param gc
	 *            {@link GC}
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param s
	 *            文字列
	 */
	public static void drawString(GC gc, int x, int y, String s) {
		int i;
		for (i = 0; i < s.length(); i++) {
			int charCode = s.charAt(i);
			gc.drawImage(FONT_IMAGES[charCode], x, y);
			x += 16;
		}
	}

	/**
	 * 文字列を描く。(色が引数で指定できるが、未対応である)
	 * 
	 * @param gc
	 *            {@link GC}
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param s
	 *            文字列
	 * @param color
	 *            {@link Color}
	 */
	public static void drawString(GC gc, int x, int y, String s, Color color) {
		drawString(gc, x, y, s);
	}

	/**
	 * 画像ファイルをロードして、Imageを生成する。
	 * Imageのコンストラクタとの相違点は、ファイルがない場合にSWTExceptionを投げずに、nullを返すということのみ。
	 * 
	 * @param device
	 *            Device
	 * @param path
	 *            画像ファイルのパス名
	 * @return Image(画像ファイルがない場合はnull)
	 */
	private static Image loadImage(Device device, String path) {
		try {
			return new Image(device, path);
		} catch (SWTException e) {
			if (e.throwable instanceof FileNotFoundException) {
				return null;
			}
			throw e;
		}
	}

}
