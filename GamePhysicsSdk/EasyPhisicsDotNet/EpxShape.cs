using System;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 剛体の形状
    /// 凸多面体の幾何情報(EpxConvexMesh)と、これの位置、姿勢からなる。
    /// また、オプションとして、任意のデータを保持させることもできる。
    /// 
    /// 位置、姿勢を持つ理由はよくわからない。
    /// 複数のEpxShapeで同一の凸メッシュを共有するためだろうか?
    /// </summary>
    public class EpxShape
    {
        /// <summary>
        /// 凸メッシュ
        /// </summary>
        private EpxConvexMesh m_geometry;

        /// <summary>
        /// オフセット位置
        /// </summary>
        private EpxVector3 _Position;

        /// <summary>
        /// オフセット姿勢
        /// </summary>
        private EpxQuat _Orientation;

        /// <summary>
        /// ユーザーデータ
        /// </summary>
        private Object _UserData;

        /// <summary>
        /// アフィン変換を行う4x4行列
        /// </summary>
        private EpxTransform3 _Transform;

        /// <summary>
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="userData"></param>
        public EpxShape(EpxConvexMesh geometry, Object userData)
        {
            m_geometry = geometry;
            _Position = new EpxVector3();
            _Orientation = new EpxQuat();
            _UserData = userData;
            _Transform = new EpxTransform3(_Orientation, _Position);
        }

        /// <summary>
        /// 凸メッシュ
        /// </summary>
        public EpxConvexMesh Geometry { get { return m_geometry; } }

        /// <summary>
        /// オフセット位置
        /// </summary>
        public EpxVector3 Position { get { return _Position; } }

        /// <summary>
        /// オフセット姿勢
        /// </summary>
        public EpxQuat Orientation { get { return _Orientation; } }

        /// <summary>
        /// ユーザーデータ
        /// </summary>
        public Object UserData { get { return _UserData; } }

        /// <summary>
        /// アフィン変換を行う4x4行列
        /// </summary>
        public EpxTransform3 Transform { get { return _Transform; } }

    };
}
