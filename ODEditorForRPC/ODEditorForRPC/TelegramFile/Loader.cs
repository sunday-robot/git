using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace TelegramFile {
    public static class Loader {
        private static System.Text.RegularExpressions.Regex regex;  // 行解析用の正規表現

        static Loader() {
            regex = new System.Text.RegularExpressions.Regex("^([ABDINPQRSW])([0-9]+) +(\\w+) +([^;]*)");
        }

        public static TelegramFile Load(string fileName, int pxIndex) {

            // ファイルを行単位で読む
            var lines = new List<string>();
            {
                var f = new StreamReader(fileName, Encoding.GetEncoding("shift_jis"));
                while (f.Peek() > 0) {
                    lines.Add(f.ReadLine());
                }
                f.Close();
            }

            var df = new TelegramFile(pxIndex);
            // 読んだファイル内容を解析する
            df.FileName = fileName;
            df.Lines = new TelegramFileLine[lines.Count];
            int offset = 0;
            for (int i = 0; i < lines.Count; i++) {
                string dataType;
                int dataCount;
                string command;
                byte[] data;

                ParseLine(lines[i], out dataType, out dataCount, out command, out data);

                var r = new TelegramFileLine(lines[i], offset, dataType, dataCount, command, data);

                offset += r.DataSize;
                df.Lines[i] = r;
            }
            if (offset < TelegramFile.ODListOffset + TelegramFile.ODListSize) {
                throw new Exception("指定されたファイルは、測光データ電文ファイルではありません。");
            }

            df.LastWriteTime = System.IO.File.GetLastWriteTime(fileName);

            return df;
        }

        public static void ParseLine(string line, out string dataType, out int dataCount,
            out string command, out byte[] data) {

            dataType = "";
            dataCount = 0;
            command = "";
            data = null;

            var m = regex.Match(line);
            if (!m.Success) {
                return;
            }

            dataType = m.Groups[1].Value;
            dataCount = int.Parse(m.Groups[2].Value);
            command = m.Groups[3].Value;

            if (command != "N")
                return;
            var fs = m.Groups[4].Value.Split(',');
            if (dataCount != fs.Length)
                throw new Exception("データタイプの次に記述されたデータ数と、実際のデータ数が異なる行があります。");
            if (dataType == "B") {
                data = new byte[dataCount];
                for (int i = 0; i < fs.Length; i++) {
                    data[i] = (byte) stringToInteger(fs[i]);
                }
            } else if (dataType == "W") {
                data = new byte[dataCount * 2];
                for (int i = 0; i < fs.Length; i++) {
                    int v = stringToInteger(fs[i]);
                    data[i * 2] = (byte) ((0xff00 & v) >> 8);
                    data[i * 2 + 1] = (byte) (v & 0xff);
                }
            }
        }

        // 10進数または"0x"、"0X"で始まる16進数文字列を整数に変換する
        private static int stringToInteger(string s) {
            s = s.Trim();
            if (s.Length >= 3) {
                var prefix = s.Substring(0, 2);
                switch (prefix) {
                case "0x":
                case "0X":
                    return Convert.ToUInt16(s.Substring(2), 16);
                }
            }
            return int.Parse(s);
        }

    }
}
