package word2vec

import common.toOnehot

fun main() {
    val window_size = 1
    val hidden_size = 5
    val batch_size = 3
    val max_epoch = 1000

    val text = "You say goodbye and I say hello."

    val words = stringToWords(text)
    val vocabulary = wordsToVocabulary(words)
    val corpus = createCorpus(words, vocabulary)
    val vocab_size = vocabulary.size
    val targetAndContextList = createTargetAndContextList(corpus, window_size)
    val targetList = mutableListOf<Array<Float>>()   // 「one-hot形式のターゲット」のリスト
    val contextList = mutableListOf<List<Array<Float>>>()   // 「one-hot形式のコンテキスト」のリスト
    targetAndContextList.forEach {
        targetList.add(toOnehot(it.target, vocab_size))
        contextList.add(List<Array<Float>>(window_size * 2) { j ->
            toOnehot(it.context[j], vocab_size)
        })
    }

    println(targetList)
    println(contextList)

//    model = SimpleCBOW(vocab_size, hidden_size)
//    val model = createSimpleSkipGram(vocab_size, hidden_size)
//    val optimizer = Adam()
//    val trainer = Trainer(model, optimizer)
//
//    trainer.fit(contexts, target, max_epoch, batch_size)
//    trainer.plot()
//
//    val word_vecs = model.word_vecs
//    for word_id, word in id_to_word.items():
//    print(word, word_vecs[word_id])
}
