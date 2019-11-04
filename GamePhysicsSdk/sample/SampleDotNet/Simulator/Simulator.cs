using EasyPhisicsDotNet;
using System.Collections.Generic;

namespace SampleDotNet.Simulator
{
    public class Simulator
    {
        private EpxVector3 _Gravity = new EpxVector3(0, -9.8f, 0);	// 重力
        private float timeStep = 0.016f;	// 単位時間
        const float contactBias = 0.1f;	// ?衝突判定のための何か?
        const float contactSlop = 0.001f;	// ?衝突判定のための何か?
        const int iteration = 10;		// ?何かの繰り返し最大数?

        private List<RigidBody> _RigidBodies = new List<RigidBody>();

        /// <summary>
        /// 剛体の状態(位置、姿勢、直進速度、回転速度)
        /// </summary>
        private List<EpxState> _RigidBodyStates = new List<EpxState>();

        /// <summary>
        /// 剛体の属性(形状を除く質量など)
        /// </summary>
        private List<EpxRigidBody> _RigidBodyProperties = new List<EpxRigidBody>();

        /// <summary>
        /// 剛体の形状(衝突判定のためのもので、画面描画用ではない)
        /// </summary>
        private List<EpxCollidable> _RigidBodyCollidables = new List<EpxCollidable>();

        /// <summary>
        /// ボールジョイント
        /// </summary>
        private List<EpxBallJoint> _Joints = new List<EpxBallJoint>();

        /// <summary>
        /// 衝突している可能性のある剛体のペアのリスト
        /// </summary>
        private List<EpxPair> _PairList = new List<EpxPair>();

        /// <summary>
        /// </summary>
        /// <param name="rigidBody">剛体</param>
        /// <returns>剛体のID(0からの通し番号)</returns>
        public int AddRigidBody(RigidBody rigidBody)
        {
            _RigidBodies.Add(rigidBody);
            _RigidBodyStates.Add(rigidBody.State);
            _RigidBodyProperties.Add(rigidBody.Properties);
            _RigidBodyCollidables.Add(rigidBody.Collidable);
            return _RigidBodies.Count - 1;
        }

        public void Tick()
        {
            _ApplyGravity(_RigidBodies, _Gravity, timeStep);
            _DetectCollision(_RigidBodyStates, _RigidBodyCollidables, _PairList);
            _SolveConstraints();
            _UpdateState(_RigidBodyStates, timeStep);
        }

        /// <summary>
        /// 全剛体に重力を与える。(並進速度を更新する)
        /// </summary>
        /// <param name="rigidBodies">剛体のリスト</param>
        /// <param name="gravity">重力加速度</param>
        /// <param name="timeStep">タイムステップ</param>
        private static void _ApplyGravity(List<RigidBody> rigidBodies, EpxVector3 gravity, float timeStep)
        {
            foreach (RigidBody rb in rigidBodies)
            {
                if (rb.Properties == null)
                    continue;   // 地面など絶対動かないものについては質量も完成モーメントも設定しない。
                if (rb.State.IsStatic)
                    continue;
                rb.State.LinearVelocity = EpxIntegrate.TrimLinearVelocity(rb.State.LinearVelocity + gravity * timeStep);
                // EpxVector3 force = gravity * rb.Properties.Mass;
                // CalcLinearVelocity(rb.State.LinearVelocity, rb.Properties, force, timeStep);
            }
        }

        /// <summary>
        /// 衝突判定をおこない、衝突情報(Pair)のリストを生成する。。
        /// </summary>
        private static void _DetectCollision(List<EpxState> rigidBodyStates, List<EpxCollidable> rigidBodyCollidables, List<EpxPair> pairList)
        {
            // 衝突判定を行うべき剛体のペアの絞り込みを行う。
            pairList = EpxBroadPhase.Execute(rigidBodyStates, rigidBodyCollidables, pairList, null);

            // 衝突判定を行う。
            EpxCollisionDetection.execute(rigidBodyStates, rigidBodyCollidables, pairList);
        }

        private void _SolveConstraints()
        {
            EpxConstraintSolver.epxSolveConstraints(
                 _RigidBodyStates, _RigidBodyProperties,
                 _PairList,
                 _Joints,
                 iteration, contactBias, contactSlop, timeStep);
        }

        private static void _UpdateState(List<EpxState> rigidBodyStates, float timeStep)
        {
            EpxIntegrate.epxIntegrate(rigidBodyStates, timeStep);
        }
    }
}
