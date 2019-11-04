package minilext.device;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;

import minilext.device.CB.FrameReceiver;
import minilext.device.CB.MessageReceiver;
import minilext.log.Log;
import minilext.type.Magnification;
import minilext.type.Position;

/**
 * CBとのやり取りを少しやりやすくするもの。 <br>
 * CBクラスは、ほぼCBそのままで、電文の加工などはしない。
 */
public final class Device {

    /** 応答電文キューのサイズ */
    private static final int MAX_RECEIVED_MESSAGE_COUNT = 1000;

    /** (説明が難しい) */
    public enum Xyz {
	/** */
	XY(1),

	/** */
	XYZ(2),

	/** */
	XZ(3);

	/** 整数値 */
	public final int id;

	/**
	 * @param id
	 *            :
	 */
	Xyz(int id) {
	    this.id = id;
	}
    }

    /**
     * CBからのメッセージ
     */
    private static class CbMessage {

	/** 1 or 3 */
	final int index;
	/**  */
	final String tag;
	/**  */
	final String[] data;

	/**
	 * @param index
	 *            :
	 * @param tag
	 *            :
	 * @param data
	 *            :
	 */
	CbMessage(int index, String tag, String[] data) {
	    this.index = index;
	    this.tag = tag;
	    this.data = data.clone();
	}
    }

    /**
     * CBの状態
     */
    private static class CbStatus {

	/** 電源ON/OFF */
	int pw;

	/** 初期化処理状態 */
	int init;

	/** カメラ状態 */
	int csts;

	/** スキャン状態 */
	int scan;

	/**
	 */
	void dumpProperties() {
	    Log.o(this, "pw : %s", pw);
	    Log.o(this, "init : %s", init);
	    Log.o(this, "csts : %s", csts);
	    Log.o(this, "scan : %s", scan);
	}
    }

    /**
     * U?コマンドの応答
     */
    public static final class UnitInfo {

	/** */
	public final String systemId;
	/** */
	public final String scanUnit;
	/** */
	public final int revolverHoleCount;
	/** */
	public final String stageId;

	/**
	 * @param systemId
	 *            :
	 * @param scanUnit
	 *            :
	 * @param revolverHoleCount
	 *            :
	 * @param stateId
	 *            :
	 */
	UnitInfo(String systemId, String scanUnit, int revolverHoleCount, String stateId) {
	    this.systemId = systemId;
	    this.scanUnit = scanUnit;
	    this.revolverHoleCount = revolverHoleCount;
	    this.stageId = stateId;
	}

	@Override
	public String toString() {
	    return systemId + "," + scanUnit + "," + revolverHoleCount + "," + stageId;
	}
    }

    /**
     * ステージ関連の処理を担うもの。(="3"で始まる電文を扱うもの)<br>
     * 少しソースコードを見やすくするためのもの。
     */
    public final class Stage {

	/**
	 * ver?<br>
	 * 
	 * @return バージョン
	 */
	public String[] getVersions() {
	    return query("3ver?");
	}

	/**
	 * LOG IN<br>
	 * ログイン
	 * 
	 * @return :
	 */
	public int logIn() {
	    return sendCommand("3LOG IN");
	}

	/**
	 * LOG OUT<br>
	 * ログアウト
	 * 
	 * @return :
	 */
	public int logOut() {
	    return sendCommand("3LOG OUT");
	}

	/**
	 * JSXY 1<br>
	 * ジョイスティック有効化
	 * 
	 * @return :
	 */
	public int enableJoyStick() {
	    return sendCommand("3JSXY 1");
	}

	/**
	 * JSXY 0<br>
	 * ジョイスティック無効化
	 * 
	 * @return :
	 */
	public int disableJoyStick() {
	    return sendCommand("3JSXY 0");
	}

	/**
	 * XRANGE left,right<br>
	 * X可動範囲設定
	 * 
	 * @param left
	 *            左端[um]
	 * @param right
	 *            右端[um]
	 * @return :
	 */
	public int setXRange(int left, int right) {
	    return sendCommand("3XRANGE " + left + "," + right);
	}

