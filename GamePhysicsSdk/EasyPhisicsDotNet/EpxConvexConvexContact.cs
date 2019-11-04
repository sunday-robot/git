using System;

namespace EasyPhisicsDotNet
{
    class EpxConvexConvexContact
    {
        /// <summary>
        /// 凸メッシュの衝突パターン?
        /// </summary>
        private enum EpxSatType
        {
            /// <summary>凸メッシュAの頂点と、凸メッシュBの面が衝突している</summary>
            PointAFacetB,

            /// <summary>凸メッシュBの頂点と、凸メッシュAの面が衝突している</summary>
            PointBFacetA,

            /// <summary>エッジ同士が衝突している</summary>
            EdgeEdge,
        }

        /// <summary>
        /// ２つの凸メッシュの衝突検出
        /// 
        /// 二つの凸メッシュの並進速度、角速度は使用していないことに注意。
        /// </summary>
        /// <param name="convexA">凸メッシュA</param>
        /// <param name="transformA">Aのワールド変換行列</param>
        /// <param name="convexB">凸メッシュB</param>
        /// <param name="transformB">Bのワールド変換行列</param>
        /// <param name="normal">[out] 衝突点の法線ベクトル（ワールド座標系）</param>
        /// <param name="penetrationDepth">[out]貫通深度</param>
        /// <param name="contactPointA">[out]衝突点（剛体Aのローカル座標系）</param>
        /// <param name="contactPointB">[out]衝突点（剛体Bのローカル座標系）</param>
        /// <returns>衝突検出ができたかどうか(衝突しているかどうか)</returns>
        public static bool Execute(
            EpxConvexMesh convexA,
            EpxTransform3 transformA,
            EpxConvexMesh convexB,
            EpxTransform3 transformB,
            out EpxVector3 normal,
            out float penetrationDepth,
            out EpxVector3 contactPointA,
            out EpxVector3 contactPointB)
        {
            // 座標系変換の回数を減らすため、面数の多い方を座標系の基準にとる
            if (convexA.m_facets.Count >= convexB.m_facets.Count)
            {
                return _CheckContact(
                    convexA, transformA,
                    convexB, transformB,
                    out normal, out penetrationDepth,
                    out contactPointA, out contactPointB);
            }
            else
            {
                var ret = _CheckContact(
                    convexB, transformB,
                    convexA, transformA,
                    out normal, out penetrationDepth,
                    out contactPointB, out contactPointA);
                normal = -normal;
                return ret;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="convexA">凸メッシュA</param>
        /// <param name="transformA">Aのワールド変換行列</param>
        /// <param name="convexB">凸メッシュB</param>
        /// <param name="transformB">Bのワールド変換行列</param>
        /// <param name="normal">[out] 衝突点の法線ベクトル（ワールド座標系）</param>
        /// <param name="penetrationDepth">[out]貫通深度</param>
        /// <param name="contactPointA">[out]衝突点（剛体Aのローカル座標系）</param>
        /// <param name="contactPointB">[out]衝突点（剛体Bのローカル座標系）</param>
        /// <returns>衝突検出ができたかどうか(衝突しているかどうか)</returns>
        private static bool _CheckContact(
            EpxConvexMesh convexA,
            EpxTransform3 transformA,
            EpxConvexMesh convexB,
            EpxTransform3 transformB,
            out EpxVector3 normal,
            out float penetrationDepth,
            out EpxVector3 contactPointA,
            out EpxVector3 contactPointB)
        {
            // 最も浅い貫通深度とそのときの分離軸
            float distanceMin;
            EpxVector3 separationAxis;
            EpxSatType satType;
            bool axisFlip;

            // 分離軸判定
            if (!_DetectSeparatingAxis(convexA, transformA, convexB, transformB, out distanceMin, out separationAxis, out satType, out axisFlip))
            {
                normal = null;
                penetrationDepth = 0;
                contactPointA = null;
                contactPointB = null;
                return false;
            }

            // ここまで到達したので、２つの凸メッシュは交差している。
            // また、反発ベクトル(axisMin)と貫通深度(distanceMin)が求まった。
            // 反発ベクトルはＡを押しだす方向をプラスにとる。

            // Bローカル→Aローカルへの変換
            var tAB = transformA.orthoInverse() * transformB;

            // Aローカル→Bローカルへの変換
            var tBA = tAB.orthoInverse();

            //----------------------------------------------------------------------------
            // 衝突座標検出

            int collCount = 0;

            var closestMinSqr = float.MaxValue;
            var closestPointA = new EpxVector3(0, 0, 0); // 初期値はこれでよいのかよくわからない。(秋山)
            var closestPointB = new EpxVector3(0, 0, 0); // 初期値はこれでよいのかよくわからない。(秋山)
            var separation = 1.1f * Math.Abs(distanceMin) * separationAxis;

            foreach (var facetA in convexA.m_facets)
            {
                var checkA = facetA.Normal.dot(-separationAxis);
                if (satType == EpxSatType.PointBFacetA && checkA < 0.99f && axisFlip)
                    continue;                    // 判定軸が面Aの法線のとき、向きの違うAの面は判定しない

                if (checkA < 0.0f)
                    continue;                    // 衝突面と逆に向いている面は判定しない

                foreach (var facetB in convexB.m_facets)
                {
                    float checkB = facetB.Normal.dot(tBA.Rotate(separationAxis));
                    if (satType == EpxSatType.PointAFacetB && checkB < 0.99f && !axisFlip)
                        continue;                        // 判定軸が面Bの法線のとき、向きの違うBの面は判定しない

                    if (checkB < 0.0f)
                        continue;                        // 衝突面と逆に向いている面は判定しない

                    collCount++;

                    // 面Ａと面Ｂの最近接点を求める
                    var triangleA = new EpxVector3[] {
                        separation + convexA.Vertices[facetA.vertId[0]],
                        separation + convexA.Vertices[facetA.vertId[1]],
                        separation + convexA.Vertices[facetA.vertId[2]],
                    };

                    var triangleB = new EpxVector3[] {
                        tAB.Transform(convexB.Vertices[facetB.vertId[0]]),
                        tAB.Transform(convexB.Vertices[facetB.vertId[1]]),
                        tAB.Transform(convexB.Vertices[facetB.vertId[2]]),
                    };

                    // エッジ同士の最近接点算出
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            EpxVector3 sA;
                            EpxVector3 sB;
                            EpxClosestFunction.epxGetClosestTwoSegments(
                                triangleA[i], triangleA[(i + 1) % 3],
                                triangleB[j], triangleB[(j + 1) % 3],
                                out sA, out sB);

                            var dSqr = (sA - sB).LengthSqr();
                            if (dSqr < closestMinSqr)
                            {
                                closestMinSqr = dSqr;
                                closestPointA = sA;
                                closestPointB = sB;
                            }
                        }
                    }

                    // 頂点Ａ→面Ｂの最近接点算出
                    for (int i = 0; i < 3; i++)
                    {
                        EpxVector3 s;
                        EpxClosestFunction.epxGetClosestPointTriangle(triangleA[i], triangleB[0], triangleB[1], triangleB[2], tBA.Rotate(facetB.Normal), out s);
                        float dSqr = (triangleA[i] - s).LengthSqr();
                        if (dSqr < closestMinSqr)
                        {
                            closestMinSqr = dSqr;
                            closestPointA = triangleA[i];
                            closestPointB = s;
                        }
                    }

                    // 頂点Ｂ→面Ａの最近接点算出
                    for (int i = 0; i < 3; i++)
                    {
                        EpxVector3 s;
                        EpxClosestFunction.epxGetClosestPointTriangle(triangleB[i], triangleA[0], triangleA[1], triangleA[2], facetA.Normal, out s);
                        float dSqr = (triangleB[i] - s).LengthSqr();
                        if (dSqr < closestMinSqr)
                        {
                            closestMinSqr = dSqr;
                            closestPointA = s;
                            closestPointB = triangleB[i];
                        }
                    }
                }
            }

            normal = transformA.Rotate(separationAxis);
            penetrationDepth = distanceMin;
            contactPointA = closestPointA - separation;
            contactPointB = tBA.Transform(closestPointB);

            return true;
        }

