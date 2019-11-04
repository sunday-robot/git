package battlecity.view.vc;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.KeyEvent;
import org.eclipse.swt.graphics.GC;

import battlecity.model.MainModel;
import battlecity.view.Banner;
import battlecity.view.GameCanvas;
import battlecity.view.Palette;
import battlecity.view.VC;
import battlecity.view.resource.Font;
import battlecity.view.resource.Sprite;

/**
 * タイトル画面<br>
 * 
 * 開始時:<br>
 * 1Pにカーソルを合わせる。<br>
 * BGMを始める。<br>
 * デモ開始タイマーを始める。<br>
 * 
 * 上下カーソルキー:<br>
 * ゲームモード選択カーソルを動かす。<br>
 * デモ開始タイマーをリセットする。<br>
 * 
 * ENTERキー:<br>
 * 選択されたゲームモードでゲームを開始する。<br>
 * 
 * デモ開始タイマー終了:<br>
 * デモプレイ画面に遷移する。<br>
 */
public final class TitleVC implements VC {
	/** 描画対象、イベント発生元のGameCanvas */
	private GameCanvas canvas;

	/** モデル */
	private MainModel model;

	/** カーソルの現在位置 */
	private int cursorPosition = 0;

	/**
	 * @param canvas
	 *            GameCanvas
	 * @param mainModel
	 *            MainModel
	 */
	public TitleVC(GameCanvas canvas, MainModel mainModel) {
		this.canvas = canvas;
		this.model = mainModel;
	}

	@Override
	public void start() {
		// デモ開始タイマーをリセットする。

		// BGMを開始する。

		// 画面を描画する。
	}

	@Override
	public void paint(GC gc) {
		int player1HighScore = model.getPlayer1HighScore();
		int player2HighScore = model.getPlayer2HighScore();
		int highScore = model.getHighScore();

		gc.setBackground(gc.getDevice().getSystemColor(SWT.COLOR_BLACK));
		gc.fillRectangle(canvas.getClientArea());

		String s;
		s = String.format("I-%5d0", player1HighScore);
		Font.drawString(gc, 16 * 2, 16 * 3, s);

		s = String.format("HI-%5d0", highScore);
		Font.drawString(gc, 16 * 11, 16 * 3, s);

		if (player2HighScore > 0) {
			s = String.format("II-%5d0", player2HighScore);
			Font.drawString(gc, 16 * 20, 16 * 3, s);
		}

		Font.drawString(gc, 16 * 11, 16 * 17, "1 PLAYER");
		Font.drawString(gc, 16 * 11, 16 * 19, "2 PLAYERS");
		Font.drawString(gc, 16 * 11, 16 * 21, "CONSTRUCTION");
		Font.drawString(gc, 16 * 11, 16 * 23, "(namcot)", Palette.ORANGE);
		Font.drawString(gc, 16 * 4, 16 * 25, "c 1980 1985 NAMCO LTD.");
		Font.drawString(gc, 16 * 6, 16 * 27, "ALL RIGHT RESERVED");

		// レンガのBGを使用した"BATTLE CITY"
		Banner.draw(gc, 4, 6, "BATTLE");
		Banner.draw(gc, 8, 11, "CITY");

		// カーソル役の戦車
		Sprite.draw(gc, 128, 264 + cursorPosition * 32, 1);
	}

	@Override
	public void keyPressed(KeyEvent e) {
		switch (e.keyCode) {
		case SWT.ARROW_UP:
			if (cursorPosition == 0) {
				cursorPosition = 2;
			} else {
				cursorPosition--;
			}
			canvas.redraw();
			break;
		case SWT.ARROW_DOWN:
			if (cursorPosition == 2) {
				cursorPosition = 0;
			} else {
				cursorPosition++;
			}
			canvas.redraw();
			break;
		case 0x0d:
			switch (cursorPosition) {
			case 0:
				canvas.start1PGame();
				break;
			case 1:
				canvas.start2PGame();
				break;
			default:
				canvas.quit();
			}
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {
	}
}
