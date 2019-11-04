using System;
using System.Collections.Generic;
using System.Text;

namespace KomokubetsuBunsekiJoken {
    public class KomokubetsuBunsekiJokenList : List<KomokubetsuBunsekiJoken> {
        public KomokubetsuBunsekiJoken Get(int komokuNo, int sampleShubetsu) {
            foreach (var e in this) {
                if ((e.KomokuNo == komokuNo) && (e.SampleShubetsu == sampleShubetsu))
                    return e;
            }
            throw new Exception("指定された項目別分析条件がありません。");
        }
    }
}
