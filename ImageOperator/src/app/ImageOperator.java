package app;

import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Deviation;
import lib.imageoperator.Emphasizer;
import lib.imageoperator.Gray16;
import lib.imageoperator.Resizer;
import lib.imageoperator.Thickener;
import lib.misc.FileNameUtil;
import lib.misc.SaveOutputImage;

import org.apache.commons.cli.CommandLine;
import org.apache.commons.cli.HelpFormatter;
import org.apache.commons.cli.Option;
import org.apache.commons.cli.Options;
import org.apache.commons.cli.ParseException;
import org.apache.commons.cli.Parser;
import org.apache.commons.cli.PosixParser;

/**
 */
public final class ImageOperator {
	/**
	 */
	private ImageOperator() {
	}

	/** 変換指定（デフォルトはいずれもfalse、nullなどで、コマンドラインオプションで変更する） */
	private static class ConvertOptions {

		/** 明暗を強調する。（最低値と最高値の2要素からなる。） */
		public int[] emphasizeRange = null;

		/** 黒い部分を太らせる。 */
		public boolean thicken = false;

		/** サイズ変更 */
		public double zoomRate = 0; // 0はサイズ変更をしないという特別な値

		/** PNGではなく、JPEG形式で出力する */
		public boolean isJpegOutput = false;

		/** JPEGの圧縮率 0.00(0%)～1.00(100%) */
		public double jpegCompressionRate = 0.75; // 標準の圧縮率はとりあえず75%

		/** モノクロ16階調画像に変換する */
		public boolean monochrome16 = false;

		/** 指定された範囲の平均濃度値を計算する */
		public int averageRange = 0;
	}

