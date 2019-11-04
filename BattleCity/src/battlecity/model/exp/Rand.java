package battlecity.model.exp;

import java.util.Random;

/**
 * 乱数のクラス
 * 
 * @author akiyama
 * 
 */
public class Rand {
    /** 乱数生成器 */
    private static Random random = new Random();

    /**
     * 指定された範囲内の乱数を返す
     * 
     * @param width
     *            乱数の最大値 + 1
     * @return 乱数
     */
    public static int get(int width) {
	return (int) (random.nextLong() % width);
    }
}
