using EasyPhisicsDotNet;
using SampleDotNet.ConvexMesh;

namespace SampleDotNet
{
    class Program
    {
        // シミュレーション定義

        const int maxRigidBodies = 500;	// 剛体の最大数
        const int maxJoints = 100;		// ジョイントの最大数
        const int maxPairs = 5000;		// 衝突判定時の剛体のペアの最大数?
        const float timeStep = 0.016f;	// 単位時間
        const float contactBias = 0.1f;	// ?衝突判定のための何か?
        const float contactSlop = 0.001f;	// ?衝突判定のための何か?
        const int iteration = 10;		// ?何かの繰り返し最大数?
        static EpxVector3 gravity = new EpxVector3(0.0f, -9.8f, 0.0f);	// 重力


        // シミュレーションデータ

        // 剛体

        /// <summary>
        /// 剛体の状態(位置、姿勢、直進速度、回転速度)
        /// </summary>
        static List<EpxState> states;

        /// <summary>
        /// 剛体の属性(形状を除く質量など)
        /// </summary>
        static EpxRigidBody[] bodies = new EpxRigidBody[maxRigidBodies];

        /// <summary>
        /// 剛体の形状(衝突判定のためのもので、画面描画用ではない)
        /// </summary>
        static EpxCollidable[] collidables = new EpxCollidable[maxRigidBodies];

        /// <summary>
        /// 
        /// </summary>
        static int numRigidBodies = 0;

        // ジョイント
        static EpxBallJoint[] joints = new EpxBallJoint[maxJoints];
        static int numJoints = 0;

        // ペア
        static int pairSwap;
        static int[] numPairs = new int[2];
        static EpxPair[][] pairs = new[] { new EpxPair[maxPairs], new EpxPair[maxPairs] };

        static int frame = 0;


        static void Main(string[] args)
        {
            physicsCreateScene();

            frame = 0;
            pairSwap = 0;
            numPairs[0] = numPairs[1] = 0;

            // 以下を繰り返す
            {
                physicsSimulate();
            }
        }

        static void physicsSimulate()
        {
            pairSwap = 1 - pairSwap;

            for (int i = 0; i < numRigidBodies; i++)
            {
                EpxVector3 externalForce = gravity * bodies[i].m_mass;
                EpxVector3 externalTorque = new EpxVector3(0.0f);
                EpxIntegrate.epxApplyExternalForce(states[i], bodies[i], externalForce, externalTorque, timeStep);
            }

            EpxBroadPhase.execute(
                states, collidables, 
                pairs[1 - pairSwap], numPairs[1 - pairSwap],
                pairs[pairSwap], out numPairs[pairSwap],
                maxPairs, null);

            EpxCollisionDetection.execute(
                states, collidables, numRigidBodies,
                pairs[pairSwap], numPairs[pairSwap]);

            EpxConstraintSolver.epxSolveConstraints(
                 states, bodies, numRigidBodies,
                 pairs[pairSwap], numPairs[pairSwap],
                 joints, numJoints,
                 iteration, contactBias, contactSlop, timeStep);

            EpxIntegrate.epxIntegrate(states, numRigidBodies, timeStep);

            frame++;
        }

        static void physicsCreateScene()
        {
            numRigidBodies = 0;
            numJoints = 0;

            createSceneTwoBox();

            createFireBody();
        }


        static void createSceneTwoBox()
        {
            // 地面
            {
                int id = numRigidBodies++;

                EpxVector3 scale = new EpxVector3(10.0f, 1.0f, 10.0f);

                // 剛体を表現するための各種データを初期化
                states[id].reset();
                states[id].m_motionType = EpxMotionType.EpxMotionTypeStatic;
                states[id].m_position = new EpxVector3(0.0f, -scale[1], 0.0f);
                bodies[id].reset();
                collidables[id].reset();

                // 凸メッシュを作成
                var convexMesh = new BoxConvexMesh(scale);

                // 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
                // 描画用メッシュは、終了時に自動的に破棄される
                //shape.userData = (void*) createRenderMesh(&shape.m_geometry);

                EpxShape shape = new EpxShape(convexMesh, null);
                shape.reset();

                // 凸メッシュ形状を登録
                collidables[id].addShape(shape);
                collidables[id].finish();
            }

            // ボックス
            {
                int id = numRigidBodies++;

                EpxVector3 scale = new EpxVector3(2.0f, 0.25f, 1.0f);

                // 剛体を表現するための各種データを初期化
                states[id].reset();
                states[id].m_position = new EpxVector3(0.0f, scale[1], 0.0f);
                bodies[id].reset();
                bodies[id].m_mass = 1.0f;
                bodies[id].m_inertia = EpxMass.epxCalcInertiaBox(scale, 1.0f);
                collidables[id].reset();

                // 凸メッシュを作成
                var convexMesh = new BoxConvexMesh(scale);

                //// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
                //// 描画用メッシュは、シーン切り替え時に自動的に破棄される
                //shape.userData = (void*) createRenderMesh(&shape.m_geometry);

                EpxShape shape = new EpxShape(convexMesh, null);
                shape.reset();

                // 凸メッシュ形状を登録
                collidables[id].addShape(shape);
                collidables[id].finish();
            }

            {
                int id = numRigidBodies++;

                EpxVector3 scale = new EpxVector3(2.0f, 0.25f, 1.0f);

                // 剛体を表現するための各種データを初期化
                states[id].reset();
                states[id].m_position = new EpxVector3(0.0f, 3.0f, 0.0f);
                states[id].m_orientation = EpxQuat.rotationZ(2.0f) * EpxQuat.rotationY(0.7f);
                bodies[id].reset();
                bodies[id].m_mass = 1.0f;
                bodies[id].m_inertia = EpxMass.epxCalcInertiaBox(scale, 1.0f);
                collidables[id].reset();

                // 凸メッシュを作成
                var convexMesh = new BoxConvexMesh(scale);

                //// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
                //// 描画用メッシュは、シーン切り替え時に自動的に破棄される
                //shape.userData = (void*) createRenderMesh(&shape.m_geometry);

                EpxShape shape = new EpxShape(convexMesh, null);
                shape.reset();

                // 凸メッシュ形状を登録
                collidables[id].addShape(shape);
                collidables[id].finish();
            }
        }

        static int fireRigidBodyId;
        static void createFireBody()
        {
            fireRigidBodyId = numRigidBodies++;

            EpxVector3 scale = new EpxVector3(0.5f);

            states[fireRigidBodyId].reset();
            states[fireRigidBodyId].m_motionType = EpxMotionType.EpxMotionTypeStatic;
            states[fireRigidBodyId].m_position = new EpxVector3(999.0f);

            bodies[fireRigidBodyId].reset();
            bodies[fireRigidBodyId].m_mass = 1.0f;
            bodies[fireRigidBodyId].m_inertia = EpxMass.epxCalcInertiaBox(scale, 1.0f);

            collidables[fireRigidBodyId].reset();

            var convexMesh = new SphereConvexMesh(scale);
            //shape.userData = (void*) createRenderMesh(&shape.m_geometry);

            EpxShape shape = new EpxShape(convexMesh, null);
            shape.reset();

            collidables[fireRigidBodyId].addShape(shape);
            collidables[fireRigidBodyId].finish();
        }
    }
}
