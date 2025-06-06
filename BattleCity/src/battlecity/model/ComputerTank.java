package battlecity.model;

import java.awt.Point;

import battlecity.Status;
import battlecity.exp.EnvInfo;
import battlecity.exp.GunHit;

/**
 * コンピューター戦車
 * 
 * @author akiyama
 * 
 */
public class ComputerTank extends Tank {
    /** 進行の障害物を確認する座標 */
    private static final Point[][] CHECK_POINTS = {
	    { new Point(0, 32), new Point(16, 32) },
	    { new Point(32, 0), new Point(32, 16) },
	    { new Point(0, -1), new Point(16, -1) },
	    { new Point(-1, 0), new Point(-1, 16) } };

    /** 麻痺時間 */
    private static int paralyzedTime;

    /** アイテムを持っていたらtrue(どのアイテムかはアイテムを出す際にランダムで決める) */
    private boolean hasItem;

    /***/
    // private GameModel gameModel;

    /**
     * コンストラクタ
     * 
     * @param gameGamen
     *            GameModel
     */
    public ComputerTank(GameMaster gameGamen) {
	// this.gameModel = gameGamen;
    }

    /**
     * 一定時間、全てのコンピューター戦車を麻痺状態(動けず、弾を撃つこともできない状態)にする。
     * プレイヤー戦車が、ストップウォッチアイテムをゲットした際にこのメソッドが呼ばれる。
     */
    public static void beParalyzed() {
	paralyzedTime = Constants.COMP_TANK_PARARIZE_TIME;
    }

    /**
     * コンピューター戦車の麻痺時間のコントロール()
     */
    public static void controlPararizeTimer() {
	if (paralyzedTime > 0)
	    paralyzedTime--;
    }

    // private int disp_point_flg; // 爆発終了後得点を表示するかどうかのフラグ

    /**
     * コンピューター戦車(敵戦車)をステージ(ゲーム画面)に登場させる
     * 
     * @param x
     *            X座標(左隅、真ん中、右隅のいずれかである。)
     * @param y
     *            Y座標(いつも一定なのだが、あったほうがわかりやすいかもしれないと思いあえて。)
     * @param dir
     *            向き(こちらもいつも下向きだったような気がするが…)
     * @param tankType
     *            (通常、高速、高速弾、重装甲の4種類だったかな?)
     * @param hasItem
     *            (アイテムを持っているかどうか、持っている場合、戦車の色が赤になるんだったかな?)
     */
    public final void spawn(int x, int y, int dir,
	    ComputerTankSpecification tankType, boolean hasItem) {
	super.spawn(x, y, dir, tankType);
	this.hasItem = hasItem;
	// disp_point_flg = 0;
    }

    @Override
    public final GunHit beShot(boolean isPlayerBullet) {
	GunHit r = GunHit.GH_NOTBREAK;

	// FIXME: 以下の様な処理は、ゲームマスターが行うべきと思われる。
	/*
	 * if (hasItem) { // アイテムを持っていたらそれを出す(死んだらアイテムを出すのではなく、はじめに撃たれたときに出す。)
	 * hasItem = false; gameModel.spawnItem(); } if (decreaseHitPoint() ==
	 * 0) { r = GunHit.GH_TBREAK; if (isPlayerBullet) { //
	 * add_score(t->number, tank_type[dest_t->type].option.point); //
	 * disp_point_flg = 1; } // } else { // change_pattern(&sprite,
	 * tank_type[dest_t->type].pattern_num + // (dest_t->hit_point - 1) * 4,
	 * 0); }
	 */
	return r;
    }

    /***/
    private static EnvInfo[] table = { EnvInfo.NOTHING, EnvInfo.RENGA,
	    EnvInfo.UNTHROUABLE, EnvInfo.UNTHROUABLE };

    /**
     * 周囲の障害物の情報を返す (コンピューター戦車用のメソッド)
     * 
     * @return 周囲の障害物の情報
     */
    final EnvInfo[] getTankEnvInfo() {
	EnvInfo[] ei = new EnvInfo[4];

	int fx;
	int fy;

	if ((getDirection() & 1) != 0) {
	    // 戦車が横向き
	    fx = adjustPotision(getX());
	    fy = getY();
	} else {
	    // 戦車が縦向き
	    fx = getX();
	    fy = adjustPotision(getY());
	}
	for (int i = 0; i < 4; i++) {
	    int e = 0;
	    for (int j = 0; j < 2; j++) {
		int cx = (fx + CHECK_POINTS[i][j].x) / 16;
		int cy = (fy + CHECK_POINTS[i][j].y) / 16;
		switch (vvram.cells[cy][cx].type) {
		case RENGA:
		    e |= 1;
		    break;
		case CONCRETE:
		case RIVER:
		case FRAME:
		    e |= 2;
		    break;
		default:
		    break;
		}
	    }
	    ei[i] = table[e];
	}
	return ei;
    }

    @Override
    public final Status control() {
	// TODO Auto-generated method stub
	return null;
    }
}
