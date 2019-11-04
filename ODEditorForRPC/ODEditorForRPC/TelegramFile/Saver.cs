using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace TelegramFile {
    public static class Saver {
        static Regex titleLinePattern = new Regex("^ *\\[Title\\]", RegexOptions.IgnoreCase);
        static Regex tajuSokuteiTitlePattern = new Regex(" \\(多重測定No\\. = [1-4]\\)");

        // 電文ファイルデータを指定されたファイル名、OD値、多重測定No.でセーブする。
        // 多重測定No.が元の内容と異なる場合、タイトル行("[Title]"で始まる行に、"(多重測定No. = 2)"の様な文字列を付加する。
        public static void Save(TelegramFile denbunFile, string fileName, int hacho, int pxIndex, int[] odList, int tajuSokuteiNo) {
            if (denbunFile.TajuSokuteiNo == tajuSokuteiNo) {
                tajuSokuteiNo = 0;  // 多重測定No.が変更されていないことを示す。
            }

            var f = new StreamWriter(fileName, false, Encoding.GetEncoding("shift_jis"));
            for (int i = 0; i < denbunFile.Lines.Length; i++) {
                var row = denbunFile.Lines[i];
                var newData = getNewData(row, pxIndex, hacho, odList, tajuSokuteiNo);
                if (newData == null) {
                    if ((tajuSokuteiNo != 0)
                        && (titleLinePattern.IsMatch(row.OriginalText))) {
                            var m = tajuSokuteiTitlePattern.Match(row.OriginalText);
                            string s;
                            if (m.Success) {
                                s = row.OriginalText.Substring(0, m.Index);
                            } else {
                                s = row.OriginalText;
                            }
                            f.WriteLine(s + " (多重測定No. = " + tajuSokuteiNo + ")");
                    } else {
                        f.WriteLine(row.OriginalText);
                    }
                } else {
                    f.WriteLine(formatLine(row, newData));
                }
            }
            f.Close();
        }

        static byte[] getNewData(TelegramFileLine denbunFileLine, int pxIndex, int hacho, int[] odList, int tajuSokuteiNo) {
            if (denbunFileLine.Data == null)
                return null;

            var newData = denbunFileLine.Data.Clone() as byte[];
            bool flag = false;

            if ((tajuSokuteiNo != 0)
                && (denbunFileLine.Offset <= TelegramFile.TajuSokuteiNoOffset)
                && (denbunFileLine.Offset + denbunFileLine.DataSize > TelegramFile.TajuSokuteiNoOffset)) {
                newData[TelegramFile.TajuSokuteiNoOffset - denbunFileLine.Offset] = (byte) tajuSokuteiNo;
                flag = true;
            }
            
            int p0Offset = TelegramFile.ODListOffset + hacho * 2;

            if ((denbunFileLine.Offset + denbunFileLine.DataSize > p0Offset)
                && (denbunFileLine.Offset < p0Offset + 28 * 14 * 2 + 2)) {
                for (int i = 0; i < denbunFileLine.Data.Length; i++) {
                    int odListIndex;
                    int rem;

                    odListIndex = Math.DivRem(denbunFileLine.Offset + i - p0Offset, 28, out rem);

                    if (odListIndex == pxIndex)
                        continue;
                    if (odListIndex > pxIndex)
                        odListIndex--;

                    switch (rem) {
                    case 0:
                        newData[i] = (byte) (odList[odListIndex] >> 8);
                        break;
                    case 1:
                        newData[i] = (byte) (odList[odListIndex] & 0xff);
                        break;
                    default:
                        continue;
                    }

                    flag = true;
                }
            }
            if (!flag)
                return null;

            return newData;
        }

        // 解析結果のメンバから電文ファイルの1行を構築する
        static string formatLine(TelegramFileLine denbunFileLine, byte[] newData) {
            int i;
            var s = denbunFileLine.DataType + denbunFileLine.DataCount + " " + denbunFileLine.Command + " ";
            if (denbunFileLine.UnitSize == 1) {
                for (i = 0; i < denbunFileLine.DataCount; i++) {
                    s += newData[i].ToString() + ",";
                }
            } else {    // this.UnitSize == 2
                for (i = 0; i < denbunFileLine.DataCount; i++) {
                    s += Converter.BytesToInt(newData, i * 2).ToString() + ",";
                }
            }

            return s.Substring(0, s.Length - 1);    // 末尾に余分な","がついているので、これを削除した文字列を返す
        }
    }
}
