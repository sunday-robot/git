class Updater {
    /**
     * レイヤー数
     */
    private val L = 3

    /**
     * 学習率
     */
    private val ROH = 0.01

    fun updateWeight() {

    }

    private fun updateWeight(w: Array<Array<Array<Double>>>, l: Int, i: Int, j: Int) {
        w[l][i][j] -= -ROH * delta(l, i) * o(l - 1, j)
    }

    /**
     * @param l レイヤーインデックス
     * @param i ユニットインデックス
     * @return δ
     */
    private fun delta(l: Int, i: Int): Double {
        return if (l == L) {
            (o(l, i) - t(i)) * fdash(u(l, i))
        } else {
            var sum = 0.0
            for (k in 1..unitCount(l + 1)) {
                sum += delta(l + 1, k) * w(l + 1, k, i) * fdash(u(l, i))
            }
            sum
        }
    }

    /**
     * @param l レイヤーインデックス
     * @return レイヤー内のユニット数
     */
    private fun unitCount(l: Int): Int {
        return 1
    }

    /**
     * @param i 出力層のユニットインデックス
     * @return 教師値(正解値)
     */
    private fun t(i: Int): Double {
        return 0.0
    }

    /**
     * @param l レイヤーインデックス
     * @param i ユニットインデックス
     * @return ユニットの活性化関数適用前の値 (=入力値 * 重み値 + bias)
     */
    private fun u(l: Int, i: Int): Double {
        return 0.0
    }

    /**
     * @param l レイヤーインデックス
     * @param i ユニットインデックス
     * @return ユニットの出力値（=活性化関数(入力値 * 重み値 + bias))
     */
    private fun o(l: Int, i: Int): Double {
        return 0.0
    }

    /**
     * @param l レイヤーインデックス
     * @param i ユニットインデックス
     * @param j ユニットの重み値インデックス
     * @return　重み値
     */
    private fun w(l: Int, i: Int, j: Int): Double {
        return 0.0
    }

    /**
     * ?の微分値
     */
    private fun fdash(s: Double): Double {
        return 0.0
    }
}
