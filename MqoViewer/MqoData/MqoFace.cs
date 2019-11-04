using System.Collections.Generic;

namespace MQData
{
    public class MqoFace
    {
        public List<int> VertexIndeces;

        /// <summary>
        /// Materialのインデックス(0～)。マテリアルが設定されていない場合は-1。
        /// </summary>
        public int MaterialIndex = -1;

        public List<MqoUV> UVs;
        public int Col;
        public int Crs;
    }
}
