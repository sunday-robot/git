using System;
using ODEditorDocument;

namespace ODListAdjuster {
    public static class Method3 {
        // このアルゴリズムでは、以下のケースで無限ループに陥ってしまう。

        // 制約条件：各測光ポイントでの傾きが0.1以上。(測光終了ポイントはP2とする)
        // STEP 0) P0 = 0, P1 = 0, P2 = 1000    => P0でNG
        // STEP 1) P0 = 0, P1 = 1000, P2 = 1000 => P1を修正し、その結果P1がNG。ただしP1は修正したばかりなのでスキップ。P2には制約条件がないのでP0に戻る。
        // STEP 2) P0 = 0, P1 = 1000, P2 = 1000 => P0がOKなので何もしない。
        // STEP 3) P0 = 0, P1 = 0, P2 = 1000    => P1がNGなので、P1を修正。(STEP 0に戻ってしまった!)

        // OD値の自動修正を行う。
        public static bool Adjust(ODEditorDocument.ODEditorDocument doc) {
            int i;
            var new_raw_od = (int[]) doc.RawOD.Clone();
            var wb_od = new double[Constants.MaxSokkoPoint + 1];

            for (i = 0; i <= Constants.MaxSokkoPoint; i++) {
                wb_od[i] = doc.GetWBOD(i);
            }

            for (; ; ) {
                int correction_count = 0;   // データ修正回数
                int px = 0;
                while (px <= Constants.MaxSokkoPoint) {
                    // 現ポイントで各演算式を評価する。
                    if (doc.IsOrderSatisfied(px, wb_od)) {
                        // 現ポイントにおいて、全ての演算式の評価結果がユーザー指定通りなら、次のポイントに進む
                        px++;
                        continue;
                    }

                    // ユーザー指定どおりでない演算式があった場合
                    // 現ポイントのOD値を修正する。
                    if (correctRawOD(doc, new_raw_od, wb_od, px, px)) {
                        correction_count++;
                        px++;   // 次のポイントに進む
                        continue;
                    }

                    // 次のポイントのOD値を修正する。
                    if ((px < Constants.MaxSokkoPoint) && correctRawOD(doc, new_raw_od, wb_od, px + 1, px)) {
                        correction_count++;
                        px += 2;   // 次の次のポイントに進む
                        continue;
                    }
                    // 次の次のポイントのOD値を修正する。
                    if ((px < 26) && !correctRawOD(doc, new_raw_od, wb_od, px + 2, px)) {
                        correction_count++;
                        px += 3;   // 次の次の次のポイントに進む
                        continue;
                    }
                    return false;
                }
                if (correction_count == 0)
                    return true;
            }
        }

        private static bool correctRawOD(ODEditorDocument.ODEditorDocument doc, int[] raw_od, double[] wb_od, int px, int eval_px) {
            int current_od = raw_od[px];
            int max_difference = Math.Max(current_od, 65535 - current_od);
            for (int i = 1; i <= max_difference; i++) {
                int new_od;

                new_od = current_od + i;
                if (new_od <= 65535) {
                    wb_od[px] = doc.CalcWBOD(new_od);
                    if (doc.IsOrderSatisfied(eval_px, wb_od)) {
                        raw_od[px] = new_od;
                        return true;
                    }
                }
                new_od = current_od - i;
                if (new_od >= 0) {
                    wb_od[px] = doc.CalcWBOD(new_od);
                    if (doc.IsOrderSatisfied(eval_px, wb_od)) {
                        raw_od[px] = new_od;
                        return true;
                    }
                }
            }
            wb_od[px] = doc.CalcWBOD(current_od);
            return false;   // 0～65535まで全て調べたがマッチしない。
        }
    }
}
