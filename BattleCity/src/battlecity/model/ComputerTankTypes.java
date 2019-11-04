package battlecity.model;

/**
 * コンピューター戦車のタイプ
 */
public class ComputerTankTypes {
    /** タイプA(基本) */
    public static final ComputerTankSpecification A = new ComputerTankSpecification(
	    2, 1, 1, 4, false, 0, 32, new int[] { 128, 16, 2 });;
    /** タイプB(高速移動。移動速度が2倍) */
    public static final ComputerTankSpecification B = new ComputerTankSpecification(
	    4, 1, 1, 4, false, 1, 32, new int[] { 128, 16, 2 });
    /** タイプC(高速弾。弾の速度が2倍だが、発射頻度は1/2) */
    public static final ComputerTankSpecification C = new ComputerTankSpecification(
	    2, 1, 1, 8, false, 2, 16, new int[] { 128, 16, 2 });
    /** タイプD(重装甲。4発当てないと倒せない) */
    public static final ComputerTankSpecification D = new ComputerTankSpecification(
	    2, 4, 1, 4, false, 3, 32, new int[] { 128, 16, 2 });
    /** ??? */
    static final int PAT_COMP_TANK = 3;
}
