package battlecity.types;

import battlecity.model.exp.Rand;

/**
 * アイテムの種類と、出現確率??? FIXME:まとめ方が悪い(なんのクラスなのか簡潔に説明できない)ので再考が必要
 * 
 * @author akiyama
 * 
 */
public enum ItemType {
    /** 画面にいる敵を全て破壊する */
    BOMB(3),
    /** 司令部にバリアを張る */
    SHOVEL(3),
    /** プレイヤー戦車を1段階パワーアップさせる */
    STAR(2),
    /** プレイヤー戦車の残機を1増やす */
    TANK(1),
    /** 司令部の周囲のレンガを修復し、一定時間コンクリートのブロックでカバーする */
    HELMET(4),
    /** 画面にいる敵を一時的に麻痺させる(動けないし、弾を撃つこともできない)(既に撃たれた弾はそのまま動き続ける?) */
    STOP_WATCH(2), NONE(0);

    /** 出現確率の分母 */
    private static int weightSum = 0;

    /** 各アイテムの出現確率(分子) */
    private int weight;

    /**
     * コンストラクタ
     * 
     * @param weight
     *            アイテムの出現確率の分子
     */
    private ItemType(int weight) {
	this.weight = weight;
    }

    /**
     * ランダムにアイテムを選択する。 完全にランダムではなく、アイテムごとに重みをつけているので、偏りがある。
     * 
     * @return 選択されたアイテム
     */
    public static ItemType selectRandomly() {
	if (weightSum == 0) {
	    weightSum = BOMB.weight + SHOVEL.weight + STAR.weight + TANK.weight
		    + HELMET.weight + STOP_WATCH.weight;
	}
	int r = Rand.get(weightSum);
	r -= BOMB.weight;
	if (r < 0)
	    return BOMB;
	r -= SHOVEL.weight;
	if (r < 0)
	    return SHOVEL;
	r -= STAR.weight;
	if (r < 0)
	    return STAR;
	r -= TANK.weight;
	if (r < 0)
	    return TANK;
	r -= HELMET.weight;
	if (r < 0)
	    return HELMET;
	return STOP_WATCH;
    }
}
