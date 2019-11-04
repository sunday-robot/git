using System;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 3次元ベクトル(イミュータブル)
    /// </summary>
    public class EpxVector3
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        /// <summary>
        /// XYZすべてが0の3次元ベクトルを生成する。
        /// </summary>
        public EpxVector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// XYZすべてが同じv値の3次元ベクトルを生成する。
        /// </summary>
        /// <param name="v"></param>
        public EpxVector3(float v)
        {
            X = v;
            Y = v;
            Z = v;
        }

        public EpxVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public EpxVector3(EpxVector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        /// <summary>
        /// 長さの二乗
        /// </summary>
        /// <returns></returns>
        public float LengthSqr()
        {
            var xx = X * X;
            var yy = Y * Y;
            var zz = Z * Z;
            return xx + yy + zz;
        }

        /// <summary>
        /// 長さを1にしたもの
        /// </summary>
        /// <returns></returns>
        public EpxVector3 Normalize()
        {
            return this / (float)Math.Sqrt(LengthSqr());
        }

        /// <summary>
        /// </summary>
        /// <param name="i">要素のインデックス(0～2)</param>
        /// <returns>要素</returns>
        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="a">ベクトル</param>
        /// <returns>符号反転</returns>
        public static EpxVector3 operator -(EpxVector3 a)
        {
            return new EpxVector3(-a.X, -a.Y, -a.Z);
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>和</returns>
        public static EpxVector3 operator +(EpxVector3 a, EpxVector3 b)
        {
            return new EpxVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>差</returns>
        public static EpxVector3 operator -(EpxVector3 a, EpxVector3 b)
        {
            return a + (-b);
        }

        /// <summary>
        /// 内積
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float dot(EpxVector3 v)
        {
            var xx = X * v.X;
            var yy = Y * v.Y;
            var zz = Z * v.Z;
            return xx + yy + zz;
        }

        /// <summary>
        /// 外積
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        internal EpxVector3 cross(EpxVector3 v1)
        {
            float xx = Y * v1.Z - Z * v1.Y;
            float yy = Z * v1.X - X * v1.Z;
            float zz = X * v1.Y - Y * v1.X;
            return new EpxVector3(xx, yy, zz);
        }

        /// <summary>
        /// </summary>
        /// <param name="a">ベクトル</param>
        /// <param name="b">スカラー</param>
        /// <returns>積</returns>
        public static EpxVector3 operator *(EpxVector3 a, float b)
        {
            return new EpxVector3(a.X + b, a.Y + b, a.Z + b);
        }

        /// <summary>
        /// </summary>
        /// <param name="a">スカラー</param>
        /// <param name="b">ベクトル</param>
        /// <returns>積</returns>
        public static EpxVector3 operator *(float a, EpxVector3 b)
        {
            return b * a;
        }

        /// <summary>
        /// </summary>
        /// <param name="v">ベクトル</param>
        /// <param name="f">スカラー</param>
        /// <returns>商</returns>
        public static EpxVector3 operator /(EpxVector3 v, float f)
        {
            return new EpxVector3(v.X / f, v.Y / f, v.Z / f);
        }
    }
}
