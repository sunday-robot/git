package battlecity.model;

import java.awt.Point;

/**
 * ゲーム全体に影響する定数群 <br/>
 * (複数のクラスで共有しなければならない定数群)
 * 
 * @author akiyama
 * 
 */
public class Constants {
    /** FPS */
    public static final int FPS = 30;

    /** ステージのサイズ(ステージサイズは正方形で、1単位は16ドット単位。で回りの枠も含めたもの) */
    public static final int STAGE_SIZE = 1 + 26 + 1; // 内部処理様に、ステージの上下左右に1マス追加している

    /** ゲームオーバーになってから、実際に終了するまでの時間 */
    public static final int MAX_END_COUNT = (FPS * 4);

    /** "GAME OVER"を表示している時間 */
    public static final int GAME_OVER_TIME = MAX_END_COUNT;

    // 以下プレイヤー戦車、コンピューター戦車、司令部に共通するもの

    /** 戦車、司令部が爆発している時間 */
    public static final int BURNING_TIME = (FPS / 4);

    // 以下プレイヤー戦車、コンピューター戦車に共通するもの

    /** 戦車登場時、ピカピカしている時間 */
    public static final int BORN_TIME = (FPS * 1);

    /** 弾を打った後、次のを発射するまでの待ち時間 */
    public static final int SHOOT_INTERVAL_TIME = (FPS / 4);

    // 以下プレイヤー戦車に関するもの

    /** 1upする点数(を100で割ったもの) */
    public static final int ONE_UP_THRESHOLD = 200;

    /** 氷の上に乗って、スリップしている時間 */
    public static final int SRIP_TIME = (FPS / 2);

    /** 相討ちされて動けずにいる時間 */
    public static final int PARARIZE_TIME = (FPS * 9 / 2);

    /** プレイヤー戦車が登場したときの */
    public static final int BARRIER_TIME2 = (FPS * 3);

    /** プレイヤー戦車の出現位置 */
    public static final Point[] INITIAL_PLAYER_TANK_POSITIONS = {
	    new Point((STAGE_SIZE / 2 - 4) * 16, (STAGE_SIZE - 3) * 16),
	    new Point((STAGE_SIZE / 2 + 2) * 16, (STAGE_SIZE - 3) * 16) };

    // 以下コンピューター戦車に関するもの

    /** 1Pゲーム時に画面に登場するコンピューター戦車の最大数 */
    public static final int MAX_COMPUTER_TANK_COUNT_IN_1P_GAME = 4;

    /** 2Pゲーム時に画面に登場するコンピューター戦車の最大数 */
    public static final int MAX_COMPUTER_TANK_COUNT_IN_2P_GAME = 6;

    /** コンピューター戦車が登場する間隔 */
    public static final int GENERATE_INTERVAL = FPS * 3;

    /** コンピュータ戦車の初期位置 */
    public static final Point[] INITIAL_COMPUTER_TANK_POSITIONS = {
	    new Point(16, 16),
	    new Point((Constants.STAGE_SIZE / 2 - 1) * 16, 16),
	    new Point((Constants.STAGE_SIZE - 3) * 16, 16) };

    /** コンピューター戦車が死んだあと得点を表示している時間 */
    public static final int DISP_POINT_TIME = (FPS * 1);

    // 以下弾に関するもの

    /** 弾が爆発している時間 */
    public static final int BURST_TIME2 = (FPS / 8);

    // 以下アイテムに関するもの

    /** 司令部がコンクリートの壁で守られている時間 */
    public static final int BASE_GUARD_TIME = FPS * 43 / 2;

    /** ストップウォッチアイテムの効果持続時間(コンピューター戦車が動けずにいる時間 ) */
    public static final int COMP_TANK_PARARIZE_TIME = (FPS * 10);

    /** ??? */
    public static final int BARRIER_TIME = (FPS * 10);

}