	/**
	 * YRANGE top,bottom<br>
	 * X可動範囲設定
	 * 
	 * @param top
	 *            上端[um]
	 * @param bottom
	 *            下端[um]
	 * @return :
	 */
	public int setYRange(int top, int bottom) {
	    return sendCommand("3YRANGE " + top + "," + bottom);
	}

	/**
	 * XYSTP<br>
	 * ステージ移動を止める。
	 * 
	 * @return :
	 */
	public int stop() {
	    return sendCommand("3XYSTP");
	}

	/**
	 * XYMAG p1<br>
	 * 倍率(というか移動速度)を設定する。
	 * 
	 * @param p1
	 *            :
	 * @return :
	 */
	public int setMagnification(int p1) {
	    return sendCommand("3XYMAG " + p1);
	}
    }

    /**
     * ステージ関連の処理を担うもの。(="3"で始まる電文を扱うもの)<br>
     * 少しソースコードを見やすくするためのもの。
     */
    public final Stage stage = new Stage();

    // /** パラメータ設定コマンドのタイムアウト値 */
    // private static final int SET_COMMAND_TIMEOUT_MS = 1_000;
    //
    // /** 即応答が返ってくるコマンドの応答タイムアウト[ms] */
    // private static final int DEFAULT_TIMEOUT = 1000;

    /** {@link CB} */
    private final CB cb;

    /** CFが有効かどうか */
    private boolean cfEnabled = false;
    /** SCFが有効かどうか */
    private boolean scfEnabled = false;
    /** CAMERAが有効かどうか */
    private boolean cameraEnabled = false;

    /** ? */
    private Xyz xyz = Xyz.XY;

    /**
     * CBの状態
     */
    private final CbStatus cbStatus = new CbStatus();

    /** レボルバー位置(1 - 5or6) */
    private int revolverPosition = 1;

    /** 現在XY位置[nm] */
    private Position xyPosition = new Position(0, 0);

    /** 現在Z位置[nm] */
    private int zPosition = 0;

    /** Zリミットが有効かどうか */
    private boolean zLimitEnabled = false;

    /** Zリミット位置[nm] */
    private int zLimitPosition = 0;

    /** ズーム倍率 */
    private Magnification zoomMagnification = new Magnification(1, 0);

    /** ? */
    private final List<PendingTask> pendingTasks = new ArrayList<>();

    /** 応答電文キュー */
    private final BlockingQueue<CbMessage> receivedMessages = new ArrayBlockingQueue<>(MAX_RECEIVED_MESSAGE_COUNT);

    /**
     * CBからの電文を受信するもの
     */
    private final CB.MessageReceiver cbMessageReceiver = new MessageReceiver() {

	@Override
	public void received(String message) {
	    CbMessage cbMessage = parse(message);

	    // TODO ここで下の処理をしてはダメ。別スレッドで。
	    for (PendingTask pt : pendingTasks) {
		if ((pt.index == cbMessage.index) && (pt.tag.equals(cbMessage.tag))) {
		    pt.runnable.run();
		    pendingTasks.remove(pt);
		    return;
		}
	    }
	    switch (cbMessage.index) {
	    case 1:
		if (received1(cbMessage.tag, cbMessage.data))
		    return;
		break;
	    case 3:
		if (received3(cbMessage.tag, cbMessage.data))
		    return;
		break;
	    default:
		throw new IllegalArgumentException();
	    }

	    synchronized (receivedMessages) {
		receivedMessages.add(cbMessage);
	    }
	}
    };

    /**
     * CBからの画像を受信するもの
     */
    private final CB.FrameReceiver cbFrameReceiver = new FrameReceiver() {

	@Override
	public void received(byte[] data) {
	    // TODO Auto-generated method stub

	}
    };

    /**
     * @param cb
     *            :
     */
    public Device(CB cb) {
	this.cb = cb;
	this.cb.initialize(cbMessageReceiver, cbFrameReceiver);
    }

