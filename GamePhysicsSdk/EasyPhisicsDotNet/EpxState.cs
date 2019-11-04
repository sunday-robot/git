namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 剛体の状態(位置、姿勢、並進速度、回転速度)
    /// </summary>
    public class EpxState
    {
        /// <summary>
        /// 固定されていて動かないかどうか
        /// (trueの場合、外力適用や制約解消などの処理がスキップされる。アプリ側で設定することで、計算負荷を軽減させられるというものらしい)
        /// </summary>
        public bool IsStatic;

        /// <summary>
        /// 位置
        /// </summary>
        public EpxVector3 Position
        {
            get { return Transform.Translation; }
            set
            {
                Transform.Translation = value;
            }
        }

        /// <summary>
        /// 姿勢
        /// </summary>
        EpxQuat _Orientation;

        /// <summary>
        /// 姿勢
        /// </summary>
        public EpxQuat Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                Transform.setOrientation(value);
            }
        }

        /// <summary>
        /// 回転及び平行移動を行う行列
        /// </summary>
        public EpxTransform3 Transform { get; private set; }

        /// <summary>
        /// 並進速度
        /// </summary>
        public EpxVector3 LinearVelocity;

        /// <summary>
        /// 回転速度
        /// </summary>
        public EpxVector3 AngularVelocity;

        public EpxState()
        {
            _Orientation = new EpxQuat();
            LinearVelocity = new EpxVector3();
            AngularVelocity = new EpxVector3();
            IsStatic = false;
            Transform = new EpxTransform3(_Orientation, new EpxVector3());
        }
    }
}
