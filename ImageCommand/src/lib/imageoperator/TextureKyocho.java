package lib.imageoperator;

import java.io.IOException;

/**
 * テクスチャを強調するフィルター
 * 
 * 方針<br>
 * 
 * 原画像Aから輝度画像Bを生成する。<br>
 * 輝度画像Bから、ぼけた輝度画像Cを生成する。 <br>
 * テクスチャ画像Dを生成する。<br>
 * D=B-C<br>
 * 輝度値の変化を強調した画像Dを以下のように生成する。<br>
 * C = (1 - k) * A - k * B
 * 
 * 原画像からぼけた画像を引く。
 * 
 */
public final class TextureKyocho {
	/**
	 */
	private TextureKyocho() {
	}

	/**
	 * @param image
	 *            処理対象の画像
	 * @param k
	 *            強調係数(1より大きいと強調、1より小さいとその逆を行う）
	 * @param kernelSize
	 *            ぼけた画像を生成するためのカーネルのサイズ、大きいほど処理時間は増大する
	 * @return 返還後の画像
	 */
	public static ColorImage execute(ColorImage image, double k, int kernelSize) {
		// 輝度値画像を作る
		GrayImage[] hsvImage = HSVUtil.divide(image);

		// 輝度値画像からボケ画像を生成する
		GrayImage intensityBokeh = Bokeh.execute(hsvImage[2], kernelSize);

		// 輝度値画像から、ボケ画像を差し引き、テクスチャ画像を生成する
		GrayImage grayTexture = Subtract.execute(hsvImage[2], intensityBokeh);

		// ボケ画像にテクスチャ画像をk倍したものを足してテクスチャ強調画像を生成する
		GrayImage destx = Add.execute(intensityBokeh,
				Multiply.execute(grayTexture, k));

		ColorImage dest = HSVUtil.merge(hsvImage[0], hsvImage[1], destx);

		try {
			hsvImage[2].save("intensity.jpg", "jpg");
			intensityBokeh.save("intensity_bokeh.jpg", "jpg");
			Normalize.normalize(grayTexture).save(
					"intensity-intensity_bokeh.jpg", "jpg");
			dest.save("texture_kyocho.jpg", "jpg");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return dest;
	}

	/**
	 * @param image
	 *            処理対象の画像
	 * @param k1
	 *            強調係数(1より大きいと強調、1より小さいとその逆を行う）
	 * @param k2
	 *            ぼけた画像のぼけ係数（カーネルのサイズ、大きいほど処理時間は増大する）
	 * @return 返還後の画像
	 */
	public static ColorImage execute2(ColorImage image, double k1, int k2) {
		// 輝度値画像を作る
		GrayImage intensity = Intensity.execute(image);

		// 輝度値画像をぼかす
		GrayImage intensityBokeh = Bokeh.execute(intensity, k2);

		// 輝度値画像から、ぼけた輝度値画像を差し引く
		GrayImage grayTexture = Subtract.execute(intensity, intensityBokeh);

		// GrayImage aa = Multiply.execute(a, (1 - k1));
		GrayImage intensityBokehDiv2Add05 = Add.execute(
				Multiply.execute(intensityBokeh, 0.5), 0.5);
		// GrayImage c = Subtract.execute(aa, bb);
		GrayImage c = Add.execute(intensityBokeh,
				Multiply.execute(grayTexture, k1));
		try {
			intensity.save("intensity.jpg", "jpg");
			intensityBokeh.save("intensity_bokeh.jpg", "jpg");
			intensityBokehDiv2Add05.save("bokeh_div_2_add_0.5.jpg", "jpg");
			Normalize.normalize(grayTexture).save(
					"intensity-intensity_bokeh.jpg", "jpg");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return new ColorImage(c);
	}
}
