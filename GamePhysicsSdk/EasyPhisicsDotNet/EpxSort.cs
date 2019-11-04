namespace EasyPhisicsDotNet
{
    class EpxSort
    {
        public static void execute(EpxPair[] data, int dataCount, EpxPair[] work)
        {
            sort(data, 0, dataCount, work);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="d">配列</param>
        /// <param name="index">ソート対象データの開始位置</param>
        /// <param name="count">ソート対象データの個数</param>
        /// <param name="buff">作業バッファ(配列と同じサイズ以上であること)</param>
        private static void sort(EpxPair[] d, int index, int count, EpxPair[] buff)
        {
            int n1 = count >> 1;    // ソート対象データの前半の個数
            int n2 = count - n1;    // 後半の個数

            // 前半をソートする
            if (n1 > 1)
                sort(d, index, n1, buff);

            // 後半をソートする
            if (n2 > 1)
                sort(d, index + n1, n2, buff);

            // 前半と後半をマージする。
            epxMergeTwoBuffers(d, index, n2, index + n1, n2, buff);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="d">配列</param>
        /// <param name="index1">前半のデータの開始位置</param>
        /// <param name="count1">前半のデータの個数</param>
        /// <param name="index2">後半のデータの開始位置</param>
        /// <param name="count2">後半のデータの個数</param>
        /// <param name="buff">作業バッファ</param>
        private static void epxMergeTwoBuffers(EpxPair[] d, int index1, int count1, int index2, int count2, EpxPair[] buff)
        {
            int i = 0;
            int j = 0;

            while ((i < count1) && (j < count2))
            {
                if (d[index1 + i].Key < d[index2 + j].Key)
                    buff[i + j] = d[index1 + i++];
                else
                    buff[i + j] = d[index2 + j++];
            }

            while (i < count1)
                buff[i + j] = d[index1 + i++];
            while (j < count2)
                buff[i + j] = d[index2 + j++];

            for (int k = 0; k < (count1+ count2); k++)
                d[index1 + k] = buff[k];
        }
    }
}
