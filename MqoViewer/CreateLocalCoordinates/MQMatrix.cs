using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQData
{
    /// <summary>
    /// 3x3行列
    /// </summary>
    public class MQMatrix
    {
        /// <summary>Ggets 0,0</summary>
        /// <value>
        /// 0,0
        /// </value>
        public double M00 {get; set;}

        /// <summary>0, 1</summary>
        public double M01 {get; set;}

        /// <summary>0, 2</summary>
        public double M02 {get; set;}

        /// <summary>1, 0</summary>
        public double M10 {get; set;}

        /// <summary>1, 1</summary>
        public double M11 {get; set;}

        /// <summary>1, 2</summary>
        public double M12 {get; set;}

        /// <summary>2, 0</summary>
        public double M20 {get; set;}

        /// <summary>2, 1</summary>
        public double M21 {get; set;}

        /// <summary>2, 2</summary>
        public double M22 {get; set;}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="m00">0, 0</param>
        /// <param name="m01">0, 1</param>
        /// <param name="m02">0, 2</param>
        /// <param name="m10">1, 0</param>
        /// <param name="m11">1, 1</param>
        /// <param name="m12">1, 2</param>
        /// <param name="m20">2, 0</param>
        /// <param name="m21">2, 1</param>
        /// <param name="m22">2, 2</param>
        public MQMatrix(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
        {
            this.M00 = m00;
            this.M01 = m01;
            this.M02 = m02;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.M20 = m20;
            this.M21 = m21;
            this.M22 = m22;
        }

        /// <summary>
        /// *
        /// </summary>
        /// <param name="m1">m1</param>
        /// <param name="m2">m2</param>
        /// <returns>m1 * m2</returns>
        public static MQMatrix operator *(MQMatrix m1, MQMatrix m2)
        {
            var m00 = m1.M00 * m2.M00 + m1.M01 * m2.M10 + m1.M02 * m2.M20;
            var m01 = m1.M00 * m2.M01 + m1.M01 * m2.M11 + m1.M02 * m2.M21;
            var m02 = m1.M00 * m2.M02 + m1.M01 * m2.M12 + m1.M02 * m2.M22;

            var m10 = m1.M10 * m2.M00 + m1.M11 * m2.M10 + m1.M12 * m2.M20;
            var m11 = m1.M10 * m2.M01 + m1.M11 * m2.M11 + m1.M12 * m2.M21;
            var m12 = m1.M10 * m2.M02 + m1.M11 * m2.M12 + m1.M12 * m2.M22;

            var m20 = m1.M20 * m2.M00 + m1.M21 * m2.M10 + m1.M22 * m2.M20;
            var m21 = m1.M20 * m2.M01 + m1.M21 * m2.M11 + m1.M22 * m2.M21;
            var m22 = m1.M20 * m2.M02 + m1.M21 * m2.M12 + m1.M22 * m2.M22;

            return new MQMatrix(m00, m01, m02, m10, m11, m12, m20, m21, m22);
        }

        /// <summary>
        /// *
        /// </summary>
        /// <param name="m">m</param>
        /// <param name="p">p</param>
        /// <returns>m * p</returns>
        public static MQPoint operator *(MQMatrix m, MQPoint p)
        {
            var x = m.M00 * p.X + m.M01 * p.Y + m.M02 * p.Z;
            var y = m.M10 * p.X + m.M11 * p.Y + m.M12 * p.Z;
            var z = m.M20 * p.X + m.M21 * p.Y + m.M22 * p.Z;
            return new MQPoint(x, y, z);
        }
    }
}
