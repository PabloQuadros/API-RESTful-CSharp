namespace ApiRestfulCSharp.Application.Cars.Queries.GetAll;

public record GetAllCarsQueryResponse(
    Guid Id, 
    string Brand, 
    string Model, 
    string Color,
    string Currency,
    decimal Price, 
    int Year
    );