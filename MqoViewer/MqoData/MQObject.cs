using System.Collections.Generic;
using System.Text;

namespace MQData
{
    /// <summary>
    /// Mqoオブジェクト
    /// 3角形あるいは4角形の集合。
    /// 単純な集合ではなく、ユーザー(モデルデータ作成者)が名前を設定でき、ローカル座標系を設定できるものである。
    /// </summary>
    public class MQObject
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name;

        /// <summary>
        /// オブジェクトのツリーの深さ
        /// (ふつうは親オブジェクトの名前となると思うが、処理効率などから深さで示したほうがよかったということだろうか?)
        /// </summary>
        public int Depth;

        /// <summary>
        /// オブジェクトツリーをたたんでいるかどうか
        /// (これはモデリングソフト用の情報で、モデリングソフト以外には何の意味もないデータ)
        /// </summary>
        public int Folding;

        /// <summary>
        /// オブジェクトの拡大情報(XYZ)
        /// (この情報は(1.0, 1.0, 1.0)に以外にすると、モデラー自身が混乱してしまうと思う。)
        /// </summary>
        public MQPoint Scale;

        /// <summary>
        /// オブジェクトの姿勢情報(HBP)
        /// </summary>
        public MQPoint Rotation;

        /// <summary>
        /// オブジェクトの位置情報(XYZ)
        /// </summary>
        public MQPoint Translation;

        /// <summary>
        /// 曲面の形式
        /// 0 平面(曲面指定をしない)
        /// 1 曲面タイプ１ （スプライン Type1）
        /// 2 曲面タイプ２ （スプライン Type2）
        /// 3 Catmull-Clark （Ver2.2以降）
        /// </summary>
        public int Patch;

        /// <summary>
        /// Catmull-Clark曲面の三角形面の処理
        /// 0 四角形に分割
        /// 1 三角形のまま分割
        /// </summary>
        public int PatchTri;

        /// <summary>
        /// 曲面の分割数
        /// 1～16
        /// (Catmull-Clarkの場合、再帰分割数を示すため1～4となる）
        /// </summary>
        public int Segment;

        /// <summary>
        /// 表示、非表示
        /// (これはモデリングソフト用の情報で、モデリングソフト以外の場合、このフラグが0(非表示の場合はこのオブジェクトを無視するだけでよい。)
        /// </summary>
        public int Visible;

        /// <summary>
        /// オブジェクトツリーを編集不可にしているかどうか
        /// (これはモデリングソフト用の情報で、モデリングソフト以外には何の意味もないデータ)
        /// </summary>
        public int Locking;

        /// <summary>
        /// シェーディング
        /// 0 フラットシェーディング
        /// 1 グローシェーディング
        /// </summary>
        public int Shading;

        /// <summary>
        /// スムージング角度(1～180)
        /// </summary>
        public double Facet;

        /// <summary>
        /// 色(RGB)
        /// (?色はオブジェクト毎ではなく、面毎に設定するものでは?)
        /// </summary>
        public MqoColor Color;

        /// <summary>
        /// 辺の色タイプ
        /// 0 環境設定での色を使用
        /// 1 オブジェクト固有の色を使用
        /// </summary>
        public int ColorType;

        /// <summary>
        /// 頂点リスト
        /// </summary>
        public List<MQPoint> Vertexes = new List<MQPoint>();

        /// <summary>
        /// 面リスト
        /// </summary>
        public List<MqoFace> Faces = new List<MqoFace>();

        /// <summary>
        /// ミラーリング情報
        /// </summary>
        public int Mirror;

        /// <summary>
        /// 鏡像の軸?
        /// </summary>
        public int MirrorAxis;
        public double MirrorDis;
        public int Lathe;
        public int LatheAxis;
        public int LatheSeg;

        private static string ObjectToString(object o)
        {
            if (o == null)
                return "null";
            if (o is List<object>)
            {
                var sb = new StringBuilder();
                sb.Append("{");
                foreach (var e in (List<object>)o)
                {
                }

                sb.Append("}");
                return sb.ToString();
            }
            else
                return o.ToString();
        }

        public override string ToString()
        {
            var vs = new StringBuilder();
            foreach (var v in Vertexes)
            {
                vs.Append(v.ToString() + ", ");
            }

            var fs = new StringBuilder();
            foreach (var f in Faces)
            {
                fs.Append(f.ToString() + ", ");
            }

            return
                "Name = " + Name + "\n"
                + "Depth = " + Depth + "\n"
                + "Folding = " + Folding + "\n"
                + "Scale = " + ObjectToString(Scale) + "\n"
                + "Rotation = " + ObjectToString(Rotation) + "\n"
                + "Translation = " + Translation + "\n"
                + "Patch = " + Patch + "\n"
                + "PatchTri = " + PatchTri + "\n"
                + "Segment = " + Segment + "\n"
                + "Visible = " + Visible + "\n"
                + "Locking = " + Locking + "\n"
                + "Shading = " + Shading + "\n"
                + "Facet = " + Facet + "\n"
                + "Color = " + ObjectToString(Color) + "\n"
                + "ColotType = " + ColorType + "\n"
                + "Vertexes = " + vs + "\n"
                + "Faces = " + fs + "\n"
                + "Mirror = " + Mirror + "\n"
                + "MirrorAxis = " + MirrorAxis + "\n"
                + "MirrorDis = " + MirrorDis + "\n"
                + "Lathe = " + Lathe + "\n"
                + "LatheAxis = " + LatheAxis + "\n"
                + "LatheSeg = " + LatheSeg + "\n";
        }
    }
}
