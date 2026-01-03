namespace ApiRestfulCSharp.Application.Cars.Queries.GetAll;

public record GetAllCarsQueryResponse(
    Guid Id, 
    string Brand, 
    string Model, 
    string Color, 
    decimal Price, 
    int Year
    );