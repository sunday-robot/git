using System;

namespace QTest
{
    public class Q
    {
        double r;
        double i;
        double j;
        double k;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r">実部</param>
        /// <param name="i">虚部i</param>
        /// <param name="j">虚部j</param>
        /// <param name="k">虚部k</param>
        public Q(double r, double i, double j, double k)
        {
            this.r = r;
            this.i = i;
            this.j = j;
            this.k = k;
        }

        /// <summary>
        /// 乗算
        /// </summary>
        /// <param name="a">被乗数</param>
        /// <param name="b">乗数</param>
        /// <returns>積</returns>
        public static Q operator *(Q a, Q b)
        {
            var rr = a.r * b.r;
            var ri = a.r * b.i; // i
            var rj = a.r * b.j; // j
            var rk = a.r * b.k; // k

            var ir = a.i * b.r; // i
            var ii = a.i * b.i; // -1
            var ij = a.i * b.j; // k
            var ik = a.i * b.k; // -j

            var jr = a.j * b.r; // j
            var ji = a.j * b.i; // -k
            var jj = a.j * b.j; // -1
            var jk = a.j * b.k; // i

            var kr = a.k * b.r; // k
            var ki = a.k * b.i; // j
            var kj = a.k * b.j; // -i
            var kk = a.k * b.k; // -1

            var r = rr - ii - jj - kk;
            var i = ri + ir + jk - kj;
            var j = rj - ik + jr + ki;
            var k = rk + ij - ji + kr;

            return new Q(r, i, j, k);
        }

        /// <summary>
        /// 実数による除算
        /// </summary>
        /// <param name="a">被除数(四元数)</param>
        /// <param name="b">除数(実数)</param>
        /// <returns>商(四元数)</returns>
        public static Q operator /(Q a, double b)
        {
            return new Q(a.r / b, a.i / b, a.j / b, a.k / b);
        }

        /// <summary>
        /// 共役を返す
        /// </summary>
        /// <returns>共役</returns>
        public Q Conjugate()
        {
            return new Q(r, -i, -j, -k);
        }

        /// <summary>
        /// 絶対値を返す
        /// </summary>
        /// <returns>絶対値</returns>
        public double Absolute()
        {
            return Math.Sqrt(r * r + i * i + j * j + k * k);
        }

        /// <summary>
        /// 逆数を返す
        /// </summary>
        /// <returns>逆数</returns>
        public Q Inverse()
        {
            double a2 = r * r + i * i + j * j + k * k;
            return Conjugate() / a2;
        }

        /// <summary>
        /// 3次元ベクトルを回転させたものを返す。
        /// </summary>
        /// <param name="v">回転させたい3次元ベクトル</param>
        /// <returns>回転後の3次元ベクトル</returns>
        public double[] Rotate(double[] v)
        {
            var q = Conjugate() * new Q(0, v[0], v[1], v[2]) * this;
            return new double[] {q.i, q.j, q.k};
        }

        /// <summary>
        /// 回転用に特化させた四元数を生成する。
        /// </summary>
        /// <param name="x">回転軸</param>
        /// <param name="y">回転軸</param>
        /// <param name="z">回転軸</param>
        /// <param name="theta">回転角度</param>
        /// <returns>四元数</returns>
        public static Q RotationQ(double x, double y, double z, double theta)
        {
            var c = Math.Cos(theta / 2);
            var s = Math.Sin(theta / 2);
            return new Q(c, x * s, y * s, z * s);
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2}, {3})", r, i, j, k);
        }
    }
}
