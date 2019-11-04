using EasyPhisicsDotNet;
using System;

namespace SampleDotNet.Simulator
{
    public class RigidBody
    {
        /// <summary>
        /// 剛体の状態(位置、姿勢、直進速度、回転速度)
        /// </summary>
        public EpxState State { get; private set; }

        /// <summary>
        /// 剛体の属性(形状を除く質量など)
        /// 
        /// 地面など質量を設定しない場合はnullも可とする?
        /// </summary>
        public EpxRigidBody Properties { get; private set; }

        /// <summary>
        /// 剛体の形状(衝突判定のためのもので、画面描画用ではない)
        /// </summary>
        public EpxCollidable Collidable { get; private set; }

        public RigidBody(EpxState state, EpxRigidBody properties, EpxCollidable collidable)
        {
            if (state == null)
            {
                throw new NullReferenceException();
            }
            if (collidable == null)
            {
                throw new NullReferenceException();
            }

            State = state;
            Properties = properties;
            Collidable = collidable;
        }
    }
}
