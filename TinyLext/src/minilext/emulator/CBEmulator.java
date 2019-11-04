package minilext.emulator;

import minilext.device.CB;
import minilext.log.Log;

/**
 */
public final class CBEmulator extends CB {

    /** 1:OLS5 */
    private final class OLS5 {

	/** コントラスト AF カラー */
	private int cafcol;

	/** 焦準絶対位置[nm] */
	private int fp;

	/**
	 * Xスキャナ周波数[0.01Hz]<br>
	 * 390000 - 410000
	 */
	private int freq = 40_000;

	/**
	 * LSM 明るさ(0-1000)
	 */
	private int hv;

	/** LD 光量(0～255) */
	private int ld;

	/**
	 * [0]:CF用PMTばらつき補正係数*1000<br>
	 * [1]:SCF用PMTばらつき補正係数*1000
	 */
	private int[] hvcoe = new int[2];

	/**
	 * [0]:CF用基準 HV 設定値とのオフセット量 [0.1%](-1000 - 1000)<br>
	 * [1]:SCF用基準 HV 設定値とのオフセット量 [0.1%](-1000 - 1000)<br>
	 */
	private int[] hvofs = new int[2];

	/** 現在の対物レンズ穴位置 */
	private int ob = 1;

	/** 焦準 NEAR位置[nm] */
	private int nl;

	/** 焦準 NEAR リミット 有効 / 無効 */
	private int nlsw;

	/** JOY スティックボタン通知有効化/無効化 */
	private int s1;

	/**
	 * 撮像モード<br>
	 * [0] LSM(0:OFF,1:CF,2:SCF,3:CF & SCF)<br>
	 * [1] Camera(0:OFF,1:ON)<br>
	 * [2] 1:XY,2:XYZ,3:XZ
	 */
	private int[] scanmod = { 0, 0, 1 };

	/**
	 * LSM 撮像サイズ<br>
	 * [0]:横方向の画素数(1024 or 4096)<br>
	 * [1]:縦方向の画素数<br>
	 * [2]:間引き量(0:1/1, 1:1/2, 2:1/4, 3:1/8)<br>
	 */
	private int[] sz = { 1024, 1024, 0 };

	/**
	 * ズーム倍率(の10倍)
	 */
	private int zm;

	/**
	 * 現在のZスケール値[fm](-1638400000000～11468800000000)
	 */
	private long zs = 0;

	/** 現在Z位置[nm] */
	private int zPosition = 0;

	/**
	 * 
	 */
	public void dumpProperties() {
	    Log.o(this, String.format("cafcol : %s", cafcol));
	    Log.o(this, String.format("fp : %s", fp));
	    Log.o(this, String.format("freq : %s", freq));
	    Log.o(this, String.format("hv : %s", hv));
	    Log.o(this, String.format("ld : %s", ld));
	    Log.o(this, String.format("hvcoe : %s", Log.arrayToString(hvcoe)));
	    Log.o(this, String.format("hvofs : %s", Log.arrayToString(hvofs)));
	    Log.o(this, String.format("ob : %s", ob));
	    Log.o(this, String.format("nl : %s", nl));
	    Log.o(this, String.format("nlsw : %s", nlsw));
	    Log.o(this, String.format("s1 : %s", s1));
	    Log.o(this, String.format("scanmod : %s", Log.arrayToString(scanmod)));
	    Log.o(this, String.format("sz : %s", Log.arrayToString(sz)));
	    Log.o(this, String.format("zm : %s", zm));
	    Log.o(this, String.format("zs : %s", zs));
	    Log.o(this, String.format("zPosition : %s", zPosition));
	}

