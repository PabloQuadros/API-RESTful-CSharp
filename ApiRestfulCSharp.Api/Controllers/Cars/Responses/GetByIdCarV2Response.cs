namespace ApiRestfulCSharp.Api.Controllers.Cars.Responses;

public record GetByIdCarV2Response(
    Guid Id, 
    string Brand, 
    string Model, 
    string Color,
    string Currency,
    decimal Price, 
    int Year
    );