    /**
     * (デバッグ用)内部変数をログに出力する
     */
    public void dumpProperties() {
	cbStatus.dumpProperties();
	Log.o(this, "cfEnabled : %s", cfEnabled);
	Log.o(this, "scfEnabled : %s", scfEnabled);
	Log.o(this, "cameraEnabled : %s", cameraEnabled);
	Log.o(this, "xyz : %s", xyz);
	Log.o(this, "cbStatus : %s", cbStatus);
	Log.o(this, "xyPosition : %s", xyPosition);
	Log.o(this, "zPosition : %s", zPosition);
	Log.o(this, "zLimitEnabled : %s", zLimitEnabled);
	Log.o(this, "zLimitPosition : %s", zLimitPosition);
	Log.o(this, "zoomMagnification : %s", zoomMagnification);
    }

    /**
     * @return ズーム倍率
     */
    public Magnification getZoomMagnification() {
	return zoomMagnification;
    }

    /**
     * @param value
     *            ズーム倍率
     */
    public void setZoomMagnification(Magnification value) {
	zoomMagnification = value;
	sendCommand("1ZM " + value.getValueX10());
    }

    /**
     * 指定座標への移動を開始する。
     * 
     * @param x
     *            [nm]
     * @param y
     *            [nm]
     */
    public void moveTo(int x, int y) {
	startCommand(String.format("3XYG %d,%d", x, y));
    }

    /**
     * @param dx
     *            :
     * @param dy
     *            :
     * @param runnable
     *            :
     */
    public void move(int dx, int dy, Runnable runnable) {
	startCommand(String.format("3XYM %d,%d", dx, dy));
	pendingTasks.add(new PendingTask(3, "XYM", runnable));
    }

    /**
     * @return 現在のXY位置[nm]
     */
    public Position getXYPosition() {
	return xyPosition;
    }

    /**
     * @return 現在のZ位置[nm[
     */
    public int getZPosition() {
	return zPosition;
    }

    /**
     * FG<br>
     * Zを移動させる。
     * 
     * @param zPosition
     *            [nm]
     */
    public void moveZPosition(int zPosition) {
	sendCommand("1FG " + zPosition);
    }

    /**
     * @return Zリミット位置[nm]
     */
    public int getZLimitPosition() {
	return zLimitPosition;
    }

    /**
     * @param zLimitPosition
     *            Zリミット位置[nm]
     */
    public void setZLimitPosition(int zLimitPosition) {
	this.zLimitPosition = zLimitPosition;
	sendCommand("1NL " + zLimitPosition);
    }

    /**
     * @return Zリミットが有効かどうか
     */
    public boolean isZLimitEnabled() {
	return zLimitEnabled;
    }

    /**
     * @param enabled
     *            Zリミットが有効かどうか
     */
    public void setZLimitEnabled(boolean enabled) {
	zLimitEnabled = enabled;
	sendCommand("1NLSW " + (enabled ? "1" : "0"));
    }

    /**
     * 
     * @param b
     *            :
     */
    public void setCameraAutoExposureEnable(boolean b) {
	cb.received("?CameraAE " + b);
    }

    /**
     * 各種問い合わせを行うもの。
     * 
     * @param command
     *            :
     * @return 応答
     */
    private String[] query(String command) {
	cb.received(command);
	try {
	    CbMessage r = receivedMessages.take();
	    return r.data;
	} catch (InterruptedException e) {
	    return null;
	}
    }

    /**
     * ステージ移動など、時間が掛かり、応答電文を非同期で受け取るタイプのコマンド電文をCBに送信する。
     * 
     * @param command
     *            :
     */
    private void startCommand(String command) {
	cb.received(command);
    }

    /**
     * 
     * @param command
     *            :
     * @return エラーコード
     */
    private int sendCommand(String command) {
	cb.received(command);
	try {
	    CbMessage r = receivedMessages.take();
	    switch (r.data[0]) {
	    case "+":
		return 0;
	    default: // "!"
		return Integer.parseInt(r.data[1]);
	    }
	} catch (InterruptedException e) {
	    return -1;
	}
    }

    /**
     * 電源制御
     * 
     * @param p1
     *            0:OFF,1:ON
     * @return :
     */
    public int power(boolean p1) {
	int r = sendCommand(p1 ? "1PW 1" : "1PW 0");
	return r;
    }