	/**
	 * @param tag
	 *            :
	 * @param data
	 *            :
	 */
	private void received(String tag, String[] data) {
	    switch (tag) {
	    case "BE?":
		receivedBEq();
		break;
	    case "CAFCOL":
		p1CAFCOL(data[0]);
		break;
	    case "CAFP":
		p1CAFP(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
		break;
	    case "CAFTH":
		p1CATH(data[0]);
		break;
	    case "FG":
		p1FG(data[0]);
		break;
	    case "FIN":
		p1FIN();
		break;
	    case "FP?":
		p1FPq();
		break;
	    case "FREQ?":
		p1FREQ();
		break;
	    case "HVCOE":
		p1HVCOE(data[0], data[1]);
		break;
	    case "HVOFS":
		p1HVOFS(data[0], data[1]);
		break;
	    case "INIT":
		p1INIT();
		break;
	    case "LAFP":
		p1LAFP(data[0], data[1], data[2], data[3], data[4], data[5]);
		break;
	    case "LAFTH":
		p1LATH(data[0]);
		break;
	    case "LD":
		p1LD(data[0]);
		break;
	    case "NL":
		p1NL(data[0]);
		break;
	    case "NLSW":
		p1NLSW(data[0]);
		break;
	    case "OB?":
		p1OB();
		break;
	    case "OB2CHPFL":
		p1OB2CHPFL(data[0]);
		break;
	    case "OBBE":
		p1OBBE(data[0]);
		break;
	    case "OBCADJ":
		p1OBCADJ(data[0], data[1]);
		break;
	    case "OBCLPFL":
		p1OBCLPFL(data[0], data[1]);
		break;
	    case "OBHVREL":
		p1OBHVREL(data[0]);
		break;
	    case "OBLADJ":
		p1OBLADJ(data[0], data[1]);
		break;
	    case "PW":
		p1PW(data[0]);
		break;
	    case "U?":
		p1U();
		break;
	    case "V":
		p1V(data[0]);
		break;
	    case "ZS?":
		p1ZS();
		break;
	    case "SCANMOD":
		receivedSCANMOD(data[0], data[1], data[2]);
		break;
	    case "CSZ":
		receivedCSZ(data[0], data[1], data[2], data[3]);
		break;
	    case "SCAN":
		receivedSCAN(data[0]);
		break;
	    case "ZM":
		receivedZM(data[0]);
		break;
	    case "HV":
		receivedHV(data[0]);
		break;
	    case "SZ":
		receivedSZ(data[0], data[1], data[2]);
		break;
	    case "FM":
		receivedFM(data[0], data[1]);
		break;
	    case "S1":
		receivedS1(data[0]);
		break;
	    default:
		throw new RuntimeException(); // ほんとはこうではない。未知の電文の場合どうするのか、電文仕様書に明記されていたはず。
	    }
	}

	/**
	 * JOY スティックボタン通知有効化/無効化
	 * 
	 * @param p1
	 *            0:無効化、1:有効化
	 */
	private void receivedS1(String p1) {
	    switch (Integer.parseInt(p1)) {
	    case 0:
		s1 = 0;
		break;
	    case 1:
		s1 = 1;
		break;
	    default:
		throw new RuntimeException();
	    }
	    sendMessage("1S1 +");
	}

	/**
	 * 焦準部 相対駆動
	 * 
	 * @param p1
	 *            "F":遠ざかる方向、"N":近づく方向
	 * @param p2
	 *            移動量[nm](5nm単位であること)
	 */
	private void receivedFM(String p1, String p2) {
	    int amount = Integer.parseInt(p2);
	    switch (p1) {
	    case "F":
		zPosition = Math.max(zPosition - amount, 0);
		break;
	    case "N":
		zPosition = Math.min(zPosition + amount, 10_000_000);
		break;
	    default:
		throw new RuntimeException();
	    }
	    zs = zPosition * 1_000_000L;
	    sendMessage("1FN +");
	}

	/**
	 * ビームエキスパンダIN/OUT<br>
	 * (1:IN, 0:OUT)
	 */
	private void receivedBEq() {
	    sendMessage("1BE 0");
	}

	/**
	 * カメラ撮像サイズ
	 * 
	 * 
	 * @param p1
	 *            カメラX方向の画素数(16の倍数でなければならない)(96-1936)
	 * @param p2
	 *            カメラYのライン数(2の倍数でなければならない)(2-1212)
	 * @param p3
	 *            カメラXのオフセット(2の倍数でなければならない)
	 * @param p4
	 *            カメラYのオフセット(2の倍数でなければならない)
	 */
	private void receivedCSZ(String p1, String p2, String p3, String p4) {
	    sendMessage("1CSZ +");
	}

	/**
	 * @param p1
	 *            LSM 明るさ(0-1000)
	 */
	private void receivedHV(String p1) {
	    hv = Integer.parseInt(p1);
	    sendMessage("1HV +");
	}

	/**
	 * 撮像開始/停止
	 * 
	 * @param p1
	 *            0:停止、1:開始
	 */
	private void receivedSCAN(String p1) {
	    sendMessage("1SCAN +");
	    switch (Integer.parseInt(p1)) {
	    case 0:// 停止
		sendMessage("1NSCAN 3");
		break;
	    case 1:// 開始
		switch (scanmod[2]) {
		case 1:// XY
		    sendMessage("1NSCAN 1");
		    break;
		case 2: // XYZ
		    throw new RuntimeException();
		case 3: // XZ
		    throw new RuntimeException();
		default:
		    throw new IllegalArgumentException(scanmod[2] + "");
		}
		break;
	    default:
		throw new IllegalArgumentException(p1);
	    }
	}

	/**
	 * 撮像モード
	 * 
	 * @param p1
	 *            LSM(0:OFF,1:CF,2:SCF,3:CF & SCF)
	 * @param p2
	 *            Camera(0:OFF,1:ON)
	 * @param p3
	 *            1:XY,2:XYZ,3:XZ
	 */
	private void receivedSCANMOD(String p1, String p2, String p3) {
	    scanmod[0] = Integer.parseInt(p1);
	    scanmod[1] = Integer.parseInt(p2);
	    scanmod[2] = Integer.parseInt(p3);
	    sendMessage("1SCANMOD +");
	}

	/**
	 * LSM 撮像サイズ
	 * 
	 * @param p1
	 *            横方向の画素数(1024 or 4096)
	 * @param p2
	 *            縦方向の画素数
	 * @param p3
	 *            間引き量(0:1/1, 1:1/2, 2:1/4, 3:1/8)
	 */
	private void receivedSZ(String p1, String p2, String p3) {
	    sz[0] = Integer.parseInt(p1);
	    sz[1] = Integer.parseInt(p2);
	    sz[2] = Integer.parseInt(p3);
	    sendMessage("1SZ +");
	}

	/**
	 * @param p1
	 *            :
	 */
	private void receivedZM(String p1) {
	    zm = Integer.parseInt(p1);
	    sendMessage("1ZM +");
	}

	/**
	 * コントラスト AF カラー
	 * 
	 * @param p1
	 *            1:R, 2:G, 3:B
	 */
	private void p1CAFCOL(String p1) {
	    cafcol = Integer.parseInt(p1);
	    sendMessage("1CAFCOL +");
	}

	/**
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
	 * @param p7
	 *            コントラストAFフィルタ<br>
	 *            0:ビニングなし<br>
	 *            1:ビニング2<br>
	 *            2:ビニング4<br>
	 *            3:ビニング8<br>
	 *            4:ビニング16<br>
	 */
	private void p1CAFP(String p1, String p2, String p3, String p4, String p5, String p6, String p7) {
	    sendMessage("1CAFP +");
	}

	/**
	 * 焦準部 絶対位置駆動
	 * 
	 * @param p1
	 *            目標位置[nm] ※ 5[nm] 単位で指定すること(Z モータ 1pulse=5[nm] のため)<br>
	 *            0 - 10000000
	 */
	private void p1FG(String p1) {
	    zPosition = Integer.parseInt(p1);
	    sendMessage("1FG +");
	}

	/**
	 * ファイナライズ
	 */
	private void p1FIN() {
	    sendMessage("1FIN +");
	}

	/**
	 * 焦準絶対位置[nm](-500000 - 10000000)
	 */
	private void p1FPq() {
	    sendMessage("1FP " + fp);
	}

	/**
	 * Xスキャナ周波数[0.01Hz]<br>
	 * 390000 - 410000
	 */
	private void p1FREQ() {
	    sendMessage("1FREQ " + freq);
	}

	/**
	 * イニシャライズ
	 */
	private void p1INIT() {
	    sendMessage("1NINIT 1"); // HW初期化中
	    sendMessage("1NCSTS 1"); // カメラステータスBUSY
	    sendMessage("1NINIT 2"); // コンフィギュレーション中
	    sendMessage("1NCSTS 1"); // カメラステータスBUSY
	    sendMessage("1INIT +");
	}

	/**
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
	 */
	private void p1LAFP(String p1, String p2, String p3, String p4, String p5, String p6) {
	    sendMessage("1LAFP +");
	}

	/**
	 * コンフォーカル AF ピーク閾値
	 * 
	 * @param p1
	 *            (0～100)ピーク検出からの割合 [%]
	 */
	private void p1LATH(String p1) {
	    sendMessage("1LATH +");
	}

	/**
	 * PMT バラツキ補正係数
	 * 
	 * @param p1
	 *            1:CF、2:SCF
	 * @param p2
	 *            PMT補正係数*1000(0-1000)
	 */
	private void p1HVCOE(String p1, String p2) {
	    int index;
	    switch (Integer.parseInt(p1)) {
	    case 1:
		index = 0;
		break;
	    case 2:
		index = 1;
		break;
	    default:
		throw new RuntimeException();
	    }
	    int c = Integer.parseInt(p2);
	    hvcoe[index] = c;
	    sendMessage("1HVCOE +");
	}

	/**
	 * 基準 HV 対物とのオフセット量
	 * 
	 * @param p1
	 *            1:CF、2:SCF
	 * @param p2
	 *            基準 HV 設定値とのオフセット量 [0.1%] (-1000 - 1000)
	 */
	private void p1HVOFS(String p1, String p2) {
	    int index;
	    switch (Integer.parseInt(p1)) {
	    case 1:
		index = 0;
		break;
	    case 2:
		index = 1;
		break;
	    default:
		throw new RuntimeException();
	    }
	    int c = Integer.parseInt(p2);
	    hvofs[index] = c;
	    sendMessage("1HVOFS +");
	}

	/**
	 * LSM 光源 (LD) 光量調整
	 * 
	 * @param p1
	 *            LD光量(0～255)
	 */
	private void p1LD(String p1) {
	    ld = Integer.parseInt(p1);
	    sendMessage("1LD +");
	}

	/**
	 * コントラスト AF ピーク閾値
	 * 
	 * @param p1
	 *            (0～100)ピーク検出からの割合 [%]
	 */
	private void p1CATH(String p1) {
	    sendMessage("1CATH +");
	}

	/**
	 * 焦準 NEAR リミット
	 * 
	 * @param p1
	 *            NEARリミット位置[nm]
	 */
	private void p1NL(String p1) {
	    nl = Integer.parseInt(p1);
	    sendMessage("1NL +");
	}

	/**
	 * 焦準 NEAR リミット 有効 / 無効
	 * 
	 * @param p1
	 *            1:有効、0:無効
	 */
	private void p1NLSW(String p1) {
	    nlsw = Integer.parseInt(p1);
	    sendMessage("1NLSW +");
	}

	/**
	 * OB位置(穴位置)<br>
	 * 1～5or6
	 */
	private void p1OB() {
	    sendMessage("1OB " + ob);
	}

	/**
	 * 同焦補正 LSM/カメラ
	 * 
	 * @param p1
	 *            1:LSM<br>
	 *            2:カメラ
	 */
	private void p1OB2CHPFL(String p1) {
	    sendMessage("1OB2CHPFL +");
	}

	/**
	 * カメラ同焦補正量を設定する
	 * 
	 * @param p1
	 *            OB穴番号(1～5or6)
	 * @param p2
	 *            同焦補正量(相対値)[nm](5nm単位)
	 */
	private void p1OBCADJ(String p1, String p2) {
	    sendMessage("1OBCADJ +");
	}

	/**
	 * LSM 同焦補正量を設定する
	 * 
	 * @param p1
	 *            OB穴番号(1～5or6)
	 * @param p2
	 *            同焦補正量 ( 相対値 ) [nm](5nm単位)
	 */
	private void p1OBCLPFL(String p1, String p2) {
	    sendMessage("1OBCLPFL +");
	}

	/**
	 * OB ビームエキスパンダ位置
	 * 
	 * @param p1
	 *            OB穴番号(1～5or6)
	 */
	private void p1OBBE(String p1) {
	    sendMessage("1OBBE +");
	}

	/**
	 * OB HV 連動の有効/無効
	 * 
	 * @param p1
	 *            <br>
	 *            1:有効<br>
	 *            0:無効
	 */
	private void p1OBHVREL(String p1) {
	    sendMessage("1OBHVREL +");
	}

	/**
	 * LSM 同焦補正量を設定する
	 * 
	 * @param p1
	 *            OB穴番号(1～5or6)
	 * @param p2
	 *            同焦補正量 ( 相対値 ) [nm](5nm単位)
	 */
	private void p1OBLADJ(String p1, String p2) {
	    sendMessage("1OBLADJ +");
	}

	/**
	 * 電源制御
	 * 
	 * @param p1
	 *            0:OFF,1:ON
	 */
	private void p1PW(String p1) {
	    switch (p1) {
	    case "0":
		sendMessage("1NPW 0"); // OFF状態であることを通知
		sendMessage("1PW +");
		break;
	    default: // "1"
		sendMessage("1NPW 1"); // ON中状態であることを通知
		sendMessage("1NPW 2"); // ON状態であることを通知
		sendMessage("1PW +");
	    }
	}

	/**
	 * ユニット有無
	 */
	private void p1U() {
	    sendMessage("1U OLS5,OLS50-SU,RV6,OLS50-USS");
	}

	/**
	 * return バージョン<br>
	 * [0]:FWバージョン<br>
	 * [1]:FPGAバージョン
	 * 
	 * @param p1
	 *            1:OLS5<br>
	 *            2:SAM<br>
	 *            3:XY<br>
	 *            4:OB<br>
	 *            5:Focus<br>
	 */
	private void p1V(String p1) {
	    switch (p1) {
	    case "1":
		sendMessage("1V 0001,0002");
		break;
	    case "2":
		sendMessage("1V 0002,0003");
		break;
	    case "3":
		sendMessage("1V 0005,0006");
		break;
	    case "4":
		sendMessage("1V 0007,0008");
		break;
	    default: // "5"
		sendMessage("1V 0009");
		break;
	    }
	}

	/**
	 * Zセンサースケール値[fm]<br>
	 * -1_638_400_000_000～11_468_800_000_000
	 */
	private void p1ZS() {
	    sendMessage("1ZS " + zs);
	}

    }

