package minilext.data;

import minilext.type.Magnification;
import minilext.type.ZRange;

/**
 * 全ての撮影設定データ
 * 
 * 方針：<br>
 * 仕様に忠実な構造とする。仕様書に出てこない"共通"データ型などを勝手に定義しない。(仕様変更への追従がしにくくなるから)<br>
 * 数値については、すべて整数(int,long)とし、浮動小数点型(double,float)は使用しない。(
 * ユーザーに示す数値は精度が明確に決められているから)<br>
 */
public final class AcquisitionSettings {
    /** 撮影種別(3D、膜厚、粗さ) */
    public enum MeasurementMode {
    /** 3D */
    EXTEND,

    /** 膜厚(線/面) */
    FILM,

    /** 粗さ */
    ROUGHNESS
    }

    /** 撮影種別(3D、膜厚、粗さ) */
    public MeasurementMode measurementMode = MeasurementMode.EXTEND;

    /** 3D撮影固有の設定 */
    public static class Extend {

	/** 高さ画像撮影の撮影モード */
	public enum AcquisitionMode {
	/** 速度優先 */
	SPEED,

	/** 標準 */
	NORMAL,

	/** 精度優先 */
	PRECISION,

	/** プレビュー */
	PREVIEW
	}

	/** 高さ画像撮影の撮影モード */
	public AcquisitionMode acquisitionMode;

	/** 自動3Dモードかどうか */
	public boolean isAutoExtendModeEnabled;

	/** 手動3Dの設定 */
	public static class Manual {

	    /** 半自動3Dの有効/無効 */
	    public boolean isSemiAutoEnabled;

	    /** 絶対位置指定時のZスキップ範囲 */
	    public final ZRange absoluteSkipRange = new ZRange();

	    /** 相対位置指定時のZスキップ範囲 */
	    public final ZRange relativeSkipRange = new ZRange();

	    /** ステップモード(ユーザーがピッチを指定する)が有効かどうか */
	    public boolean isStepModeEnabled;

	    /** ステップモードのピッチ */
	    public boolean stepModePitchNM;
	}

	/** 手動3Dの設定 */
	public final Manual manual = new Manual();

	/** Zスキップが有効かどうか */
	public boolean isZSkipEnabled;

	/** ダブルスキャンが有効かどうか */
	public boolean isDoubleScanEnabled;

	/** カラー3Dが有効かどうか */
	public boolean isColorEnabled;
    }

    /** 3D撮影固有の設定 */
    public final Extend extend = new Extend();

    /** 膜厚(面、線)の設定 */
    public static class Film {

	/** 膜厚の種類(線または面) */
	public enum Type {
	/** 線膜厚 */
	LINE,

	/** 面膜厚 */
	PLANE
	}

	/** 膜厚の種類(線または面) */
	public Type type;

	// Z範囲については未実装
    }

    /** 膜厚(面、線)の設定 */
    public final Film film = new Film();

    /** 手動3D、膜厚共通のZ範囲設定 */
    public static class ManualExtendAndFilmZRangeSettings {

	/** 手動3DのZ範囲指定方法(位置or距離) */
	public enum ZRangeMode {
	/** 位置指定(内部表現としては、絶対座標指定) */
	POSITION,

	/** 現在Z位置を基準とする距離指定(内部表現としては、相対座標指定) */
	DISTANCE
	}

	/** 3D 手動範囲指定の方法{@link ManualExtendZRangeMode } */
	public ZRangeMode zRangeMode = ZRangeMode.POSITION;

	/** 絶対位置指定時のZ範囲 */
	public final ZRange absoluteZRange = new ZRange();

	/** 相対位置指定時のZ範囲 */
	public final ZRange relativeZRange = new ZRange();
    }

    /** 手動3D、膜厚のZ範囲設定 */
    public final ManualExtendAndFilmZRangeSettings manualExtendAndFilmZRangeSettings = new ManualExtendAndFilmZRangeSettings();

    /** 1ライン(粗さ) */
    public static class Roughness {
	// 省略
    }

    /** 1ライン(粗さ) */
    public final Roughness roughness = new Roughness();

    /** 対物レンズのインデックス(0～5) */
    public int objectiveLensIndex;

    /** レーザーの明るさ(HV値)(0～1000) */
    public int lsmBrightness;

    /** カラーの明るさに関する設定 */
    public static class ColorBrightnessSettings {

	/** AEの無効、有効、ロック */
	public enum AutoExposureMode {
	/** AEは無効である */
	DISABLED,

	/** AEが有効である */
	ENABLED,

	/** AEは有効であるがロックされている */
	LOCKED
	}

	/** AEの無効、有効、ロック */
	public AutoExposureMode autoExposureMode;

	/** AEで決まったカラーの明るさ値(0～1000) */
	public int autoExposureBrightness;

	/** 手動設定されたカラーの明るさ値(0～1000) */
	public int manualBrightness;
    }

    /** カラーの明るさに関する設定 */
    public final ColorBrightnessSettings colorBrightnessSettings = new ColorBrightnessSettings();

    /** ズーム倍率 */
    public Magnification zoomMagnification = new Magnification(1, 0);

    /** 高精細(4K)かどうか */
    public boolean isHighResolutionEnabled = false;

    /** バンドサイズ */
    public enum BandSize {
	/** */
	B11(1, 1),
	/** */
	B43(4, 3),
	/** */
	B21(2, 1),
	/** */
	B41(4, 1),
	/** */
	B81(8, 1);

	/** 横 */
	private final int x;
	/** 縦 */
	private final int y;

	/**
	 * @param x
	 *            :
	 * @param y
	 *            :
	 */
	BandSize(int x, int y) {
	    this.x = x;
	    this.y = y;
	}

	/**
	 * @param width
	 *            横方向の画素数
	 * @return 縦方向の画素数
	 */
	public int getHeight(int width) {
	    return width * y / x;
	}
    }

    /** バンドサイズ */
    public BandSize bandSize = BandSize.B11;
}
