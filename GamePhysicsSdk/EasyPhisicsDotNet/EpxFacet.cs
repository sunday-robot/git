namespace EasyPhisicsDotNet
{
    /// ３角形面
    public class EpxFacet
    {
        /// <summary>
        /// 法線
        /// </summary>
        private EpxVector3 _Normal;

        /// <summary>
        /// 法線
        /// </summary>
        public EpxVector3 Normal { get { return _Normal; } }

        /// <summary>
        /// 頂点インデックス配列
        /// </summary>
        public int[] vertId;


        public EpxFacet(int v1, int v2, int v3, EpxVector3 normal)
        {
            vertId = new[]{ v1, v2, v3};
            _Normal = normal;
        }
    }

}
