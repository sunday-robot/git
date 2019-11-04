package battlecity.view.resource;

import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;

import org.eclipse.swt.SWTException;
import org.eclipse.swt.graphics.Device;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Image;

/**
 * ゲームの背景などに使用されるBG(Background Graphicsの略?)の描画を行うもの。
 */
public final class BG {
	/** 背景画像のリスト */
	private static final List<Image> IMAGES = new ArrayList<Image>();

	/** */
	private BG() {
	}

	/**
	 * 画像データをロードする。
	 * 
	 * @param device
	 *            Device
	 * @param fileNameFormat
	 *            画像ファイルのパス名のフォーマット文字列(例:"c:/bg/bcty_%d.png")
	 */
	public static void load(Device device, String fileNameFormat) {
		for (int i = 0;; i++) {
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
	 * BGを描く
	 * 
	 * @param gc
	 *            GC
	 * @param x
	 *            X(セル座標)
	 * @param y
	 *            Y(セル座標)
	 * @param index
	 *            BGのインデックス(0～)
	 */
	public static void draw(GC gc, int x, int y, int index) {
		gc.drawImage(IMAGES.get(index), x * 16, y * 14);
	}
}
