using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQData;

namespace CreateLocalCoordinates
{
    /// <summary>
    /// ?
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ?
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            // EulaerTest();
            RotationMatrixTest();
            // Test();
        }

        /// <summary>
        /// 一番長いベクトルが主軸(Z軸)
        /// 主軸ベクトルの終点が原点
        /// 主軸ベクトルの終点を共有するベクトルが副軸(X軸)の方向を示すもの
        /// </summary>
        /// <param name="p0">p0</param>
        /// <param name="p1">p1</param>
        /// <param name="p2">p2</param>
        /// <param name="a0">主軸</param>
        /// <param name="a1">副軸の方向を示すもの</param>
        public static void GetAxisVector(MQPoint p0, MQPoint p1, MQPoint p2, out MQPoint a0, out MQPoint a1)
        {
            // メタセコイアでは、多角形を構成する頂点の順番が反時計回りに見える側が表だが、これとは無関係に、2番目に長い辺を主軸(Z軸)、3番目に長い辺を副軸(X軸)(の方向を示す)ものとする。
            var e0 = p2 - p1;
            var e1 = p0 - p2;
            var e2 = p1 - p0;
            var l0 = e0.Length();
            var l1 = e1.Length();
            var l2 = e2.Length();

            if (l0 > l1)
            {
                if (l0 > l2)
                {
                    if (l1 > l2)
                    {
                        // l0, l1, l2
                        a0 = e1;
                        a1 = e2;
                    }
                    else
                    {
                        // l0, l2, l1
                        a0 = e2;
                        a1 = e1;
                    }
                }
                else
                {
                    // l2, l0, l1
                    a0 = e0;
                    a1 = e1;
                }
            }
            else
            {
                // l1 >= l0
                if (l1 > l2)
                {
                    // l1 >= l0, l1 > l2
                    if (l0 > l2)
                    {
                        // l1, l0, l2
                        a0 = e0;
                        a1 = e2;
                    }
                    else
                    {
                        // l1, l2, l0
                        a0 = e2;
                        a1 = e0;
                    }
                }
                else
                {
                    // l2, l1, l0
                    a0 = e1;
                    a1 = e0;
                }
            }
        }

        /// <summary>
        /// 第1軸と第2軸(の方向)を示すベクトルから、正規化された3つの軸ベクトルを生成する。
        /// </summary>
        /// <param name="a1">第1軸を示すベクトル(大きさは1でなくてもよい)</param>
        /// <param name="a2">第2軸(大きさは1でなくてもよいし、第1軸と直交している必要もない)</param>
        /// <param name="ca1">正規化された第1軸(長さを1に補正しただけのもの)</param>
        /// <param name="ca2">正規化された第2軸(第1軸に直行するように方向が補正され、長さも1に補正されたもの)</param>
        /// <param name="ca3">第3軸(第1軸と第2軸に直行し、長さが1のベクトル)</param>
        public static void CreateCoordinates(MQPoint a1, MQPoint a2, out MQPoint ca1, out MQPoint ca2, out MQPoint ca3)
        {
            ca1 = a1.Unit();
            ca2 = (a2 - (a2.Dot(a1)) / (a1.Length2()) * a1).Unit();
            ca3 = ca1.Cross(ca2);
        }

        private static void Test()
        {
            var o = new MQPoint(0, 0, 0);
            var z = new MQPoint(1, 1, 1);
            var x = new MQPoint(1, 0, 0);
            double head;
            double pitch;
            double bank;
            CreateZXLocalCoordinate(o, z, x, out head, out pitch, out bank);
            var hd = Degree(head);
            var pd = Degree(pitch);
            var bd = Degree(bank);
            Console.Write("{0}, {1}, {2}\n", hd, pd, bd);
        }

        private static void EulaerTest()
        {
            var m = CreateEulerRotationMatrix(Math.PI / 4, Math.PI / 4, Math.PI / 4);

            var xaxis = new MQPoint(1, 0, 0);
            var yaxis = new MQPoint(0, 1, 0);
            var zaxis = new MQPoint(0, 0, 1);

            var xx = m * xaxis;
            var yy = m * yaxis;
            var zz = m * zaxis;

            Console.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }

        /// <summary>
        /// オイラー角で回転行列を生成する
        /// </summary>
        /// <param name="head">Y軸周りの回転角度</param>
        /// <param name="pitch">X軸周りの回転角度</param>
        /// <param name="bank">Z軸周りの回転角度</param>
        /// <returns>回転行列</returns>
        private static MQMatrix CreateEulerRotationMatrix(double head, double pitch, double bank)
        {
            var ch = Math.Cos(head);
            var sh = Math.Sin(head);
            var cp = Math.Cos(pitch);
            var sp = Math.Sin(pitch);
            var cb = Math.Cos(bank);
            var sb = Math.Sin(bank);

            // h y
            //  ch 0 sh   
            //   0 1  0
            // -sh 0 ch

            // p x
            // 1 0  0
            // 0 cp -sp
            // 0 sp cp

            // h * p
            // ch, sh*sp, sh*cp
            // 0,   cp,      -sp
            // -sh,ch*sp,ch*cp

            // b z
            // cb -sb 0
            // sb  cb  0
            // 0    0   1

            // h * p *b

            var m = new MQMatrix(
                ch * cb + sh * sp * sb, // xx
                -ch * sb + sh * sp * cb,    // yx
                sh * cp,    // zx
                cp * sb,    // xy
                cp * cb,    // yy
                -sp,    // zy
                -sh * cb + ch * sp * sb,    // xz
                sh * sb + ch * sp * cb, // yz
                ch * cp);   // zz
            return m;
        }

        static double Degree(double radian)
        {
            return radian * 180 / Math.PI;
        }

        private static MQMatrix RotateX(double theta)
        {
            var c = Math.Cos(theta);
            var s = Math.Sin(theta);
            var m = new MQMatrix(1, 0, 0, 0, c, -s, 0, s, c);
            return m;
        }

        private static MQMatrix RotateY(double theta)
        {
            var c = Math.Cos(theta);
            var s = Math.Sin(theta);
            var m = new MQMatrix(c, 0, s, 0, 1, 0, -s, 0, c);
            return m;
        }

        /// <summary>
        /// 原点、Z軸先端、X軸方向から、ローカル座標系用のH,P,Bを返す。
        /// </summary>
        /// <param name="o">原点</param>
        /// <param name="z">Z軸先端</param>
        /// <param name="x">X軸方向</param>
        /// <returns></returns>
        public static void CreateZXLocalCoordinate(MQPoint o, MQPoint z, MQPoint x, out double head, out double pitch, out double bank)
        {
            // headは、単純に、XZ平面でのZ軸の方向を示す。
            head = Math.Atan2(z.X, z.Z);

            // pitchは、XZ平面と、Z軸の角度を示す。
            pitch = Math.Atan2(z.Y, Math.Sqrt(z.X * z.X + z.Z * z.Z));

            // xのx軸成分
            var xx = x - (x.Dot(z)) / (z.Length2()) * z;

            // bankは、???
            bank = 0;
        }

        private static MQMatrix RotateZ(double theta)
        {
            var c = Math.Cos(theta);
            var s = Math.Sin(theta);
            var m = new MQMatrix(c, -s, 0, s, c, 0, 0, 0, 1);
            return m;
        }

        private static void RotationMatrixTest()
        {
            MQPoint a1 = new MQPoint(0, 0, 1);
            MQPoint a2 = new MQPoint(1, 0, 1);
            MQPoint ca1;
            MQPoint ca2;
            MQPoint ca3;
            CreateCoordinates(a1, a2, out ca1, out ca2, out ca3);
            Console.WriteLine("{0}, {1}\n -> {2}, {3}, {4}", a1, a2, ca1, ca2, ca3);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="triangle"></param>
        ///// <returns></returns>
        //public static MQObject createlocalcoordinate(MQPoint p0, MQPoint p1, MQPoint p2)
        //{
        //    var v0 = p2 - p1;
        //    var v1 = p0 - p2;
        //    var v2 = p1 - p0;
        //    var vv0 = v0 * v0;
        //    var vv1 = v1 * v1;
        //    var vv2 = v2 * v2;

        //    MQPoint o;
        //    MQPoint ax;
        //    MQPoint ayy;

        //    if (vv0 > vv1)
        //    {
        //        // v0 > v1
        //        if (vv0 > vv2)
        //        {
        //            // v0 > v1, v0 > v2
        //            o = p0;
        //            if (vv1 > vv2)
        //            {
        //                // v0 > v1 > v2
        //                ax = v1;
        //                ayy = v2;
        //            }
        //            else
        //            {
        //                // v0 > v1 > v2
        //                ax = v2;
        //                ayy = v1;
        //            }
        //        }
        //        else
        //        {
        //            // v1 >= v0, v2 >= v0
        //            if (vv1 > vv2)
        //            {
        //                // v1 > v2 >= v0
        //                o = v1;
        //            }
        //            else
        //            {
        //                // v2 >= v1 >= v0
        //                o = v2;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // v1 >= v0
        //    }

        //    mqpoint originposition;

        //}
    }
}
