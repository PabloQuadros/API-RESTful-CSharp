using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Queries.GetById;

public record GetByIdCarQuery(Guid Id) : IRequest<GetByIdCarQueryResponse>;