using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace MqoData
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
        public static List<GeometryModel3D> Convert(MqoData mqoData)
        {
            var gms = new List<GeometryModel3D>();

            foreach (var mqoObject in mqoData.MqoObjects)
            {
            }

            var gm = new GeometryModel3D();
            var dm = new DiffuseMaterial();
            dm.Color = new Color();
            gm.Material = dm;
//            gm.Geometry;

            // m.Geometry = new Geometry3D();
            return gms;
        }

        /// <summary>
        /// MqoObjectを元に、MeshGeometry3Dを生成する。
        /// TODO:実際には、MqoObjectと、MeshGeometry3Dは1対1対応するものではない可能性が高い。
        /// MQOの場合、面毎にマテリアルを設定できるが、MeshGeometryでは一つしか持てないからである。
        /// MqoFaceと、MeshGeometry3Dが対応付けられると思うが、それでは頂点の共有があまりできない。
        /// 前述の事項も勘違いしているかもしれないので、もう少しあとできちんと整理する。
        /// </summary>
        /// <param name="mqoObject">MqoObject</param>
        /// <returns>MeshGeometry3D</returns>
        public MeshGeometry3D MqoObjectToMeshGeometry3D(MqoObject mqoObject)
        {
            var mesh = new MeshGeometry3D();

            foreach (var v in mqoObject.Vertexes)
            {
                var p = new Point3D(v.X, v.Y, v.Z);
                mesh.Positions.Add(p);
            }

            foreach (var f in mqoObject.Faces)
            {
                foreach (var vi in f.VertexIndeces)
                {
                    // TODO まだ面の表裏のことを考えて(把握できて)いない。
                    mesh.TriangleIndices.Add(vi);
                }
            }

            return mesh;
        }
    }
}
