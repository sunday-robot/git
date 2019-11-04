package minilext.model;

import java.io.File;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

import minilext.LextNotImplementedException;
import minilext.data.AcquisitionSettings;
import minilext.data.AcquisitionSettings.ColorBrightnessSettings.AutoExposureMode;
import minilext.data.AcquisitionSettings.Extend.AcquisitionMode;
import minilext.data.AcquisitionSettings.ManualExtendAndFilmZRangeSettings.ZRangeMode;
import minilext.data.AcquisitionSettings.MeasurementMode;
import minilext.data.ApplicationSettings;
import minilext.data.ApplicationState;
import minilext.data.CalibrationData;
import minilext.data.DeviceConfiguration;
import minilext.data.DeviceSettings;
import minilext.data.DeviceSpecification;
import minilext.data.MatlMode;
import minilext.data.MultiPointSettings;
import minilext.data.SystemSettings;
import minilext.device.Device;
import minilext.device.Device.Xyz;
import minilext.log.Log;
import minilext.type.Lens;
import minilext.type.Magnification;
import minilext.type.Position;
import minilext.type.Size;

/** MVCのM。データとビジネスロジックからなる */
public final class Model {

    /** ディスク空き容量のマージン */
    public static final long DISK_SPACE_MARGIN = 1_000_000_000;

    /** FOVのサイズ計算の基準値(倍率1.0の場合のFOVの幅、高さ) */
    private static final int FOV_LENGTH_NM = 12800;

    /**
     * 撮影メソッド群(単にModelクラスのメソッドをグルーピングするためだけのもの)
     */
    public final class AcquisitionMethods {

	/**
	 */
	public void startCameraLive() {
	    stopLive();
	    device.setScanMode(false, false, true, Xyz.XY);
	    device.setCameraSize(calibrationData.cameraRoi.width, calibrationData.cameraRoi.height,
		    calibrationData.cameraRoi.x, calibrationData.cameraRoi.y);
	    device.startScan();
	}

	/**
	 */
	public void startLsmLive() {
	    stopLive();
	    device.setScanMode(true, true, false, Xyz.XY);
	    device.setZoomMagnification(acquisitioonSettings.zoomMagnification);
	    device.setHv(acquisitioonSettings.lsmBrightness);
	    device.setSize(1024, acquisitioonSettings.bandSize.getHeight(1024), 0);
	    device.startScan();
	}

	/**
	 */
	public void start2ChLive() {
	    stopLive();
	    device.setScanMode(false, true, true, Xyz.XY);
	    device.setZoomMagnification(acquisitioonSettings.zoomMagnification);
	    device.setHv(acquisitioonSettings.lsmBrightness);
	    device.setSize(1024, acquisitioonSettings.bandSize.getHeight(1024), 0);
	    device.setCameraSize(calibrationData.cameraRoi.width, calibrationData.cameraRoi.height,
		    calibrationData.cameraRoi.x, calibrationData.cameraRoi.y);
	    device.startScan();
	}

	/**
	 * ライブを止める
	 */
	public void stopLive() {
	    switch (scanState) {
	    case Live:
		device.stopScan();
		scanState = ScanState.Idle;
		break;
	    case Idle:
		// 何もしない。
		break;
	    case Series:
		// 何もしない(でよいのかよくわからない。)
		break;
	    default:
		throw new LextNotImplementedException(scanState.toString());
	    }
	}

	/**
	 * 設定内容のチェックを行い、問題がある場合、その旨返す。 問題がなければ撮影を開始する。
	 */
	public void startAcquisition() {
	    switch (matlMode) {
	    case SINGLE:
		startSingleAcquisition();
		break;
	    case MULTI_POINT:
		throw new LextNotImplementedException();
	    case STITCH:
		throw new LextNotImplementedException();
	    default:
		throw new LextNotImplementedException();
	    }
	}

	/**
	 * 設定内容のチェックを行い、問題がある場合、その旨返す。 問題がなければ撮影を開始する。 <br>
	 * 単発の撮影用
	 */
	private void startSingleAcquisition() {
	    switch (acquisitioonSettings.measurementMode) {
	    case EXTEND:
		if (acquisitioonSettings.extend.isAutoExtendModeEnabled) {
		    throw new LextNotImplementedException(); // TODO
		} else {
		    acquisitionExecutor = new ManualExtendAcquisitionExecutor(Model.this);
		    acquisitionExecutor.start();
		}
		break;
	    case FILM:
		throw new LextNotImplementedException(); // TODO
	    case ROUGHNESS:
		throw new LextNotImplementedException(); // TODO
	    default:
		throw new LextNotImplementedException();
	    }
	}

