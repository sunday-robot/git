using System;
using System.Collections.Generic;
using System.Text;

namespace KomokubetsuBunsekiJoken {
    public class KomokubetsuBunsekiJoken {
        public int KomokuNo;        // 項目No.
        public int SampleShubetsu;  // サンプル種別
        public int ShuHacho;        // 主波長

        public KomokubetsuBunsekiJoken(int komokuNo, int sampleShubetsu, int shuHacho) {
            this.KomokuNo = komokuNo;
            this.SampleShubetsu = sampleShubetsu;
            this.ShuHacho = shuHacho;
        }
    }
}