    /**
     * @param tag
     *            :
     * @param data
     *            :
     * @return 処理したかどうか
     */
    private boolean received1(String tag, String[] data) {
	switch (tag) {
	case "NPW":
	    cbStatus.pw = Integer.parseInt(data[0]);
	    return true;
	case "NINIT":
	    cbStatus.init = Integer.parseInt(data[0]);
	    return true;
	case "NCSTS":
	    cbStatus.csts = Integer.parseInt(data[0]);
	    return true;
	case "NSCAN":
	    cbStatus.scan = Integer.parseInt(data[0]);
	    return true;
	default:
	    return false;
	}
    }

    /**
     * @param tag
     *            :
     * @param data
     *            :
     * @return 処理したかどうか
     */
    private boolean received3(String tag, String[] data) {
	switch (tag) {
	case "NPW":
	    cbStatus.pw = Integer.parseInt(data[1]);
	    return true;
	case "XYG":
	    return true; // XYGの結果は、意味がないので無視でよい?
	default:
	    return false;
	}
    }

    /**
     * CBからの受信した電文を解析する。
     * 
     * @param s
     *            :
     * @return :
     */
    private static CbMessage parse(String s) {
	int index = Integer.parseInt(s.substring(0, 1));
	String[] f = s.substring(1).split(" ");
	String tag = f[0];
	String[] data = f[1].split(",");
	return new CbMessage(index, tag, data);
    }

    /**
     * INIT<br>
     * イニシャライズ
     * 
     * @return :
     */
    public int initialize() {
	int r = sendCommand("1INIT");
	return r;
    }

    /**
     * FIN<br>
     * ファイナライズ
     * 
     * @return :
     */
    public int doFinalize() {
	int r = sendCommand("1FIN");
	return r;
    }

    /**
     * U?<br>
     * 
     * @return ユニット有無
     */
    public UnitInfo getUnit() {
	String[] r = query("1U?");
	return new UnitInfo(r[0], r[1], Integer.parseInt(r[2].substring(2)), r[3]);
    }

    /**
     * V
     * 
     * @param p1
     *            1:OLS5<br>
     *            2:SAM<br>
     *            3:XY<br>
     *            4:OB<br>
     *            5:Focus<br>
     * @return <br>
     *         [0]:FWバージョン<br>
     *         [1]:FPGAバージョン
     */
    public String getVersion(int p1) {
	String[] r = query("1V " + p1);
	return r[0];
    }

    /**
     * ZS?
     * 
     * @return Zセンサースケール値[fm]<br>
     *         -1_638_400_000_000～11_468_800_000_000
     */
    public long getZScale() {
	String[] r = query("1ZS?");
	return Long.parseLong(r[0]);
    }

    /**
     * OB?<br>
     * OB位置を取得する
     * 
     * @return OB位置(穴位置)<br>
     *         1～5or6
     */
    public int getOb() {
	String[] r = query("1OB?");
	return Integer.parseInt(r[0]);
    }

    /**
     * @return 穴位置(1 - 5or6)
     */
    public int getRevolverPosition() {
	return revolverPosition;
    }

    /**
     * @param position
     *            穴位置(1 - 5or6)
     */
    public void setRevolverPosition(int position) {
	revolverPosition = position;
	sendCommand("OBSEQ " + position);
    }

    /**
     * FREQ?
     * 
     * @return Xスキャナ周波数[0.01Hz]<br>
     *         390000 - 410000
     */
    public int getFrequency() {
	String[] r = query("1FREQ?");
	return Integer.parseInt(r[0]);
    }

    /**
     * OBHVREL 1<br>
     * OB HV 連動の有効化
     * 
     * @return :
     */
    public int enableObHvRel() {
	int r = sendCommand("1OBHVREL 1");
	return r;
    }

    /**
     * OBHVREL 0<br>
     * OB HV 連動の無効化
     * 
     * @return :
     */
    public int disableObHvRel() {
	int r = sendCommand("1OBHVREL 0");
	return r;
    }

