using System;

namespace ApiRestfulCSharp.Domain.Cars.ValueObjects;

public sealed record Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
        
        Validate();
    }

    private void Validate()
    {
        if (Amount < 0)
            throw new ArgumentException("The amount cannot be negative.");

        if (string.IsNullOrWhiteSpace(Currency))
            throw new ArgumentException("Currency is mandatory.");
    }
}
