
namespace RpcKomokubetsuEnzanShiki {
    // RPC項目別演算式パラメータ
    public class RpcKomokubetsuEnzanShiki {
        public int KomokuNo; // 項目番号
        //        public string KomokuName;   // 分析項目名
        public int SampleShubetsu; // 項目条件パラメータと同じくビットマップとしたが、本クラスにおいてはビットが立つのは1つだけ
        public bool IsRBKentai;    // RB検体かそれ以外か
        public int ConditionNo;         // 条件の番号(1～8)
        public int CheckStartPoint;    // チェック開始測光ポイント(0～27)
        public int CheckEndPoint;      // チェック終了測光ポイント(0～27)
        public int KihonEnzanShikiNo;  // 基本演算式の番号(1から20)
        public double KagenChi;        // 許容限界下限値
        public double JogenChi;        // 許容限界上限値

        public RpcKomokubetsuEnzanShiki(
            int komokuNo,
            //            string komokuName,
            int sampleShubetsu,
            bool isRBKentai,
            int conditionNo,
            int checkStartPoint,
            int checkEndPoint,
            int kihonEnzanShikiNo,
            double kagenChi,
            double jogenChi) {
            this.KomokuNo = komokuNo;
            //            this.KomokuName = komokuName;
            this.SampleShubetsu = sampleShubetsu;
            this.IsRBKentai = isRBKentai;
            this.ConditionNo = conditionNo;
            this.CheckStartPoint = checkStartPoint;
            this.CheckEndPoint = checkEndPoint;
            this.KihonEnzanShikiNo = kihonEnzanShikiNo;
            this.KagenChi = kagenChi;
            this.JogenChi = jogenChi;
        }

        public override string ToString() {
            return string.Format(
                "項目:{0,2}.{1,12}, "
                + "サンプル種別:{2}, "
                + "{3,-5}, "
                + "{4}, "
                + "P{5}～P{6}, "
                + "演算式No.:{7,2}, "
                + "許容範囲:{8,8} ～ {9,8}",
                this.KomokuNo, ""/*this.KomokuName*/,
                this.SampleShubetsu,
                this.IsRBKentai ? "RB" : "notRB",
                this.ConditionNo,
                this.CheckStartPoint, this.CheckEndPoint,
                this.KihonEnzanShikiNo,
                this.KagenChi, this.JogenChi);
        }
    }
}
