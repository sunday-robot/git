using System;
using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    public class EpxConstraintSolver
    {
        /// <summary>
        /// 拘束ソルバー
        /// </summary>
        /// <param name="states">剛体の状態の配列</param>
        /// <param name="bodies">剛体の属性の配列</param>
        /// <param name="pairs">ペア配列</param>
        /// <param name="numPairs">ペア数</param>
        /// <param name="joints">ジョイント配列</param>
        /// <param name="iteration">計算の反復回数</param>
        /// <param name="bias">位置補正のバイアス</param>
        /// <param name="slop">貫通許容誤差</param>
        /// <param name="timeStep">タイムステップ</param>
        public static void epxSolveConstraints(
             List<EpxState> states,
             List<EpxRigidBody> bodies,
             List<EpxPair> pairs,
             List<EpxBallJoint> joints,
             int iteration,
             float bias,
             float slop,
             float timeStep)
        {
            List<EpxSolverBody> solverBodies = _CreateSolverBodies(states, bodies);

            // 拘束のセットアップ
            for (int i = 0; i < joints.Count; i++)
            {
                EpxBallJoint joint = joints[i];

                EpxState stateA = states[joint.rigidBodyA];
                EpxRigidBody bodyA = bodies[joint.rigidBodyA];
                EpxSolverBody solverBodyA = solverBodies[joint.rigidBodyA];

                EpxState stateB = states[joint.rigidBodyB];
                EpxRigidBody bodyB = bodies[joint.rigidBodyB];
                EpxSolverBody solverBodyB = solverBodies[joint.rigidBodyB];

                EpxVector3 rA = solverBodyA.Orientation.Rotate(joint.anchorA);
                EpxVector3 rB = solverBodyB.Orientation.Rotate(joint.anchorB);

                EpxVector3 positionA = stateA.Position + rA;
                EpxVector3 positionB = stateB.Position + rB;
                EpxVector3 direction = positionA - positionB;
                float distanceSqr = direction.LengthSqr();

                if (distanceSqr < float.Epsilon * float.Epsilon)
                {
                    joint.constraint.jacDiagInv = 0.0f;
                    joint.constraint.rhs = 0.0f;
                    joint.constraint.lowerLimit = -float.MaxValue;
                    joint.constraint.upperLimit = float.MaxValue;
                    joint.constraint.axis = new EpxVector3(1.0f, 0.0f, 0.0f);
                    continue;
                }

                float distance = (float)Math.Sqrt(distanceSqr);
                direction /= distance;

                EpxVector3 velocityA = stateA.LinearVelocity + stateA.AngularVelocity.cross(rA);
                EpxVector3 velocityB = stateB.LinearVelocity + stateB.AngularVelocity.cross(rB);
                EpxVector3 relativeVelocity = velocityA - velocityB;

                EpxMatrix3 K = EpxMatrix3.Scale(new EpxVector3(solverBodyA.MassInv + solverBodyB.MassInv)) -
                        crossMatrix(rA) * solverBodyA.InertiaInv * crossMatrix(rA) -
                        crossMatrix(rB) * solverBodyB.InertiaInv * crossMatrix(rB);

                float denom = (K * direction).dot(direction);
                joint.constraint.jacDiagInv = 1.0f / denom;
                joint.constraint.rhs = -relativeVelocity.dot(direction); // velocity error
                joint.constraint.rhs -= joint.bias * distance / timeStep; // position error
                joint.constraint.rhs *= joint.constraint.jacDiagInv;
                joint.constraint.lowerLimit = -float.MaxValue;
                joint.constraint.upperLimit = float.MaxValue;
                joint.constraint.axis = direction;

                joint.constraint.accumImpulse = 0.0f;
            }

            for (int i = 0; i < pairs.Count; i++)
            {
                EpxPair pair = pairs[i];

                EpxState stateA = states[pair.rigidBodyA];
                EpxRigidBody bodyA = bodies[pair.rigidBodyA];
                EpxSolverBody solverBodyA = solverBodies[pair.rigidBodyA];

                EpxState stateB = states[pair.rigidBodyB];
                EpxRigidBody bodyB = bodies[pair.rigidBodyB];
                EpxSolverBody solverBodyB = solverBodies[pair.rigidBodyB];

                pair.Contact.Friction = (float)Math.Sqrt(bodyA.Friction * bodyB.Friction);

                for (int j = 0; j < pair.Contact.m_contactPoints.Count; j++)
                {
                    EpxContactPoint cp = pair.Contact.m_contactPoints[j];

                    EpxVector3 rA = solverBodyA.Orientation.Rotate(cp.pointA);
                    EpxVector3 rB = solverBodyB.Orientation.Rotate(cp.pointB);

                    EpxMatrix3 K = EpxMatrix3.Scale(
                        new EpxVector3(solverBodyA.MassInv + solverBodyB.MassInv)) -
                            crossMatrix(rA) * solverBodyA.InertiaInv * crossMatrix(rA) -
                            crossMatrix(rB) * solverBodyB.InertiaInv * crossMatrix(rB);

                    EpxVector3 velocityA = stateA.LinearVelocity + stateA.AngularVelocity.cross(rA);
                    EpxVector3 velocityB = stateB.LinearVelocity + stateB.AngularVelocity.cross(rB);
                    EpxVector3 relativeVelocity = velocityA - velocityB;

                    EpxVector3 tangent1, tangent2;

                    epxCalcTangentVector(cp.normal, out tangent1, out tangent2);

                    float restitution = (pair.Contact == null) ? 0.5f * (bodyA.Restitution + bodyB.Restitution) : 0.0f;

                    // Normal
                    {
                        EpxVector3 axis = cp.normal;
                        float denom = (K * axis).dot(axis);
                        cp.constraints[0].jacDiagInv = 1.0f / denom;
                        cp.constraints[0].rhs = -(1.0f + restitution) * relativeVelocity.dot(axis); // velocity error
                        cp.constraints[0].rhs -= (bias * Math.Min(0.0f, cp.distance + slop)) / timeStep; // position error
                        cp.constraints[0].rhs *= cp.constraints[0].jacDiagInv;
                        cp.constraints[0].lowerLimit = 0.0f;
                        cp.constraints[0].upperLimit = float.MaxValue;
                        cp.constraints[0].axis = axis;
                    }

                    // Tangent1
                    {
                        EpxVector3 axis = tangent1;
                        float denom = (K * axis).dot(axis);
                        cp.constraints[1].jacDiagInv = 1.0f / denom;
                        cp.constraints[1].rhs = -relativeVelocity.dot(axis);
                        cp.constraints[1].rhs *= cp.constraints[1].jacDiagInv;
                        cp.constraints[1].lowerLimit = 0.0f;
                        cp.constraints[1].upperLimit = 0.0f;
                        cp.constraints[1].axis = axis;
                    }

                    // Tangent2
                    {
                        EpxVector3 axis = tangent2;
                        float denom = (K * axis).dot(axis);
                        cp.constraints[2].jacDiagInv = 1.0f / denom;
                        cp.constraints[2].rhs = -relativeVelocity.dot(axis);
                        cp.constraints[2].rhs *= cp.constraints[2].jacDiagInv;
                        cp.constraints[2].lowerLimit = 0.0f;
                        cp.constraints[2].upperLimit = 0.0f;
                        cp.constraints[2].axis = axis;
                    }
                }
            }

            // Warm starting
            for (int i = 0; i < pairs.Count; i++)
            {
                EpxPair pair = pairs[i];

                EpxSolverBody solverBodyA = solverBodies[pair.rigidBodyA];
                EpxSolverBody solverBodyB = solverBodies[pair.rigidBodyB];

                for (int j = 0; j < pair.Contact.m_contactPoints.Count; j++)
                {
                    EpxContactPoint cp = pair.Contact.m_contactPoints[j];
                    EpxVector3 rA = solverBodyA.Orientation.Rotate(cp.pointA);
                    EpxVector3 rB = solverBodyB.Orientation.Rotate(cp.pointB);

                    for (int k = 0; k < 3; k++)
                    {
                        float deltaImpulse = cp.constraints[k].accumImpulse;
                        solverBodyA.DeltaLinearVelocity += deltaImpulse * solverBodyA.MassInv * cp.constraints[k].axis;
                        solverBodyA.DeltaAngularVelocity += deltaImpulse * solverBodyA.InertiaInv * rA.cross(cp.constraints[k].axis);
                        solverBodyB.DeltaLinearVelocity -= deltaImpulse * solverBodyB.MassInv * cp.constraints[k].axis;
                        solverBodyB.DeltaAngularVelocity -= deltaImpulse * solverBodyB.InertiaInv * rB.cross(cp.constraints[k].axis);
                    }
                }
            }

            // 拘束の演算
            for (int itr = 0; itr < iteration; itr++)
            {
                for (int i = 0; i < joints.Count; i++)
                {
                    EpxBallJoint joint = joints[i];

                    EpxSolverBody solverBodyA = solverBodies[joint.rigidBodyA];
                    EpxSolverBody solverBodyB = solverBodies[joint.rigidBodyB];

                    EpxVector3 rA = solverBodyA.Orientation.Rotate(joint.anchorA);
                    EpxVector3 rB = solverBodyB.Orientation.Rotate(joint.anchorB);

                    EpxConstraint constraint = joint.constraint;
                    float deltaImpulse = constraint.rhs;
                    EpxVector3 deltaVelocityA = solverBodyA.DeltaLinearVelocity + solverBodyA.DeltaAngularVelocity.cross(rA);
                    EpxVector3 deltaVelocityB = solverBodyB.DeltaLinearVelocity + solverBodyB.DeltaAngularVelocity.cross(rB);
                    deltaImpulse -= constraint.jacDiagInv * constraint.axis.dot(deltaVelocityA - deltaVelocityB);
                    float oldImpulse = constraint.accumImpulse;
                    constraint.accumImpulse = EpxUtil.EPX_CLAMP(oldImpulse + deltaImpulse, constraint.lowerLimit, constraint.upperLimit);
                    deltaImpulse = constraint.accumImpulse - oldImpulse;
                    solverBodyA.DeltaLinearVelocity += deltaImpulse * solverBodyA.MassInv * constraint.axis;
                    solverBodyA.DeltaAngularVelocity += deltaImpulse * solverBodyA.InertiaInv * rA.cross(constraint.axis);
                    solverBodyB.DeltaLinearVelocity -= deltaImpulse * solverBodyB.MassInv * constraint.axis;
                    solverBodyB.DeltaAngularVelocity -= deltaImpulse * solverBodyB.InertiaInv * rB.cross(constraint.axis);
                }

                for (int i = 0; i < pairs.Count; i++)
                {
                    EpxPair pair = pairs[i];

                    EpxSolverBody solverBodyA = solverBodies[pair.rigidBodyA];
                    EpxSolverBody solverBodyB = solverBodies[pair.rigidBodyB];

                    for (int j = 0; j < pair.Contact.m_contactPoints.Count; j++)
                    {
                        EpxContactPoint cp = pair.Contact.m_contactPoints[j];
                        EpxVector3 rA = solverBodyA.Orientation.Rotate(cp.pointA);
                        EpxVector3 rB = solverBodyB.Orientation.Rotate(cp.pointB);

                        {
                            EpxConstraint constraint = cp.constraints[0];
                            float deltaImpulse = constraint.rhs;
                            EpxVector3 deltaVelocityA = solverBodyA.DeltaLinearVelocity + solverBodyA.DeltaAngularVelocity.cross(rA);
                            EpxVector3 deltaVelocityB = solverBodyB.DeltaLinearVelocity + solverBodyB.DeltaAngularVelocity.cross(rB);
                            deltaImpulse -= constraint.jacDiagInv * constraint.axis.dot(deltaVelocityA - deltaVelocityB);
                            float oldImpulse = constraint.accumImpulse;
                            constraint.accumImpulse = EpxUtil.EPX_CLAMP(oldImpulse + deltaImpulse, constraint.lowerLimit, constraint.upperLimit);
                            deltaImpulse = constraint.accumImpulse - oldImpulse;
                            solverBodyA.DeltaLinearVelocity += deltaImpulse * solverBodyA.MassInv * constraint.axis;
                            solverBodyA.DeltaAngularVelocity += deltaImpulse * solverBodyA.InertiaInv * rA.cross(constraint.axis);
                            solverBodyB.DeltaLinearVelocity -= deltaImpulse * solverBodyB.MassInv * constraint.axis;
                            solverBodyB.DeltaAngularVelocity -= deltaImpulse * solverBodyB.InertiaInv * rB.cross(constraint.axis);
                        }

                        float maxFriction = pair.Contact.Friction * Math.Abs(cp.constraints[0].accumImpulse);
                        cp.constraints[1].lowerLimit = -maxFriction;
                        cp.constraints[1].upperLimit = maxFriction;
                        cp.constraints[2].lowerLimit = -maxFriction;
                        cp.constraints[2].upperLimit = maxFriction;

                        {
                            EpxConstraint constraint = cp.constraints[1];
                            float deltaImpulse = constraint.rhs;
                            EpxVector3 deltaVelocityA = solverBodyA.DeltaLinearVelocity + solverBodyA.DeltaAngularVelocity.cross(rA);
                            EpxVector3 deltaVelocityB = solverBodyB.DeltaLinearVelocity + solverBodyB.DeltaAngularVelocity.cross(rB);
                            deltaImpulse -= constraint.jacDiagInv * constraint.axis.dot(deltaVelocityA - deltaVelocityB);
                            float oldImpulse = constraint.accumImpulse;
                            constraint.accumImpulse = EpxUtil.EPX_CLAMP(oldImpulse + deltaImpulse, constraint.lowerLimit, constraint.upperLimit);
                            deltaImpulse = constraint.accumImpulse - oldImpulse;
                            solverBodyA.DeltaLinearVelocity += deltaImpulse * solverBodyA.MassInv * constraint.axis;
                            solverBodyA.DeltaAngularVelocity += deltaImpulse * solverBodyA.InertiaInv * rA.cross(constraint.axis);
                            solverBodyB.DeltaLinearVelocity -= deltaImpulse * solverBodyB.MassInv * constraint.axis;
                            solverBodyB.DeltaAngularVelocity -= deltaImpulse * solverBodyB.InertiaInv * rB.cross(constraint.axis);
                        }
                        {
                            EpxConstraint constraint = cp.constraints[2];
                            float deltaImpulse = constraint.rhs;
                            EpxVector3 deltaVelocityA = solverBodyA.DeltaLinearVelocity + solverBodyA.DeltaAngularVelocity.cross(rA);
                            EpxVector3 deltaVelocityB = solverBodyB.DeltaLinearVelocity + solverBodyB.DeltaAngularVelocity.cross(rB);
                            deltaImpulse -= constraint.jacDiagInv * constraint.axis.dot(deltaVelocityA - deltaVelocityB);
                            float oldImpulse = constraint.accumImpulse;
                            constraint.accumImpulse = EpxUtil.EPX_CLAMP(oldImpulse + deltaImpulse, constraint.lowerLimit, constraint.upperLimit);
                            deltaImpulse = constraint.accumImpulse - oldImpulse;
                            solverBodyA.DeltaLinearVelocity += deltaImpulse * solverBodyA.MassInv * constraint.axis;
                            solverBodyA.DeltaAngularVelocity += deltaImpulse * solverBodyA.InertiaInv * rA.cross(constraint.axis);
                            solverBodyB.DeltaLinearVelocity -= deltaImpulse * solverBodyB.MassInv * constraint.axis;
                            solverBodyB.DeltaAngularVelocity -= deltaImpulse * solverBodyB.InertiaInv * rB.cross(constraint.axis);
                        }
                    }
                }
            }

            // 移動速度と回転速度を更新
            for (int i = 0; i < states.Count; i++)
            {
                states[i].LinearVelocity += solverBodies[i].DeltaLinearVelocity;
                states[i].AngularVelocity += solverBodies[i].DeltaAngularVelocity;
            }

            //	allocator->deallocate(solverBodies);
        }
        
        /// <summary>
        /// ソルバー用プロキシを作成する
        /// </summary>
        /// <param name="states"></param>
        /// <param name="bodies"></param>
        /// <returns></returns>
        static List<EpxSolverBody> _CreateSolverBodies(
             List<EpxState> states,
             List<EpxRigidBody> bodies)

        {
            List<EpxSolverBody> solverBodies = new List<EpxSolverBody>(states.Count);

            for (int i = 0; i < states.Count; i++)
            {
                EpxState state = states[i];

                float massInv;
                EpxMatrix3 inertiaInv;

                if (state.IsStatic)
                {
                    massInv = 0.0f;
                    inertiaInv = new EpxMatrix3(0.0f);
                }
                else
                {
                    EpxRigidBody body = bodies[i];
                    massInv = 1.0f / body.Mass;
                    EpxMatrix3 m = new EpxMatrix3(state.Orientation);
                    inertiaInv = m * body.Inertia.inverse() * m.Transpose();
                }

                EpxSolverBody solverBody = new EpxSolverBody(new EpxVector3(0.0f), new EpxVector3(0), state.Orientation, inertiaInv, massInv);
                solverBodies.Add(solverBody);
            }
            return solverBodies;
        }

        static EpxMatrix3 crossMatrix(EpxVector3 v)
        {
            return new EpxMatrix3(
                new EpxVector3(0.0f, v.Z, -v.Y),
                new EpxVector3(-v.Z, 0.0f, v.X),
                new EpxVector3(v.Y, -v.X, 0.0f));
        }

        static void epxCalcTangentVector(EpxVector3 normal, out EpxVector3 tangent1, out EpxVector3 tangent2)
        {
            EpxVector3 vec = new EpxVector3(1.0f, 0.0f, 0.0f);
            EpxVector3 n = new EpxVector3(0, normal.Y, normal.Z);
            if (n.LengthSqr() < float.Epsilon)
            {
                vec = new EpxVector3(0.0f, 1.0f, 0.0f);
            }
            tangent1 = normal.cross(vec).Normalize();
            tangent2 = tangent1.cross(normal).Normalize();
        }
    }
}
