using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Commands.Delete;

public record DeleteCarCommand(Guid Id) : IRequest<Unit>;