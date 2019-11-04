using System;
using ODEditorDocument;

namespace ODListAdjuster {
    public static class Method4 {
        // OD値の自動修正を行う。
        public static bool Adjust(ODEditorDocument.ODEditorDocument doc) {
            var new_raw_od = (int[]) doc.RawOD.Clone();
            var wb_od = new double[Constants.MaxSokkoPoint + 1];

            for (int i = 0; i <= Constants.MaxSokkoPoint; i++) {
                wb_od[i] = doc.GetWBOD(i);
            }

            for (; ; ) {
                int correction_count = 0;   // データ修正回数
                int corr_px = 0;
                for (int eval_px = 0; eval_px <= Constants.MaxSokkoPoint; eval_px++) {
                    // 現ポイントで各演算式を評価する。
                    if (doc.IsOrderSatisfied(eval_px, wb_od)) {
                        // 現ポイントにおいて、全ての演算式の評価結果がユーザー指定通りなら、次のポイントに進む
                        continue;
                    }

                    if (corr_px < eval_px)
                        corr_px = eval_px;
                    int corr_px_end = Math.Min(eval_px + 2, Constants.MaxSokkoPoint);
                    for (; corr_px <= corr_px_end; corr_px++) {
                        if (correctRawOD(doc, new_raw_od, wb_od, corr_px, eval_px)) {
                            corr_px++;
                            correction_count++;
                            goto EVAL_PX_LOOP_END;
                        }
                    }
                    return false;

                EVAL_PX_LOOP_END:
                    ;
                }
                if (correction_count == 0) {
                    doc.RawOD = new_raw_od;
                    return true;
                }
            }
        }

        static bool correctRawOD(ODEditorDocument.ODEditorDocument doc, int[] raw_od, double[] wb_od, int px, int eval_px) {
            // 測光ポイントpxの生OD値を、測光ポイントeval_pxにおいてユーザーに指定された通りにNG/OKとなるように修正する。
            // 現状の生OD値を中心に正負の方向に1ずつ生OD値を修正し、ユーザー指定通りになったら終了する。
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