	/**
	 * スナップ撮影を行う。
	 */
	public void startSnap() {
	    // TODO
	}

	/**
	 * 撮影を一時停止させる。
	 */
	public void pause() {
	    // TODO
	}

	/**
	 * 一時停止状態の撮影を再開させる。
	 */
	public void resume() {
	    // TODO
	}

	/**
	 * 撮影を終了させる。
	 */
	public void stop() {
	    // TODO
	}

    }

    /**
     * XYステージメソッド群(単にModelクラスのメソッドをグルーピングするためだけのもの)
     */
    public final class StageMethods {

	/**
	 * ステージ座標に関するメソッドの内、ハードウェア座標系でやり取りするものを集めただけのもの。
	 */
	public final class HardwareCoordinateSystem {
	}

	/**
	 * ステージ座標に関するメソッドの内、サンプル座標系でやり取りするものを集めただけのもの。
	 */
	public final class SampleCoordinateSystem {

	    /** X軸上の1点目 */
	    public Position xAxis1;

	    /** X軸上の2点目 */
	    public Position xAxis2;

	    /** Y軸上の点 */
	    public Position yAxis;

	    /** サンプル座標系の原点 */
	    private double ox = 0;

	    /** サンプル座標系の原点 */
	    private double oy = 0;

	    /** サンプル座標系のX軸の単位ベクトルのハードウェア座標系でのX成分 */
	    private double xx = 1;

	    /** サンプル座標系のX軸の単位ベクトルのハードウェア座標系でのY成分 */
	    private double xy = 0;

	    /**
	     * 
	     * @param h1
	     *            X軸上の1点目
	     * @param h2
	     *            X軸上の2点目
	     * @param v
	     *            Y軸上の1点
	     */
	    public void setCoordinate(Position h1, Position h2, Position v) {
		// c = h1 + H * t
		// c = v + (-Hy, Hx) * u
		// H = h2 - h1
		// t = (hx * (-h0.x + v0.x) - hy * (h0.y + v0.y)) / (hx * hx +
		// hy * hy);
		int hx = h2.x - h1.x;
		int hy = h2.y - h1.y;
		int hh = hx * hx + hy * hy;
		double t = ((double) (hx * (v.x - h1.x) - hy * (v.y + h1.y))) / hh;
		ox = h1.x + hx * t;
		oy = h1.y + hy * t;
		double hl = Math.sqrt(hh);
		xx = hx / hl;
		xy = hy / hl;
	    }

	    /**
	     * @return 現在のステージ位置のサンプル座標系での座標値
	     */
	    public Position getPosition() {
		Position p = device.getXYPosition();
		double x = p.x - ox;
		double y = p.y - oy;
		return new Position((int) (xx * x - xy * y), (int) (xy * x + xx * y));
	    }
	}

	/** ハードウェア座標系でやり取りするメソッド群 */
	public final HardwareCoordinateSystem hardwareCoordinateSystem = new HardwareCoordinateSystem();

	/** サンプル座標系でやり取りするメソッド群 */
	public final SampleCoordinateSystem sampleCoordinateSystem = new SampleCoordinateSystem();

	/**
	 * 指定位置への絶対移動を開始する
	 * 
	 * @param x
	 *            [nm]
	 * @param y
	 *            [nm]
	 */
	public void moveToX(int x, int y) {
	    device.moveTo(x, y);
	}

	/**
	 * 指定移動量での相対移動
	 * 
	 * @param dx
	 *            [nm]
	 * @param dy
	 *            [nm]
	 */
	public void move(int dx, int dy) {
	    Position p = device.getXYPosition();
	    device.moveTo(p.x + dx, p.y + dy);
	}

	/**
	 * @return 現在位置[nm]
	 */
	public Position getPosition() {
	    return device.getXYPosition();
	}

