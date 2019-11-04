namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 回転及び平行移動を行う変換行列(3x3の回転行列と、平行移動を行うベクトルから構成される)
    /// </summary>
    public class EpxTransform3
    {
        // c0.x  c1.x  c2.x  c3.x
        // c0.y  c1.y  c2.y  c3.y
        // c0.z  c1.z  c2.z  c3.z
        // 0     0     0     1

        EpxMatrix3 _Rotation;
        //EpxVector3 _C0;
        //EpxVector3 _C1;
        //EpxVector3 _C2;
        EpxVector3 _Translation;

        public EpxTransform3(EpxQuat unitQuat, EpxVector3 translateVec)
        {
            _Rotation = new EpxMatrix3(unitQuat);
            _Translation = translateVec;
        }

        EpxTransform3(EpxVector3 c0, EpxVector3 c1, EpxVector3 c2, EpxVector3 c3)
        {
            _Rotation = new EpxMatrix3(c1, c2, c3);
            _Translation = c3;
        }

        public EpxTransform3(EpxMatrix3 rotation, EpxVector3 translation)
        {
            _Rotation = rotation;
            _Translation = translation;
        }

        public void setOrientation(EpxQuat unitQuat)
        {
            _Rotation = new EpxMatrix3(unitQuat);
        }

        /// <summary>
        /// </summary>
        /// <returns>平行移動成分</returns>
        public EpxVector3 Translation { get { return _Translation; } set { _Translation = value; } }

        public EpxTransform3 orthoInverse()
        {
            var r = _Rotation.Transpose();
            var t = -(r * _Translation);
            return new EpxTransform3(r, t);
        }

        public static EpxTransform3 operator *(EpxTransform3 a, EpxTransform3 b)
        {
            return new EpxTransform3(
                a._Rotation * b._Rotation,
                a.Transform(b._Translation));
        }

        /// <summary>
        /// 平行移動成分は無視し、回転のみを行う
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public EpxVector3 Rotate(EpxVector3 v)
        {
            return _Rotation * v;
        }

        /// <summary>
        /// 回転及び平行移動を行う
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public EpxVector3 Transform(EpxVector3 v)
        {
            return _Rotation * v + _Translation;
        }
    }
}