    /**
     * LAFP p1～p6<br>
     * コンフォーカル AF パラメータ
     * 
     * @param p1
     *            OB穴番号(1～5or6)
     * @param p2
     *            開始時の移動量[nm]
     * @param p3
     *            サーチ範囲[nm]
     * @param p4
     *            方向判別時の移動量[nm]
     * @param p5
     *            方向判別用サーチ範囲[nm]
     * @param p6
     *            ピッチ[nm]
     * @return :
     */
    public int setConfocalAFParameters(int p1, int p2, int p3, int p4, int p5, int p6) {
	return sendCommand("1LAFP " + p1 + "," + p2 + "," + p3 + "," + p4 + "," + p5 + "," + p6);
    }

    /**
     * CAFP p1～p7<br>
     * コントラスト AF パラメータ
     * 
     * @param p1
     *            OB穴番号(1～5or6)
     * @param p2
     *            開始時の移動量[nm]
     * @param p3
     *            サーチ範囲[nm]
     * @param p4
     *            方向判別時の移動量[nm]
     * @param p5
     *            方向判別用サーチ範囲[nm]
     * @param p6
     *            ピッチ[nm]
     * @param p7
     *            コントラストAFフィルタ<br>
     *            0:ビニングなし<br>
     *            1:ビニング2<br>
     *            2:ビニング4<br>
     *            3:ビニング8<br>
     *            4:ビニング16<br>
     * @return :
     */
    public int setContrastAFParameters(int p1, int p2, int p3, int p4, int p5, int p6, int p7) {
	return sendCommand("1CAFP " + p1 + "," + p2 + "," + p3 + "," + p4 + "," + p5 + "," + p6 + "," + p7);
    }

    /**
     * BE?
     * 
     * @return ビームエキスパンダIN/OUT(1:IN, 0:OUT)
     */
    public String getBeamExpanderState() {
	return query("1BE?")[0];
    }

    /**
     * OBBE p1,p2<br>
     * OB ビームエキスパンダ位置
     * 
     * @param p1
     *            OB穴番号(1～5or6)
     * @param p2
     *            0:OUT,1:IN
     * @return :
     */
    public int setOBBeamExpanderState(int p1, int p2) {
	return sendCommand("1OBBE " + p1 + "," + p2);
    }

    /**
     * OBLADJ p1,p2<br>
     * LSM 同焦補正量を設定する
     * 
     * @param p1
     *            OB穴番号(1～5or6)
     * @param p2
     *            同焦補正量 ( 相対値 ) [nm](5nm単位)
     * @return :
     */
    public int setOBLSMAdjustment(int p1, int p2) {
	return sendCommand("1OBLADJ " + p1 + "," + p2);
    }

    /**
     * OBLADJ p1,p2<br>
     * カメラ同焦補正量を設定する
     * 
     * @param p1
     *            OB穴番号(1～5or6)
     * @param p2
     *            同焦補正量(相対値)[nm](5nm単位)
     * @return :
     */
    public int setOBCameraAdjustment(int p1, int p2) {
	return sendCommand("1OBCADJ " + p1 + "," + p2);
    }

    /**
     * OBCLPFL p1,p2<br>
     * カメラLSM間 同焦補正値
     * 
     * @param p1
     *            OB穴番号(1～5or6)
     * @param p2
     *            同焦補正量(相対値)[nm](5nm単位)
     * @return :
     */
    public int setOBCLPFL(int p1, int p2) {
	return sendCommand("1OBCLPFL " + p1 + "," + p2);
    }

    /**
     * OB2CHPFL p1,p2<br>
     * 同焦補正 LSM/カメラ<br>
     * 
     * OB切り替えで使用する 2ch(LSM& カメラ ) 時の同焦補正 LSM/カメラを変更する<br>
     * 
     * ↑よく理解できないが、2Chライブ状態で、OB切り替えをした際の同焦補正値として、
     * LSM用のものをつかのか、カメラ用のものを使うのかを指定するものであると思われる。
     * 
     * @param p1
     *            1:LSM<br>
     *            2:カメラ
     * @return :
     */
    public int setOB2CHPFL(int p1) {
	return sendCommand("1OB2CHPFL " + p1);
    }

