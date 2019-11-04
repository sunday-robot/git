namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 凸エッジ
    /// 平らなエッジは衝突判定には不要。
    /// 凹エッジは、そもそも凸多面体しか扱わないという制限があるので存在しない。
    /// </summary>
    public class EpxEdge
    {
        /// <summary>
        /// 端点0のインデックス
        /// </summary>
        private int _V0;

        /// <summary>
        /// 端点1のインデックス
        /// </summary>
        private int _V1;

        /// <summary>
        /// 端点0のインデックス
        /// </summary>
        public int V0 { get { return _V0; } }

        /// <summary>
        /// 端点1のインデックス
        /// </summary>
        public int V1 { get { return _V1; } }

        /// <summary>
        /// </summary>
        /// <param name="vertex0">端点0のインデックス</param>
        /// <param name="vertex1">端点1のインデックス</param>
        public EpxEdge(int vertex0, int vertex1)
        {
            _V0 = vertex0;
            _V1 = vertex1;
        }
    }
}
