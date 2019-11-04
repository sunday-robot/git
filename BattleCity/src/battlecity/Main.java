package battlecity;

import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;

import battlecity.model.MainModel;
import battlecity.view.GameCanvas;

/**
 * アプリケーションクラス
 */
public final class Main {
	/** */
	private Main() {
	}

	/**
	 * @param args
	 *            引数
	 * @throws Exception
	 *             何らかのエラー
	 */
	public static void main(String[] args) throws Exception {
		initialize();

		MainModel mainModel = new MainModel(".\\data");

		final Display d = new Display();
		Shell shell = createMainWindow(d, mainModel);

		while (!shell.isDisposed()) {
			if (!d.readAndDispatch())
				d.sleep();
		}
		d.dispose();
	}

	/**
	 * メインウィンドウを生成する
	 * 
	 * @param display
	 *            Display
	 * @param mainModel
	 *            {@link MainModel}
	 * @return Shell
	 */
	private static Shell createMainWindow(Display display, MainModel mainModel) {
		Shell shell = new Shell(display);
		shell.setText("Battle City"); // ウィンドウタイトルの設定

		// ウィンドウにゲームCanvasを追加する。(ウィンドウの表示内容は、このCanvas一つだけなので、レイアウトなどは無用。)
		new GameCanvas(shell, mainModel);

		shell.pack(); // ゲームCanvasを表示する最小限の大きさにする。
		shell.open();
		return shell;
	}

	/**
	 * 初期化する
	 * 
	 * @throws Exception
	 *             何らかの例外
	 */
	private static void initialize() throws Exception {
		// フォントの読み込み
		// bcty.bft

		// グラフィックデータの読み込み
		// bcty16.bft
		// bcty32_1.bft
		// bcty32_2.bft
		// bcty64.bft

		// init_sprite();

		// ステージデータの読み込み
		// stages = StageLoader.load(".");

		// BGMの読み込み
		// bcty.bgm

		// 効果音の読み込み
		// bcty.efs

		// ハイスコアファイルの読み込み
		// highScore = new HighScore("bcty.scr");
	}

	// private static void gameMain() throws Exception {
	// // 初期化
	// initialize();
	// // メインループ(無限ループ)
	// // メインループは、1/60秒で処理を終えるものとする。
	// // キーの入力も1/60秒の間の入力をまとめたものとする。
	// main_loop: for (;;) {
	// // タイトル画面
	// switch (Title.show()) {
	// case -1: // タイムアウト
	// break;
	// case 0: // 1 player mode game start
	// // start_game(0);
	// break;
	// case 1: // 2 players mode game start
	// // start_game(1);
	// break;
	// case 2: // quit
	// break main_loop;
	// default: // view high scores
	// // input_high_score(-1, 0, 0);
	// }
	// }
	// // terminate();
	// }
	//
}
