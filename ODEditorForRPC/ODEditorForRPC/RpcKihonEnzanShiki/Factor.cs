using System.Collections;
using System.Collections.Generic;

namespace RpcKihonEnzanShiki {
    // 加減算項目
    public class Factor {
        public bool IsSubtrahend;   // 減数項目かどうかのフラグ
        public List<Term> Terms;

        public Factor() {
            this.IsSubtrahend = false;
            this.Terms = new List<Term>();
        }

        public double Evaluate(double a, double b, double c) {
            double v = 1;
            foreach (var t in this.Terms) {
                v *= t.Evaluate(a, b, c);
            }
            return this.IsSubtrahend ? -v : v;
        }

        public override string ToString() {
            string s = "";
            foreach (var t in this.Terms) {
                s += t.ToString();
            }
            if (s[0] == '*')
                s = s.Remove(0, 1);
            return (this.IsSubtrahend ? "-" : "+") + s;
        }

        public void GetVariables(ref Hashtable h) {
            foreach (var e in this.Terms) {
                e.GetVariables(ref h);
            }
        }
    }
}
