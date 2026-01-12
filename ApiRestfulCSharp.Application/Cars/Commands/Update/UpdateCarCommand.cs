using System;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Commands.Update;

public sealed record UpdateCarCommand() : IRequest<Unit>
{
    public Guid Id { get; init; }
    public required string Brand { get; init; }
    public required string Model { get; init; }
    public required string Color { get; init; }
    public required string Currency { get; init; }
    public decimal Price { get; init; }
    public int Year { get; init; }
}
   