    /** 3:SSU(ステージ) */
    private final class SSU {

	/***/
	private String moveCommand;

	/** XYGコマンドを実行するもの */
	private final Stage stageMover = new Stage(new Stage.Listener() {

	    @Override
	    public void positionUpdated(int x, int y) {
		sendMessage(String.format("3NXYP %d,%d", x, y));
	    }

	    @Override
	    public void ended(int errorCode) {
		sendMessage("3" + moveCommand + " +");
	    }
	});

	/** ジョイスティック操作可否 */
	private boolean jsxy = true;

	/** ログイン状態 */
	private boolean log = false;

	/** X可動範囲[nm] */
	private int[] xrange = new int[2];

	/** 対物レンズ倍率(移動速度) */
	private int xymag = 1;

	/** 基準移動速度[0,01ms/s] */
	private int xyspd = 1066;

	/** Y可動範囲[nm] */
	private int[] yrange = new int[2];

	/**
	 * (デバッグ用)プロパティをコンソールに出力する。
	 */
	public void dumpProperties() {
	    Log.o(this, String.format("jsxy: %s", jsxy));
	    Log.o(this, String.format("log: %s", log));
	    Log.o(this, String.format("xrange: %s", Log.arrayToString(xrange)));
	    Log.o(this, String.format("xymag: %s", xymag));
	    Log.o(this, String.format("xyspd: %s", xyspd));
	    Log.o(this, String.format("yrange: %s", Log.arrayToString(yrange)));

	}

