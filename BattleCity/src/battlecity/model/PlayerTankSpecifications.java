package battlecity.model;

/**
 * プレイヤー戦車の種類
 * 
 * @author akiyama
 */
public class PlayerTankSpecifications extends TankSpecification {
    /** 次にどのタイプになるか */
    public final PlayerTankSpecifications nextType;

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
     * @param nextType
     *            次にどのタイプになるか
     */
    public PlayerTankSpecifications(int speed, int hitPoint, int gunCount,
	    int gunSpeed, boolean isHyperGun, PlayerTankSpecifications nextType) {
	super(speed, hitPoint, gunCount, gunSpeed, isHyperGun);
	this.nextType = nextType;
    }
}
