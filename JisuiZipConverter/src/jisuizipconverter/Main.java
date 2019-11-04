package jisuizipconverter;

import java.awt.Image;
import java.awt.Point;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import javax.imageio.ImageIO;

import lib.imageoperator.Gamma;
import lib.imageoperator.Resizer;

import org.apache.commons.cli.CommandLine;
import org.apache.commons.cli.HelpFormatter;
import org.apache.commons.cli.Option;
import org.apache.commons.cli.Options;
import org.apache.commons.cli.ParseException;
import org.apache.commons.cli.Parser;
import org.apache.commons.cli.PosixParser;

/***/
public final class Main {
	/** Nexus7のサイズ */
	private static final Point NEXUS_7_SIZE = new Point(800, 1280);

	/** Kobo gloのサイズ */
	private static final Point KOBO_GLO_SIZE = new Point(758, 1024);

	/** 出力ファイルの拡張子のデフォルト値 */
	private static final String DEFAULT_EXTENSION = ".zip";

	/** ガンマ値のデフォルト値 */
	private static final double DEFAULT_GAMMA = 2.2;

	/** Kobo用の拡張子 */
	private static final String KOBO_GLO_EXTENSION = ".cbz";

	/** Kobo gloのガンマ値 */
	private static final double KOBO_GLO_GAMMA = 1.71;

	/** 入力パラメータ */
	static class Parameters {
		/** 入力ファイルパス名のリスト */
		String[] inputFiles;

		/** 入力画像のガンマ値 */
		double inputGamma = DEFAULT_GAMMA;

		/** リサイズをより正確にするかどうか(見た目にはほとんど変わらないが、JPEGやPNGではより圧縮できる。ただし非常に遅い。) */
		boolean resizePrecisely = false;

		/** 出力ファイルの拡張子 */
		String outputFileExtension = DEFAULT_EXTENSION;

		/** 出力画像のサイズ */
		Point imageSize = (Point) NEXUS_7_SIZE.clone();

		/** 出力画像のガンマ値 */
		double outputGamma = DEFAULT_GAMMA;
	}

	/***/
	private Main() {
	}

