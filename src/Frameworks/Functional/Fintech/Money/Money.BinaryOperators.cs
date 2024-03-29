namespace Fintech;

public partial record Money
{
    public static Money operator +(Money left, Money right) =>
        left.Currency == right.Currency
            ? new(left.Amount + right.Amount, left.Currency)
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static Money operator +(Money left, decimal right) =>
        new(left.Amount + right, left.Currency);

    public static Money operator +(decimal left, Money right) =>
        new(left + right.Amount, right.Currency);

    public static Money operator -(Money left, Money right) =>
        left.Currency == right.Currency
            ? new(left.Amount - right.Amount, left.Currency)
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static Money operator -(Money left, decimal right) =>
        new(left.Amount - right, left.Currency);

    public static Money operator -(decimal left, Money right) =>
        new(left - right.Amount, right.Currency);

    public static Money operator *(Money left, Money right) =>
        left.Currency == right.Currency
            ? new(left.Amount * right.Amount, left.Currency)
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static Money operator *(Money left, decimal right) =>
        new(left.Amount * right, left.Currency);

    public static Money operator *(decimal left, Money right) =>
        new(left * right.Amount, right.Currency);

    public static Money operator /(Money left, Money right) =>
        left.Currency == right.Currency
            ? new(left.Amount / right.Amount, left.Currency)
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static Money operator /(Money left, decimal right) =>
        new(left.Amount / right, left.Currency);

    public static Money operator /(decimal left, Money right) =>
        new(left / right.Amount, right.Currency);
}