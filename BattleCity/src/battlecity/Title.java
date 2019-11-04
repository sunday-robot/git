package battlecity;

/**
 * タイトル画面
 * 
 * @author akiyama
 * 
 */
public class Title {
    /** */
    private static int cursor;

    /**
     * 
     */
    private static void draw() {
    }

    /**
     * 
     * @return 0: 1 player mode<br>
     *         1: 2 Players mode<br>
     *         2: Quit<br>
     *         3: View High Scores
     */
    static int show() {
	// int selected = 0;

	// music_play(BGM_TITLE, 1);
	draw();
	// set_key_mode(KM_SELECT);
	/*
	 * do { KeyCode key;
	 * 
	 * while (!kq_deq(&key)) ; key &= ~K_P2; // 1Pでも2Pでもどちらも同じ扱いにする。 if (key
	 * <= K_LEFT) move_cursor(key); // 上下左右の方向キーの場合 else if (key <= K_B)
	 * selected = 1; // ゲームパッドのAボタン、あるいはBボタンの場合は決定を意味する。 else {
	 * set_cursor(2); // ESCあるいは'Q'キーが押された場合、カーソル位置を2にする。 selected = 1; } }
	 * while (!selected);
	 */
	// sound_out(EFS_DETERM);
	return cursor;
    }

}