        private static bool _DetectSeparatingAxis(
            EpxConvexMesh convexA,
            EpxTransform3 transformA,
            EpxConvexMesh convexB,
            EpxTransform3 transformB,
            out float distanceMin, out EpxVector3 axisMin, out EpxSatType satType, out bool axisFlip)
        {
            distanceMin = -float.MaxValue;
            axisMin = new EpxVector3(0.0f);
            satType = EpxSatType.EdgeEdge;
            axisFlip = false;  // 初期値がfalseでよいのかわからない。元のC++でも初期化されない?(秋山)

            // Bローカル→Aローカルへの変換
            var tAB = transformA.orthoInverse() * transformB;

            // Aローカル→Bローカルへの変換
            var tBA = tAB.orthoInverse();

            #region Aの各面へのBの頂点のめり込みをチェック
            foreach (var facet in convexA.m_facets)
            {
                // Aの面法線を分離軸とする
                var separatingAxis = facet.Normal;
                // A面を分離軸に投影
                float maxA = separatingAxis.dot(convexA.Vertices[facet.vertId[0]]);
                // ConvexBを分離軸に投影(必要なのは最小値のみ)
                float minB;
                EpxConvexMeshUtil.GetProjection(convexB, tBA.Rotate(facet.Normal), out minB);
                var offset = tAB.Translation.dot(separatingAxis);
                minB += offset;

                // 判定
                var d = minB - maxA;
                if (d > 0)
                    return false;
                if (d > distanceMin)
                {
                    distanceMin = d;
                    axisMin = -separatingAxis;
                    axisFlip = true;
                    satType = EpxSatType.PointBFacetA;
                }
            }
            #endregion Aの各面へのBの頂点のめり込みをチェック

            #region  Bの各面へのAの頂点のめり込みをチェック
            foreach (EpxFacet facet in convexB.m_facets)
            {
                // ConvexBの面法線をConvecAの座標系に変換したものを分離軸とする
                var separatingAxis = tAB.Rotate(facet.Normal);
                // B面を分離軸に投影
                float maxB = separatingAxis.dot(convexB.Vertices[facet.vertId[0]]);
                float offset = tAB.Translation.dot(separatingAxis);
                maxB += offset;

                // ConvexAを分離軸に投影
                float minA;
                EpxConvexMeshUtil.GetProjection(convexA, separatingAxis, out minA);

                // 判定
                var d = minA - maxB;
                if (d > 0)
                    return false;
                if (d > distanceMin)
                {
                    distanceMin = d;
                    axisMin = separatingAxis;
                    axisFlip = false;
                    satType = EpxSatType.PointAFacetB;
                }
            }
            #endregion Bの各面へのAの頂点のめり込みをチェック

            #region ConvexAとConvexBのエッジの外積を分離軸とする
            foreach (var edgeA in convexA.Edges)
            {
                var edgeVecA = convexA.Vertices[edgeA.V1] - convexA.Vertices[edgeA.V0];
                foreach (var edgeB in convexB.Edges)
                {
                    var edgeVecB = tAB.Rotate(convexB.Vertices[edgeB.V1] - convexB.Vertices[edgeB.V0]);

                    EpxVector3 separatingAxis = edgeVecA.cross(edgeVecB);
                    if (separatingAxis.LengthSqr() < float.Epsilon * float.Epsilon)
                        continue;

                    separatingAxis = separatingAxis.Normalize();

                    // ConvexAを分離軸に投影
                    float minA, maxA;
                    EpxConvexMeshUtil.GetProjection(convexA, separatingAxis, out minA, out maxA);

                    // ConvexBを分離軸に投影
                    float minB, maxB;
                    EpxConvexMeshUtil.GetProjection(convexB, tBA.Rotate(separatingAxis), out minB, out maxB);
                    float offset = tAB.Translation.dot(separatingAxis);
                    minB += offset;
                    maxB += offset;

                    // 判定
                    if (!EPX_CHECK_MINMAX(separatingAxis, minA, maxA, minB, maxB,
                        ref distanceMin, ref axisMin, ref axisFlip))
                        return false;

                    satType = EpxSatType.EdgeEdge;
                }
            }
            #endregion ConvexAとConvexBのエッジの外積を分離軸とする

            return true;
        }