    /**
     * 
     * @param cf
     *            :
     * @param scf
     *            :
     * @param camera
     *            :
     * @param xyz
     *            :
     */
    public void setScanMode(boolean cf, boolean scf, boolean camera, Xyz xyz) {
	this.cfEnabled = cf;
	this.scfEnabled = scf;
	this.cameraEnabled = camera;
	this.xyz = xyz;
	int p1 = (cf ? 1 : 0) | (scf ? 2 : 0);
	int p2 = (camera ? 1 : 0);
	sendCommand("1SCANMOD " + p1 + "," + p2 + "," + xyz.id);
    }

    /**
     * カメラの画角設定を行う。 CBでは、幅が16の倍数、それ以外が2の倍数でなければならないという制約があるが、ここでその制約を吸収する
     * 
     * @param width
     *            :
     * @param height
     *            :
     * @param x
     *            :
     * @param y
     *            :
     */
    public void setCameraSize(int width, int height, int x, int y) {
	int x2 = x + width;
	int y2 = y + height;
	int p3 = x & (~1);
	int p4 = y & (~1);
	int p1 = (x2 - p3 + 15) & (~15);
	int p2 = (y2 - p4 + 1) & (~1);
	sendCommand("1CSZ " + p1 + "," + p2 + "," + p3 + "," + p4);
    }

    /**
     * スキャン開始
     */
    public void startScan() {
	sendCommand("1SCAN 1");
    }

    /**
     * スキャン停止
     */
    public void stopScan() {
	sendCommand("1SCAN 0");
    }

    /**
     * @param hv
     *            :
     */
    public void setHv(int hv) {
	sendCommand("1HV " + hv);
    }

    /**
     * LSM画像サイズ
     * 
     * @param width
     *            :
     * @param height
     *            :
     * @param skip
     *            0:1/1,1:1/2,2:1/4,3:1/8
     */
    public void setSize(int width, int height, int skip) {
	sendCommand("1SZ " + width + "," + height + "," + skip);
    }

    /**
     * 焦準部相対駆動
     * 
     * @param direction
     *            "F" or "N"
     * @param zMoveAmount
     *            移動量[nm]
     */
    public void doFM(String direction, int zMoveAmount) {
	sendCommand("1FM " + direction + "," + zMoveAmount);
    }

    /**
     * JOYスティックボタン通知有効化
     */
    public void enableJoyStickButtonNotification() {
	sendCommand("1S1 1");
    }

    /**
     * JOYスティックボタン通知無効化
     */
    public void disableJoyStickButtonNotification() {
	sendCommand("1S1 0");
    }

    /**
     * コンフォーカル AF ピーク閾値
     * 
     * @param p1
     *            (0～100)ピーク検出からの割合 [%]
     * @return エラーコード
     */
    public int setLAFTH(int p1) {
	return sendCommand("1LAFTH " + p1);
    }

    /**
     * コントラスト AF ピーク閾値
     * 
     * @param p1
     *            (0～100)ピーク検出からの割合 [%]
     * @return エラーコード
     */
    public int setCAFTH(int p1) {
	return sendCommand("1CAFTH " + p1);
    }

    /**
     * @param p1
     *            :
     * @return :
     */
    public int setCAFCOL(int p1) {
	return sendCommand("1CAFCOL " + p1);
    }

    /**
     * @param p1
     *            :
     * @return :
     */
    public int setLD(int p1) {
	return sendCommand("1LD " + p1);
    }

    /**
     * @param p1
     *            :
     * @param p2
     *            :
     */
    public void setHVCOE(int p1, int p2) {
	sendCommand("1HVCOE " + p1 + "," + p2);
    }

    /**
     * @param p1
     *            :
     * @param p2
     *            :
     */
    public void setHVOFS(int p1, int p2) {
	sendCommand("1HVOFS " + p1 + "," + p2);
    }

    /**
     * FP?<br>
     * 焦準部の位置情報を取得する
     * 
     * @return 焦準絶対位置 [nm]
     */
    public int getFP() {
	String[] r = query("1FP?");
	zPosition = Integer.parseInt(r[0]);
	return zPosition;
    }
}
