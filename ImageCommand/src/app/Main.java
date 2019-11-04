package app;

import java.io.IOException;

import lib.imageoperator.BlendWithColor;
import lib.imageoperator.Bokeh;
import lib.imageoperator.ColorImage;
import lib.imageoperator.GrayImage;
import lib.imageoperator.Intensity;
import lib.imageoperator.RGB;
import lib.imageoperator.SaidoKyocho;
import lib.imageoperator.SeparateFromColor;
import lib.imageoperator.TextureKyocho;
import lib.misc.FileNameUtil;

/**
 * 各種画像加工をバッチ処理するもの。
 */
public final class Main {
	/**
	 */
	private Main() {
	}

	/**
	 * @param args
	 *            ? どんなIFが使いやすいのか、まだわからない。
	 * @throws Exception
	 *             Exception
	 */
	public static void main(String[] args) throws Exception {
		// makeUnblendColorImage();
		// makeSaidoKyochoImage();
		// makeIntensityImage();
		// makeBlendUnblendImage();
		// makeBokehImage();
		// makeGrayBokehImage();
		// makeTexttureKyochoImage();
		separateFromColor(ColorImage.load(args[0]),
				Double.parseDouble(args[1]), Double.parseDouble(args[2]),
				Double.parseDouble(args[3]), Double.parseDouble(args[4]),
				args[5]);
		// xxx(args);
	}

	/**
	 * 
	 * @param image
	 *            :
	 * @param red
	 *            :
	 * @param green
	 *            :
	 * @param blue
	 *            :
	 * @param blendRatio
	 *            :
	 * @param separatedImageFile
	 *            :
	 */
	private static void separateFromColor(ColorImage image, double red,
			double green, double blue, double blendRatio,
			String separatedImageFile) {
		ColorImage image2 = SeparateFromColor.execute(image, new RGB(red,
				green, blue), blendRatio);
		try {
			image2.save(separatedImageFile, "jpg");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	/**
	 * 
	 * @param args
	 *            :
	 */
	private static void xxx(String[] args) {
		// Double.parseDouble(args[1]), Integer.parseInt(args[2]));
	}

	/**
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeTexttureKyochoImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		ColorImage input = ColorImage.load(inputFilePath);
		ColorImage output = TextureKyocho.execute(input, 2, 5);
		output.save(FileNameUtil.addPostFix(inputFilePath, "_out"), "png");
	}

	/**
	 * ボケ画像を作る
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeBokehImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		ColorImage input = ColorImage.load(inputFilePath);
		ColorImage output = Bokeh.execute(input, 15);
		output.save(FileNameUtil.addPostFix(inputFilePath, "_bokeh"), "png");
	}

	/**
	 * ボケ画像を作る
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeGrayBokehImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		ColorImage input = ColorImage.load(inputFilePath);
		GrayImage gray = Intensity.execute(input);
		GrayImage output = Bokeh.execute(gray, 15);
		output.save(FileNameUtil.addPostFix(inputFilePath, "_gray_bokeh"),
				"png");
	}

	/**
	 * カラーの除去(混合の解除)を行う。
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeUnblendColorImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		RGB blendColor = new RGB(0.5, 0.5, 0.5);
		double blendRate = 0.5;
		// String inputFilePath = "testdata/pastel_blue.png";
		ColorImage input = ColorImage.load(inputFilePath);
		ColorImage output = SeparateFromColor.execute(input, blendColor,
				blendRate);
		output.save(FileNameUtil.addPostFix(inputFilePath, "_unblended"), "png");
	}

	/**
	 * 彩度強調のテスト
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeSaidoKyochoImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		double k1 = 0.5;
		double k2 = 0.5;
		ColorImage input = ColorImage.load(inputFilePath);
		ColorImage output = SaidoKyocho.execute(input, k1, k2);
		output.save(FileNameUtil.addPostFix(inputFilePath, "_saidoKyocho"),
				"png");
	}

	/**
	 * カラー画像から輝度値画像を作るテスト
	 * 
	 * @throws IOException
	 *             ：
	 */
	public static void makeIntensityImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		ColorImage input = ColorImage.load(inputFilePath);
		GrayImage output = Intensity.execute(input);
		output.save(FileNameUtil.addPostFix(inputFilePath, "_intensity"), "png");
	}

	/**
	 * カラーの画像ファイルを作る。
	 * 
	 * なぜかグレースケール画像の輝度値が設定したものと異なるので、その調査(比較)のために作成したもの。
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeColorImageFile() throws IOException {
		ColorImage image = new ColorImage(768, 256);
		for (int y = 0; y < 256; y++) {
			for (int x = 0; x < 256; x++) {
				int v = Math.max(x, y);
				image.v[y][x][0] = v / 255.0;
				image.v[y][x + 256][1] = v / 255.0;
				image.v[y][x + 512][2] = v / 255.0;
			}
		}
		image.save("testdata/colorimage.png", "png", 1);
	}

	/**
	 * グレースケールの画像ファイルを作る。
	 * 
	 * なぜかグレースケール画像の輝度値が設定したものと異なるので、その調査のために作成したもの。
	 * 
	 * グレースケールのBufferedImageでsetRGB()した場合、必ず輝度値変換が行われるのが原因だった。
	 * 
	 * このため、グレースケールのBufferedImageを使用するのはやめ、常にカラー画像を使うことにした。
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeGrayImageFile() throws IOException {
		GrayImage image = new GrayImage(256, 256);
		for (int y = 0; y < 256; y++) {
			for (int x = 0; x < 256; x++) {
				int v = Math.max(x, y);
				image.v[y][x] = v / 255.0;
			}
		}
		image.save("testdata/grayimage.png", "png", 1);
	}

	/**
	 * 画像とカラーの混合と分離のテスト
	 * 
	 * @throws IOException
	 *             :
	 */
	public static void makeBlendUnblendImage() throws IOException {
		String inputFilePath = "testdata/sample.png";
		ColorImage input = ColorImage.load(inputFilePath);
		RGB blendColor = new RGB(1, 1, 1);
		double blendRate = 0.3;
		ColorImage blendedOutput = BlendWithColor.execute(input, blendColor,
				blendRate);
		ColorImage unblendBlendedOutput = SeparateFromColor.execute(
				blendedOutput, blendColor, blendRate);
		ColorImage unblendedOutput = SeparateFromColor.execute(input,
				blendColor, blendRate);
		blendedOutput.save(FileNameUtil.addPostFix(inputFilePath, "_blended"),
				"png");
		unblendBlendedOutput.save(
				FileNameUtil.addPostFix(inputFilePath, "_blended_unblendedn"),
				"png");
		unblendedOutput.save(
				FileNameUtil.addPostFix(inputFilePath, "_unblended"), "png");
	}
}
