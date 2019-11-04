using System;
using System.Collections.Generic;
using System.Text;

namespace RpcKihonEnzanShiki {
    public static class Formatter {
        // 画面表示用の文字列に変換する
        public static string Format(RpcKihonEnzanShiki r) {
            return string.Format("{0,2}. {1}", r.No, FormatExpression(r.Expression));
        }

        public static string FormatExpression(Expression e) {
            string s = "";
            foreach (var f in e.Factors) {
                s += FormatFactor(f);
            }
            if (s[1] == '+')
                s = s.Remove(0, 3);
            else
                s = "-" + s.Remove(0, 3);
            return s;
        }

        // 画面表示用の文字列に変換する
        public static string FormatFactor(Factor f) {
            string s = "";
            foreach (var t in f.Terms) {
                s += FormatTerm(t);
            }
            s = s.Remove(0, 3); // 先頭の" * "を削除
            return (f.IsSubtrahend ? " - " : " + ") + s;
        }

        // 画面表示用の文字列に変換する
        public static string FormatTerm(Term t) {
            string s;
            switch (t.TermType) {
            case TermType.NUMBER:
                s = t.Number.ToString();
                break;
            case TermType.VARIABLE:
                switch (t.VariableSymbol) {
                case 'A':
                    s = "MP(n)";
                    break;
                case 'B':
                    s = "MP(n+1)";
                    break;
                default:
                    s = "MP(n+2)";
                    break;
                }
                break;
            case TermType.PAREN_EXPRESSION:
                s = "(" + FormatExpression(t.Expression) + ")";
                break;
            default:
                s = "|" + FormatExpression(t.Expression) + "|";
                break;
            }
            return (t.IsDivisor ? " / " : " * ") + s;
        }
    }
}
