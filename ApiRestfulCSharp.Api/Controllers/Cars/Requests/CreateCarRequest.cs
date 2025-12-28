namespace ApiRestfulCSharp.Api.Controllers.Cars.Requests;

public record CreateCarRequest(
    string Brand, 
    string Model, 
    string Color, 
    int Year, 
    string Currency,
    decimal Price
);