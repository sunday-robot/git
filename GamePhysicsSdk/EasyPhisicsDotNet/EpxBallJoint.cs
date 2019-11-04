namespace EasyPhisicsDotNet
{
    /// ボールジョイント
    public class EpxBallJoint
    {
        /// <summary>
        /// 拘束の強さの調整値
        /// </summary>
        public float bias;

        /// <summary>
        /// 剛体Aへのインデックス
        /// </summary>
        public int rigidBodyA;

        /// <summary>
        /// 剛体Bへのインデックス
        /// </summary>
        public int rigidBodyB;

        /// <summary>
        /// 剛体Aのローカル座標系における接続点
        /// </summary>
        public EpxVector3 anchorA;

        /// <summary>
        /// 剛体Bのローカル座標系における接続点
        /// </summary>
        public EpxVector3 anchorB;

        /// <summary>
        /// 拘束
        /// </summary>
        public EpxConstraint constraint;

        public EpxBallJoint()
        {
            bias = 0;
            rigidBodyA = 0;
            rigidBodyB = 0;
            anchorA = new EpxVector3();
            anchorB = new EpxVector3();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        void reset()
        {
            bias = 0.1f;
            constraint.accumImpulse = 0;
        }
    }
}
