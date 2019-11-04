package app.sonyreader;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.imageoperator.Monochrome;
import lib.imageoperator.Thickener;
import lib.misc.SaveOutputImage;

import org.apache.commons.cli.CommandLine;
import org.apache.commons.cli.Option;
import org.apache.commons.cli.Options;
import org.apache.commons.cli.ParseException;
import org.apache.commons.cli.Parser;
import org.apache.commons.cli.PosixParser;

/**
 * Sony Reader用に画像を変換する。<br>
 * ・モノクロ化(一応完成)<br>
 * ・濃淡強調(完成には程遠い)<br>
 * ・リサイズ(一応完成)<br>
 * ・16階調化(未実装)
 */
public final class ConvertForSonyReader {

	/***/
	private ConvertForSonyReader() {
	}

	/** 変換指定（デフォルトはいずれもfalse、nullなどで、コマンドラインオプションで変更する） */
	private static class ConvertOptions {
		/** 縦横比を維持せずに、SonyReaderの画面と同じサイズにする。 */
		public boolean fitSize;
		/** 明暗を強調する。（最低値と最高値の2要素からなる。） */
		public int[] emphasizeRange;
		/** 黒いい部分を太らせる。 */
		public boolean thicken;
	}

	/**
	 * 
	 * @param args
	 *            -
	 * @param convertOptions
	 *            -
	 * @return オプションを除去したコマンドライン引数
	 */
	private static String[] parseCommandLine(String[] args,
			ConvertOptions convertOptions) {
		Option fOption = new Option("f", false,
				"fit sony reader screen size (do not keep aspect ratio)");
		Option eOption = new Option("e", true,
				"set emphasize intensity range(min,max)");
		eOption.setArgs(2);
		Option tOption = new Option("t", false, "thicken dark pixels");

		Options options = new Options();
		options.addOption(fOption);
		options.addOption(eOption);
		options.addOption(tOption);
		Parser parser = new PosixParser();
		CommandLine commandLine;
		try {
			commandLine = parser.parse(options, args);
		} catch (ParseException e) {
			System.out.println(e.getLocalizedMessage());
			// System.out.println(options.);
			return null;
		}
		if (commandLine.hasOption(fOption.getOpt())) {
			convertOptions.fitSize = true;
		}
		if (commandLine.hasOption(eOption.getOpt())) {
			String[] optionValues = commandLine.getOptionValues(eOption
					.getOpt());
			convertOptions.emphasizeRange = new int[2];
			convertOptions.emphasizeRange[0] = Integer
					.parseInt(optionValues[0]);
			convertOptions.emphasizeRange[1] = Integer
					.parseInt(optionValues[1]);
			System.out.printf("emphasize range is set to (%d, %d)\n",
					convertOptions.emphasizeRange[0],
					convertOptions.emphasizeRange[1]);
		}
		if (commandLine.hasOption(tOption.getOpt())) {
			convertOptions.thicken = true;
		}
		return commandLine.getArgs();
	}

	/**
	 * 
	 * @param args
	 *            画像ファイル名配列
	 * @throws IOException
	 *             入出力エラー
	 * @throws ParseException
	 */
	public static void main(String[] args) throws IOException {
		ConvertOptions convertOptions = new ConvertOptions();
		args = parseCommandLine(args, convertOptions);
		if (args == null) {
			System.exit(-1);
		}
		java.util.Arrays.sort(args);
		for (String fileName : args) {
			convert(fileName, convertOptions);
		}
	}

	/**
	 * 指定された画像ファイルをSonyReader用に変換した画像ファイルを生成する
	 * 
	 * @param fileName
	 *            ファイル名
	 * @param convertOptions
	 *            ConvertOptions
	 * @throws IOException
	 *             入出力エラー
	 */
	private static void convert(String fileName, ConvertOptions convertOptions)
			throws IOException {
		BufferedImage image = ImageIO.read(new File(fileName));
		System.out.printf("%s, %d, %d\n", fileName, image.getWidth(),
				image.getHeight());
		image = Monochrome.execute(image);
		if (convertOptions.thicken) {
			image = Thickener.execute(image);
		}
		if (convertOptions.emphasizeRange != null) {
			image = Emphasizer.execute(image, convertOptions.emphasizeRange[0],
					convertOptions.emphasizeRange[1]);
		}
		image = ResizerForSonyReader.execute(image, !convertOptions.fitSize);
		SaveOutputImage.execute(image, fileName, "png");
	}

	// /**
	// * 指定された画像の濃度値(輝度値)を強調した画像を返す
	// *
	// * @param image
	// * 変換前の画像
	// * @return 下限値と、上限値
	// */
	// private static int[] getEmphasizeRange(BufferedImage image) {
	// int[] histgram = Histgram.makeHistogram(image);
	// int minorPixelCount = image.getWidth() * image.getHeight() / 50; //
	// 上位/下位の少数派の数
	// int lowestIndex = 0;
	// int highestIndex = 0;
	// for (int i = 0, pixelCount = 0; i < 255; i++) {
	// pixelCount += histgram[i];
	// if (pixelCount >= minorPixelCount) {
	// lowestIndex = i;
	// break;
	// }
	// }
	// for (int i = 255, pixelCount = 0; i >= 0; i--) {
	// pixelCount += histgram[i];
	// if (pixelCount >= minorPixelCount) {
	// highestIndex = i;
	// break;
	// }
	// }
	// return new int[] { lowestIndex, highestIndex };
	// }
}
