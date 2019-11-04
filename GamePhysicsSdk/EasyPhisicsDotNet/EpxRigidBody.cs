namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 剛体の性質(形状以外の性質で、慣性テンソル、質量、反発係数、摩擦係数からなる)
    /// </summary>
    public class EpxRigidBody
    {
        /// <summary>
        /// 反発係数のデフォルト値
        /// </summary>
        private const float DefaultRestitution = 0.2f;

        /// <summary>
        /// 摩擦係数のデフォルト値
        /// </summary>
        private const float DefaultFriction = 0.6f;

        /// <summary>
        /// 質量
        /// </summary>
        public float Mass { get; private set; }

        /// <summary>
        /// 慣性テンソル
        /// </summary>
        public EpxMatrix3 Inertia { get; private set; }

        /// <summary>
        /// 反発係数
        /// </summary>
        public float Restitution { get; private set; }

        /// <summary>
        /// 摩擦係数
        /// </summary>
        public float Friction { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="mass">質量</param>
        /// <param name="inertia">慣性テンソル</param>
        /// <param name="restitution">反発係数</param>
        /// <param name="friction">摩擦係数</param>
        public EpxRigidBody(float mass, EpxMatrix3 inertia, float restitution, float friction)
        {
            Mass = mass;
            Inertia = inertia;
            Restitution = restitution; ;
            Friction = friction;
        }

        /// <summary>
        /// </summary>
        /// <param name="mass">質量</param>
        /// <param name="inertia">慣性テンソル</param>
        public EpxRigidBody(float mass, EpxMatrix3 inertia)
            : this(mass, inertia, DefaultRestitution, DefaultFriction)
        {
        }
    }
}
