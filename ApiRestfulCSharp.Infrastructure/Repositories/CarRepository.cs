using ApiRestfulCSharp.Application.Cars;
using ApiRestfulCSharp.Application.Common;
using ApiRestfulCSharp.Domain.Cars;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ApiRestfulCSharp.Infrastructure.Extensions;

namespace ApiRestfulCSharp.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly List<Car> _cars = new();

    public (List<Car> Items, int TotalCount) GetAll(
        int page, 
        int pageSize, 
        string? brand, 
        string? sortBy, 
        bool isDescending)
    {
        var query = _cars.AsQueryable();
        
        query = query
            .ApplyFiltering(brand)
            .ApplySorting(sortBy, isDescending);
        
        var totalCount = query.Count();

        var items = query
            .ApplyPaging(page, pageSize)
            .ToList();

        return (items, totalCount);
    }

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

    public void Delete(Car car)
    {
        _cars.Remove(car);
    }
}