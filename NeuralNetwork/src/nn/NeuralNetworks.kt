package nn

/**
 * ニューラルネットワークの1レイヤー
 * @property neurons ニューロンのリスト
 */
class NeuralNetworks(val layers: List<NeuralLayer>) {
    /**
     * 推論
     * @param inputs 入力(手前のレイヤーのニューロンの出力)
     * @return 出力のリスト(軸索の値)
     */
    fun infer(input: List<Double>): List<Double> {
        var values = input
        for (layer in layers) {
            values = layer.infer(values)
        }
        return values
    }

    /**
     * @return 出力のリスト(軸索の値)
     */
    fun getOutputs(): List<Double> {
        return layers[layers.size - 1].getOutputs()
    }
}
