using ApiRestfulCSharp.Domain.Cars.ValueObjects;

namespace ApiRestfulCSharp.Domain.Cars;

public sealed class Car
{
    public Guid Id { get; private set; }
    public string Brand { get; private set; } 
    public string Model { get; private set; }
    public string Color { get; private set; }
    public int Year { get; private set; }
    public Money Price { get; private set; }


    internal Car(string brand, string model, string color, int year, Money price)
    {
        Id = Guid.NewGuid();
        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
        Price = price;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Brand))
            throw new ArgumentException("The brand is mandatory and cannot be empty.");

        if (string.IsNullOrWhiteSpace(Model))
            throw new ArgumentException("The model is mandatory and cannot be empty.\n");

        if (string.IsNullOrWhiteSpace(Color))
            throw new ArgumentException("Color is mandatory.");
        
        if (Year < 1886 || Year > DateTime.Now.Year + 1)
            throw new ArgumentException("The year must be later than 1886 and consistent with the current one.");    
        
        if (Price is null)
            throw new ArgumentException("Price is mandatory.");
    }

    public void AdjustPrice(Money newPrice)
    {
        if (newPrice is null)
            throw new ArgumentException("Price is mandatory.");

        var maxAllowedIncrease = Price.Amount * 1.5m;

        if (newPrice.Amount > maxAllowedIncrease && newPrice.Currency == Price.Currency)
            throw new InvalidOperationException(
                "The price cannot be increased by more than 50%."
            );

        Price = newPrice;
    }
}