using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 凸メッシュ
    /// </summary>
    public class EpxConvexMesh
    {
        /// <summary>
        /// 頂点配列
        /// </summary>
        private List<EpxVector3> m_vertices;

        /// <summary>
        /// エッジ(辺)配列
        /// 
        /// 平面上のエッジ(エッジを共有する二つの面のなす角度がほぼ180度となるエッジ)は、衝突判定に使用しないので、ここには登録しない。
        /// </summary>
        private List<EpxEdge> m_edges;

        /// <summary>
        /// 面(3角形)配列
        /// 
        /// 面積の小さすぎる(epsilon未満の)3角形は、衝突判定に使用しない(できない?)ので、ここには登録しない。
        /// </summary>
        public List<EpxFacet> m_facets;

        /// <summary>
        /// 凸メッシュを作成する<br>
        /// ・入力データが既に凸包になっていること。<br>
        /// ・3平面から共有されるエッジ、穴あき面は禁止。<br>
        /// ・縮退面は自動的に削除される。
        /// </summary>
        /// <param name="vertices">頂点配列(x1, y1, z1, x2, y2, z2という配列)</param>
        /// <param name="indices">面インデックス配列</param>
        /// <param name="scale">拡大率</param>
        public EpxConvexMesh(float[] vertices, int[] indices, EpxVector3 scale)
        {
            m_vertices = _CreateVertices(vertices, scale);
            m_facets = _CreateFacets(m_vertices, indices);
            m_edges = _CreateEdges(m_vertices, m_facets);
        }

        public List<EpxVector3> Vertices { get { return m_vertices; } }
        public List<EpxEdge> Edges { get { return m_edges; } }

        /// <summary>
        /// 頂点配列を生成する
        /// </summary>
        /// <param name="vertices">頂点配列(x1, y1, z1, x2, y2, z2という配列)</param>
        /// <param name="scale">拡大率</param>
        /// <returns>頂点配列</returns>
        private static List<EpxVector3> _CreateVertices(float[] vertices, EpxVector3 scale)
        {
            List<EpxVector3> v = new List<EpxVector3>();
            for (int i = 0; i < vertices.Length; i += 3)
                v.Add(new EpxVector3(vertices[i] * scale.X, vertices[i + 1] * scale.Y, vertices[i + 2] * scale.Z));
            return v;
        }

        /// <summary>
        /// 面配列を生成する
        /// </summary>
        /// <param name="vertices">頂点配列</param>
        /// <param name="indices">面インデックス配列</param>
        /// <returns>面配列</returns>
        private static List<EpxFacet> _CreateFacets(List<EpxVector3> vertices, int[] indices)
        {
            var facets = new List<EpxFacet>();
            for (int j = 0; j < indices.Length; j += 3)
            {
                var p0 = vertices[indices[j]];
                var p1 = vertices[indices[j + 1]];
                var p2 = vertices[indices[j + 2]];
                EpxVector3 normal = (p1 - p0).cross(p2 - p0);

                // 面積が基準値よりも小さい場合は登録しない
                float areaSqr = normal.LengthSqr();
                if (areaSqr <= float.Epsilon * float.Epsilon)
                    continue;                // 縮退面は登録しない

                var facet = new EpxFacet(indices[j], indices[j + 1], indices[j + 2], normal.Normalize());
                facets.Add(facet);
            }
            return facets;
        }

        /// <summary>
        /// エッジ配列を生成する
        /// </summary>
        /// <param name="vertices">頂点配列</param>
        /// <param name="facets">面配列</param>
        /// <returns>エッジ配列</returns>
        private static List<EpxEdge> _CreateEdges(List<EpxVector3> vertices, List<EpxFacet> facets)
        {
            var edges = new List<EpxEdge>();
            var edgeletMap = new Dictionary<HashSet<int>, EpxFacet>();
            foreach (var facet in facets)
            {
                for (int e = 0; e < 3; e++)
                {
                    var vi0 = facet.vertId[e];
                    var vi1 = facet.vertId[(e + 1) % 3];
                    var key = new HashSet<int> { vi0, vi1 };
                    if (!edgeletMap.ContainsKey(key))
                    {
                        // 共有面がまだ不明なエッジはマップに登録するのみ
                        edgeletMap.Add(key, facet);
                        continue;
                    }

                    // 共有面を見つけたが、平面上のエッジは不要なので角度を判定する
                    // エッジに含まれないＡ面の頂点がB面の表か裏かで判断
                    var facetB = edgeletMap[key];
                    var s = vertices[facet.vertId[(e + 2) % 3]];
                    var q = vertices[facetB.vertId[0]];
                    float d = (s - q).dot(facetB.Normal);
                    if (d >= -float.Epsilon)
                        continue;

                    edges.Add(new EpxEdge(vi0, vi1));
                }
            }
            return edges;
        }
    }
}
