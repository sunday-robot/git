using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuruKuru
{
    /// <summary>
    /// ゲームのモデル(ビジネスロジックとデータ)
    /// </summary>
    public class Game
    {
        private static int _PetalDishColumnCount = 10;
        private static int _PetalDishRowCount = 9;   // 一番上の行の上は画面には下1/3程度しか表示されない。

        private PetalDish[,] _PetalDishes = new PetalDish[_PetalDishRowCount, _PetalDishColumnCount];

        /// <summary>
        /// 90度の回転にかかる時間(単位はフレーム数)
        /// </summary>
        private static int _RotateTime = 500;    // 

        /// <summary>
        /// 回転の残りの時間(単位はフレーム)(回転開始直後は_RotateTime、回転終了時で0になる。)
        /// </summary>
        private int _RotateRemainTime;

        /// <summary>
        /// 回転中の軸の位置(X)
        /// </summary>
        private int _RotateX;

        /// <summary>
        /// 回転中の軸の位置(Y)
        /// </summary>
        private int _RotateY;

        public Game()
        {
        }

        /// <summary>
        /// 指定された回転軸での回転を開始させる。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void StartRotate(int x, int y)
        {
            if (_RotateRemainTime > 0)
                return;
            _RotateRemainTime = _RotateTime;
            _RotateX = x;
            _RotateY = y;
        }

        /// <summary>
        /// 時間を進める
        /// </summary>
        private void tick()
        {
            if (_RotateTime > 0)
            {
                _RotateRemainTime--;
                if (_RotateRemainTime == 0)
                {
                    // 回転終了と同時に判定を行うのではなく、一定時間待ってから判定を行う。

                    // ペンディング中の回転要求が、同じ回転軸に対するものである場合、この回転軸での判定待ち処理は開始せず、
                    // さらなる回転を行う。
                }
            }
        }

        private FeaverLevel _FeaverLevel;

        /// <summary>
        /// 指定された回転軸を中心とする"リング"が完成しているかどうかを返す。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private bool isRingCompleted(int x, int y)
        {
            int dishX = x * 2 + y % 2;

            int grayCount = 0;
            int redCount = 0;
            int greenCount = 0;

            if (!countPetalColor(_PetalDishes[y, dishX].Petal, ref grayCount, ref redCount, ref greenCount))
                return false;
            if (!countPetalColor(_PetalDishes[y, dishX + 1].Petal, ref grayCount, ref redCount, ref greenCount))
                return false;
            if (!countPetalColor(_PetalDishes[y + 1, dishX].Petal, ref grayCount, ref redCount, ref greenCount))
                return false;
            if (!countPetalColor(_PetalDishes[y + 1, dishX + 1].Petal, ref grayCount, ref redCount, ref greenCount))
                return false;

            switch (_FeaverLevel)
            {
                case FeaverLevel.Gray:  // フィーバーではない状態は、赤か緑が4枚そろった場合、リング完成
                    return (redCount == 4) || (greenCount == 4);
                case FeaverLevel.White: // フィーバーレベル1または2の場合、グレーが4枚そろった場合もリング完成
                case FeaverLevel.Yellow:
                    return (redCount == 4) || (greenCount == 4) || (grayCount == 4);
                default: // case FeaverLevel.Rainbow:   // フィーバーレベル3の場合、赤とグレー、あるいは緑とグレーが合わせて4枚になった場合もリング完成
                    return (redCount == 4) || (greenCount == 4) || (grayCount == 4) || (redCount == 0) || (greenCount == 0);
            }
        }

        private static bool countPetalColor(Petal petal, ref int grayCount, ref int redCount, ref int greenCount)
        {

            if (petal == null)
                return false;
            switch (petal.Color)
            {
                case PetalColor.Gray:
                    grayCount++;
                    break;
                case PetalColor.Red:
                    redCount++;
                    break;
                default:
                    greenCount++;
                    break;
            }
            return true;
        }
    }
}
