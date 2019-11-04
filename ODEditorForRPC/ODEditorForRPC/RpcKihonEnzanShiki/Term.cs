using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace RpcKihonEnzanShiki {
    // 乗除算項目
    public class Term {
        public bool IsDivisor; // 除数項目かどうかのフラグ
        public TermType TermType;
        public int Number;
        public char VariableSymbol;   // 'A', 'B', 'C'
        public Expression Expression;

        public Term() {
        }

        public double Evaluate(double a, double b, double c) {
            double v;

            switch (this.TermType) {
            case TermType.NUMBER:
                v = this.Number;
                break;
            case TermType.VARIABLE:
                switch (this.VariableSymbol) {
                case 'A':
                    v = a;
                    break;
                case 'B':
                    v = b;
                    break;
                default:
                    v = c;
                    break;
                }
                break;
            case TermType.ABSOLUTE_EXPRESSION:
                v = Math.Abs(this.Expression.Evaluate(a, b, c));
                break;
            default:
                v = this.Expression.Evaluate(a, b, c);
                break;
            }
            return this.IsDivisor ? 1 / v : v;
        }

        public override string ToString() {
            string s;
            switch (this.TermType) {
            case TermType.NUMBER:
                s = this.Number.ToString();
                break;
            case TermType.VARIABLE:
                s = this.VariableSymbol.ToString();
                break;
            case TermType.PAREN_EXPRESSION:
                s = "(" + this.Expression.ToString() + ")";
                break;
            default:
                s = "|" + this.Expression.ToString() + "|";
                break;
            }
            return (this.IsDivisor ? "/" : "*") + s;
        }

        public void GetVariables(ref Hashtable h) {
            switch (this.TermType) {
            case TermType.NUMBER:
                break;
            case TermType.VARIABLE:
                h[this.VariableSymbol] = 1;
                break;
            default:
                this.Expression.GetVariables(ref h);
                break;
            }
        }
    }

    public enum TermType {
        NUMBER,                 // 0以上の整数(実数ではない)
        VARIABLE,               // 変数("A"、"B"、"C")
        ABSOLUTE_EXPRESSION,    // 絶対値記号("|")で括られた式
        PAREN_EXPRESSION        // "("と")"で括られた式
    };
}
