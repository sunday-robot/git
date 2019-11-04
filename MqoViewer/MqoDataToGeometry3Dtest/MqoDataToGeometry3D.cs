using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace MQData
{
    /// <summary>
    /// aaa
    /// </summary>
    public class MqoDataToGeometry3DList
    {
        /// <summary>
        /// MqoDataを元に、GeometryModel3Dのリストを生成する。
        /// </summary>
        /// <param name="mqoData">MqoData</param>
        /// <returns>GeometryModel3D</returns>
        public static List<GeometryModel3D> Convert(MQDocument mqoData)
        {
            var gm3List = new List<GeometryModel3D>();

            #region ポリゴンのマテリアル(色(テクスチャ)、反射率等)のテーブルを作成する
            var materals = new List<Material>();
            if (mqoData.Materials.Count == 0)
            {
                var dm = new DiffuseMaterial();
                var wc = new Color();
                wc.A = 128;
                wc.R = 128;
                wc.G = 128;
                wc.B = 128;
                dm.Color = wc;
                materals.Add(dm);
            }
            else
            {
                foreach (var mqoMaterial in mqoData.Materials)
                {
                    var color = mqoMaterial.Col;
                    var dm = new DiffuseMaterial();
                    var wc = new Color();
                    wc.A = (byte)Math.Round(255 * color.Alpha);
                    wc.R = (byte)Math.Round(255 * color.Red);
                    wc.G = (byte)Math.Round(255 * color.Green);
                    wc.B = (byte)Math.Round(255 * color.Blue);
                    dm.Color = wc;
                    materals.Add(dm);
                }
            }
            // マテリアルテーブルは本メソッド終了時に不要になるが、要素のマテリアルデータはGeometryModel3Dにて保持される。
            #endregion

            #region 各MQOオブジェクトを変換する
            foreach (var mqoObject in mqoData.MQObjects)
            {
                // ポリゴンの頂点座標の変換行列を設定する
                // ここで指定するのはおかしいのではないか?
                Transform3D t3;
                {
                    var rt = createHPBRotationTransform(mqoObject.Rotation.X, mqoObject.Rotation.Y, mqoObject.Rotation.Z);
                    var tt = new TranslateTransform3D(mqoObject.Translation.X, mqoObject.Translation.Y, mqoObject.Translation.Z);
                    var a = new System.Windows.Media.Media3D.MatrixTransform3D();
                    var m = new Matrix3D();
                }

                #region 頂点座標のテーブルを作成する
                var positions = new Point3DCollection();
                foreach (var v in mqoObject.Vertexes)
                {
                    var p = new Point3D(v.X, v.Y, v.Z);
                    positions.Add(p);
                }
                // 頂点座標のテーブルは、全MeshGeometry3Dで共用する
                #endregion
                #region 各ポリゴンを、GeometryModel3Dオブジェクトのリストに変換する?
                // Mqoの一枚のポリゴン(三角形または四角形)から、GeometryModel3Dオブジェクトを生成し、
                // リストに追加する。
                foreach (var mqoFace in mqoObject.Faces)
                {
                    var gm3 = new GeometryModel3D();

                    //                    gm3.Transform = t3;

                    #region ポリゴン(三角形あるいは四角形)の頂点座標(のインデックス)をGeometryModel3D#Geometryに設定する
                    {
                        // TODO まだ面の表裏のことを考えて(把握できて)いない。
                        // →WPFでは、頂点の順番が時計回りになっているほうが表(見える)である。Mqoは把握できていない。
                        var mg3 = new MeshGeometry3D();
                        mg3.Positions = positions;  // 頂点座標のテーブル
                        for (int i = 2; i < mqoFace.VertexIndeces.Count; i++)   // メタセコイヤVer.3では三角形か四角形しか扱えないが、Ver.4からは任意の多角形(凸多角形かどうかは未確認)に対応している。一応このfor文で、任意の凸多角形に対応しているはず。
                        {
                            mg3.TriangleIndices.Add(mqoFace.VertexIndeces[0]);
                            mg3.TriangleIndices.Add(mqoFace.VertexIndeces[i - 1]);
                            mg3.TriangleIndices.Add(mqoFace.VertexIndeces[i]);
                        }
                        gm3.Geometry = mg3;
                    }
                    #endregion

                    #region ポリゴンのマテリアルを、GeometryModel3D#Materialに設定する
                    gm3.Material = materals[mqoFace.MaterialIndex];
                    #endregion

                    gm3List.Add(gm3);
                }
                #endregion
            }
            #endregion

            return gm3List;
        }

        static RotateTransform3D createHPBRotationTransform(double head, double pitch, double bank)
        {
            var hq = new Quaternion(new Vector3D(0, 0, 1), head);
            var pq = new Quaternion(new Vector3D(0, 1, 0), pitch);
            var bq = new Quaternion(new Vector3D(1, 0, 0), bank);
            var qr = new QuaternionRotation3D(hq * pq * bq);
            var rt = new RotateTransform3D(qr);
            return rt;
        }

    }
}
