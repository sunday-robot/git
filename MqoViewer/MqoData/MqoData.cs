namespace MQData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Mqoファイルの内容を保持するクラス。ただし、以下のものは保持しない。
    /// ・フォーマットバージョン("1.0"、"1.1"など)
    /// ・thumbnail(面倒なので。これは必要ないと思う。)
    /// 固定文字列(1行目の識別子など)は、本クラスでは保持しない。(ローダー/セーバーが知っていれば良いもの。)
    /// 各メンバのクラス名は、Mqoファイル内で使用されている名前に、プレフィックス"Mqo"を付加したものとする。
    /// </summary>
    public class MQDocument
    {
        /// <summary>
        /// シーン情報(モデルデータではなく、モデラー用のカメラや照明などの情報)
        /// </summary>
        public MqoScene Scene;

        /// <summary>
        /// 背景画像(モデルデータではなく、モデラー用の情報)
        /// </summary>
        public MqoBackImage BackImage;

        /// <summary>
        /// 素材情報(色、光沢などの情報)のリスト
        /// </summary>
        public List<MqoMaterial> Materials = new List<MqoMaterial>();

        /// <summary>
        /// オブジェクトのリスト
        /// 本来は、Objectsという名前にすべきかもしれないが、標準クラスのobjectのようでわかりにくいので、あえてMQObjectsとした。
        /// </summary>
        public List<MQObject> MQObjects = new List<MQObject>();

        public override string ToString()
        {
            string bs;
            if (BackImage == null)
                bs = "null";
            else
                bs = BackImage.ToString();

            var msb = new StringBuilder();
            for (var i = 0; i < Materials.Count; i++)
            {
                msb.Append("Material[" + i + "] = {\n" + Materials[i].ToString() + "}\n");
            }

            var osb = new StringBuilder();
            for (var i = 0; i < MQObjects.Count; i++)
            {
                osb.Append("MqoObjects[" + i + "] = {\n" + MQObjects[i].ToString() + "}\n");
            }

            return
                "Scene = {\n" + Scene.ToString() + "}\n"
                + "BackImage = {\n" + bs + "}\n"
                + msb.ToString()
                + osb.ToString();
        }

        internal static string ListToString<T>(List<T> objectList)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            if (objectList != null && objectList.Count > 0)
            {
                sb.Append(objectList[0]);
                for (int i = 1; i < objectList.Count; i++)
                {
                    sb.Append("," + objectList[i].ToString());
                }
            }

            sb.Append("}");
            return sb.ToString();
        }
    }
}
