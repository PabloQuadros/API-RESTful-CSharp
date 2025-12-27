using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Commands.Create;

public sealed record CreateCarCommand(
    string Brand,
    string Model,
    string Color,
    int Year,
    decimal Price
) : IRequest<CreateCarCommandResponse>;