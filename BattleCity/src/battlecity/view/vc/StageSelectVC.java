package battlecity.view.vc;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.KeyEvent;
import org.eclipse.swt.graphics.GC;

import battlecity.model.MainModel;
import battlecity.view.GameCanvas;
import battlecity.view.VC;
import battlecity.view.resource.Font;

/**
 * ステージ選択画面。
 * 
 * ・ENTERキー押下で選択されたステージを開始する。<br>
 * ・カーソルキー上下でステージを選択する<br>
 * ・タイムアウトはなし<br>
 */
public class StageSelectVC implements VC {
	/** 描画対象、イベント発生元のGameCanvas */
	private GameCanvas canvas;

	/** モデル */
	private MainModel model;

	/** ステージ番号(1～) */
	private int stageNumber = 1;

	/**
	 * コンストラクタ
	 * 
	 * @param canvas
	 *            GameCanvas
	 * @param mainModel
	 *            MainModel
	 */
	public StageSelectVC(GameCanvas canvas, MainModel mainModel) {
		this.canvas = canvas;
		this.model = mainModel;

		// BGMスタート
	}

	@Override
	public void paint(GC gc) {
		gc.setBackground(gc.getDevice().getSystemColor(SWT.COLOR_GRAY));
		gc.fillRectangle(canvas.getClientArea());

		String s;
		s = String.format("STAGE %2d", stageNumber);
		Font.drawString(gc, 16 * 12, 16 * 14, s);
	}

	@Override
	public void keyReleased(KeyEvent e) {
	}

	@Override
	public void keyPressed(KeyEvent e) {
		switch (e.keyCode) {
		case SWT.ARROW_UP:
			if (stageNumber == 1) {
				stageNumber = model.getMaximumStageNumber();
			} else {
				stageNumber--;
			}
			canvas.redraw();
			break;
		case SWT.ARROW_DOWN:
			if (stageNumber == model.getMaximumStageNumber()) {
				stageNumber = 1;
			} else {
				stageNumber++;
			}
			canvas.redraw();
			break;
		case SWT.CR:
			canvas.startStage(stageNumber);
			break;
		}
	}

	@Override
	public void start() {
		// TODO Auto-generated method stub

	}
}
