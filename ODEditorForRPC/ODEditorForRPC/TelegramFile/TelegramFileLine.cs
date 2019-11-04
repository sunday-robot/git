using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramFile {
    // 20、21電文の電文ファイルの行のクラス
    [Serializable()]
    public class TelegramFileLine {
        public readonly int Offset;      // 先頭からの位置(0～)
        public readonly string OriginalText;     // 電文ファイルの1行

        // 以下はOriginalTextを解析した結果(データ行(ファイルの先頭部分や、空行、コメントのみの行など)で無い場合は
        // 何もセットされない)
        public readonly string DataType; // データタイプ("B"、"W"など。データ行で無い場合は""をセットする。)
        public readonly int DataCount;   // データ数("B2"の場合は2をセットする。)
        public readonly string Command;  // 電文生成コマンド("N"や、"I"など)
        public readonly byte[] Data;   // 電文のデータ部(データタイプが"B"または"W"で、電文生成コマンドが"N"の場合にのみセットする。)

        public TelegramFileLine(string originalText, int offset, string dataType, int dataCount, string command, byte[] data) {
            this.OriginalText = originalText;
            this.Offset = offset;
            this.DataType = dataType;
            this.DataCount = dataCount;
            this.Command = command;
            this.Data = data;
        }

        // 1つのデータのサイズを返す(データタイプに対応する。データタイプが"B"なら1、"W"なら2など)
        public int UnitSize {
            get {
                switch (this.DataType) {
                case "A":   // ASCII文字データ
                case "B":   // 符号なし1バイトデータ
                case "N":   // ASCII数値
                case "P":   // パックBCD1バイトデータ
                case "S":   // 符号付1バイトデータ
                    return 1;
                case "I":   // 符号あり2バイトデータ
                case "Q":   // パックBCD2バイトデータ
                case "W":   // 符号なし2バイトデータ
                    return 2;
                default:    // "D"符号なし4バイトデータ)、"R"(浮動小数点4バイトデータ)
                    return 4;
                }
            }
        }

        public int DataSize {
            get {
                return this.UnitSize * this.DataCount;
            }
        }
    }
}
