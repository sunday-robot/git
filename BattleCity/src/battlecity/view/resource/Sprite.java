package battlecity.view.resource;

import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;

import org.eclipse.swt.SWTException;
import org.eclipse.swt.graphics.Device;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Image;

/**
 * いわゆるスプライト。多分後で設計の大幅な見直しが必要になると思われる。
 */
public class Sprite {
	/** 画像データの配列 */
	private static final List<Image> IMAGES = new ArrayList<Image>();

	/**
	 * 画像データをロードする。
	 * 
	 * @param device
	 *            Device
	 * @param fileNameFormat
	 *            画像ファイルのパス名のフォーマット文字列(例:"c:/bg/bcty_%d.png")
	 */
	public static void load(Device device, String fileNameFormat) {
		int i;
		for (i = 0;; i++) {
			String fileName = String.format(fileNameFormat, i);
			Image image = loadImage(device, fileName);
			if (image == null) {
				break;
			}
			IMAGES.add(image);
		}
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

	/**
	 * スプライトを描く
	 * 
	 * @param gc
	 *            GC
	 * @param x
	 *            X
	 * @param y
	 *            Y
	 * @param index
	 *            スプライトのインデックス(0～)
	 */
	public static void draw(GC gc, int x, int y, int index) {
		Image image = IMAGES.get(index);
		gc.drawImage(image, x, y);
	}

}
