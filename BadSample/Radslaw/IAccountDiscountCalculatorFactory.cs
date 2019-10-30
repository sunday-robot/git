namespace BadSample.Radslaw0 {
    public interface IAccountDiscountCalculatorFactory {
        IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
    }
}
