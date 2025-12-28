namespace ApiRestfulCSharp.Domain.Cars;

public sealed class Car
{
    public Guid Id { get; private set; }
    public string Brand { get; private set; } 
    public string Model { get; private set; }
    public string Color { get; private set; }
    public int Year { get; private set; }
    public string Currency { get; private set; }
    public decimal Price { get; private set; }


    public Car(string brand, string model, string color, int year, string currency ,decimal price)
    {
        Id = Guid.NewGuid();
        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
        Currency = currency;
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
    
        if (string.IsNullOrWhiteSpace(Currency))
            throw new ArgumentException("Currency is mandatory.");
        
        if (Price < 0)
            throw new ArgumentException("The price cannot be negative.");
    }
}