using System.Collections.Generic;

namespace RpcKomokubetsuEnzanShiki {
    public class RpcKomokubetsuEnzanShikiList : List<RpcKomokubetsuEnzanShiki> {
        public override string ToString() {
            string s = "";
            foreach (var e in this) {
                s += e.ToString() + "\n";
            }
            return s;
        }
    }
}
