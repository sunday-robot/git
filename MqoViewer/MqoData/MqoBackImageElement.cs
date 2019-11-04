using System.Text;

namespace MQData
{
    /// <summary>
    /// 背景画像情報
    /// </summary>
    public class MqoBackImageElement
    {
        /// <summary>
        /// 画像のファイルパス
        /// </summary>
        public string FilePath;

        /// <summary>
        /// 左座標
        /// </summary>
        public double Left;

        /// <summary>
        /// 上座標
        /// </summary>
        public double Top;

        /// <summary>
        /// 右座標
        /// </summary>
        public double Right;

        /// <summary>
        /// 下座標
        /// </summary>
        public double Bottom;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"" + FilePath + "\", ");
            sb.Append("Left = " + Left + ", ");
            sb.Append("Top = " + Top + ", ");
            sb.Append("Right = " + Right + ", ");
            sb.Append("Bottom = " + Bottom + ", ");
            return sb.ToString();
        }
    }
}
