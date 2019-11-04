using System;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 3x3行列(イミュータブル)
    /// </summary>
    public class EpxMatrix3
    {
        public EpxVector3 C0 { get { return _C0; } }
        public EpxVector3 C1 { get { return _C1; } }
        public EpxVector3 C2 { get { return _C2; } }

        private EpxVector3 _C0;
        private EpxVector3 _C1;
        private EpxVector3 _C2;

        /// <summary>
        /// 単位行列を生成する
        /// </summary>
        public EpxMatrix3()
            : this(1, 1, 1)
        {
        }

        /// <summary>
        /// すべての要素が指定された値の行列を生成する
        /// </summary>
        /// <param name="f">全要素共通の値</param>
        public EpxMatrix3(float f)
        {
            _C0 = new EpxVector3(f);
            _C1 = new EpxVector3(f);
            _C2 = new EpxVector3(f);
        }

        /// <summary>
        /// 四元数で示される回転を行う行列を生成する
        /// </summary>
        /// <param name="q">単位四元数</param>
        public EpxMatrix3(EpxQuat q)
        {
            var qx = q.X;
            var qy = q.Y;
            var qz = q.Z;
            var qw = q.W;
            var qx2 = qx + qx;
            var qy2 = qy + qy;
            var qz2 = qz + qz;
            var qxqx2 = qx * qx2;
            var qxqy2 = qx * qy2;
            var qxqz2 = qx * qz2;
            var qxqw2 = qw * qx2;
            var qyqy2 = qy * qy2;
            var qyqz2 = qy * qz2;
            var qyqw2 = qw * qy2;
            var qzqz2 = qz * qz2;
            var qzqw2 = qw * qz2;
            _C0 = new EpxVector3(1 - qyqy2 - qzqz2, qxqy2 + qzqw2, qxqz2 - qyqw2);
            _C1 = new EpxVector3(qxqy2 - qzqw2, 1 - qxqx2 - qzqz2, qyqz2 + qxqw2);
            _C2 = new EpxVector3(qxqz2 + qyqw2, qyqz2 - qxqw2, 1 - qxqx2 - qyqy2);
        }

        /// <summary>
        /// 指定された列要素の行列を生成する
        /// 
        /// (回転行列であれば、回転後のX軸、Y軸、Z軸の座標値が各列成分にあたる)
        /// </summary>
        /// <param name="c0">列要素0</param>
        /// <param name="c1">列要素1</param>
        /// <param name="c2">列要素2</param>
        public EpxMatrix3(EpxVector3 c0, EpxVector3 c1, EpxVector3 c2)
        {
            _C0 = c0;
            _C1 = c1;
            _C2 = c2;
        }

        /// <summary>
        /// </summary>
        /// <param name="e00">要素(0,0)の値</param>
        /// <param name="e11">要素(1,1)0の値</param>
        /// <param name="e22">要素(2,2)の値</param>
        public EpxMatrix3(float e00, float e11, float e22)
        {
            _C0 = new EpxVector3(e00, 0, 0);
            _C1 = new EpxVector3(0, e11, 0);
            _C2 = new EpxVector3(0, 0, e22);
        }

        /// <summary>
        /// 転置行列を生成する
        /// </summary>
        /// <returns>転置行列</returns>
        public EpxMatrix3 Transpose()
        {
            return new EpxMatrix3(
                new EpxVector3(_C0.X, _C1.X, _C2.X),
                new EpxVector3(_C0.Y, _C1.Y, _C2.Y),
                new EpxVector3(_C0.Z, _C1.Z, _C2.Z));
        }

        public EpxMatrix3 inverse()
        {
            var tmp0 = _C1.cross(_C2);
            var tmp1 = _C2.cross(_C0);
            var tmp2 = _C0.cross(_C1);
            var detinv = 1 / _C2.dot(tmp2);
            return new EpxMatrix3(
                new EpxVector3(tmp0.X * detinv, tmp1.X * detinv, tmp2.X * detinv),
                new EpxVector3(tmp0.Y * detinv, tmp1.Y * detinv, tmp2.Y * detinv),
                new EpxVector3(tmp0.Z * detinv, tmp1.Z * detinv, tmp2.Z * detinv));
        }

        public static EpxVector3 operator *(EpxMatrix3 m, EpxVector3 v)
        {
            float x = m._C0[0] * v.X + m._C1[0] * v.Y + m._C2[0] * v.Z;
            float y = m._C0[1] * v.X + m._C1[1] * v.Y + m._C2[1] * v.Z;
            float z = m._C0[2] * v.X + m._C1[2] * v.Y + m._C2[2] * v.Z;
            return new EpxVector3(x, y, z);
        }

        /// <summary>
        /// </summary>
        /// <param name="i">要素のインデックス(0～2)</param>
        /// <returns>要素</returns>
        public EpxVector3 this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return _C0;
                    case 1:
                        return _C1;
                    case 2:
                        return _C2;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        public static EpxMatrix3 operator *(float s, EpxMatrix3 m)
        {
            return new EpxMatrix3(s * m._C0, s * m._C1, s * m._C2);
        }

        public static EpxMatrix3 operator *(EpxMatrix3 a, EpxMatrix3 b)
        {
            float[,] e = new float[3, 3];
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    e[r, c] = a[r][0] * b[c][0] + a[r][1] * b[1][c] + a[r][2] * b[2][c];
                }
            }
            return new EpxMatrix3(
                new EpxVector3(e[0, 0], e[1, 0], e[2, 0]),
                new EpxVector3(e[0, 1], e[1, 1], e[2, 1]),
                new EpxVector3(e[0, 2], e[1, 2], e[2, 2]));
        }

        public static EpxMatrix3 operator -(EpxMatrix3 a, EpxMatrix3 b)
        {
            return new EpxMatrix3(a._C0 - b._C0, a._C1 - b._C1, a._C2 - b._C2);
        }

        /// <summary>
        /// 拡大縮小の実を行う3x3行列を生成する
        /// </summary>
        /// <param name="v">各軸方向の拡大率</param>
        /// <returns>拡大/縮小を行う3x3行列</returns>
        public static EpxMatrix3 Scale(EpxVector3 v)
        {
            return new EpxMatrix3(v.X, v.Y, v.Z);
        }
    }
}
