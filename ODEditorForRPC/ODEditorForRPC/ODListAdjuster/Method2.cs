using System;
using ODEditorDocument;

namespace ODListAdjuster {
    public static class Method2 {
        // このアルゴリズムでは、以下のケースで無限ループに陥ってしまう。

        // 制約条件：各測光ポイントでの傾きが0.1以上。
        // STEP 0) P0 = 0, P1 = 0, P2 = 1000    => P0でNG
        // STEP 1) P0 = 0, P1 = 1000, P2 = 1000 => P0はOKだが、P1はNG
        // STEP 2) P0 = 0, P1 = 0, P2 = 1000    => P1はOKだが、P0がNG
        
        // OD値の自動修正を行う。
        public static bool Adjust(ODEditorDocument.ODEditorDocument doc) {
            int i;
            var new_raw_od = (int[]) doc.RawOD.Clone();
            var wb_od = new double[Constants.MaxSokkoPoint + 1];

            for (i = 0; i <= Constants.MaxSokkoPoint; i++) {
                wb_od[i] = doc.GetWBOD(i);
            }

            int px = 0; // 測光ポイント
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
                    // 2つ前の測光ポイントに戻ってやり直す。
                    px -= 2;
                } else if ((px < Constants.MaxSokkoPoint) && correctRawOD(doc, new_raw_od, wb_od, px + 1, px)) {
                    // 1つ前の測光ポイントに戻ってやり直す。
                    px -= 1;
                } else if ((px < Constants.MaxSokkoPoint - 1) && !correctRawOD(doc, new_raw_od, wb_od, px + 2, px)) {
                    // 現ポイントをやり直す。
                    ;
                } else {
                    return false;
                }
                if (px < 0)
                    px = 0;
            }
            doc.RawOD = new_raw_od;

            return true;
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
