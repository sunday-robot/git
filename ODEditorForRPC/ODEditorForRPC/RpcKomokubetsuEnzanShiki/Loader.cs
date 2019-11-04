using System;
using ODEditorDocument;
using System.Text;

namespace RpcKomokubetsuEnzanShiki {
    public static class Loader {
        const int fileSize = headerSize + komokuNameDataSize + sampleShubetsuBetsuDataSize * 5;
        const int headerSize = 64;
        const int komokuNameDataSize = 120 * 21;
        const int sampleShubetsuBetsuDataSize = 2 * kentaiShubetsuBetsuDataSize;
        const int kentaiShubetsuBetsuDataSize = 120 * komokuBetsuDataSize;
        const int komokuBetsuDataSize = 8 * jokenDataSize;
        const int jokenDataSize = 33;

        // RPC項目別演算式パラメータを読む
        public static RpcKomokubetsuEnzanShikiList Load(string fileName) {
            var list = new RpcKomokubetsuEnzanShikiList();

#if true
            var f = System.IO.File.OpenRead(fileName);
            var buf = new byte[fileSize];
            var read_size = f.Read(buf, 0, fileSize);
            f.Close();

            if (read_size != fileSize) {
                throw new Exception("RPC項目別演算式パラメータファイルのサイズが異常です。");
            }

            // 項目別演算式情報から、本プログラムに必要な情報を取得する。
            // (ファイルには項目名なども含まれているが、本プログラムでは使用しない(項目名設定パラメータのものを使用する)ので取得しない。)
            for (int sampleShubetsuIndex = 0; sampleShubetsuIndex < 5; sampleShubetsuIndex++) {     // 血清、尿、その他、その他1、全血の5種類
                for (int kentaiShubetsuIndex = 0; kentaiShubetsuIndex < 2; kentaiShubetsuIndex++) { // RB検体、RB検体以外の2種類
                    for (int komokuIndex = 0; komokuIndex < 120; komokuIndex++) {   // 1から120まで
                        for (int jokenIndex = 0; jokenIndex < 8; jokenIndex++) { // 演算式は最大8種類
                            int offset = headerSize + komokuNameDataSize
                                + sampleShubetsuIndex * sampleShubetsuBetsuDataSize
                                + kentaiShubetsuIndex * kentaiShubetsuBetsuDataSize
                                + komokuIndex * komokuBetsuDataSize
                                + jokenIndex * jokenDataSize;

                            // 判定実施有無
                            if (buf[offset] == 0)
                                continue;
                            offset++;

                            // 判定実施波長(本プログラムでは主波長固定とするのでスキップ)
                            offset += 4;

                            // チェック開始測光ポイント
                            var checkKaishiSokkoPoint = BitConverter.ToInt32(buf, offset);
                            offset += 4;

                            // チェック終了測光ポイント
                            var checkShuryoSokkoPoint = BitConverter.ToInt32(buf, offset);
                            offset += 4;

                            // 基本演算式番号
                            var kihonEnzanShikiNo = BitConverter.ToInt32(buf, offset);
                            kihonEnzanShikiNo++;    // ファイル上は演算式番号ではなく、演算式番号から1を差し引いた値が記録されている。
                            offset += 4;

                            // 許容限界下限値
                            var kyoyoGenkaiKagenchi = BitConverter.ToDouble(buf, offset);
                            offset += 8;

                            // 許容限界上限値
                            var kyoyoGenkaiJogenchi = BitConverter.ToDouble(buf, offset);

                            var shiki = new RpcKomokubetsuEnzanShiki(
                                komokuIndex + 1,
                                1 << sampleShubetsuIndex,
                                kentaiShubetsuIndex == 1,
                                jokenIndex + 1,
                                checkKaishiSokkoPoint, checkShuryoSokkoPoint,
                                kihonEnzanShikiNo,
                                kyoyoGenkaiKagenchi, kyoyoGenkaiJogenchi);
                            list.Add(shiki);
                        }
                    }
                }
            }
#else
            // 項目1、血清、RB検体以外
            list.Add(new RpcKomokubetsuEnzanShiki(1, "Test1", 1, false, 1, 0, Constants.SokkoEndPoint, -0.9, 2.1));
            list.Add(new RpcKomokubetsuEnzanShiki(1, "Test1", 1, false, 2, 0, Constants.SokkoEndPoint, 0, 1.0));
            list.Add(new RpcKomokubetsuEnzanShiki(1, "Test1", 1, false, 3, 0, Constants.SokkoEndPoint, -0.7, 1.3));

            // 項目2、尿、RB検体以外
            list.Add(new RpcKomokubetsuEnzanShiki(2, "Test2", 2, false, 1, 0, Constants.SokkoEndPoint, -0.2, 0.1));

            // 項目3、その他、RB検体以外
            list.Add(new RpcKomokubetsuEnzanShiki(3, "Test3", 4, false, 2, 0, Constants.SokkoEndPoint, 0.02, 0.05));
#endif
            return list;
        }
    }
}
