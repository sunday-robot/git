package battlecity.view;

import org.eclipse.swt.events.KeyListener;
import org.eclipse.swt.graphics.GC;

/**
 * タイトル画面、ステージ選択画面、ゲーム画面などのインターフェイス
 * 
 * MVCのVC部分なので、VC…
 */
public interface VC extends KeyListener {
	/**
	 * 画面切り替え時
	 * 
	 * 各種タイマーのリセットや、画面描画などを行う。
	 */
	void start();

	/**
	 * 描画を行う。
	 * 
	 * @param gc
	 *            {@link GC}
	 */
	void paint(GC gc);
}