	/**
	 * 指定された1024x1024の画像上の1点が中心(512,512)に表示されるように、ステージを動かす。
	 * 
	 * @param x
	 *            画像上のX位置(0～1023)
	 * @param y
	 *            画像上のY位置(0～1023)
	 */
	public void pullToCenter(int x, int y) {
	    Position p = device.getXYPosition();
	    int dx = (int) (p.x + (x - 512) * getPixelWidth());
	    int dy = (int) (p.y + (y - 512) * getPixelHeight());
	    device.disableJoyStickButtonNotification();
	    device.stage.disableJoyStick();
	    device.stage.setMagnification((int) getMagnification() * 4 / 10); // 引き込み移動時は、現在の倍率の40%の倍率に相当する速度でステージを移動させる。
	    setBusy(true);
	    device.move(dx, dy, new Runnable() {

		@Override
		public void run() {
		    device.stage.setMagnification((int) getMagnification()); // 元の移動速度に戻す。
		    device.stage.enableJoyStick();
		    device.enableJoyStickButtonNotification();
		    setBusy(false);
		}
	    });
	}
    }

    /** Z駆動に関するメソッドを集めただけのもの。 */
    public final class ZMethods {

	/**
	 * @param zDirection
	 *            移動方向
	 * @param amountIndex
	 *            移動量インデックス
	 * @return 移動後のZセンサースケール値[fm]
	 */
	public long move(ZDirection zDirection, int amountIndex) {
	    device.doFM(zDirection.id, getZMoveAmount(amountIndex));
	    return device.getZScale();
	}
    }

    /**
     * 自動保存などのアプリケーション設定に関するメソッドを集めただけのもの。
     */
    public final class ApplicationMethods {
    }

    /**
     * 撮影に関するメソッドを集めただけのもの。
     */
    public final AcquisitionMethods acquisition = new AcquisitionMethods();

    /**
     * ステージに関するメソッドを集めただけのもの。
     */
    public final StageMethods stage = new StageMethods();

    /** Z駆動に関するメソッドを集めただけのもの。 */
    public final ZMethods z = new ZMethods();

    /**
     * 自動保存などのアプリケーション設定に関するメソッドを集めただけのもの。
     */
    public final ApplicationMethods application = new ApplicationMethods();

    /** アプリケーションの状態 */
    private ApplicationState applicationState = ApplicationState.STARTING;

    /** システム設定 */
    private final SystemSettings systemSettings;

    /** アプリケーション設定 */
    private final ApplicationSettings applicationSettings;

    /** 撮影設定情報 */
    private final AcquisitionSettings acquisitioonSettings;

    /** 撮影開始可否チェック及び撮影を行うもの。 */
    private AcquisitionExecutor acquisitionExecutor;

    /** */
    private final DeviceConfiguration deviceConfiguration;

    /** */
    private final DeviceSettings deviceSettings;

    /***/
    private final Device device;

    /***/
    private boolean busy = false;

    /** ? */
    private final List<StateListener> stateListeners = new ArrayList<>();

    /** 単発、多点測定、貼り合わせ */
    private MatlMode matlMode = MatlMode.SINGLE;

    /** 多点測定 */
    private final MultiPointSettings multiPointSettings = new MultiPointSettings();

    /** キャリブレーションデータ */
    private final CalibrationData calibrationData;

    /** ライブの状態 */
    private LiveMode liveMode = LiveMode.Camera;

    /**
     * スキャンの状態(Idle or ライブ中 or シリーズスキャン中)
     */
    private ScanState scanState = ScanState.Idle;

    /**
     * ?
     */
    private Thread messageThread;

    // int zoomMagnificationX10 = 10;
    // int currentX = 0;
    // int currentY = 0;

    /**
     * @param device
     *            :
     * @param deviceConfiguration
     *            :
     * @param deviceSettings
     *            :
     */
    public Model(Device device, DeviceConfiguration deviceConfiguration, DeviceSettings deviceSettings) {
	this.systemSettings = new SystemSettings();
	this.applicationSettings = loadApplicationSettings();
	this.device = device;
	loadDeviceConfiguration();
	acquisitioonSettings = loadInitialAcquisitionSettings();
	calibrationData = loadDeviceCalibration();
	this.deviceConfiguration = deviceConfiguration;
	this.deviceSettings = deviceSettings;
    }

    /**
     * @return アプリケーションの状態
     */
    public ApplicationState getApplicationState() {
	return applicationState;
    }

