using System.Collections.Generic;
using System.Text;

namespace MQData
{
    /// <summary>
    /// MqoファイルのSceneチャンクのクラス
    /// このチャンクには、視点情報(カメラの位置、注視点の位置、カメラの傾き、カメラの視野角)と、
    /// 光源情報(環境光一つと、複数の並行光源)が含まれる。
    /// (点光源がないが、ここで扱う光源は、モデラーでの編集作業中にモデルに対して当てられるものなので、点光源などはなくてもよい。)
    /// </summary>
    public class MqoScene
    {
        /// <summary>
        /// カメラの位置?
        /// </summary>
        public MQPoint Pos;

        /// <summary>
        /// 注視点?
        /// </summary>
        public MQPoint LookAt;

        /// <summary>
        /// 左右方向の回転角度(Degree)と思われるが、posとlookatで決まって来るのでは???
        /// </summary>
        public double Head;

        /// <summary>
        /// 上下方向の回転角度(Degree)と思われるが、posとlookatで決まって来るのでは???
        /// </summary>
        public double Pich;

        /// <summary>
        /// 首をかしげる方向の回転角度(Degree)と思われる。これだけはposとlookatでは決まらないので必要?
        /// </summary>
        public double Bank;

        /// <summary>
        /// 等角投影法かどうかのフラグ。
        /// </summary>
        public bool Ortho;

        /// <summary>
        /// 視野角とおもわれる。
        /// </summary>
        public double Zoom2;

        /// <summary>
        /// 多分環境光
        /// </summary>
        public MqoColor Amb;

        /// <summary>
        /// よくわからない。手前のクリップ位置?
        /// </summary>
        public double FrontClip;

        /// <summary>
        /// よくわからない。奥のクリップ位置?
        /// </summary>
        public double BackClip;

        /// <summary>
        /// 並行光源リスト
        /// </summary>
        public List<MqoLight> Dirlights;

        /// <summary>
        /// ?
        /// </summary>
        public double ZoomPers;

        /// <summary>
        /// デバッグ用の文字列化メソッド
        /// </summary>
        /// <returns>ある程度見やすく成形されたオブジェクトの内容</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Scene {\n");
            sb.Append("Pos = " + Pos.ToString() + "\n");
            sb.Append("LookAt = " + LookAt.ToString() + "\n");
            sb.Append("Head = " + Head.ToString() + "\n");
            sb.Append("Pich = " + Pich.ToString() + "\n");
            sb.Append("Bank = " + Bank.ToString() + "\n");
            sb.Append("Ortho = " + Ortho.ToString() + "\n");
            sb.Append("Zoom2 = " + Zoom2.ToString() + "\n");
            sb.Append("Amb = " + Amb.ToString() + "\n");
            sb.Append("DirLights = " + MQDocument.ListToString(Dirlights) + "\n");
            sb.Append("ZoomPers = " + ZoomPers.ToString() + "\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
