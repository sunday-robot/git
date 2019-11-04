using System;

namespace EasyPhisicsDotNet
{
    class EpxConvexMeshUtil
    {
        /// <summary>
        /// 軸上に凸メッシュを投影し、最小値と最大値を得る
        /// </summary>
        /// <param name="convexMesh">凸メッシュ</param>
        /// <param name="axis">投影軸</param>
        /// <param name="pmin">[out]投影領域の最小値</param>
        /// <param name="pmax">[out]投影領域の最大値</param>
        public static void GetProjection(EpxConvexMesh convexMesh, EpxVector3 axis, out float pmin, out float pmax)
        {
            float min = float.MaxValue;
            float max = -float.MaxValue;
            foreach (EpxVector3 v in convexMesh.Vertices)
            {
                float prj = axis.dot(v);
                min = Math.Min(min, prj);
                max = Math.Max(max, prj);
            }
            pmin = min;
            pmax = max;
        }

        /// <summary>
        /// 軸上に凸メッシュを投影し、最小値と最大値を得る
        /// </summary>
        /// <param name="convexMesh">凸メッシュ</param>
        /// <param name="axis">投影軸</param>
        /// <param name="pmin">[out]投影領域の最小値</param>
        public static void GetProjection(EpxConvexMesh convexMesh, EpxVector3 axis, out float pmin)
        {
            float min = float.MaxValue;
            foreach (EpxVector3 v in convexMesh.Vertices)
            {
                float prj = axis.dot(v);
                min = Math.Min(min, prj);
            }
            pmin = min;
        }
    }
}
