using System;

namespace BadSample.Akiyama {
    public class DiscountManager {
        /// <summary>
        /// 顧客のランク、経過年数に応じた割引後の値段を返す。
        /// </summary>
        /// <param name="price">割引なしの値段</param>
        /// <param name="accountStatus">顧客のランク</param>
        /// <param name="years">顧客登録してからの経過年数</param>
        /// <returns>割引後の価格</returns>
        public static decimal ApplyDiscount(decimal price, MemberRank memberRank, int years) {
            if (memberRank == MemberRank.NonMember)
                return price;
            return price * (1 - _RankDiscountRatio(memberRank)) * (1 - _YearDiscountRatio(years));
        }

        /// <summary>
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        static decimal _RankDiscountRatio(MemberRank rank) {
            switch (rank) {
            case MemberRank.Silver:
                return 0.1m;
            case MemberRank.Gold:
                return 0.3m;
            case MemberRank.Platinum:
                return 0.5m;
            default:
                throw new NotSupportedException(rank.ToString());
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="year">契約年数</param>
        /// <returns>契約年数割引率</returns>
        static decimal _YearDiscountRatio(int years) {
            return Math.Min(years, 5) * 0.01m;
        }
    }
}
