using System;
using System.Collections.Generic;
using System.Text;

namespace KomokubetsuBunsekiJoken {
    public static class KomokubetsuBunsekiJokenLoader {
        const int FileSize = 64 + 120 * 736 * 5;

        public static KomokubetsuBunsekiJokenList Load(string fileName) {
            var list = new KomokubetsuBunsekiJokenList();

            var f = System.IO.File.OpenRead(fileName);
            var buf = new byte[FileSize];
            var read_size = f.Read(buf, 0, FileSize);
            f.Close();

            if (read_size != FileSize) {
                throw new Exception("項目別分析条件パラメータファイルのサイズが異常です。");
            }

            for (int i = 0; i < 5; i++) {   // 血清、尿、その他、その他1、全血
                for (int komokuNo = 1; komokuNo <= 120; komokuNo++) {
                    int index = 64 + i * 736 * 120 + (komokuNo - 1) * 736;
                    if (buf[index] == 0)    // オペレーション
                        continue;           // オペレーション=Noの場合は何もしない
                    index += 70;

                    var shuHacho = BitConverter.ToInt32(buf, index);
                    index += 4;

                    var joken = new KomokubetsuBunsekiJoken(komokuNo, 1 << i, shuHacho);
                    list.Add(joken);
                }
            }
            return list;
        }
    }
}