	/**
	 * @param tag
	 *            :
	 * @param data
	 *            :
	 */
	private void received(String tag, String[] data) {
	    switch (tag) {
	    case "JSXY":
		receivedJSXY(data[0]);
		break;
	    case "LOG":
		receivedLOG(data[0]);
		break;
	    case "ver?":
		receivedVerQ();
		break;
	    case "XRANGE":
		receivedXRANGE(data[0], data[1]);
		break;
	    case "XYG":
		p3XYG(data[0], data[1]);
		break;
	    case "XYM":
		receivedXYM(data[0], data[1]);
		break;
	    case "XYMAG":
		receivedXYMAG(data[0]);
		break;
	    case "XYSTP":
		p3XYSTP();
		break;
	    case "YRANGE":
		receivedYRANGE(data[0], data[1]);
		break;
	    default:
		throw new RuntimeException(); // ほんとはこうではない。未知の電文の場合どうするのか、電文仕様書に明記されていたはず。
	    }
	}

	/**
	 * ジョイスティック有効/無効
	 * 
	 * @param p1
	 *            0:無効、1:有効
	 */
	private void receivedJSXY(String p1) {
	    jsxy = numberToBoolean(p1);
	    sendMessage("3JSXY +");
	}

	/**
	 * ログイン
	 * 
	 * @param p1
	 *            IN or OUT
	 */
	private void receivedLOG(String p1) {
	    log = inOutToBoolean(p1);
	    sendMessage("3LOG +");
	}

