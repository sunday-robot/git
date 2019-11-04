package nn

/**
 * ニューラルネットワークの1レイヤー
 * @property neurons ニューロンのリスト
 */
class NeuralLayer(val neurons: List<Neuron>) {
    constructor(inputCount: Int, neuronCount: Int) : this(List<Neuron>(inputCount, {})) {

    }

    /**
     * 推論
     * @param inputs 入力(手前のレイヤーのニューロンの出力)
     * @return 出力のリスト(軸索の値)
     */
    fun infer(input: List<Double>): List<Double> = neurons. map { it.infer(input) }

    /**
     * @return 出力のリスト(軸索の値)
     */
    fun getOutputs() = neurons.map { it.getOutput() }
}