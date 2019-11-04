using System.Text;

namespace MQData
{
    /// <summary>
    /// 背景画像情報(モデルデータではない)
    /// </summary>
    public class MqoBackImage
    {
        /// <summary>
        /// 投影図の背景画像情報
        /// </summary>
        public MqoBackImageElement Pers;

        /// <summary>
        /// 上面図の背景画像情報
        /// </summary>
        public MqoBackImageElement Top;

        /// <summary>
        /// 正面図の背景画像情報
        /// </summary>
        public MqoBackImageElement Front;

        /// <summary>
        /// 側面図の背景画像情報
        /// </summary>
        public MqoBackImageElement Left;

        /// <summary>
        /// ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("MqoBackImage {\n");
            sb.Append("Pers = " + _ToString(Pers) + "\n");
            sb.Append("Top = " + _ToString(Top) + "\n");
            sb.Append("Front = " + _ToString(Front) + "\n");
            sb.Append("Left = " + _ToString(Left) + "\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        private static string _ToString(object obj) {
            if (obj == null)
                return "(null)";
            return obj.ToString();
        }
    }
}
