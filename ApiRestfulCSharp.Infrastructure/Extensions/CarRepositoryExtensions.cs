using ApiRestfulCSharp.Domain.Cars;

namespace ApiRestfulCSharp.Infrastructure.Extensions;

public static class CarRepositoryExtensions
{
    public static IQueryable<Car> ApplyFiltering(this IQueryable<Car> query, string? brand)
    {
        if (string.IsNullOrWhiteSpace(brand))
            return query;

        return query.Where(c => c.Brand.Contains(brand, StringComparison.OrdinalIgnoreCase));
    }

    public static IQueryable<Car> ApplySorting(this IQueryable<Car> query, string? sortBy, bool isDescending)
    {
        return isDescending 
            ? sortBy?.ToLower() switch
            {
                "price" => query.OrderByDescending(c => c.Price),
                "model" => query.OrderByDescending(c => c.Model),
                "brand" => query.OrderByDescending(c => c.Brand),
                _ => query.OrderByDescending(c => c.Year)
            }
            : sortBy?.ToLower() switch
            {
                "price" => query.OrderBy(c => c.Price),
                "model" => query.OrderBy(c => c.Model),
                "brand" => query.OrderBy(c => c.Brand),
                _ => query.OrderBy(c => c.Year)
            };
    }
    
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int page, int pageSize)
    {
        return query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}