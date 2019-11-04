using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Mq
{
    /// <summary>
    /// Mqoファイル専用のスキャナー。
    /// C#などのソースファイルと異なり、Mqoファイルでは、行が意味を持つ。
    /// </summary>
    public class Scanner
    {
        private static Regex _SymbolRE = new Regex("^[_A-Za-z][_0-9A-Za-z]*");
        private static Regex _NumberRE = new Regex(@"^-?[0-9]*(\.[0-9]+)?");

        private TextReader _TextReader;
        private string _Line = "";
        
        /// <summary>
        ///  現在の行番号
        /// </summary>
        private int _LineNumber = 0;

        public Scanner(TextReader tr)
        {
            _TextReader = tr;
        }

        public bool FetchLine()
        {
            while (true)
            {
                _Line = _TextReader.ReadLine();
                if (_Line == null)
                    return false;
                _LineNumber++;
                _Line = _Line.Trim();
                if (_Line.Length > 0)
                    return true;
            }
        }
        
        /// <summary>
        /// トークンを1つ返す。
        /// トークンがなければ(行末尾のトークンを既に読んでしまっている場合は)nullを返す。
        /// </summary>
        /// <returns>取得したトークンまたはnull</returns>
        public Object Get()
        {
            _Line = _Line.TrimStart();
            if (_Line.Length == 0)
                return null;

            var c = _Line[0];

            if (Char.IsLetter(c))
            {
                // シンボル
                var m = _SymbolRE.Match(_Line);
                _Line = _Line.Substring(m.Length);
                return new Symbol(m.Value);
            }
            else if (c == '-' || Char.IsDigit(c))
            {
                // 数値
                var m = _NumberRE.Match(_Line);
                _Line = _Line.Substring(m.Length);
                return Double.Parse(m.Value);
            }
            else if (c == '"')
            {
                // 文字列
                var index = _Line.IndexOf('"', 1);
                if (index < 0)
                {
                    throw new Exception("文字列終端の二重引用符がありません。");
                }
                var s = _Line.Substring(1, index - 1);
                _Line = _Line.Substring(index + 1);
                return s;
            }
            else
            {
                // 記号
                _Line = _Line.Substring(1);
                return new Symbol(c.ToString());
            }
        }

        internal int GetInteger()
        {
            var v = (double)Get();
            return (int)v;
        }

        internal void SetLineNumber(int lineNumber)
        {
            _LineNumber = lineNumber;
        }

        internal int GetLineNumber()
        {
            return _LineNumber;
        }
    }
}
