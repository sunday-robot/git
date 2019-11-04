using System;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 直方体と球の質量、慣性テンソルを求めるユーティリティクラス
    /// </summary>
    public class EpxMass
    {
        /// <summary>
        /// 直方体の質量を返す
        /// </summary>
        /// <param name="density">密度</param>
        /// <param name="halfExtent">直方体の大きさの半分</param>
        /// <returns>質量</returns>
        public static float epxCalcMassBox(float density, EpxVector3 halfExtent)
        {
            return density * halfExtent.X * halfExtent.Y * halfExtent.Z * 8;
        }

        /// <summary>
        /// 直方体の完成モーメントを返す
        /// </summary>
        /// <param name="halfExtent">直方体の大きさの半分</param>
        /// <param name="mass">質量</param>
        /// <returns>慣性モーメント</returns>
        public static EpxMatrix3 epxCalcInertiaBox(EpxVector3 halfExtent, float mass)
        {
            EpxVector3 sqrSz = new EpxVector3(
                halfExtent.X * halfExtent.X / 3,
                halfExtent.Y * halfExtent.Y / 3,
                halfExtent.Z * halfExtent.Z / 3);
            EpxMatrix3 inertia = new EpxMatrix3(
                mass * (sqrSz.Y + sqrSz.Z),
                mass * (sqrSz.Z + sqrSz.X),
                mass * (sqrSz.X + sqrSz.Y));
            return inertia;
        }

        /// <summary>
        /// 球の質量を返す
        /// </summary>
        /// <param name="density">密度</param>
        /// <param name="radius">球の半径</param>
        /// <returns>質量</returns>
        public static float epxCalcMassSphere(float density, float radius)
        {
            return (float)(4.0f / 3.0f * Math.PI * radius * radius * radius * density);
        }

        /// <summary>
        /// 球の慣性モーメントを返す
        /// </summary>
        /// <param name="radius">半径</param>
        /// <param name="mass">質量</param>
        /// <returns>慣性モーメント</returns>
        public static EpxMatrix3 epxCalcInertiaSphere(float radius, float mass)
        {
            var v = 0.4f * mass * radius * radius;
            EpxMatrix3 inertia = new EpxMatrix3(v, v, v);
            return inertia;
        }
    }
}
