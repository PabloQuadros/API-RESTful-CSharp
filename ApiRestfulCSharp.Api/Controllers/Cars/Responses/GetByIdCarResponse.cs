namespace ApiRestfulCSharp.Api.Controllers.Cars.Responses;

public record GetByIdCarResponse(
    Guid Id,
    string Description
    );
