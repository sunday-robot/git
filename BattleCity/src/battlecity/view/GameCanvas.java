package battlecity.view;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.KeyEvent;
import org.eclipse.swt.events.KeyListener;
import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Image;
import org.eclipse.swt.widgets.Canvas;
import org.eclipse.swt.widgets.Composite;
import org.eclipse.swt.widgets.Display;

import battlecity.model.MainModel;
import battlecity.view.resource.BG;
import battlecity.view.resource.Font;
import battlecity.view.resource.Sprite;
import battlecity.view.vc.GameOverVC;
import battlecity.view.vc.StageResultVC;
import battlecity.view.vc.StageSelectVC;
import battlecity.view.vc.TitleVC;

/**
 * ゲームのViewクラス(???)
 */
public final class GameCanvas extends Canvas implements PaintListener, KeyListener {
	/** 画面の幅 */
	private static final int WIDTH = 256 * 2;

	/** 画面の高さ */
	private static final int HEIGHT = 240 * 2;

	/** フレーム周期 */
	protected static final long FRAME_PERIOD = 1000 / 60;

	/** 現在の画面 */
	private VC currentVC;

	/** タイトル画面 */
	private final TitleVC titleVC;

	/** ステージ選択画面 */
	private final StageSelectVC stageSelectVC;

	/** ステージ結果画面 */
	private final StageResultVC stageResultVC;

	/** ゲームオーバー画面 */
	private final GameOverVC gameOverVC;

	/** ゲーム画面の描画対象 */
	private Image bufferedImage = null;

	/**
	 * @param parent
	 *            Composite
	 * @param model
	 *            MainModel
	 */
	public GameCanvas(Composite parent, MainModel model) {
		super(parent, SWT.NO_BACKGROUND);
		setSize(WIDTH, HEIGHT);
		addPaintListener(this);
		addKeyListener(this);

		Font.load(getDisplay(), "graphics/font/BCTY_%02d.png");
		BG.load(getDisplay(), "graphics/bg/BCTY16_%02d.png");
		Sprite.load(getDisplay(), "graphics/sprite/32/BCTY32_%02d.png");

		titleVC = new TitleVC(this, model);
		stageSelectVC = new StageSelectVC(this, model);
		stageResultVC = new StageResultVC(this, model);
		gameOverVC = new GameOverVC(this);

		final Display display = GameCanvas.this.getShell().getDisplay();
		Runnable runnable = new Runnable() {
			public void run() {
				long t0 = System.currentTimeMillis();
				tick();
				if (!display.isDisposed()) {
					long t1 = System.currentTimeMillis();
					int sleepTime = (int) (FRAME_PERIOD - (t1 - t0));
					display.timerExec(sleepTime, this);
				}
			}

			private void tick() {
				// System.out.println("tick");
			}
		};

		runnable.run();

		showTitle();
	}

	@Override
	public void paintControl(PaintEvent e) {
		if (bufferedImage == null) {
			bufferedImage = new Image(e.display, e.width, e.height);
		}
		GC gc = new GC(bufferedImage);
		currentVC.paint(gc);
		gc.dispose();

		e.gc.drawImage(bufferedImage, 0, 0);
	}

	@Override
	public void keyPressed(KeyEvent e) {
		currentVC.keyPressed(e);
	}

	@Override
	public void keyReleased(KeyEvent e) {
		currentVC.keyReleased(e);
	}

	/**
	 * タイトル画面に遷移する。TODO メソッド名がダメ。何とかしたい。
	 */
	public void showTitle() {
		setVC(titleVC);
	}

	/**
	 * 
	 */
	public void start1PGame() {
		setVC(stageSelectVC);
	}

	/**
	 * 
	 */
	public void start2PGame() {
		setVC(stageSelectVC);
	}

	/**
	 * プログラムを終了する。
	 */
	public void quit() {
		getShell().dispose();
	}

	/**
	 * ステージを開始する。
	 * 
	 * @param stageNumber
	 *            ステージの番号(1～)
	 */
	public void startStage(int stageNumber) {
		// TODO
		setVC(stageResultVC);
	}

	/**
	 * ステージ選択画面に遷移する。TODO メソッド名がダメ。
	 */
	public void startStageSelect() {
		// setVC(stageSelectVC);
		setVC(gameOverVC);
	}

	/**
	 * @param vc
	 *            VC
	 */
	private void setVC(VC vc) {
		currentVC = vc;
		redraw();
	}

}
