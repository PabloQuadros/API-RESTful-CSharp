using System;
using ApiRestfulCSharp.Domain.Exceptions;

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
            throw new DomainException("The amount cannot be negative.");

        if (string.IsNullOrWhiteSpace(Currency))
            throw new DomainException("Currency is mandatory.");
    }
}
