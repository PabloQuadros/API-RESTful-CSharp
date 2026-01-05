namespace ApiRestfulCSharp.Application.Cars.Queries.GetById;

public record GetByIdCarQueryResponse(    
    Guid Id, 
    string Brand, 
    string Model, 
    string Color,
    string Currency,
    decimal Price, 
    int Year
    );