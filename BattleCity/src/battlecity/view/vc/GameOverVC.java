package battlecity.view.vc;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.KeyEvent;
import org.eclipse.swt.graphics.GC;

import battlecity.view.Banner;
import battlecity.view.GameCanvas;
import battlecity.view.VC;

/**
 * ゲームオーバー画面
 */
public final class GameOverVC implements VC {
	/** 描画対象、イベント発生元のGameCanvas */
	private GameCanvas canvas;

	/**
	 * @param canvas
	 *            GameCanvas
	 */
	public GameOverVC(GameCanvas canvas) {
		this.canvas = canvas;
	}

	@Override
	public void start() {
		// TODO タイマーリセット
		// TODO BGMスタート
	}

	@Override
	public void paint(GC gc) {
		Banner.draw(gc, 8, 9, "GAME"); // 64,72
		Banner.draw(gc, 8, 15, "OVER"); // 64,125
	}

	@Override
	public void keyPressed(KeyEvent e) {
		switch (e.keyCode) {
		case SWT.CR:
			canvas.showTitle();
			break;
		default:
			break;
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {
	}

}