    /**
     * @return 現在の対物レンズの倍率
     */
    public Magnification getLensMagnification() {
	int revolverPosition = device.getRevolverPosition();
	Lens lens = deviceConfiguration.lensList[revolverPosition - 1];
	return lens.specification.magnification;
    }

    /**
     * @return 現在のズーム倍率
     */
    public Magnification getZoomMagnification() {
	return acquisitioonSettings.zoomMagnification;
    }

    /**
     * @return 視野の幅[nm]
     */
    public double getFOVWidth() {
	int revolverIndex = device.getRevolverPosition() - 1;
	double calibration = calibrationData.lensMagnificationCalibrationFactorSets[revolverIndex].maker.x
		* calibrationData.lensMagnificationCalibrationFactorSets[revolverIndex].user.x;
	double magnification = getLensMagnification().getValue() * calibration * getZoomMagnification().getValue();
	double fovWidth = FOV_LENGTH_NM / magnification;
	return fovWidth;
    }

    /**
     * @return 1kの場合の画素の幅[nm]
     */
    public double getPixelWidth() {
	return getFOVWidth() / 1024;
    }

    /**
     * @return 視野の高さ[nm]
     */
    public double getFovHeight() {
	int revolverIndex = device.getRevolverPosition() - 1;
	double calibration = calibrationData.lensMagnificationCalibrationFactorSets[revolverIndex].maker.y
		* calibrationData.lensMagnificationCalibrationFactorSets[revolverIndex].user.y;
	double magnification = getLensMagnification().getValue() * calibration * getZoomMagnification().getValue();
	double fovHeight = FOV_LENGTH_NM / magnification;
	return fovHeight;
    }

    /**
     * @return 1kの場合の画素の高さ[nm]
     */
    public double getPixelHeight() {
	return getFovHeight() / 1024;
    }

    /**
     * @param index
     *            0:微動、1:粗動、2:大粗動
     * @return Z移動量[nm]
     */
    private int getZMoveAmount(int index) {
	// TODO 対物レンズによって変えなければならない。
	return (1 + index) * 100;
    }

    /**
     * @return ?
     */
    public boolean isBusy() {
	return busy;
    }

    /**
     * @param busy
     *            ?
     */
    private void setBusy(boolean busy) {
	this.busy = busy;
	if (this.busy) {
	    for (StateListener listener : stateListeners) {
		listener.taskStarted();
	    }
	} else {
	    for (StateListener listener : stateListeners) {
		listener.taskEnd();
	    }
	}
    }

    /**
     * ?
     */
    public interface StateListener {

	/**
	 * 
	 */
	void taskStarted();

	/**
	 * 
	 */
	void taskEnd();
    }

    /** ライブの状態 */
    enum LiveMode {
	/**  */
	Camera,

	/** */
	Lsm,

	/** */
	_2Ch
    }

    /**
     * スキャンの状態(Idle or ライブ中 or シリーズスキャン中)
     */
    enum ScanState {
	/** */
	Idle,

	/** */
	Live,

	/** */
	Series
    }

    /** Z移動の方向 */
    public enum ZDirection {
	/** */
	Up("F"),

	/** */
	Down("N");

	/** */
	public final String id;

	/**
	 * @param id
	 *            :
	 */
	ZDirection(String id) {
	    this.id = id;
	}
    }

    /**
     * @return アプリケーション設定をロードする。
     */
    private static ApplicationSettings loadApplicationSettings() {
	ApplicationSettings s = new ApplicationSettings();
	s.autoSave.enabled = false;
	s.autoSave.folderPath = null;
	return s;
    }

    /**
     * @return :
     */
    private AcquisitionSettings loadInitialAcquisitionSettings() {
	return new AcquisitionSettings();
    }

