namespace BadSample.Radslaw0 {
    public interface ILoyaltyDiscountCalculator {
        decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
    }
}