	/**
	 * ステージX 動作範囲
	 * 
	 * @param p1
	 *            left
	 * @param p2
	 *            right
	 */
	private void receivedXRANGE(String p1, String p2) {
	    xrange[0] = Integer.parseInt(p1);
	    xrange[1] = Integer.parseInt(p2);
	    sendMessage("3XRANGE +");
	}

	/**
	 * ステージXY 絶対位置移動（直線補間）
	 * 
	 * @param p1
	 *            X[nm]
	 * @param p2
	 *            Y[nm]
	 */
	private void p3XYG(String p1, String p2) {
	    moveCommand = "XYG";
	    stageMover.moveTo(Integer.parseInt(p1), Integer.parseInt(p2), xyspd * 10_000 / xymag);
	}

	/**
	 * ステージXY 相対位置移動（直線補間）
	 * 
	 * @param p1
	 *            dX[nm]
	 * @param p2
	 *            dY[nm]
	 */
	private void receivedXYM(String p1, String p2) {
	    moveCommand = "XYM";
	    stageMover.move(Integer.parseInt(p1), Integer.parseInt(p2), xyspd * 10_000 / xymag);
	}

	/**
	 * ステージXY 倍率<br>
	 * 対物レンズの倍率にあったステージ速度が設定される。
	 * 
	 * @param p1
	 *            倍率(対物レンズの倍率)
	 */
	private void receivedXYMAG(String p1) {
	    xymag = Integer.parseInt(p1);
	    sendMessage("3XYMAG +");
	}

