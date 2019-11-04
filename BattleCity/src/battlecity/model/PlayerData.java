package battlecity.model;

/**
 * プレイヤーの情報
 */
public class PlayerData {
    /** 得点 */
    private int score;

    /** 戦車の残りの数 */
    // TODO 残りとは、控室にいる戦車の数なのか、決める必要あり。
    private int leftTankCount;

    /** 戦車のレベル(0~3) */
    private int tankLevel;

    /**
     * @return 戦車の残りの数
     */
    public int getLeftTankCount() {
	return leftTankCount;
    }

    /**
     * @param leftTankCount
     *            戦車の残りの数
     */
    public void setLeftTankCount(int leftTankCount) {
	this.leftTankCount = leftTankCount;
    }

    /**
     * @return the score
     */
    public int getScore() {
	return score;
    }

    /**
     * @param score
     *            the score to set
     */
    public void setScore(int score) {
	this.score = score;
    }

    /**
     * @return the tankLevel
     */
    public int getTankLevel() {
	return tankLevel;
    }

    /**
     * @param tankLevel the tankLevel to set
     */
    public void setTankLevel(int tankLevel) {
	this.tankLevel = tankLevel;
    }
}
