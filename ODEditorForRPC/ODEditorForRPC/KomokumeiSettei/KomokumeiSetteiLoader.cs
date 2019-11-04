using System;
using System.Collections.Generic;
using System.Text;

namespace KomokumeiSettei {
    public static class KomokumeiSetteiLoader {
        const int FileSize = 64 + 2 + 120 * 133;

        public static KomokumeiSetteiList Load(string fileName) {
            var list = new KomokumeiSetteiList();

            var f = System.IO.File.OpenRead(fileName);
            var buf = new byte[FileSize];
            var read_size = f.Read(buf, 0, FileSize);
            f.Close();

            if (read_size != FileSize) {
                throw new Exception("項目名設定パラメータファイルのサイズが異常です。");
            }

            for (int komokuNo = 1; komokuNo <= 120; komokuNo++) {
                int index = 64 + (komokuNo - 1) * 133;
                index += 2;

                var bunsekiKomokumei = Encoding.Unicode.GetString(buf, index, 12);
                index += 12;

                list.Add(new KomokumeiSettei(komokuNo, bunsekiKomokumei));
            }
            return list;
        }
    }
}
