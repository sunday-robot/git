using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuruKuru
{
    /// <summary>
    /// 一枚一枚の花びらを表すクラス
    /// </summary>
    class Petal
    {
        /// <summary>
        /// 花びらが一段下の皿に落ちるまでにかかる時間
        /// </summary>
        const int _FallTime = 10;

        /// <summary>
        /// 花びらの色
        /// </summary>
        public PetalColor Color;

        // ↓このクラスのメンバーではないかも。
        /// <summary>
        /// 花びらが一段下の皿に落ちるまでの残り時間
        /// </summary>
        int _FallingRemainTime;
    }
}
