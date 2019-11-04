using System;
using System.Collections.Generic;

namespace RpcKihonEnzanShiki {
    public class RpcKihonEnzanShikiList : List<RpcKihonEnzanShiki> {
        public RpcKihonEnzanShikiList() {
        }

        public RpcKihonEnzanShiki GetByNumber(int no) {
            foreach (var e in this) {
                if (e.No == no)
                    return e;
            }
            throw new Exception("基本演算式番号が不正です。");
        }
    }
}
