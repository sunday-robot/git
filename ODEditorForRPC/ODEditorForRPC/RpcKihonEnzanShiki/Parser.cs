using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RpcKihonEnzanShiki {
    // expression --> (null | '-') factor { ('+' | '-') factor}                        
    // factor --> term { ('*' | '/') term} 
    // term --> number | variable | '|' expression '|' | '(' expression ')'
    // 
    // number --> [0-9]+   // この正規表現では、"0123"も受け入れてしまうが、基本演算式で数値0は使用されない(意味が無い)ので、問題ない。
    // variable --> A | B | C

    public static class Parser {
        public static Expression Parse(string expression) {
            string e = expression.Clone() as string;
            try {
                return parseExpression(ref e);
            } catch (Exception exp) {
                string s = "式の解析が出来ません。(" + exp.Message + ")\n";
                s += expression + "\n" + "^".PadLeft(expression.Length - e.Length);
                throw new Exception(s);
            }
        }

        private static Expression parseExpression(ref string expression) {
            if (expression.Length == 0)
                throw new Exception("式がありません。");

            var e = new Expression();

            bool isSubtrahend; // 減数項目かどうかのフラグ
            if (expression[0] == '-') {
                isSubtrahend = true;
                expression = expression.Remove(0, 1);
            } else
                isSubtrahend = false;
            for (; ; ) {
                var f = parseFactor(ref expression);
                f.IsSubtrahend = isSubtrahend;
                e.Factors.Add(f);
                if (expression.Length == 0)
                    return e;

                switch (expression[0]) {
                case '+':
                    isSubtrahend = false;
                    break;
                case '-':
                    isSubtrahend = true;
                    break;
                default:
                    return e;
                }
                expression = expression.Remove(0, 1);
            }
        }

        private static Factor parseFactor(ref string expression) {
            var f = new Factor();

            bool isDivisor = false;    // 除数項目かどうかのフラグ
            for (; ; ) {
                var t = parseTerm(ref expression);
                t.IsDivisor = isDivisor;
                f.Terms.Add(t);
                if (expression.Length == 0)
                    return f;

                switch (expression[0]) {
                case '*':
                    isDivisor = false;
                    break;
                case '/':
                    isDivisor = true;
                    break;
                default:
                    return f;
                }
                expression = expression.Remove(0, 1);
            }
        }

        public static Term parseTerm(ref string expression) {
            if (expression.Length == 0) {
                throw new Exception("式が途中で終了しています。");
            }

            var t = new Term();
            Match m;

            m = Regex.Match(expression, "^[ABC]");
            if (m.Success) {
                t.TermType = TermType.VARIABLE;
                t.VariableSymbol = expression[0];
                expression = expression.Remove(0, 1);
                return t;
            }

            m = Regex.Match(expression, "^[0-9]+");
            if (m.Success) {
                t.TermType = TermType.NUMBER;
                t.Number = int.Parse(m.Value);
                expression = expression.Remove(0, m.Value.Length);
                return t;
            }

            if (expression[0] == '(') {
                expression = expression.Remove(0, 1);
                t.TermType = TermType.PAREN_EXPRESSION;
                t.Expression = parseExpression(ref expression);
                if ((expression.Length == 0) || (expression[0] != ')')) {
                    throw new Exception("')'が見つかりません。");
                }
                expression = expression.Remove(0, 1);   // ")"を削除する
                return t;
            }

            // 絶対値の処理
            if (expression[0] == '|') {
                expression = expression.Remove(0, 1);
                t.TermType = TermType.ABSOLUTE_EXPRESSION;
                t.Expression = parseExpression(ref expression);
                if ((expression.Length == 0) || (expression[0] != '|')) {
                    throw new Exception("'|'が見つかりません。");
                }
                expression = expression.Remove(0, 1);   // "|"(閉じ絶対値記号)を削除する
                return t;
            }

            throw new Exception("未知の文字です。");
        }

    }
}
