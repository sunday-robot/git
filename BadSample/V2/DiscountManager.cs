using System;

namespace BadSample.V2 {
    public class DiscountManager {
        /// <summary>
        /// 顧客のステータス、経過年数に応じた割引後の値段を返す。
        /// </summary>
        /// <param name="amount">割引なしの値段</param>
        /// <param name="accountStatus">顧客のランク</param>
        /// <param name="years">顧客登録してからの経過年数</param>
        /// <returns></returns>
        public decimal Calculate(decimal amount, int type, int years) {
            if (type == 1)
                return amount;// 未登録なので割引なし

            // 顧客のステータスに応じた割引率を求める
            decimal ratio1;
            switch (type) {
            case 2:
                ratio1 = 0.1m;
                break;
            case 3:
                ratio1 = 0.3m;
                break;
            case 4:
                ratio1 = 0.5m;
                break;
            default:
                throw new NotSupportedException(type.ToString());
            }

            // 経過年数に応じた割引率
            decimal ratio2 = Math.Min(years, 5) * 0.01m;

            return amount * (1 - ratio1) * (1 - ratio2);
        }
    }
}
