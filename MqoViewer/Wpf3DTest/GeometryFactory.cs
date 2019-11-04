using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Wpf3DTest
{
    /// <summary>
    /// 立方体などの簡単なGeometry3D(3D形状データ)を生成するもの。
    /// </summary>
    public class Geometry3DFactory
    {
        /// <summary>
        /// スムーズシェーディングされる立方体を生成する。
        /// あまり使い道はないと思われるが、CreateFlatCube()よりは、データ数が少ないので、軽いという利点はある。。
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <param name="size">辺の長さ</param>
        /// <returns>立方体のGeometry3D</returns>
        public static Geometry3D CreateSmoothCube(double x, double y, double z, double size)
        {
            var s = size / 2;
            var x0 = x - s;
            var x1 = x + s;
            var y0 = y - s;
            var y1 = y + s;
            var z0 = z - s;
            var z1 = z + s;
            var mg = new MeshGeometry3D();
                
            mg.Positions.Add(new Point3D(x0, y0, z0));
            mg.Positions.Add(new Point3D(x1, y0, z0));
            mg.Positions.Add(new Point3D(x0, y1, z0));
            mg.Positions.Add(new Point3D(x1, y1, z0));
            mg.Positions.Add(new Point3D(x0, y0, z1));
            mg.Positions.Add(new Point3D(x1, y0, z1));
            mg.Positions.Add(new Point3D(x0, y1, z1));
            mg.Positions.Add(new Point3D(x1, y1, z1));

            _AddSquare(mg.TriangleIndices, 0, 2, 3, 1);  // 背面
            _AddSquare(mg.TriangleIndices, 7, 6, 4, 5);  // 前面
            _AddSquare(mg.TriangleIndices, 0, 1, 5, 4);  // 下面
            _AddSquare(mg.TriangleIndices, 7, 3, 2, 6);  // 上面
            _AddSquare(mg.TriangleIndices, 0, 4, 6, 2);  // 左面
            _AddSquare(mg.TriangleIndices, 7, 5, 1, 3);  // 右面

            return mg;
        }

        /// <summary>
        /// フラットシェーディングされる立方体を生成する。
        /// (WPFではスムーズシェーディングしかできないので、
        /// フラットシェーディングを行わせるために24個(=4つの頂点 * 6つの面)の
        /// 頂点座標&法線方向が必要となるので効率は悪い。)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <param name="size">辺の長さ</param>
        /// <returns>立方体のGeometry3D</returns>
        public static Geometry3D CreateFlatCube(double x, double y, double z, double size)
        {
            var s = size / 2;
            var x0 = x - s;
            var x1 = x + s;
            var y0 = y - s;
            var y1 = y + s;
            var z0 = z - s;
            var z1 = z + s;
            var mg = new MeshGeometry3D();

            Vector3D normal;

            // 背面
            mg.Positions.Add(new Point3D(x0, y0, z0));
            mg.Positions.Add(new Point3D(x0, y1, z0));
            mg.Positions.Add(new Point3D(x1, y1, z0));
            mg.Positions.Add(new Point3D(x1, y0, z0));
            normal = new Vector3D(0, 0, -1);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            _AddSquare(mg.TriangleIndices, 0, 1, 2, 3);

            // 前面
            mg.Positions.Add(new Point3D(x1, y1, z1));
            mg.Positions.Add(new Point3D(x0, y1, z1));
            mg.Positions.Add(new Point3D(x0, y0, z1));
            mg.Positions.Add(new Point3D(x1, y0, z1));
            normal = new Vector3D(0, 0, 1);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            _AddSquare(mg.TriangleIndices, 4, 5, 6, 7);

            // 下面
            mg.Positions.Add(new Point3D(x0, y0, z0));
            mg.Positions.Add(new Point3D(x1, y0, z0));
            mg.Positions.Add(new Point3D(x1, y0, z1));
            mg.Positions.Add(new Point3D(x0, y0, z1));
            normal = new Vector3D(0, -1, 0);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            _AddSquare(mg.TriangleIndices, 8, 9, 10, 11);

            // 上面
            mg.Positions.Add(new Point3D(x1, y1, z1));
            mg.Positions.Add(new Point3D(x1, y1, z0));
            mg.Positions.Add(new Point3D(x0, y1, z0));
            mg.Positions.Add(new Point3D(x0, y1, z1));
            normal = new Vector3D(0, 1, 0);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            _AddSquare(mg.TriangleIndices, 12, 13, 14, 15);

            // 左面
            mg.Positions.Add(new Point3D(x0, y0, z0));
            mg.Positions.Add(new Point3D(x0, y0, z1));
            mg.Positions.Add(new Point3D(x0, y1, z1));
            mg.Positions.Add(new Point3D(x0, y1, z0));
            normal = new Vector3D(-1, 0, 0);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            _AddSquare(mg.TriangleIndices, 16, 17, 18, 19);

            // 右面
            mg.Positions.Add(new Point3D(x1, y1, z1));
            mg.Positions.Add(new Point3D(x1, y0, z1));
            mg.Positions.Add(new Point3D(x1, y0, z0));
            mg.Positions.Add(new Point3D(x1, y1, z0));
            normal = new Vector3D(1, 0, 0);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            mg.Normals.Add(normal);
            _AddSquare(mg.TriangleIndices, 20, 21, 22, 23);

            return mg;
        }

        /// <summary>
        /// 四角形を追加する。
        /// 正確には、頂点1と頂点3を結ぶ対角線で分割された二つの三角形を追加する。
        /// </summary>
        /// <param name="triangleIndices">頂点インデックスリスト</param>
        /// <param name="i1">頂点1のインデックス</param>
        /// <param name="i2">頂点2のインデックス</param>
        /// <param name="i3">頂点3のインデックス</param>
        /// <param name="i4">頂点4のインデックス</param>
        private static void _AddSquare(Int32Collection triangleIndices, int i1, int i2, int i3, int i4)
        {
            // TODO 6つも頂点インデックスを追加するのではなく、4つにする方法があるのではないか?
            triangleIndices.Add(i1);
            triangleIndices.Add(i3);
            triangleIndices.Add(i4);
            triangleIndices.Add(i1);
            triangleIndices.Add(i2);
            triangleIndices.Add(i3);
        }
    }
}
