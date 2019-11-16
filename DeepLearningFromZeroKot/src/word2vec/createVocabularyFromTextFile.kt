package word2vec

fun createVocabularyFromTextFile(filePath: String): Vocabulary {
    val words = createWordsFromTextFile(filePath)
    return wordsToVocabulary(words)
}

fun main(args: Array<String>) {
    args.forEach {
        val vocabulary = createVocabularyFromTextFile(it)
        (0 until vocabulary.size).forEach {
            val w = vocabulary.word(it)
            println("${it}:${w}")
        }
    }
}
