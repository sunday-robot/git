package battlecity.model;

/**
 * ステージデータのクラス
 */
public final class StageData {
	/** 地形データ */
	public char[][] bg = new char[26][26];
	/** 敵戦車の登場順序 */
	public ComputerTankSpecification[] enemyTankSequence = new ComputerTankSpecification[20];
	/** 敵戦車がアイテムを持っているかどうか */
	public boolean[] enemyTankHasItemSequence = new boolean[20];
}