	/**
	 * ステージXY 停止<br>
	 * 停止完了後、応答電文を送信する
	 */
	private void p3XYSTP() {
	    stageMover.stop();
	    sendMessage("3XYP +");
	}

	/**
	 * ステージY 動作範囲
	 * 
	 * @param p1
	 *            top
	 * @param p2
	 *            bottom
	 */
	private void receivedYRANGE(String p1, String p2) {
	    yrange[0] = Integer.parseInt(p1);
	    yrange[1] = Integer.parseInt(p2);
	    sendMessage("3YRANGE +");
	}

	/**
	 * バージョン
	 */
	private void receivedVerQ() {
	    sendMessage("3ver 0001,0001");
	}
    }

    /** 1:OLS5 */
    private final OLS5 ols5 = new OLS5();

    /** 3:SSU(ステージ) */
    private final SSU ssu = new SSU();

    @Override
    public void received(String text) {
	Log.o(this, "   -> \"" + text + "\"");
	char index = text.charAt(0);
	String[] f = text.substring(1).split(" ");
	String tag = f[0];
	String[] data;
	if (f.length == 1)
	    data = null;
	else
	    data = f[1].split(",");
	switch (index) {
	case '1':
	    ols5.received(tag, data);
	    break;
	case '3':
	    ssu.received(tag, data);
	    break;
	default:
	    throw new IllegalArgumentException();
	}
    }

    @Override
    public void dumpProperties() {
	ols5.dumpProperties();
	ssu.dumpProperties();
    }

    /**
     * ホストへ電文を送信する。(ログ出力の後、send()を呼ぶだけのメソッド。)
     * 
     * @param text
     *            :
     */
    private void sendMessage(String text) {
	Log.o(this, "<- \"" + text + "\"");
	send(text);
    }

    /**
     * @param p
     *            "0"or"1"
     * @return :
     */
    private static boolean numberToBoolean(String p) {
	switch (p) {
	case "0":
	    return false;
	case "1":
	    return true;
	default:
	    throw new RuntimeException();
	}
    }

    /**
     * @param p
     *            "IN"or"OUT"
     * @return :
     */
    private static boolean inOutToBoolean(String p) {
	switch (p) {
	case "IN":
	    return false;
	case "OUT":
	    return true;
	default:
	    throw new RuntimeException();
	}
    }

}
