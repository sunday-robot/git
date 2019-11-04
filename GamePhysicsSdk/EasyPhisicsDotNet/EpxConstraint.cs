namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 拘束
    /// </summary>
    public struct EpxConstraint
    {
        /// <summary>
        /// 拘束軸
        /// </summary>
        public EpxVector3 axis;

        /// <summary>
        /// 拘束式の分母
        /// </summary>
        public float jacDiagInv;

        /// <summary>
        /// 初期拘束力
        /// </summary>
        public float rhs;

        /// <summary>
        /// 拘束力の下限
        /// </summary>
        public float lowerLimit;

        /// <summary>
        /// 拘束力の上限
        /// </summary>
        public float upperLimit;

        /// <summary>
        /// 蓄積される拘束力
        /// </summary>
        public float accumImpulse;
    };
}
