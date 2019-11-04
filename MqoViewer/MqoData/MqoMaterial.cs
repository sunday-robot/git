namespace MQData
{
    /// <summary>
    /// 素材情報(色、光沢などの情報)
    /// </summary>
    public class MqoMaterial
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name;

        /// <summary>
        /// シェーダーの種類(通常は3?)
        /// 0 Classic
        /// 1 Constant
        /// 2 Lambert
        /// 3 Phong
        /// 4 Blinn
        /// </summary>
        public int ShaderNo;

        /// <summary>
        /// 色(R, G, B, Aそれぞれ0～1)
        /// </summary>
        public MqoColor Col;

        /// <summary>
        /// 拡散光(0～1)
        /// </summary>
        public double Diff;

        /// <summary>
        /// 環境光(0～1)
        /// </summary>
        public double Amb;

        /// <summary>
        /// 自己照明(0～1)
        /// </summary>
        public double Emi;

        /// <summary>
        /// 反射光(0～1)
        /// </summary>
        public double Spc;

        /// <summary>
        /// 反射光の強さ(0～1)
        /// </summary>
        public double Power;

        /// <summary>
        /// テクスチャマッピング用画像ファイルのパス
        /// </summary>
        public string Tex;

        /// <summary>
        /// バンプマッピング用画像ファイルのパス
        /// </summary>
        public string Bump;

        /// <summary>
        /// マッピング方式0 UV
        /// 1 平面
        /// 2 円筒
        /// 3 球
        /// </summary>
        public int ProjType;

        /// <summary>
        /// 投影位置(X, Y, Z)
        /// </summary>
        public MQPoint ProjPos;

        /// <summary>
        /// 投影拡大率(X, Y, Z)
        /// </summary>
        public MQPoint ProjScale;

        /// <summary>
        /// 投影角度(H, P, B)
        /// </summary>
        public MQPoint ProjAngle;

        /// <summary>
        /// 鏡面反射(0.000～1.000)
        /// </summary>
        public double Reflect;

        /// <summary>
        /// 屈折率(1.000～5.000)
        /// </summary>
        public double Refract;

        public override string ToString()
        {
            string cs;
            if (Col == null)
                cs = "null";
            else
                cs = Col.ToString();

            return
                "Name = " + Name + "\n"
                + "ShaderNo = " + ShaderNo + "\n"
                + "Col = {\n" + cs + "}\n"
                + "Diff = " + Diff + "\n"
                + "Amb = " + Amb + "\n"
                + "Emi = " + Emi + "\n"
                + "Spc = " + Spc + "\n"
                + "Power = " + Power + "\n"
                + "Tex = " + Tex + "\n"
                + "Bump = " + Bump + "\n"
                + "ProjType = " + ProjType + "\n"
                + "ProjPos = " + ProjPos + "\n"
                + "ProjScale = " + ProjScale + "\n"
                + "ProjAngle = " + ProjAngle + "\n";
        }
    }
}