	/**
	 * 引数で指定されたZIPファイル(PNGやJPEGファイルを含むもの)
	 * 
	 * @param args
	 *            ZIPファイル(複数)
	 * @throws IOException
	 *             :
	 */
	public static void main(String[] args) {
		Parameters parameters = parseCommandLine(args);

		if (args.length == 0) {
			usage();
			return;
		}

		for (String filePath : parameters.inputFiles) {
			try {
				convertZipFile(filePath, parameters.inputGamma,
						parameters.outputFileExtension, parameters.imageSize.x,
						parameters.imageSize.y, parameters.outputGamma,
						parameters.resizePrecisely);
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	/**
	 * 
	 * @param args
	 *            コマンドライン引数のリスト
	 * @return 変換パラメータと入力ファイル名のリスト
	 */
	private static Parameters parseCommandLine(String[] args) {
		Parameters parameters = new Parameters();
		Options options = new Options();

		Option kOption = new Option("k", "koboglo", false,
				"set size and gamma for kobo glo, and set output file extension to \".cbz\"");
		options.addOption(kOption);

		Option nOption = new Option("n", "nexus7", false,
				"set size for nexus 7(2012)");
		options.addOption(nOption);

		Option wOption = new Option("w", "width", true, "set width");
		wOption.setArgs(1);
		options.addOption(wOption);

		Option hOption = new Option("h", "height", true, "set height");
		hOption.setArgs(1);
		options.addOption(hOption);

		Option pOption = new Option("p", "precisely", false,
				"resize precisely(but very slow)");
		options.addOption(pOption);

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

		for (Option o : commandLine.getOptions()) {
			if (o.getOpt().equals("k")) {
				parameters.outputFileExtension = KOBO_GLO_EXTENSION;
				parameters.imageSize.x = KOBO_GLO_SIZE.x;
				parameters.imageSize.y = KOBO_GLO_SIZE.y;
				parameters.outputGamma = KOBO_GLO_GAMMA;
			} else if (o.getOpt().equals("n")) {
				parameters.imageSize.x = NEXUS_7_SIZE.x;
				parameters.imageSize.y = NEXUS_7_SIZE.y;
				parameters.outputFileExtension = DEFAULT_EXTENSION;
			} else if (o.getOpt().equals("w")) {
				parameters.imageSize.x = Integer.parseInt(o.getValue());
			} else if (o.getOpt().equals("h")) {
				parameters.imageSize.y = Integer.parseInt(o.getValue());
			} else if (o.getOpt().equals("p")) {
				parameters.resizePrecisely = true;
			} else {
				throw new RuntimeException();
			}
		}
		parameters.inputFiles = commandLine.getArgs();

		return parameters;
	}

	/**
	 * 
	 * @param inputFilePath
	 *            入力ファイルパス
	 * @param inputGamma
	 *            入力画像のガンマ補正値
	 * @param outputFileExtension
	 *            ファイルの拡張子(".zip"など)
	 * @param outputImageWidth
	 *            出力画像の最大幅
	 * @param outputImageHeight
	 *            出力画像の最大高さ
	 * @param outputGamma
	 *            出力画像のガンマ補正値
	 * @param resizePrecisely
	 *            より正確なリサイズを行うかどうか
	 * @throws IOException
	 *             :
	 */
	private static void convertZipFile(String inputFilePath, double inputGamma,
			String outputFileExtension, int outputImageWidth,
			int outputImageHeight, double outputGamma, boolean resizePrecisely)
			throws IOException {
		ZipOutputStream zos = createZipOutputStream(inputFilePath,
				outputFileExtension);
		ZipInputStream zis = new ZipInputStream(new FileInputStream(
				inputFilePath));
		ZipEntry ze;
		while ((ze = zis.getNextEntry()) != null) {
			System.out.println(ze.toString());
			if (ze.isDirectory())
				continue;

			// 入力ファイルから画像データを読み込む
			BufferedImage image = ImageIO.read(zis);
			if (image == null)
				continue; // 画像ファイルとして読めないもの(thumb.dbなど)は無視

			image = convertImage(image, inputGamma, outputImageWidth,
					outputImageHeight, outputGamma, resizePrecisely);

			// 出力ファイルに画像を書き込む
			ZipEntry oze = new ZipEntry(ze.getName() + ".jpg");
			zos.putNextEntry(oze);
			// ImageIO.write(image, "PNG", zos);
			ImageIO.write(image, "JPEG", zos);
			zos.closeEntry();
		}
		zis.close();
		zos.close();
	}

	/**
	 * 
	 * @param image
	 *            入力画像
	 * @param inputGamma
	 *            入力画像のガンマ補正値
	 * @param maxWidth
	 *            最大幅
	 * @param maxHeight
	 *            最大高さ
	 * @param outputGamma
	 *            出力画像のガンマ補正値
	 * @param resizePrecisely
	 *            より正確なリサイズを行うかどうか
	 * @return 変換後の画像
	 */
	private static BufferedImage convertImage(BufferedImage image,
			double inputGamma, int maxWidth, int maxHeight, double outputGamma,
			boolean resizePrecisely) {
		image = Gamma.execute(image, 1 / inputGamma);
		image = resize(image, maxWidth, maxHeight, resizePrecisely);
		image = Gamma.execute(image, outputGamma);
		return image;
	}

	/**
	 * 最大幅、最大高さを超えないように、画像のサイズを調整する。(最大幅、最大高さの範囲内の場合は何もしない。)
	 * 
	 * @param image
	 *            画像
	 * @param maxWidth
	 *            最大幅
	 * @param maxHeight
	 *            最大高さ
	 * @param resizePrecisely
	 *            より正確なリサイズを行うかどうか
	 * @return 画像
	 */
	private static BufferedImage resize(BufferedImage image, int maxWidth,
			int maxHeight, boolean resizePrecisely) {
		int w = image.getWidth();
		int h = image.getHeight();
		if ((w <= maxWidth) && (h <= maxHeight))
			return image;

		int sw;
		int sh;
		if (w * maxHeight > h * maxWidth) {
			sw = maxWidth;
			sh = h * maxWidth / w;
		} else {
			sw = w * maxHeight / h;
			sh = maxHeight;
		}
		long t0 = System.nanoTime();
		if (resizePrecisely) {
			// SCALE_AREA_AVERAGINGと見た目は区別できないが、実際にはこちらのほうがスムーズらしく、画像ファイルはPNGでもJPEGでも数%は小さくなる。
			// ただし圧倒的に遅い(10倍程度時間がかかる?)
			image = Resizer.execute(image, sw, sh);
		} else {
			Image si = image.getScaledInstance(sw, sh,
					Image.SCALE_AREA_AVERAGING); // SCALA_SMOOTHと同じらしい、他はSCALE_AREA_REPLICATEと同じらしい。REPLICATEはモアレが発生してしまうので使えない。
			image = new BufferedImage(sw, sh, image.getType());
			image.getGraphics().drawImage(si, 0, 0, sw, sh, null);
		}
		long t1 = System.nanoTime();
		System.out.println(t1 - t0);

		return image;
	}

	/**
	 * @param inputFilePath
	 *            入力ファイルのパス名
	 * @param fileExtension
	 *            出力ファイルの拡張子(".zip"など)
	 * @return 出力ファイルのZipOutputStream
	 * @throws FileNotFoundException
	 *             -
	 */
	private static ZipOutputStream createZipOutputStream(String inputFilePath,
			String fileExtension) throws FileNotFoundException {
		File inFile = new File(inputFilePath);
		File parent = inFile.getParentFile();
		File outDir;
		if (parent == null) {
			outDir = new File("out");
		} else {
			outDir = new File(parent, "out");
		}
		outDir.mkdir();
		File outFile = new File(outDir, getBaseName(inputFilePath)
				+ fileExtension);
		ZipOutputStream zos = new ZipOutputStream(new FileOutputStream(outFile));
		// zos.setMethod(ZipOutputStream.STORED)で、圧縮しないようにしたかった(JPEGファイルはZIP圧縮してもほとんどサイズが変わらず無駄なので)が、
		// この場合putNextEntry()でファイルのサイズなどを正しく設定しなければならない。ファイルのサイズはJPEG形式にエンコードしなければわからないので、
		// STOREDの指定はあきらめた。(DEFLATEDで、圧縮レベルを0(圧縮しない)も試したが、こちらの場合ファイルはできるが、Windowsのエクスプローラーで正しく扱えないという問題があったので、これもあきらめた.)
		return zos;
	}

	/**
	 * @param filePath
	 *            ファイルパス
	 * @return ベースネーム
	 */
	private static String getBaseName(String filePath) {
		File f = new File(filePath);
		String fileName = f.getName();
		int index = fileName.lastIndexOf(".");
		if (index < 0)
			return fileName;
		String baseName = fileName.substring(0, index);
		return baseName;
	}

	/**
	 */
	private static void usage() {
	}
}
