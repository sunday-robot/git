using System;

namespace EasyPhisicsDotNet
{
    class EpxClosestFunction
    {
        /// ２つの線分の最近接点検出
        /// @param segmentPointA0 線分Aの始点
        /// @param segmentPointA1 線分Aの終点
        /// @param segmentPointB0 線分Bの始点
        /// @param segmentPointB1 線分Bの終点
        /// @param[out] closestPointA 線分A上の最近接点
        /// @param[out] closestPointB 線分B上の最近接点
        public static void epxGetClosestTwoSegments(
             EpxVector3 segmentPointA0, EpxVector3 segmentPointA1,
             EpxVector3 segmentPointB0, EpxVector3 segmentPointB1,
            out EpxVector3 closestPointA, out EpxVector3 closestPointB)
        {
            EpxVector3 v1 = segmentPointA1 - segmentPointA0;
            EpxVector3 v2 = segmentPointB1 - segmentPointB0;
            EpxVector3 r = segmentPointA0 - segmentPointB0;

            float a = v1.dot(v1);
            float b = v1.dot(v2);
            float c = v2.dot(v2);
            float d = v1.dot(r);
            float e = v2.dot(r);
            float det = -a * c + b * b;
            float s;
            float t = 0.0f;

            // 逆行列の存在をチェック
            if (det * det > float.Epsilon)
                s = (c * d - b * e) / det;
            else
                s = 0;

            // 線分A上の最近接点を決めるパラメータsを0.0～1.0でクランプ
            s = EpxUtil.EPX_CLAMP(s, 0.0f, 1.0f);

            // 線分Bのtを求める
            t = (e + s * b) / c;

            // 線分B上の最近接点を決めるパラメータtを0.0～1.0でクランプ
            t = EpxUtil.EPX_CLAMP(t, 0.0f, 1.0f);

            // 再度、線分A上の点を求める
            s = (-d + t * b) / a;
            s = EpxUtil.EPX_CLAMP(s, 0.0f, 1.0f);

            closestPointA = segmentPointA0 + s * v1;
            closestPointB = segmentPointB0 + t * v2;
        }

        /// 頂点から３角形面への最近接点検出
        /// @param point 頂点
        /// @param trianglePoint0 ３角形面の頂点0
        /// @param trianglePoint1 ３角形面の頂点1
        /// @param trianglePoint2 ３角形面の頂点2
        /// @param triangleNormal ３角形面の法線ベクトル
        /// @param[out] closestPoint ３角形面上の最近接点
        public static void epxGetClosestPointTriangle(
             EpxVector3 point,
             EpxVector3 trianglePoint0,
             EpxVector3 trianglePoint1,
             EpxVector3 trianglePoint2,
             EpxVector3 triangleNormal,
            out EpxVector3 closestPoint)
        {
            // ３角形面上の投影点
            EpxVector3 proj = point - triangleNormal.dot(point - trianglePoint0) * triangleNormal;

            // エッジP0,P1のボロノイ領域
            EpxVector3 edgeP01 = trianglePoint1 - trianglePoint0;
            EpxVector3 edgeP01_normal = edgeP01.cross(triangleNormal);

            float voronoiEdgeP01_check1 = (proj - trianglePoint0).dot(edgeP01_normal);
            float voronoiEdgeP01_check2 = (proj - trianglePoint0).dot(edgeP01);
            float voronoiEdgeP01_check3 = (proj - trianglePoint1).dot(-edgeP01);

            if (voronoiEdgeP01_check1 > 0.0f && voronoiEdgeP01_check2 > 0.0f && voronoiEdgeP01_check3 > 0.0f)
            {
                epxGetClosestPointLine(trianglePoint0, edgeP01, proj, out closestPoint);
                return;
            }

            // エッジP1,P2のボロノイ領域
            EpxVector3 edgeP12 = trianglePoint2 - trianglePoint1;
            EpxVector3 edgeP12_normal = edgeP12.cross(triangleNormal);

            float voronoiEdgeP12_check1 = (proj - trianglePoint1).dot(edgeP12_normal);
            float voronoiEdgeP12_check2 = (proj - trianglePoint1).dot(edgeP12);
            float voronoiEdgeP12_check3 = (proj - trianglePoint2).dot(-edgeP12);

            if (voronoiEdgeP12_check1 > 0.0f && voronoiEdgeP12_check2 > 0.0f && voronoiEdgeP12_check3 > 0.0f)
            {
                epxGetClosestPointLine(trianglePoint1, edgeP12, proj, out closestPoint);
                return;
            }

            // エッジP2,P0のボロノイ領域
            EpxVector3 edgeP20 = trianglePoint0 - trianglePoint2;
            EpxVector3 edgeP20_normal = edgeP20.cross(triangleNormal);

            float voronoiEdgeP20_check1 = (proj - trianglePoint2).dot(edgeP20_normal);
            float voronoiEdgeP20_check2 = (proj - trianglePoint2).dot(edgeP20);
            float voronoiEdgeP20_check3 = (proj - trianglePoint0).dot(-edgeP20);

            if (voronoiEdgeP20_check1 > 0.0f && voronoiEdgeP20_check2 > 0.0f && voronoiEdgeP20_check3 > 0.0f)
            {
                epxGetClosestPointLine(trianglePoint2, edgeP20, proj, out closestPoint);
                return;
            }

            // ３角形面の内側
            if (voronoiEdgeP01_check1 <= 0.0f && voronoiEdgeP12_check1 <= 0.0f && voronoiEdgeP20_check1 <= 0.0f)
            {
                closestPoint = proj;
                return;
            }

            // 頂点P0のボロノイ領域
            if (voronoiEdgeP01_check2 <= 0.0f && voronoiEdgeP20_check3 <= 0.0f)
            {
                closestPoint = trianglePoint0;
                return;
            }

            // 頂点P1のボロノイ領域
            if (voronoiEdgeP01_check3 <= 0.0f && voronoiEdgeP12_check2 <= 0.0f)
            {
                closestPoint = trianglePoint1;
                return;
            }

            // 頂点P2のボロノイ領域
            if (voronoiEdgeP20_check2 <= 0.0f && voronoiEdgeP12_check3 <= 0.0f)
            {
                closestPoint = trianglePoint2;
                return;
            }

            throw new NotImplementedException();
        }

        static void epxGetClosestPointLine(
            EpxVector3 point,
            EpxVector3 linePoint,
            EpxVector3 lineDirection,
            out EpxVector3 closestPoint)
        {
            float s = (point - linePoint).dot(lineDirection) / lineDirection.dot(lineDirection);
            closestPoint = linePoint + s * lineDirection;
        }
    }
}
