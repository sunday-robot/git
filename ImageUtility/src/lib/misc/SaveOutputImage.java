package lib.misc;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

/**
 */
public final class SaveOutputImage {
	/**
	 */
	private SaveOutputImage() {
	}

	/**
	 * 指定された画像を、outフォルダを作成し、同じファイル名でセーブする。
	 * 
	 * @param image
	 *            出力する画像データ
	 * @param originalFileName
	 *            入力画像ファイルのパス名
	 * @throws IOException
	 *             入出力エラー
	 */
	public static void execute(BufferedImage image, String originalFileName)
			throws IOException {
		execute(image, originalFileName, "jpeg");
	}

	/**
	 * 指定された画像を、outフォルダを作成し、同じファイル名でセーブする。
	 * 
	 * @param image
	 *            出力する画像データ
	 * @param originalFileName
	 *            入力画像ファイルのパス名
	 * @param formatName
	 *            出力ファイルのフォーマット名
	 * @throws IOException
	 *             入出力エラー
	 */
	public static void execute(BufferedImage image, String originalFileName,
			String formatName) throws IOException {
		execute(image, originalFileName, formatName, null);
	}

	/**
	 * 指定された画像を、outフォルダを作成し、同じファイル名でセーブする。
	 * 
	 * @param image
	 *            出力する画像データ
	 * @param originalFileName
	 *            入力画像ファイルのパス名
	 * @param formatName
	 *            出力ファイルのフォーマット名
	 * @param postFix
	 *            後置詞
	 * @throws IOException
	 *             入出力エラー
	 */
	public static void execute(BufferedImage image, String originalFileName,
			String formatName, String postFix) throws IOException {
		String extension;
		if (formatName.equals("jpeg")) {
			extension = "jpg";
		} else if (formatName.equals("png")) {
			extension = "png";
		} else {
			extension = null;
		}
		File inputFile = new File(originalFileName);
		File outputDirectory = new File(inputFile.getParentFile(), "out");
		String name = inputFile.getName();
		int index = name.lastIndexOf('.');
		String baseName = name.substring(0, index);
		if (postFix != null) {
			baseName = baseName + "_" + postFix;
		}
		File outputFile = new File(outputDirectory, baseName + "." + extension);
		outputDirectory.mkdir();
		ImageIO.write(image, formatName, outputFile);
	}

	// static void saveAsPng16(BufferedImage image, String originalFileName) {
	// Iterator<ImageWriter> iws = ImageIO.getImageWritersByFormatName("PNG");
	// for (ImageWriter iw = iws.next(); iws.hasNext();) {
	// System.out.printf("%s\n", iw.toString());
	// }
	// }
}
