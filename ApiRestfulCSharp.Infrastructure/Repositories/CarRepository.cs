using ApiRestfulCSharp.Application.Cars;
using ApiRestfulCSharp.Domain.Cars;

namespace ApiRestfulCSharp.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly List<Car> _cars = new();

    public List<Car> GetAll() => _cars;

    public Car? GetById(Guid id) => _cars.FirstOrDefault(c => c.Id == id);

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        var existingCar = GetById(car.Id);
        if (existingCar == null) return;

        //TODO Adicionar update no car
    }

    public void Delete(Guid id)
    {
        var car = GetById(id);
        if (car != null) _cars.Remove(car);
    }
}