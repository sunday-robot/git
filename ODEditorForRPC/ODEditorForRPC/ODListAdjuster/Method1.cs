using System;
using ODEditorDocument;

namespace ODListAdjuster {
    public static class Method1 {
        // このアルゴリズムでは、以下のケースであっさり解なしとして終了してしまう。

        // 制約条件：各測光ポイントでの傾きが0.1以上。
        // STEP 0) P0 = 0, P1 = 0, P2 = 1000    => P0でNG
        // P0のOD値をいくら大きくしてもダメ。
        
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
                if (!correctRawOD(doc, new_raw_od, wb_od, px)) {
                    return false;
                }
                // 2つ前の測光ポイントに戻ってやり直す。
                px -= 2;
                if (px < 0)
                    px = 0;
            }

            doc.RawOD = new_raw_od;
            return true;
        }

        // P27から生OD値を修正する。
        private static bool adjust_backward(ODEditorDocument.ODEditorDocument doc) {
            int i;
            var new_raw_od = (int[]) doc.RawOD.Clone();
            var wb_od = new double[Constants.MaxSokkoPoint + 1];

            for (i = 0; i <= Constants.MaxSokkoPoint; i++) {
                wb_od[i] = doc.GetWBOD(i);
            }

            int px = Constants.MaxSokkoPoint; // 測光ポイント
            while (px >= 0) {
                // 現ポイントで各演算式を評価する。
                if (doc.IsOrderSatisfied(px, wb_od)) {
                    // 現ポイントにおいて、全ての演算式の評価結果がユーザー指定通りなら、次のポイントに進む
                    px--;
                    continue;
                }
                // ユーザー指定どおりでない演算式があった場合
                // 現ポイントのOD値を修正する。
                if (!correctRawOD(doc, new_raw_od, wb_od, px)) {
                    return false;
                }
                // 2つ前の測光ポイントに戻ってやり直す。
                px += 2;
                if (px > Constants.MaxSokkoPoint)
                    px = Constants.MaxSokkoPoint;
            }

            doc.RawOD = new_raw_od;
            return true;
        }

        private static bool correctRawOD(ODEditorDocument.ODEditorDocument doc, int[] raw_od, double[] wb_od, int px) {
            int current_od = raw_od[px];
            int max_difference = Math.Max(current_od, 65535 - current_od);
            for (int i = 1; i <= max_difference; i++) {
                int new_od;

                new_od = current_od + i;
                if (new_od <= 65535) {
                    wb_od[px] = doc.CalcWBOD(new_od);
                    if (doc.IsOrderSatisfied(px, wb_od)) {
                        raw_od[px] = new_od;
                        return true;
                    }
                }
                new_od = current_od - i;
                if (new_od >= 0) {
                    wb_od[px] = doc.CalcWBOD(new_od);
                    if (doc.IsOrderSatisfied(px, wb_od)) {
                        raw_od[px] = new_od;
                        return true;
                    }
                }
            }
            return false;   // 0～65535まで全て調べたがマッチしない。
        }

    }
}
