package app.sonyreader;

import java.awt.Point;
import java.awt.image.BufferedImage;

import lib.imageoperator.Resizer;

/**
 * @author akiyama
 */
public class ResizerForSonyReader {
    /**
     * Sony Readerの画面サイズ<br>
     * （正確にはSony Readerのコンテンツ表示領域のサイズで、余白の分だけ画面サイズ(600x800)より少し小さい）
     */
    private static final Point SONY_READER_SIZE = new Point(584, 754);

    /**
     * 指定された画像をSony Reader用に変換(リサイズなど)した画像を返す
     * 
     * @param image
     *            変換前の画像
     * @param keepAspectRatio
     *            縦横比を維持するかどうか（falseの場合、SonyReaderの画面と同じサイズにする。）
     * @return 変換後の画像
     */
    public static BufferedImage execute(BufferedImage image,
	    boolean keepAspectRatio) {
	Point newSize;
	if (keepAspectRatio)
	    newSize = getJustSize(image.getWidth(), image.getHeight());
	else
	    newSize = SONY_READER_SIZE;
	BufferedImage destImage = Resizer.execute(image, newSize.x, newSize.y);
	return destImage;
    }

    /**
     * 原画像の縦横比を変えないで、Sony Reader用の幅あるいは高さが丁度よい画像サイズを返す。
     * 
     * @param width
     *            原画像の幅(画素数)
     * @param height
     *            原画像の高さ(画素数)
     * @return Sony Readerに丁度よい画像サイズ
     */
    private static Point getJustSize(int width, int height) {
	if (width * SONY_READER_SIZE.y > SONY_READER_SIZE.x * height) {
	    // Sony Readerに比べ、横長の画像の場合、高さを自動調整する
	    int h = SONY_READER_SIZE.x * height / width;
	    return new Point(SONY_READER_SIZE.x, h);
	} else {
	    // Sony Readerに比べ、縦長の画像の場合、幅を自動調整する
	    int w = SONY_READER_SIZE.y * width / height;
	    return new Point(w, SONY_READER_SIZE.y);
	}
    }
}
