using System;
using ApiRestfulCSharp.Domain.Cars.ValueObjects;

namespace ApiRestfulCSharp.Domain.Cars;

public sealed class CarBuilder
{
    private string _brand;
    private string _model;
    private string _color;
    private int _year;
    private Money _price;

    public CarBuilder WithBrand(string brand)
    {
        _brand = brand;
        return this;
    }

    public CarBuilder WithModel(string model)
    {
        _model = model;
        return this;
    }

    public CarBuilder WithColor(string color)
    {
        _color = color;
        return this;
    }

    public CarBuilder WithYear(int year)
    {
        _year = year;
        return this;
    }

    public CarBuilder WithPrice(decimal amount, string currency)
    {
        _price = new Money(amount, currency);
        return this;
    }

    public Car Build()
    {
        return new Car(
            _brand,
            _model,
            _color,
            _year,
            _price
        );
    }
}
