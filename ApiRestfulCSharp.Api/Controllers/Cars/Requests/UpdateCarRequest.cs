using System;

namespace ApiRestfulCSharp.Api.Controllers.Cars.Requests;

public record UpdateCarRequest(
    string Brand, 
    string Model, 
    string Color, 
    int Year, 
    string Currency,
    decimal Price
);