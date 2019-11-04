package battlecity.model;

/**
 * コンピューター戦車スペック
 * 
 * @author akiyama
 * 
 */
public final class ComputerTankSpecification extends TankSpecification {
    /**
     * 得点となっているが、これが直接得点となるのではない。 ステージ終了後に、得点の集計をするので、ゲーム中はどのタイプの戦車を
     * 何台やっつけたか、ということを表に登録する。この要素はこの表(int型で サイズ4の配列)の何番目なのかを表している。
     */
    private final int point; // 得点

    /** 弾を撃つ確率(1/rate) */
    private final int shootRate;

    /** 方向を変更する確率(1/rate) */
    private final int[] dirChangeRate = new int[3];

    /**
     * コンストラクタ
     * 
     * @param speed
     *            スピード
     * @param hitPoint
     *            ヒットポイント
     * @param maxGunCount
     *            同時に画面上に存在しうる砲弾の数
     * @param gunSpeed
     *            砲弾のスピード
     * @param isHyperGun
     *            強化された砲弾かどうか
     * @param point
     *            得点
     * @param shootRate
     *            砲弾の発射間隔
     * @param dirChangeRate
     *            方向変更の確率
     */
    ComputerTankSpecification(int speed, int hitPoint, int maxGunCount,
	    int gunSpeed, boolean isHyperGun, int point, int shootRate,
	    int[/* 3 */] dirChangeRate) {
	super(speed, hitPoint, maxGunCount, gunSpeed, isHyperGun);
	this.point = point;
	this.shootRate = shootRate;
	this.dirChangeRate[0] = dirChangeRate[0];
	this.dirChangeRate[1] = dirChangeRate[1];
	this.dirChangeRate[2] = dirChangeRate[2];
    }

    /**
     * @return 得点?
     */
    public int getPoint() {
	return point;
    }

    /**
     * @return 発射頻度
     */
    public int getShootRate() {
	return shootRate;
    }
}
