using ApiRestfulCSharp.Domain.Cars;

namespace ApiRestfulCSharp.Application.Cars;

public interface ICarRepository
{
    List<Car> GetAll();
    Car? GetById(Guid id);
    void Add(Car car);
    void Update(Car car);
    void Delete(Guid id);
}