using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    public class EpxCollisionDetection
    {
        /// <summary>
        /// 衝突検出
        /// </summary>
        /// <param name="states">剛体の状態の配列</param>
        /// <param name="collidables">剛体の形状の配列</param>
        /// <param name="pairs">ペア配列</param>
        public static void execute(
            List<EpxState> states,
            List<EpxCollidable> collidables,
            List<EpxPair> pairs)
        {
            foreach (var pair in pairs)
            {
                var stateA = states[pair.rigidBodyA];
                var stateB = states[pair.rigidBodyB];
                var collA = collidables[pair.rigidBodyA];
                var collB = collidables[pair.rigidBodyB];

                var transformA = stateA.Transform;
                var transformB = stateB.Transform;

                foreach (var shapeA in collA.m_shapes)
                {
                    var worldTransformA = transformA * shapeA.Transform;

                    foreach (var shapeB in collB.m_shapes)
                    {
                        var worldTransformB = transformB * shapeB.Transform;

                        EpxVector3 contactPointA;
                        EpxVector3 contactPointB;
                        EpxVector3 normal;
                        float penetrationDepth;

                        if (EpxConvexConvexContact.Execute(
                            shapeA.Geometry, worldTransformA,
                            shapeB.Geometry, worldTransformB,
                            out normal, out penetrationDepth,
                            out contactPointA, out contactPointB) && penetrationDepth < 0.0f)
                        {

                            // 衝突点を剛体の座標系へ変換し、コンタクトへ追加する。
                            pair.Contact.addContact(
                                penetrationDepth, normal,
                                shapeA.Transform.Transform(contactPointA),
                                shapeB.Transform.Transform(contactPointB));
                        }
                    }
                }
            }
        }
    }
}
