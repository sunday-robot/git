using System;

namespace MQData
{
    /// <summary>
    /// 3次元ベクトル
    /// </summary>
    public class MQPoint
    {
        public double X;
        public double Y;
        public double Z;

        public MQPoint(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }

        /// <summary>
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public double Dot(MQPoint p)
        {
            return X * p.X + Y * p.Y + Z * p.Z;
        }

        /// <summary>
        /// </summary>
        /// <param name="p"></param>
        /// <returns>外積</returns>
        public MQPoint Cross(MQPoint p)
        {
            return new MQPoint(
                Y * p.Z - Z * p.Y,
                Z * p.X - X * p.Z,
                X * p.Y - Y * p.X);
        }

        public static MQPoint operator -(MQPoint p1, MQPoint p2)
        {
            return new MQPoint(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        /// <summary>
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns>vector / scaler</returns>
        public static MQPoint operator /(MQPoint p, double d)
        {
            return new MQPoint(p.X / d, p.Y / d, p.Z / d);
        }

        /// <summary>
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns>ベクトルとスカラーの積</returns>
        public static MQPoint operator *(double d, MQPoint p)
        {
            return p * d;
        }

        /// <summary>
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns>ベクトルとスカラーの積</returns>
        public static MQPoint operator *(MQPoint p, double d)
        {
            return new MQPoint(p.X * d, p.Y * d, p.Z * d);
        }

        /// <summary>
        /// </summary>
        /// <returns>長さ</returns>
        public double Length()
        {
            return Math.Sqrt(Length2());
        }

        public double Length2()
        {
            return X * X + Y * Y + Z * Z;
        }

        /// <summary>
        /// </summary>
        /// <returns>単位ベクトル(同じ向きで長さが1のベクトル)</returns>
        public MQPoint Unit()
        {
            return this / this.Length();
        }

    }
}
