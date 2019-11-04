namespace EasyPhisicsDotNet
{
    /// 衝突点
    public class EpxContactPoint
    {
        public float distance; ///< 貫通深度
        public EpxVector3 pointA; ///< 衝突点（剛体Aのローカル座標系）
        public EpxVector3 pointB; ///< 衝突点（剛体Bのローカル座標系）
        public EpxVector3 normal; ///< 衝突点の法線ベクトル（ワールド座標系）
        public EpxConstraint[] constraints = new EpxConstraint[3]; ///< 拘束
    }
}
