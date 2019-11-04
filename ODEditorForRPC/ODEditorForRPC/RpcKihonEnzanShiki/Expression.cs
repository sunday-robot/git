using System;
using System.Collections;
using System.Collections.Generic;

namespace RpcKihonEnzanShiki {
    // 基本演算式
    public class Expression {
        public List<Factor> Factors;

        public Expression() {
            this.Factors = new List<Factor>();
        }

        // 式を評価(計算)する。
        public double Evaluate(double a, double b, double c) {
            double v = 0;
            foreach (var f in this.Factors) {
                v += f.Evaluate(a, b, c);
            }
            return Math.Round(v, 4);    // 小数部4桁に丸める(四捨五入する)
        }

        public override string ToString() {
            string s = "";
            foreach (var f in this.Factors) {
                s += f.ToString();
            }
            if (s[0] == '+')
                s = s.Remove(0, 1);
            return s;
        }

        public void GetVariables(ref Hashtable h) {
            foreach (var e in this.Factors) {
                e.GetVariables(ref h);
            }
        }
    }
}
