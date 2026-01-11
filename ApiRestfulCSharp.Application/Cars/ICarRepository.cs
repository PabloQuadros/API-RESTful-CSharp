using ApiRestfulCSharp.Application.Common;
using ApiRestfulCSharp.Domain.Cars;

namespace ApiRestfulCSharp.Application.Cars;

public interface ICarRepository
{
    (List<Car> Items, int TotalCount) GetAll(
        int page, 
        int pageSize, 
        string? brand, 
        string? sortBy, 
        bool isDescending);
    Car? GetById(Guid id);
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);
}