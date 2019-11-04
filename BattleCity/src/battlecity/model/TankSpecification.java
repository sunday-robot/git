package battlecity.model;

/**
 * 戦車のスペックを示すもの。(必要かなあ???)
 */
public abstract class TankSpecification {
    /** スピード */
    private final int speed;

    /** ヒットポイント */
    private final int hitPoint;

    /** 一画面中に出現させられる砲弾の数 */
    private final int gunCount;

    /** 砲弾のスピード */
    private final int gunSpeed;

    /** 威力の強大な砲弾か(???) */
    private final boolean isHyperGun;

    /**
     * コンストラクタ
     * 
     * @param speed
     *            スピード
     * @param hitPoint
     *            ヒットポイント
     * @param gunCount
     *            一画面中に出現させられる砲弾の数
     * @param gunSpeed
     *            砲弾のスピード
     * @param isHyperGun
     *            威力の強大な砲弾か(???)
     */
    public TankSpecification(int speed, int hitPoint, int gunCount,
	    int gunSpeed, boolean isHyperGun) {
	this.speed = speed;
	this.hitPoint = hitPoint;
	this.gunCount = gunCount;
	this.gunSpeed = gunSpeed;
	this.isHyperGun = isHyperGun;
    }

    /**
     * @return スピード
     */
    public int getSpeed() {
	return speed;
    }

    /**
     * @return ヒットポイント
     */
    public int getHitPoint() {
	return hitPoint;
    }

    /**
     * @return 一画面中に出現させられる砲弾の数
     */
    public int getGunCount() {
	return gunCount;
    }

    /**
     * @return 砲弾のスピード
     */
    public int getGunSpeed() {
	return gunSpeed;
    }

    /**
     * @return 威力の強大な砲弾か
     */
    public boolean isHyperGun() {
	return isHyperGun;
    }

}
