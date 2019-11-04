namespace EasyPhisicsDotNet
{
    /// <summary>
    /// ソルバーボディ
    /// </summary>
    class EpxSolverBody
    {
        /// <summary>
        /// 並進速度差分
        /// </summary>
        public EpxVector3 DeltaLinearVelocity { get; set; }

        /// <summary>
        /// 回転速度差分
        /// </summary>
        public EpxVector3 DeltaAngularVelocity { get; set; }

        /// <summary>
        /// 姿勢
        /// </summary>
        public EpxQuat Orientation { get; }

        /// <summary>
        /// 慣性テンソルの逆行列
        /// </summary>
        public EpxMatrix3 InertiaInv { get; }

        /// <summary>
        /// 質量の逆数
        /// </summary>
        public float MassInv { get; }

        public EpxSolverBody(EpxVector3 deltaLinearVelocity, EpxVector3 deltaAngularVelocity, EpxQuat orientation, EpxMatrix3 inertiaInv, float massInv)
        {
            DeltaLinearVelocity = deltaLinearVelocity;
            DeltaAngularVelocity = deltaAngularVelocity;
            Orientation = orientation;
            InertiaInv = inertiaInv;
            MassInv = massInv;
        }
    };
}
