using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramFile {
    // 20、21電文の電文ファイルのクラス
    [Serializable()]
    public class TelegramFile {
        public const int TajuSokuteiNoOffset = 52;  // 多重測定No.のオフセット
        public const int ODListOffset = 184;        // 電文上、OD値が始まるオフセット
        public const int ODListSize = 29 * 14 * 2;  // 電文上は、P0～P27の28個ではなく、もう1つ余分なデータ(M541の場合P10とP11の間のPX、M519の場合はP27の後のダミーデータ)がある。

        string fileName;        // フルパス
        DateTime lastWriteTime; // ファイルロード時の最終更新日時(上書き保存時に、他のプログラムで書き換えられていないかを確認するためのもの)
        TelegramFileLine[] lines; // 各行の内容

        public TelegramFile(int pxIndex) {
            this.fileName = "";
            this.lines = new TelegramFileLine[0];
        }

        #region プロパティ

        public string FileName {
            get {
                return this.fileName;
            }
            set {
                this.fileName = value;
            }
        }

        public DateTime LastWriteTime {
            get {
                return this.lastWriteTime;
            }
            set {
                this.lastWriteTime = value;
            }
        }

        public TelegramFileLine[] Lines {
            get {
                return this.lines;
            }
            set {
                this.lines = value;
            }
        }

        public string Contents {
            get {
                string s = "";
                foreach (var e in this.lines) {
                    s += e.OriginalText + System.Environment.NewLine;
                }
                return s;
            }
        }

        public int TajuSokuteiNo {
            get {
                return this.getByte(TajuSokuteiNoOffset);
            }
        }

        #endregion プロパティ

        public int[] GetODList(int hacho, int pxIndex) {
            var odList = new int[28];
            int p0Offset = ODListOffset + hacho * 2;

            int i;
            for (i = 0; i < pxIndex; i++) {
                odList[i] = this.getUShort(p0Offset + i * 14 * 2);
            }
            for (i = pxIndex + 1; i < 29; i++) {
                odList[i - 1] = this.getUShort(p0Offset + i * 14 * 2);
            }

            return odList;
        }

        byte getByte(int offset) {
            int i;
            for (i = 0; i < this.lines.Length; i++) {
                var l = this.lines[i];
                if (l.Offset + l.DataSize <= offset) {
                    continue;
                }
                if (l.Data == null) {
                    throw new Exception(
                        "以下の行からオフセット " + offset + " のデータ取得は出来ません。\n"
                        + "行番号:" + (i + 1) + "\n"
                        + l.OriginalText);
                }
                return l.Data[offset - l.Offset];
            }
            throw new Exception(string.Format("電文ファイルにオフセット{0}({1:X}h)のデータはありません。", offset, offset));
        }

        ushort getUShort(int offset) {
            var h = this.getByte(offset);
            var l = this.getByte(offset + 1);

            return (ushort) (h * 256 + l);
        }
    }
}
