namespace EasyPhisicsDotNet
{
    /// ペア
    public class EpxPair
    {
        /// <summary>
        /// キー(剛体Aのインデックスと、剛体Bのインデックスから生成する)
        /// </summary>
        private int _Key;

        /// <summary>
        /// 剛体Aのインデックス
        /// </summary>
        public int rigidBodyA;

        /// <summary>
        /// 剛体Bのインデックス
        /// </summary>
        public int rigidBodyB;

        /// <summary>
        /// 衝突情報
        /// </summary>
        public EpxContact Contact;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public EpxPair(int i, int j)
        {
            if (i < j)
            {
                rigidBodyA = i;
                rigidBodyB = j;
            }
            else
            {
                rigidBodyA = j;
                rigidBodyB = i;
            }
            _Key = rigidBodyB << 16 | rigidBodyA;
            Contact = null;
        }

        /// <summary>
        /// ソート用のキー(何のために並べ替えを行うのかは不明→新旧二つの配列の差を見るために使用するものらしい)
        /// </summary>
        public int Key
        {
            get
            {
                return _Key;
            }
        }
    }
}