    /**
     * アプリケーションを開始する。
     */
    public void start() {
	// デバイスの初期化を行う。具体的には以下の処理を行う。<br>
	// CBの電源をONにする。 <br>
	// 各種調整データをCBに設定する<br>

	int r;

	r = device.power(false);
	r = device.power(true);
	r = device.initialize();
	Device.UnitInfo unitInfo = device.getUnit();
	String ols5Version = device.getVersion(1);
	String samVersion = device.getVersion(2);
	String xyVersion = device.getVersion(3);
	String obVersion = device.getVersion(4);
	String focusVersion = device.getVersion(5);
	long zScale = device.getZScale();
	int ob = device.getOb();
	int freq = device.getFrequency();

	String[] stageVersions = device.stage.getVersions();
	r = device.stage.logIn();
	r = device.stage.enableJoyStick();
	r = device.stage.disableJoyStick();
	r = device.stage.setXRange(-50_000_000, 50_000_000);
	r = device.stage.setYRange(-50_000_000, 50_000_000);
	r = device.stage.enableJoyStick();
	r = device.enableObHvRel();
	r = device.enableObHvRel();
	r = device.setConfocalAFParameters(1, 1_500_000, 3_000_000, 15_120, 3_000_000, 750);
	r = device.setConfocalAFParameters(2, 770_000, 1_540_000, 1_540, 1_540_000, 750);
	r = device.setConfocalAFParameters(3, 180_000, 360_000, 360, 360_000, 360);
	r = device.setConfocalAFParameters(4, 44_000, 88_000, 90, 88_000, 90);
	r = device.setConfocalAFParameters(5, 42_000, 84_000, 85, 84_000, 85);
	r = device.setContrastAFParameters(1, 1839975, 3679955, 60765, 3679955, 60765, 2);
	r = device.setContrastAFParameters(2, 451955, 903915, 14925, 903915, 14926, 2);
	r = device.setContrastAFParameters(3, 104090, 208175, 3440, 208175, 3440, 2);
	r = device.setContrastAFParameters(4, 30270, 60540, 1000, 60540, 1000, 3);
	r = device.setContrastAFParameters(5, 30270, 60540, 1000, 60540, 1000, 3);
	String be = device.getBeamExpanderState();

	{
	    r = device.setOBBeamExpanderState(1, 0);
	    r = device.setOBLSMAdjustment(1, 0);
	    r = device.setOBCameraAdjustment(1, 0);
	    r = device.setOBCLPFL(1, 0);
	}

	{
	    r = device.setOBBeamExpanderState(2, 0);
	    r = device.setOBLSMAdjustment(2, 0);
	    r = device.setOBCameraAdjustment(2, 0);
	    r = device.setOBCLPFL(2, 0);
	}

	{
	    r = device.setOBBeamExpanderState(3, 0);
	    r = device.setOBLSMAdjustment(3, 0);
	    r = device.setOBCameraAdjustment(3, 0);
	    r = device.setOBCLPFL(3, 0);
	}

	{
	    r = device.setOBBeamExpanderState(4, 0);
	    r = device.setOBLSMAdjustment(4, 0);
	    r = device.setOBCameraAdjustment(4, 0);
	    r = device.setOBCLPFL(4, 0);
	}

	{
	    r = device.setOBBeamExpanderState(5, 0);
	    r = device.setOBLSMAdjustment(5, 0);
	    r = device.setOBCameraAdjustment(5, 0);
	    r = device.setOBCLPFL(5, 0);
	}

	r = device.setOB2CHPFL(1);

	r = device.setLAFTH(75);
	r = device.setCAFTH(75);
	r = device.setCAFCOL(2);
	r = device.setLD(100);
	device.setHVCOE(1, 1000);
	int fp = device.getFP();
	device.setHVCOE(2, 1000);
	device.setHVOFS(1, 0);
	device.setHVOFS(2, 0);

	// TODO この後もまだまだ続くが面倒なので後回し。

	System.out.println(ols5Version);
	System.out.println(samVersion);
	System.out.println(xyVersion);
	System.out.println(obVersion);
	System.out.println(focusVersion);
	System.out.println(zScale);
	System.out.println(ob);
	System.out.println(freq);
	System.out.println(stageVersions[0]);
	System.out.println(be);
	System.out.println(fp);

	System.out.printf("%d\n", r);
	System.out.printf("%s\n", unitInfo);

	setAdjustmentParameters();
    }

    /**
     * アプリケーションを終了させる。未保存ファイルに関する問い合わせが終わった後に呼ぶこと。
     */
    public void end() {
	acquisition.stopLive();
	device.moveZPosition(0);
	device.doFinalize();
	device.stage.stop();
	device.stage.disableJoyStick();
	device.stage.setMagnification(1);
	device.stage.enableJoyStick();
	device.stage.logOut();
	device.power(false);
    }