        /// <summary>
        /// </summary>
        /// <param name="axis">分離軸</param>
        /// <param name="minA">分離軸に投影された凸メッシュAの最小値</param>
        /// <param name="maxA">分離軸に投影された凸メッシュAの最大値</param>
        /// <param name="minB">分離軸に投影された凸メッシュBの最小値</param>
        /// <param name="maxB">分離軸に投影された凸メッシュBの最大値</param>
        /// <param name="satCount">[io]衝突の数?</param>
        /// <param name="distanceMin">Aの面へのめり込みの深さ</param>
        /// <param name="axisMin"></param>
        /// <param name="axisFlip"></param>
        /// <returns>凸メッシュAとBが衝突しているかどうか</returns>
        static bool EPX_CHECK_MINMAX(EpxVector3 axis, float minA, float maxA, float minB, float maxB,
            ref float distanceMin, ref EpxVector3 axisMin, ref bool axisFlip)
        {
            var d1 = minA - maxB;
            if (d1 > 0)
                return false;   // BはAの面の裏側に離れて存在存在していて重複はしていない

            var d2 = minB - maxA;   // Bの頂点がAの面にめり込んでいる深さ
            if (d2 > 0)
                return false;   // BはAの面の表側に離れて存在していて重複はしていない

            // この判定必要???
            if (d1 > distanceMin)
            {
                distanceMin = d1;
                axisMin = axis;
                axisFlip = false;
            }

            // Aの面へのめり込みがもっとも浅いものを選択する
            if (d2 > distanceMin)
            {
                distanceMin = d2;
                axisMin = -axis;
                axisFlip = true;
            }

            return true;
        }

    }
}
