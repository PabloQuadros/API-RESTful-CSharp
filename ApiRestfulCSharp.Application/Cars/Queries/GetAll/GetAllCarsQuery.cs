using ApiRestfulCSharp.Application.Common;
using ApiRestfulCSharp.Domain.Cars;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Queries.GetAll;

public record GetAllCarsQuery(
    int Page = 1,
    int PageSize = 10,
    string? Brand = null, 
    string? SortBy = "Year",
    bool IsDescending = false
) : IRequest<PaginatedResult<GetAllCarsQueryResponse>>;