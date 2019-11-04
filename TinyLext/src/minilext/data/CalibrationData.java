package minilext.data;

import minilext.type.LensMagnificationCalibration;

/**
 * 調整データ
 */
public final class CalibrationData {

	/**
	 * CCD画角調整データ<br>
	 * CCD画像は、LSMよりも少し広い範囲の画像である。<br>
	 * このデータは、CCD画像での、LSMの画像範囲を示すものである。<br>
	 */
	public static final class CameraRoi {

		/** 左上座標[pixel] */
		public int x = 0;

		/** 左上座標[pixel] */
		public int y = 0;

		/** 幅[pixel] */
		public int width = 1936;

		/** 高さ[pixel] */
		public int height = 1212;
	}

	/**
	 * CCD画角調整データ
	 */
	public final CameraRoi cameraRoi = new CameraRoi();

	/**
	 * 対物レンズのメーカーキャリブレーション値と、ユーザーキャリブレーション値
	 */
	public static final class LensMagnficationCalibrationFactorSet {

		/** メーカーキャリブレーション値 */
		public final LensMagnificationCalibration maker = new LensMagnificationCalibration(1, 1);

		/** ユーザーキャリブレーション値 */
		public final LensMagnificationCalibration user = new LensMagnificationCalibration(1, 1);
	}

	/** 各穴位置の対物レンズ倍率補正係数 */
	public final LensMagnficationCalibrationFactorSet[] lensMagnificationCalibrationFactorSets;

	/**
	 * 対物間芯ずれ量<br>
	 * 
	 * 基準となる対物レンズでの中心位置と、本対物レンズでの中心位置
	 */
	public static final class CenterPosition {

		/** [nm] */
		int x;

		/** [nm] */
		int y;
	}

	/**
	 * 対物間芯ずれ量
	 */
	public final CenterPosition[] centerPositions = new CenterPosition[6];

	/**
	 * 各対物レンズでのLSM、CCD間の焦点位置のずれ量[nm]
	 */
	public final int[] cameraFocusOffsets = new int[6];

	/**
	 * 対物間焦点ずれ量[nm]<br>
	 * 
	 * 基準となる対物レンズでの焦点位置と、本対物レンズでの焦点位置
	 */
	public final int[] focusOffsets = new int[6];

	/***/
	public CalibrationData() {
		lensMagnificationCalibrationFactorSets = new LensMagnficationCalibrationFactorSet[6];
		for (int i = 0; i < lensMagnificationCalibrationFactorSets.length; i++) {
			lensMagnificationCalibrationFactorSets[i] = new LensMagnficationCalibrationFactorSet();
		}
	}

}
