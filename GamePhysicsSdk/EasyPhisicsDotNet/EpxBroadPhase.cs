using System;
using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    public class EpxBroadPhase
    {
        static readonly EpxVector3 AabbExpand = new EpxVector3(0.01f);

        /// <summary>
        /// ブロードフェーズ
        /// </summary>
        /// <param name="states">剛体の状態の配列</param>
        /// <param name="collidables">剛体の形状の配列</param>
        /// <param name="oldPairs">前フレームのペア配列</param>
        /// <param name="callback">コールバック</param>
        /// <returns>検出されたペア配列</returns>
        public static List<EpxPair> Execute(
            List<EpxState> states,
            List<EpxCollidable> collidables,
            List<EpxPair> oldPairs,
            IEpxBroadPhaseCallback callback)
        {
            // ペアを検出する
            var newPairs = _CreatePairs(states, collidables, callback);

            // 検出されたペアのうち、既存のものについては、衝突情報を更新の上、再利用する。
            _ReuseOldContactInformation(newPairs, oldPairs, states);

            return newPairs;
        }

        /// <summary>
        /// AABB交差ペアを見つける（総当たり）
        /// 処理の内容を明確にするため、ここでは空間分割テクニックを使っていませんが、
        /// 理論編で解説されているSweet and prune等の手法を使えば高速化できます。
        /// </summary>
        /// <param name="states"></param>
        /// <param name="collidables"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        static List<EpxPair> _CreatePairs(List<EpxState> states, List<EpxCollidable> collidables, IEpxBroadPhaseCallback callback)
        {
            var pairs = new List<EpxPair>();
            for (int i = 0; i < states.Count; i++)
            {
                EpxVector3 centerA; // 中心座標
                EpxVector3 halfA;   // 大きさ
                _GetAabb(states[i], collidables[i], out centerA, out halfA);
                for (int j = i + 1; j < states.Count; j++)
                {
                    if (callback != null)
                        if (!callback.Execute(i, j))
                            continue;
                    EpxVector3 centerB;// 中心座標
                    EpxVector3 halfB; // 大きさ
                    _GetAabb(states[j], collidables[j], out centerB, out halfB);
                    if (_EpxIntersectAABB(centerA, halfA, centerB, halfB))
                        pairs.Add(new EpxPair(i, j));
                }
            }
            return pairs;
        }

        static void _GetAabb(EpxState state, EpxCollidable collidable, out EpxVector3 center, out EpxVector3 half)
        {
            center = state.Transform.Transform(collidable.Center);
            half = _AbsPerElem(state.Transform.Rotate(collidable.Half + AabbExpand));// AABBサイズを若干拡張
        }

        static EpxVector3 _AbsPerElem(EpxVector3 v)
        {
            return new EpxVector3((float)Math.Abs(v.X), (float)Math.Abs(v.Y), (float)Math.Abs(v.Z));
        }

        static bool _EpxIntersectAABB(EpxVector3 centerA, EpxVector3 halfA, EpxVector3 centerB, EpxVector3 halfB)
        {
            if (Math.Abs(centerA[0] - centerB[0]) > halfA[0] + halfB[0])
                return false;
            if (Math.Abs(centerA[1] - centerB[1]) > halfA[1] + halfB[1])
                return false;
            if (Math.Abs(centerA[2] - centerB[2]) > halfA[2] + halfB[2])
                return false;
            return true;
        }

        static void _ReuseOldContactInformation(
            List<EpxPair> newPairs,
            List<EpxPair> oldPairs,
            List<EpxState> states)
        {
            if (oldPairs.Count == 0)
                return;
            var ope = oldPairs.GetEnumerator();
            foreach (EpxPair n in newPairs)
            {
                var o = ope.Current;
                if (n.Key < o.Key)
                    continue;
                if (n.Key == o.Key)
                {
                    // ブロードフェイズで衝突情報を更新するのではなく、ナローフェイズで更新するほうがわかりやすいのではないか?(秋山)
                    EpxContact c = o.Contact;
                    c.Refresh(
                        states[o.rigidBodyA].Transform,
                        states[o.rigidBodyB].Transform);
                    n.Contact = c;
                }
                if (!ope.MoveNext())
                    return;
            }
        }
    }
}
