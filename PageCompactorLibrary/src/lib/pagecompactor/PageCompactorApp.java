package lib.pagecompactor;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

import lib.imageoperator.Emphasizer;
import lib.imageoperator.Gray16;
import lib.imageoperator.Resizer;
import lib.imageoperator.Thickener;
import lib.misc.SaveOutputImage;

import org.apache.commons.cli.CommandLine;
import org.apache.commons.cli.HelpFormatter;
import org.apache.commons.cli.Option;
import org.apache.commons.cli.Options;
import org.apache.commons.cli.ParseException;
import org.apache.commons.cli.Parser;
import org.apache.commons.cli.PosixParser;

/**
 * 
 * @author akiyama
 * 
 */
public class PageCompactorApp {

    /** 変換指定（デフォルトはいずれもfalse、nullなどで、コマンドラインオプションで変更する） */
    private static class ConvertOptions {

	/** 明暗を強調する。（最低値と最高値の2要素からなる。） */
	public int[] emphasizeRange = null;

	/** 黒いい部分を太らせる。 */
	public boolean thicken = false;

	/** サイズ変更 */
	public double zoomRate = 0; // 0はサイズ変更をしないという特別な値

	/** PNGではなく、JPEG形式で出力する */
	public boolean isJpegOutput = false;

	/** JPEGの圧縮率 0.00(0%)～1.00(100%) */
	public double jpegCompressionRate = 0.75; // 標準の圧縮率はとりあえず75%

	/** モノクロ16階調画像に変換する */
	public boolean monochrome16 = false;
    }

    /**
     * コマンドライン引数を解析する。
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
	return fileNames;
    }

    /**
     * 指定された画像ファイルを指定されたページレイアウト定義情報でコンパクトにし、outフォルダに出力する。。
     * 
     * @param args
     *            画像ファイル名 or コマンドラインオプション
     * @param inputPage
     *            ページレイアウト定義情報
     */
    public static void compactPages(String[] args, PageLayout inputPage) {
	ConvertOptions convertOptions = new ConvertOptions();
	String[] fileNames = parseCommandLine(args, convertOptions);

	try {
	    for (int i = 0; i < fileNames.length; i++) {
		optimizePage(fileNames[i], i + 1, inputPage, convertOptions);
	    }
	} catch (IOException e) {
	    e.printStackTrace();
	}
    }

    /**
     * 右ページ(奇数ページ)の処理<br/>
     * 
     * @param fileName
     *            処理前の画像ファイル
     * @param pageNumber
     *            ページ番号(1～)
     * @param inputPage
     *            ページのレイアウト定義情報
     * @param convertOptions
     *            画像変換オプション
     * @throws IOException
     *             入出力エラー
     */
    private static void optimizePage(String fileName, int pageNumber,
	    PageLayout inputPage, ConvertOptions convertOptions)
	    throws IOException {
	BufferedImage image = ImageIO.read(new File(fileName));
	System.out.printf("%s, %d, %d\n", fileName, image.getWidth(),
		image.getHeight());
	if (pageNumber % 2 == 1)
	    image = PageCompactor.getRightPage(image, inputPage);
	else
	    image = PageCompactor.getLeftPage(image, inputPage);

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
}