    /**
     * @return Zリミット有効/無効
     */
    public boolean isZLimitEnabled() {
	return device.isZLimitEnabled();
    }

    /**
     * @param enabled
     *            Zリミット有効/無効
     */
    public void setZLimitEnabled(boolean enabled) {
	if (enabled) {
	    if (device.getZPosition() > device.getZLimitPosition()) {
		device.moveZPosition(device.getZLimitPosition());
	    }
	}

	device.setZLimitEnabled(enabled);
    }

    /**
     * @return zLimitPosition Zリミット位置[nm]
     */
    public int getZLimitPosition() {
	return device.getZLimitPosition();
    }

    /**
     * @param zLimitPosition
     *            Zリミット位置[nm]
     */
    public void setZLimitPosition(int zLimitPosition) {
	device.setZLimitPosition(zLimitPosition);
    }

    /**
     *
     */
    private void loadDeviceConfiguration() {
	// TODO Auto-generated method stub

    }

    /**
     * @return :
     */
    private CalibrationData loadDeviceCalibration() {
	CalibrationData c = new CalibrationData();
	return c;
    }

    /**
     * @return :
     */
    public MeasurementMode getMeasurementMode() {
	return acquisitioonSettings.measurementMode;
    }

    /**
     * @param value
     *            :
     */
    public void setMeasurementMode(MeasurementMode value) {
	acquisitioonSettings.measurementMode = value;
    }

    /**
     * @return :
     */
    public AcquisitionMode getExtendAcquisitionMode() {
	return acquisitioonSettings.extend.acquisitionMode;
    }

    /**
     * @param value
     *            :
     */
    public void setExtendAcquisitionMode(AcquisitionMode value) {
	acquisitioonSettings.extend.acquisitionMode = value;
    }

    /**
     * @return :
     */
    public ZRangeMode getZRangeMode() {
	return acquisitioonSettings.manualExtendAndFilmZRangeSettings.zRangeMode;
    }

    /**
     * @param value
     *            :
     */
    public void setRangeMode(ZRangeMode value) {
	acquisitioonSettings.manualExtendAndFilmZRangeSettings.zRangeMode = value;
    }

    /**
     * CBに各種調整データを設定する。
     */
    private void setAdjustmentParameters() {
	// cb.sendCommand("abc");
    }

    /**
     * @return 現在の対物レンズ、ズーム倍率での視野のサイズ[nm]
     */
    public Size getFovNM() {
	Lens lens = deviceConfiguration.lensList[deviceSettings.revolverIndex];
	double m = lens.specification.magnification.getValue();
	double cx = lens.calibrationX;
	double cy = lens.calibrationY;
	double z = device.getZoomMagnification().getValue();
	int w = (int) (FOV_LENGTH_NM / (m * cx * z));
	int h = (int) (FOV_LENGTH_NM / (m * cy * z));
	return new Size(w, h);
    }

    /**
     * (注意)画面表示用の簡易的なものでしかない。キャリブレーション値を適用していない不正確なものなので、各種計算緒元にはできない。<br>
     * 
     * 画面表示用(*)の現在の総合倍率(対物レンズの倍率 * ズーム倍率)を返す
     * 
     * @return 総合倍率
     */
    public double getMagnification() {
	double m = deviceConfiguration.lensList[deviceSettings.revolverIndex].specification.magnification.getValue();
	double z = device.getZoomMagnification().getValue();
	return m * z;
    }

    /**
     * カメラのAEモードを設定する。
     * 
     * @param m
     *            AEモード
     */
    public void setCameraAutoExposureMode(AutoExposureMode m) {
	acquisitioonSettings.colorBrightnessSettings.autoExposureMode = m;
	device.setCameraAutoExposureEnable(m == AutoExposureMode.ENABLED);
    }

    /**
     * @param stateListener
     *            :
     */
    public void addStateListner(StateListener stateListener) {
	if (stateListeners.contains(stateListener)) {
	    throw new LextNotImplementedException();
	}
	stateListeners.add(stateListener);
    }

    /**
     * @param stateListener
     *            :
     */
    public void removeStateListener(StateListener stateListener) {
	if (!stateListeners.contains(stateListener)) {
	    throw new LextNotImplementedException();
	}
	stateListeners.remove(stateListener);
    }

