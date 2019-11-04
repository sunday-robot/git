package battlecity.exp;

/**
 * 砲弾の移動結果コード???
 * 
 * @author akiyama
 * 
 */
public enum GunHit {
    /** 何もなく進んだ */
    GH_NOTHIT(0),
    /** 別の砲弾とぶつかった??? */
    GH_GUN(1),
    /** 壁にあたった??? */
    GH_WBREAK(2),
    /** ??? */
    GH_NOTBREAK(4),
    /** 戦車にあたった??? */
    GH_TBREAK(8);

    /** 値 */
    private int value;

    /**
     * コンストラクタ
     * 
     * @param value
     *            値
     */
    private GunHit(int value) {
	this.value = value;
    }
}