	/**
	 * @param args
	 *            String[]
	 */
	public static void main(String[] args) {
		ConvertOptions convertOptions = new ConvertOptions();
		args = parseCommandLine(args, convertOptions);
		if (args == null)
			System.exit(-1);
		try {
			for (String fileName : args) {
				convert(fileName, convertOptions);
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	/**
	 * コマンドライン引数を解析し、ConvertOptionsに？？？
	 * 
	 * @param args
	 *            コマンドライン引数の配列
	 * @param convertOptions
	 *            画像変換オプション指定
	 * @return コマンドライン引数の配列(コマンドラインオプションを除去したもの）
	 */
	private static String[] parseCommandLine(String[] args,
			ConvertOptions convertOptions) {
		Options options = new Options();

		Option eOption = new Option("e", "emphasize", true,
				"set emphasize intensity range(min,max)");
		eOption.setArgs(2);
		options.addOption(eOption);

		Option tOption = new Option("t", "thicken", false,
				"thicken dark pixels");
		options.addOption(tOption);

		Option zOption = new Option("z", "zoom", true, "set zoom rate(1=100%)");
		zOption.setArgs(1);
		options.addOption(zOption);

		Option jOption = new Option("j", "jpeg", false, "out put jpeg file");
		options.addOption(jOption);

		Option cOption = new Option("c", "jpegCompressionRate", true,
				"jpeg compression rate(0(%)-100(%))");
		cOption.setArgs(1);
		options.addOption(cOption);

		Option m16Option = new Option("m16", "monoChrome16", false,
				"output as monochrome 16 image");
		options.addOption(m16Option);

		Option aOption = new Option("a", "averageRange", true,
				"Average range(1-)");
		aOption.setArgs(1);
		options.addOption(aOption);

		Parser parser = new PosixParser();
		CommandLine commandLine;
		try {
			commandLine = parser.parse(options, args);
		} catch (ParseException e) {
			System.out.println(e.getLocalizedMessage());
			HelpFormatter hf = new HelpFormatter();
			hf.printHelp("ImageOperator", options);
			return null;
		}
		if (commandLine.hasOption(eOption.getOpt())) {
			String[] optionValues = commandLine.getOptionValues(eOption
					.getOpt());
			convertOptions.emphasizeRange = new int[2];
			convertOptions.emphasizeRange[0] = Integer
					.parseInt(optionValues[0]);
			convertOptions.emphasizeRange[1] = Integer
					.parseInt(optionValues[1]);
		}
		if (commandLine.hasOption(tOption.getOpt())) {
			convertOptions.thicken = true;
		}
		if (commandLine.hasOption(zOption.getOpt())) {
			String[] optionValues = commandLine.getOptionValues(zOption
					.getOpt());
			convertOptions.zoomRate = Double.parseDouble(optionValues[0]);
		}
		if (commandLine.hasOption(jOption.getOpt())) {
			convertOptions.isJpegOutput = true;
		}
		if (commandLine.hasOption(cOption.getOpt())) {
			String[] optionValues = commandLine.getOptionValues(cOption
					.getOpt());
			convertOptions.jpegCompressionRate = Double
					.parseDouble(optionValues[0]) / 100;
		}
		if (commandLine.hasOption(m16Option.getOpt())) {
			convertOptions.monochrome16 = true;
		}

		String[] fileNames = commandLine.getArgs();
		if (fileNames.length == 0) {
			HelpFormatter hf = new HelpFormatter();
			hf.printHelp("ImageOperator", options);
			return null;
		}

		if (commandLine.hasOption(aOption.getOpt())) {
			String[] optionValues = commandLine.getOptionValues(aOption
					.getOpt());
			convertOptions.averageRange = Integer.parseInt(optionValues[0]);
		}

		return fileNames;
	}

	/**
	 * 画像をロードする
	 * 
	 * @param fileName
	 *            String
	 * @return BufferedImage
	 * @throws IOException
	 *             ロード失敗
	 */
	private static BufferedImage loadImage(String fileName) throws IOException {
		Image img = ImageIO.read(new File(fileName));
		return (BufferedImage) img;
	}

	/**
	 * 指定された画像ファイルにconvertOptionsに指定された処理を適用し、 outフォルダに同じファイル名で出力する。
	 * 
	 * @param fileName
	 *            元画像のファイル名
	 * @param convertOptions
	 *            変換処理
	 * @throws IOException
	 *             入出力エラー
	 */
	private static void convert(String fileName, ConvertOptions convertOptions)
			throws IOException {
		System.out.printf("%s\n", fileName);
		BufferedImage image = loadImage(fileName);

		if (convertOptions.averageRange > 0) {
			System.out.printf("averaging range %d\n",
					convertOptions.averageRange);
			// image = Average.execute(image, convertOptions.averageRange);
			BufferedImage[] images = Deviation.execute(image,
					convertOptions.averageRange);
			image = images[0];
			String distFilePath = FileNameUtil.addPostFix(fileName, "_d");
			SaveOutputImage.execute(images[1], distFilePath, "png");
		}
		if (convertOptions.emphasizeRange != null) {
			System.out.printf("emphasizing %d - %d\n",
					convertOptions.emphasizeRange[0],
					convertOptions.emphasizeRange[1]);
			image = Emphasizer.execute(image, convertOptions.emphasizeRange[0],
					convertOptions.emphasizeRange[1]);
		}
		if (convertOptions.thicken) {
			System.out.printf("thickening\n");
			image = Thickener.execute(image);
		}
		if (convertOptions.zoomRate > 0) {
			System.out.printf("zooming %f %%\n", convertOptions.zoomRate * 100);
			int w = (int) (image.getWidth() * convertOptions.zoomRate);
			int h = (int) (image.getHeight() * convertOptions.zoomRate);
			image = Resizer.execute(image, w, h);
		}
		if (convertOptions.monochrome16) {
			System.out.printf("converting to monochrome 16\n");
			image = Gray16.execute(image);
		}
		System.out.printf("saving\n");
		if (convertOptions.isJpegOutput) {
			SaveOutputImage.execute(image, fileName, "jpeg");
		} else {
			SaveOutputImage.execute(image, fileName, "png");
		}
	}

	// /**
	// *
	// * @param fileName1
	// * @param left
	// * @param right
	// * @param top
	// * @param bottom
	// * @param fileName2
	// * @throws IOException
	// */
	// public static void trim(String fileName1, int left, int right, int top,
	// int bottom, String fileName2) throws IOException {
	// BufferedImage img1 = loadImage(fileName1);
	// BufferedImage img2 = Trim.execute(img1, left, right, top, bottom);
	// saveImage(img2, fileName2);
	// }
	//
	// /**
	// *
	// * @param fileName1
	// * @param x
	// * @param y
	// * @param width
	// * @param height
	// * @param newX
	// * @param newY
	// * @param fileName2
	// * @throws IOException
	// */
	// private static void copyRange(String fileName1, int x, int y, int width,
	// int height, int newX, int newY, String fileName2)
	// throws IOException {
	// BufferedImage img1 = loadImage(fileName1);
	// BufferedImage img2 = SubImage.execute(img1, x, y, width, height);
	// BufferedImage img3 = Paste.execute(img1, newX, newY, img2);
	// saveImage(img3, fileName2);
	// }

	// /**
	// *
	// * @param fileName
	// * @throws IOException
	// */
	// private static void histogram(String fileName) throws IOException {
	// BufferedImage img = loadImage(fileName);
	// int[] histogram = Histgram.makeHistogram(img);
	// int sum = 0;
	// for (int i = 0; i < histogram.length; i++) {
	// System.out.printf("%3d, %5d\n", i, histogram[i]);
	// sum += histogram[i];
	// }
	// System.out.printf("total, %5d\n", sum);
	// }

	// /**
	// *
	// * @param fileName1
	// * @param fileName2
	// * @param fileName3
	// * @throws IOException
	// */
	// private static void subImage(String fileName1, String fileName2,
	// String fileName3) throws IOException {
	// final BufferedImage img1 = loadImage(fileName1);
	// final BufferedImage img2 = loadImage(fileName2);
	// final BufferedImage img3 = execute(img1, img2);
	// saveImage(img3, fileName3);
	// }

	// /**
	// * 画像をセーブする
	// *
	// * @param img
	// * BufferedImage
	// * @param fileName
	// * String
	// * @throws IOException
	// * セーブ失敗
	// */
	// private static void saveImage(final BufferedImage img, String fileName)
	// throws IOException {
	// ImageIO.write(img, "png", new File(fileName));
	// }

}