    /**
     * 専用スレッドを生成し、メッセージキューの監視を開始する。
     */
    public void startMessagePump() {
	messageThread = new Thread() {

	    @Override
	    public void run() {
		while (true) {
		    ;
		}
	    }
	};

    }

    /**
     * アプリケーションの動作状態を更新し、リスナー(GUI)に通知する。
     * 
     * @param s
     *            :
     */
    public void setApplicationState(ApplicationState s) {
	applicationState = s;

	// TODO GUIに状態変更の通知をする。
    }

    /**
     * @return 自動保存が有効に設定されているかどうか
     */
    public boolean isAutoSaveEnabled() {
	return applicationSettings.autoSave.enabled;
    }

    /**
     * @param value
     *            自動保存が有効かどうか
     */
    public void setAutoSaveEnabled(boolean value) {
	applicationSettings.autoSave.enabled = value;
    }

    /**
     * @return 一時ファイルドライブの空き容量
     */
    public long getTemporayFileDriveSpace() {
	File f = systemSettings.getTemporayFileFolderPath().toFile();
	if (!f.exists())
	    throw new LextNotImplementedException("一時フォルダが存在しません。" + f);
	return f.getFreeSpace();
    }

    /**
     * @return 自動保存フォルダのドライブの空き容量
     */
    public long getAutoSaveFolderDriveSpace() {
	return applicationSettings.autoSave.folderPath.toFile().getFreeSpace();
    }

    /**
     * @return 自動保存先フォルダのパス
     */
    public Path getAutoSaveFolderPath() {
	return applicationSettings.autoSave.folderPath;
    }

    /**
     * @param path
     *            自動保存先フォルダのパス
     */
    public void setAutoSaveFolderPath(Path path) {
	applicationSettings.autoSave.folderPath = path;
    }

    /**
     * @return 一時ファイル用フォルダのパス
     */
    public Path getTemporayFolder() {
	return systemSettings.getTemporayFileFolderPath();
    }

    /** 自動保存ファイルのファイ名に設定される通し番号(アプリケーション起動時に1となる） */
    private int autoSaveSeqeuncialNumber = 1;

    /**
     * @return 手動3D、膜厚の上限位置が適切かどうか
     */
    public boolean isUpperPositionValid() {
	return getUpperPosition() >= 0;
    }

    /**
     * @return 手動3D、膜厚の下限位置が適切かどうか
     */
    public boolean isULowerPositionValid() {
	int p = getLowerPosition();
	int zl = getActualZLimit();
	return p <= zl;
    }

    /***/
    public void dumpProperties() {
	Log.o(this, "liveMode = %s", liveMode);
	multiPointSettings.dumpProperties();
    }

    /**
     * @return Zリミットが有効ならZリミット位置。無効ならハードウェアZ下限位置。
     */
    private int getActualZLimit() {
	if (device.isZLimitEnabled()) {
	    return device.getZLimitPosition();
	} else {
	    return DeviceSpecification.HW_Z_LIMIT_NM;
	}
    }

    /**
     * @return 手動3Dまたは膜厚の上限位置[nm]
     */
    private int getUpperPosition() {
	switch (acquisitioonSettings.manualExtendAndFilmZRangeSettings.zRangeMode) {
	case POSITION:
	    return acquisitioonSettings.manualExtendAndFilmZRangeSettings.absoluteZRange.upperPositionNM;
	case DISTANCE:
	    return deviceSettings.zNM
		    + acquisitioonSettings.manualExtendAndFilmZRangeSettings.relativeZRange.upperPositionNM;
	default:
	    throw new LextNotImplementedException();
	}
    }

    /**
     * @return 手動3Dまたは膜厚の下限位置[nm]
     */
    private int getLowerPosition() {
	switch (acquisitioonSettings.manualExtendAndFilmZRangeSettings.zRangeMode) {
	case POSITION:
	    return acquisitioonSettings.manualExtendAndFilmZRangeSettings.absoluteZRange.upperPositionNM;
	case DISTANCE:
	    return deviceSettings.zNM
		    + acquisitioonSettings.manualExtendAndFilmZRangeSettings.relativeZRange.upperPositionNM;
	default:
	    throw new LextNotImplementedException();
	}
    }
}
