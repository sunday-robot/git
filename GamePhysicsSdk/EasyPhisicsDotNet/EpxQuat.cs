using System;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 四元数
    /// </summary>
    public class EpxQuat
    {
        private float x;
        private float y;
        private float z;
        private float w;

        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public EpxQuat(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// </summary>
        /// <param name="v">v.x, v.y, v.z</param>
        /// <param name="w"></param>
        public EpxQuat(EpxVector3 v, float w)
            : this(v.X, v.Y, v.Z, w)
        {
        }

        public EpxQuat()
            : this(0, 0, 0, 1)
        {
        }

        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float Z { get { return z; } }
        public float W { get { return w; } }

        public static EpxQuat Identity()
        {
            return new EpxQuat();
        }

        /// <summary>
        /// </summary>
        /// <returns>正規化(長さを1にする)された四元数</returns>
        public EpxQuat Normalize()
        {
            var length = (float)Math.Sqrt(x * x + y * y + z * z + w * w);
            return this / length;
        }

        public EpxVector3 Rotate(EpxVector3 v)
        {
            float xx = w * v.X + y * v.Z - z * v.Y;
            float yy = w * v.Y + z * v.X - x * v.Z;
            float zz = w * v.Z + x * v.Y - y * v.X;
            float ww = x * v.X + y * v.Y + z * v.Z;
            return new EpxVector3(
                ww * x + xx * w - yy * z + zz * y,
                ww * y + yy * w - zz * x + xx * z,
                ww * z + zz * w - xx * y + yy * x
            );
        }

        public static EpxQuat operator +(EpxQuat a, EpxQuat b)
        {
            return new EpxQuat(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        public static EpxQuat operator *(EpxQuat a, EpxQuat b)
        {
            var q = new EpxQuat(
                a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
                a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x,
                a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w,
                a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z);
            return q;
        }

        public static EpxQuat operator *(EpxQuat q, float s)
        {
            return new EpxQuat(q.x * s, q.y * s, q.z * s, q.w * s);
        }

        public static EpxQuat operator /(EpxQuat q, float s)
        {
            return q * (1 / s);
        }

        public static EpxQuat RotationX(float radians)
        {
            var angle = radians * 0.5f;
            var s = (float)Math.Sin(angle);
            var c = (float)Math.Cos(angle);
            return new EpxQuat(s, 0, 0, c);
        }

        public static EpxQuat RotationY(float radians)
        {
            var angle = radians * 0.5f;
            var s = (float)Math.Sin(angle);
            var c = (float)Math.Cos(angle);
            return new EpxQuat(0, s, 0, c);
        }

        public static EpxQuat RotationZ(float radians)
        {
            var angle = radians * 0.5f;
            var s = (float)Math.Sin(angle);
            var c = (float)Math.Cos(angle);
            return new EpxQuat(0, 0, s, c);
        }
    }
}
