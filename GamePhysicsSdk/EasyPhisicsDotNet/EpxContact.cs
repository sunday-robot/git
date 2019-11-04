using System;
using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    /// 衝突情報
    public class EpxContact
    {
        /// <summary>
        /// 
        /// </summary>
        const float EPX_CONTACT_SAME_POINT = 0.01f;

        /// <summary>
        /// 衝突点の閾値（法線方向）
        /// </summary>
        const float EPX_CONTACT_THRESHOLD_NORMAL = 0.01f;

        /// <summary>
        /// 衝突点の閾値（平面上）
        /// </summary>
        const float EPX_CONTACT_THRESHOLD_TANGENT = 0.002f;

        /// <summary>
        /// 摩擦
        /// </summary>
        public float Friction;

        /// <summary>
        /// 衝突点の配列
        /// </summary>
        public List<EpxContactPoint> m_contactPoints = new List<EpxContactPoint>();

        /// 衝突点を追加する
        /// @param penetrationDepth 貫通深度
        /// @param normal 衝突点の法線ベクトル（ワールド座標系）
        /// @param contactPointA 衝突点（剛体Aのローカル座標系）
        /// @param contactPointB 衝突点（剛体Bのローカル座標系）
        public void addContact(float penetrationDepth, EpxVector3 normal, EpxVector3 contactPointA, EpxVector3 contactPointB)
        {
            int id = findNearestContactPoint(m_contactPoints, contactPointA, contactPointB, normal);
            if (id < 0)
            {
                // 衝突点を新規追加
                id = m_contactPoints.Count;
                m_contactPoints.Add(new EpxContactPoint());
            }

            m_contactPoints[id].distance = penetrationDepth;
            m_contactPoints[id].pointA = contactPointA;
            m_contactPoints[id].pointB = contactPointB;
            m_contactPoints[id].normal = normal;
        }

        /// <summary>
        /// 衝突点をリフレッシュする
        /// </summary>
        /// <param name="tA">剛体Aの位置、姿勢</param>
        /// <param name="tB">剛体Bの位置、姿勢</param>
        public void Refresh(EpxTransform3 tA, EpxTransform3 tB)
        {
            var removeIndexList = new List<int>();
            // 衝突点の更新
            // 両衝突点間の距離が閾値（CONTACT_THRESHOLD）を超えたら消去
            for (int i = 0; i < m_contactPoints.Count; i++)
            {
                var normal = m_contactPoints[i].normal;
                var cpA = tA.Transform(m_contactPoints[i].pointA);
                var cpB = tB.Transform(m_contactPoints[i].pointB);

                // 貫通深度がプラスに転じたかどうかをチェック
                var distance = normal.dot(cpA - cpB);
                if (distance > EPX_CONTACT_THRESHOLD_NORMAL)
                    removeIndexList.Add(i);
                else
                {
                    m_contactPoints[i].distance = distance;

                    // 深度方向を除去して両点の距離をチェック
                    cpA = cpA - m_contactPoints[i].distance * normal;
                    float distanceAB = (cpA - cpB).LengthSqr();
                    if (distanceAB > EPX_CONTACT_THRESHOLD_TANGENT)
                        removeIndexList.Add(i);
                }
            }

            foreach (int index in removeIndexList)
                m_contactPoints.RemoveAt(index);
        }

        /// <summary>
        /// 同一とみなしてよいほど近い衝突点が既にリストに登録されているかどうかを検索し、あればそのインデックスを返す。
        /// 近い衝突点がなければ-1を返す。複数の候補がある場合は一番近いもののインデックスを返す。
        /// </summary>
        /// <param name="newPointA">衝突点（剛体Aのローカル座標系）</param>
        /// <param name="newPointB">衝突点（剛体Bのローカル座標系）</param>
        /// <param name="newNormal">衝突点の法線ベクトル（ワールド座標系）</param>
        /// <returns>同一衝突点のインデックス。見つからない場合は-1</returns>
        static int findNearestContactPoint(List<EpxContactPoint> m_contactPoints,　EpxVector3 newPointA, EpxVector3 newPointB, EpxVector3 newNormal)
        {
            int nearestIdx = -1;

            float minDiff = EPX_CONTACT_SAME_POINT;
            for (int i = 0; i < m_contactPoints.Count; i++)
            {
                float diffA = (m_contactPoints[i].pointA - newPointA).LengthSqr();
                float diffB = (m_contactPoints[i].pointB - newPointB).LengthSqr();
                if (diffA < minDiff && diffB < minDiff && newNormal.dot(m_contactPoints[i].normal) > 0.99f)
                {
                    minDiff = Math.Max(diffA, diffB);
                    nearestIdx = i;
                }
            }

            return nearestIdx;
        }

        ///// 衝突点を入れ替える
        ///// @param newPoint 衝突点（剛体Aのローカル座標系）
        ///// @param newDistance 貫通深度
        ///// @return 破棄する衝突点のインデックスを返す。
        //int sort4ContactPoints(EpxVector3 newPoint, float newDistance)
        //{
        //    int maxPenetrationIndex = -1;
        //    float maxPenetration = newDistance;

        //    // 最も深い衝突点は排除対象からはずす
        //    for (int i = 0; i < m_contactPoints.Count; i++)
        //    {
        //        if (m_contactPoints[i].distance < maxPenetration)
        //        {
        //            maxPenetrationIndex = i;
        //            maxPenetration = m_contactPoints[i].distance;
        //        }
        //    }

        //    float[] res = new float[4];

        //    // 各点を除いたときの衝突点が作る面積のうち、最も大きくなるものを選択
        //    EpxVector3 newp = new EpxVector3(newPoint);
        //    EpxVector3[] p = new EpxVector3[]{
        //                m_contactPoints[0].pointA,
        //                m_contactPoints[1].pointA,
        //                m_contactPoints[2].pointA,
        //                m_contactPoints[3].pointA,
        //    };

        //    if (maxPenetrationIndex != 0)
        //    {
        //        res[0] = calcArea4Points(newp, p[1], p[2], p[3]);
        //    }

        //    if (maxPenetrationIndex != 1)
        //    {
        //        res[1] = calcArea4Points(newp, p[0], p[2], p[3]);
        //    }

        //    if (maxPenetrationIndex != 2)
        //    {
        //        res[2] = calcArea4Points(newp, p[0], p[1], p[3]);
        //    }

        //    if (maxPenetrationIndex != 3)
        //    {
        //        res[3] = calcArea4Points(newp, p[0], p[1], p[2]);
        //    }

        //    int maxIndex = 0;
        //    float maxVal = res[0];

        //    if (res[1] > maxVal)
        //    {
        //        maxIndex = 1;
        //        maxVal = res[1];
        //    }

        //    if (res[2] > maxVal)
        //    {
        //        maxIndex = 2;
        //        maxVal = res[2];
        //    }

        //    if (res[3] > maxVal)
        //    {
        //        maxIndex = 3;
        //        maxVal = res[3];
        //    }

        //    return maxIndex;
        //}

        ///// 衝突点をマージする
        ///// @param contact 合成する衝突情報
        //void merge(EpxContact contact)
        //{
        //    for (int i = 0; i < contact.m_contactPoints.Count; i++)
        //    {
        //        EpxContactPoint cp = m_contactPoints[i];

        //        int id = findNearestContactPoint(cp.pointA, cp.pointB, cp.normal);
        //        if (id >= 0)
        //        {
        //            if (Math.Abs(cp.normal.dot(m_contactPoints[id].normal)) > 0.99f)
        //            {
        //                // 同一点を発見、蓄積された情報を引き継ぐ
        //                m_contactPoints[id].distance = cp.distance;
        //                m_contactPoints[id].pointA = cp.pointA;
        //                m_contactPoints[id].pointB = cp.pointB;
        //                m_contactPoints[id].normal = cp.normal;
        //            }
        //            else
        //            {
        //                // 同一点ではあるが法線が違うため更新
        //                m_contactPoints[id] = cp;
        //            }
        //        }
        //        else if (m_contactPoints.Count < EPX_NUM_CONTACTS)
        //        {
        //            // 衝突点を新規追加
        //            m_contactPoints[m_numContacts++] = cp;
        //        }
        //        else
        //        {
        //            // ソート
        //            id = sort4ContactPoints(cp.pointA, cp.distance);

        //            // コンタクトポイント入れ替え
        //            m_contactPoints[id] = cp;
        //        }
        //    }
        //}

        private float calcArea4Points(EpxVector3 p0, EpxVector3 p1, EpxVector3 p2, EpxVector3 p3)
        {
            float areaSqrA = ((p0 - p1).cross(p2 - p3)).LengthSqr();
            float areaSqrB = ((p0 - p2).cross(p1 - p3)).LengthSqr();
            float areaSqrC = ((p0 - p3).cross(p1 - p2)).LengthSqr();
            return Math.Max(Math.Max(areaSqrA, areaSqrB), areaSqrC);
        }

    }
}
