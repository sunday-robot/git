package battlecity.model;

import battlecity.Status;
import battlecity.exp.GunHit;
import battlecity.exp.Hits;

/**
 * プレイヤー戦車
 * 
 * @author akiyama
 * 
 */
public class PlayerTank extends Tank {
    /** FIXME:PlayerTankがgameModelを参照しないほうが良いはず。 */
    // private GameModel gameModel;

    /** 破壊されたかどうか(???) */
    // private boolean destroyed;

    // int tankType; // プレイヤー戦車のレベルと思われる

    /** スコア */
    int score;

    /** 撃たれたかどうか */
    private Hits hits;

    /** バリアの残り時間 */
    private int barrierTime;

    /** 残りの戦車の数(画面に登場している戦車は除く) */
    public int leftTankCount;

    /**
     * コンストラクタ
     * 
     * @param gameGamen
     *            GameModel
     */
    public PlayerTank(GameMaster gameGamen) {
	// this.gameModel = gameGamen;
    }

    /**
     * 初期化する???
     * 
     * @param isActive
     *            ???
     */
    public final void initialize(boolean isActive) {
	if (isActive) {
	    // destroyed = false;
	    // tankType = -1; // ???初期値はどうする?
	    leftTankCount = 3;
	    score = 0;
	    // } else {
	    // destroyed = true;
	}
    }

    /**
     * スコアを加算する FIXME : これはGameMasterに移すもの。
     * 
     * @param p
     *            ???
     */
    private void addScore(int p) {
	if (p < 0 || p > 4) {
	    throw new Error("exception");
	}
	hits.num[p]++;
	int a = this.score / Constants.ONE_UP_THRESHOLD;
	this.score += (p + 1);
	int b = this.score / Constants.ONE_UP_THRESHOLD;
	if (a != b) {
	    this.leftTankCount++;
	    // sound_out(EFS_ONE_UP);
	    // // print_rest_player_tank(tn,
	    // ++GameModel.playerTanks[tn].num_of_tank);
	}
    }

    /**
     * パワーアップさせる(???)
     */
    private void powerUp() {
	// this.type = tank_type[this.type].option.next_type;
	// set_tank_type(this);
	// // change_pattern(&this.sprite, tank_type[this.type].pattern_num, 0);
    }

    // 戦車を現在向いている方向に１ドット進める、動けなかったら０を返す
    @Override
    protected final boolean moveSub() {
	if (!super.moveSub())
	    return false;
	/*
	 * 
	 * //
	 * FIXME:　以下のアイテムを取得する処理などは、PlayerTankクラスではなく、ゲームを進行させ、各種判定を行うマネージャの仕事とすべきだ
	 * 。 // アイテムのチェック ItemType itemType = gameModel.item
	 * .getItemType(this.getX(), this.getY()); if (itemType ==
	 * ItemType.NONE) return true;
	 * 
	 * addScore(4); switch (itemType) { case BOMB: // 爆弾、得点は入らないのでこの場で処理する
	 * for (Tank t : tanks) { t.die(); } break; case SHOVEL: //
	 * 司令部を一定時間コンクリートの壁でガードすると // ともに壁の修理もする。 // FIXME:
	 * 全体の制御を見直し、以下の処理を本クラスから出すこと。 gameModel.guardBase(); break; case STAR:
	 * // 戦車のパワーアップ powerUp(); break; case TANK: // 1up // // one_up();
	 * break; case HELMET: this.barrierTime = Constants.BARRIER_TIME; break;
	 * case STOP_WATCH: ComputerTank.beParalyzed(); break; default: throw
	 * new Error("move_tank_sub():???? アイテムの種類が異常です " +
	 * itemType.toString()); } if (itemType != ItemType.BOMB || itemType !=
	 * ItemType.TANK) { // // sound_out(EFS_GET_ITEM); }
	 * gameModel.item.setStatus(Status.DISP_POINT);
	 * gameModel.item.setTimer(Constants.DISP_POINT_TIME); // //必要ないはず
	 * item.setType(0); // // change_pattern(&item.sprite, PAT_POINT + 4,
	 * 2);
	 */
	return true;
    }

    @Override
    final GunHit beShot(boolean isPlayerBullet) {
	GunHit r = GunHit.GH_NOTBREAK;

	if (barrierTime > 0)
	    return GunHit.GH_NOTBREAK;
	if (isPlayerBullet) {
	    // プレイヤー戦車同士の相撃ちの場合は、撃たれた側が一定時間動けなくなる
	    miscTime = Constants.PARARIZE_TIME;
	    return GunHit.GH_NOTBREAK;
	}
	if (decreaseHitPoint() == 0) {
	    r = GunHit.GH_TBREAK;
	    // } else {
	    // // change_pattern(&sprite, tank_type[dest_t.type].pattern_num +
	    // (dest_t.hit_point - 1) * 4, 0);
	}
	return r;
    }

    @Override
    public final Status control() {
	return null;
    }
}
