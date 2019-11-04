fun main() {
    val ary = arrayOf(1, 2, 3, 4, 5, 6)
    val ary2to4 = ary. sliceArray(IntRange(2, 4))

    print(ary)
    ary[2] *=10
    ary2to4[2] *=10
    print(ary2to4)
}