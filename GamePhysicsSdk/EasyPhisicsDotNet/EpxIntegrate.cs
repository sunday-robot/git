using System;
using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    public class EpxIntegrate
    {
        const float EPX_MAX_LINEAR_VELOCITY = 340;
        const float EPX_MAX_ANGULAR_VELOCITY = (float)(Math.PI * 60);

        /// <summary>
        /// 剛体に外力を与え、並進速度と角速度を更新する。
        /// </summary>
        /// <param name="state">剛体の状態(並進速度と角速度を含むもの)</param>
        /// <param name="body">剛体の属性(重さ、慣性テンソルなど、形状以外のもの)</param>
        /// <param name="externalForce">与えるフォース</param>
        /// <param name="externalTorque">与えるトルク</param>
        /// <param name="timeStep">タイムステップ</param>
        public static void epxApplyExternalForce(
            EpxState state,
            EpxRigidBody body,
            EpxVector3 externalForce,
            EpxVector3 externalTorque,
            float timeStep)
        {
            if (state.IsStatic)
                return;
            state.LinearVelocity = CalcLinearVelocity(state.LinearVelocity, body, externalForce, timeStep);
            state.AngularVelocity = CalcAnglerVelocity(state.AngularVelocity, state.Orientation, body, externalTorque, timeStep);
        }

        /// <summary>
        /// 剛体の並進速度を計算する。
        /// </summary>
        /// <param name="currentLinearVelocity">現在の並進速度</param>
        /// <param name="body">剛体の属性(重さ、慣性テンソルなど、形状以外のもの)</param>
        /// <param name="externalForce">与えるフォース</param>
        /// <param name="timeStep">タイムステップ</param>
        public static EpxVector3 CalcLinearVelocity(
            EpxVector3 currentLinearVelocity,
            EpxRigidBody body,
            EpxVector3 externalForce,
            float timeStep)
        {
            var v = currentLinearVelocity + externalForce / body.Mass * timeStep;
            return TrimLinearVelocity(v);
        }

        /// <summary>
        /// 並進速度を最大値を超えないように調整する。
        /// </summary>
        /// <param name="v">並進速度</param>
        /// <returns>最大値を超えないように調整された並進速度</returns>
        public static EpxVector3 TrimLinearVelocity(EpxVector3 v)
        {
            float l2 = v.LengthSqr();
            if (l2 > (EPX_MAX_LINEAR_VELOCITY * EPX_MAX_LINEAR_VELOCITY))
                return v / (float)Math.Sqrt(l2) * EPX_MAX_LINEAR_VELOCITY;
            return v;
        }

        /// <summary>
        /// 剛体の角速度を計算する。
        /// </summary>
        /// <param name="currentAnglerVelocity">現在の角速度</param>
        /// <param name="currentOrientation">現在の姿勢(向き)</param>
        /// <param name="body">剛体の属性(重さ、慣性テンソルなど、形状以外のもの)</param>
        /// <param name="externalTorque">与えるトルク</param>
        /// <param name="timeStep">タイムステップ</param>
        public static EpxVector3 CalcAnglerVelocity(
            EpxVector3 currentAnglerVelocity,
            EpxQuat currentOrientation,
            EpxRigidBody body,
            EpxVector3 externalTorque,
            float timeStep)
        {
            var o = new EpxMatrix3(currentOrientation);
            var to = o.Transpose();
            EpxMatrix3 wi = o * body.Inertia * to;  // ワールド座標系での慣性テンソル?
            EpxMatrix3 wii = o * body.Inertia.inverse() * to;
            var v = wii * (wi * currentAnglerVelocity + externalTorque * timeStep);
            return TrimAnglerVelocity(v);
        }

        /// <summary>
        /// 角速度を最大値を超えないように調整する。
        /// </summary>
        /// <param name="v">角速度</param>
        /// <returns>最大値を超えないように調整された角速度</returns>
        public static EpxVector3 TrimAnglerVelocity(EpxVector3 v)
        {
            float l2 = v.LengthSqr();
            if (l2 > (EPX_MAX_ANGULAR_VELOCITY * EPX_MAX_ANGULAR_VELOCITY))
                return v / (float)Math.Sqrt(l2) * EPX_MAX_ANGULAR_VELOCITY;
            return v;
        }

        /// <summary>
        /// 剛体の並進速度、角速度で、位置、姿勢(向き)を更新する。
        /// </summary>
        /// <param name="states">剛体の状態の配列</param>
        /// <param name="timeStep">タイムステップ</param>
        public static void epxIntegrate(
            List<EpxState> states,
            float timeStep)
        {
            foreach (var state in states)
            {
                EpxQuat dAng = (new EpxQuat(state.AngularVelocity, 0)) * state.Orientation * 0.5f;

                state.Position += state.LinearVelocity * timeStep;
                state.Orientation = (state.Orientation + dAng * timeStep).Normalize();
            }

        }
    }
}
