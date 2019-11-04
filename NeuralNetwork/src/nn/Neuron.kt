package nn

/**
 * @property weights 重み(樹状突起の感度)
 * @property output 出力(軸索の値)
 */
class Neuron(val weights: List<Double>, private var output: Double) {
    /**
     * @param inputCount 入力値の数(＝樹状突起の数)
     */
    constructor(inputCount: Int) : this(List<Double>(inputCount, {1.0}), 0.0) {
    }

    /**
     * 推論
     * @param inputs 入力(手前のレイヤーのニューロンの出力)
     * @return 出力(軸索の値)
     */
    fun infer(inputs: List<Double>): Double {
        output = inputs.zip(weights).sumByDouble { it.first * it.second }
        return output
    }

    /**
     * @return 出力(軸索の値)
     */
    fun getOutput() = output
}
