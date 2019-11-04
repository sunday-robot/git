package battlecity.view.vc;

import org.eclipse.swt.events.KeyEvent;
import org.eclipse.swt.graphics.GC;

import battlecity.model.MainModel;
import battlecity.view.GameCanvas;
import battlecity.view.Palette;
import battlecity.view.VC;
import battlecity.view.resource.Font;
import battlecity.view.resource.Sprite;

/**
 * ステージの結果画面(成績画面)
 */
public final class StageResultVC implements VC {
	/** 描画対象、イベント発生元のGameCanvas */
	private GameCanvas canvas;

	/** モデル */
	private MainModel model;

	/** 進捗度 */
	private int progress;

	/**
	 * @param canvas
	 *            GameCanvas
	 * @param model
	 *            MainModel
	 */
	public StageResultVC(GameCanvas canvas, MainModel model) {
		this.canvas = canvas;
		this.model = model;
	}

	@Override
	public void start() {
		// TODO Auto-generated method stub

	}

	@Override
	public void paint(GC gc) {
		int highScore = 20000;
		int stageNumber = 1;
		int player1Score = 1000;
		Font.drawString(gc, 8 * 16, 3 * 16, "HI-SCORE", Palette.RED);
		Font.drawString(gc, 19 * 16, 3 * 16, String.format("%5d", highScore), Palette.ORANGE);
		Font.drawString(gc, 12 * 16, 5 * 16, "STAGE");
		Font.drawString(gc, 18 * 16, 5 * 16, String.format("%2d", stageNumber));
		Font.drawString(gc, 3 * 16, 7 * 16, "I-PLAYER", Palette.RED);
		Font.drawString(gc, 6 * 16, 9 * 16, String.format("%5d", player1Score), Palette.ORANGE);

		int kc11 = model.getKillCount(1, 1);
		int kc12 = model.getKillCount(1, 2);
		int kc13 = model.getKillCount(1, 3);
		int kc14 = model.getKillCount(1, 4);

		int kc21 = model.getKillCount(2, 1);
		int kc22 = model.getKillCount(2, 2);
		int kc23 = model.getKillCount(2, 3);
		int kc24 = model.getKillCount(2, 4);

		x(gc, 0, 2);
		x(gc, 1, 3);
		x(gc, 2, 5);
		x(gc, 3, 7);

		gc.fillRectangle(12 * 16, 364, 8 * 16, 4);
		Font.drawString(gc, 6 * 16, 23 * 16, "TOTAL");
	}

	/**
	 * まだどういう機能を持たせたらいいのかわからない。
	 * 
	 * @param gc
	 *            GC
	 * @param computerTankKind
	 *            x
	 * @param count
	 *            x
	 */
	private static void x(GC gc, int computerTankKind, int count) {
		int y = computerTankKind * 3 * 16 + 192;
		Font.drawString(gc, 80, y, String.format("%2d PTS %2d<", count, count * (computerTankKind + 1)));
		Sprite.draw(gc, 240, y, computerTankKind * 8 + 34);
	}

	@Override
	public void keyPressed(KeyEvent e) {
		if (progress < 4) {
			progress++;
			canvas.redraw();
		} else {
			canvas.startStageSelect();
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {
	}

}
