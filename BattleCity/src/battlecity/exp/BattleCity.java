package battlecity.exp;

import org.eclipse.swt.SWT;
import org.eclipse.swt.graphics.Point;
import org.eclipse.swt.layout.FormAttachment;
import org.eclipse.swt.layout.FormData;
import org.eclipse.swt.layout.FormLayout;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;

import battlecity.gomi.GameView;

/**
 * アプリケーションクラス
 */
public final class BattleCity {
	/** */
	// private GameState gameState;

	/** */
	private BattleCity() {
	}

	/** ハイスコア */
	// private static HighScore highScore;

	/** ステージデータの配列 */
	// private static Stage[] stages;

	/**
	 * メインウィンドウを生成する
	 * 
	 * @param display
	 *            Display
	 * @return Shell
	 */
	private static Shell createMainWindow(Display display) {
		Shell shell = new Shell(display);

		// ウィンドウタイトルの設定
		shell.setText("Battle City");

		// レイアウトマネージャの生成、設定
		// shell.setLayout(new GridLayout(2, true));
		FormLayout layout = new FormLayout();
		layout.spacing = 5;
		shell.setLayout(layout);

		GameView c = new GameView(shell);
		c.pack();

		Point p = c.computeSize(SWT.DEFAULT, SWT.DEFAULT);
		FormData formData = new FormData(p.x, p.y);
		formData.top = new FormAttachment(0);
		formData.left = new FormAttachment(0);
		formData.right = new FormAttachment(100);
		// formData.bottom = new FormAttachment(startStopButton);
		c.setLayoutData(formData);

		shell.pack();
		shell.open();

		return shell;
	}

	/**
	 * 
	 * @param args
	 *            引数
	 * @throws Exception
	 *             何らかのエラー
	 */
	public static void main(String[] args) throws Exception {
		initialize();

		Display d = new Display();
		Shell shell = createMainWindow(d);

		while (!shell.isDisposed()) {
			if (!d.readAndDispatch())
				d.sleep();
		}
		d.dispose();
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
