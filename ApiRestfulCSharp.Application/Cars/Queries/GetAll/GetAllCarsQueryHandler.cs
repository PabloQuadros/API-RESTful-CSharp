using ApiRestfulCSharp.Application.Common;
using ApiRestfulCSharp.Domain.Cars;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Queries.GetAll;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, PaginatedResult<GetAllCarsQueryResponse>>
{
    private readonly ICarRepository _repository;

    public GetAllCarsQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public Task<PaginatedResult<GetAllCarsQueryResponse>> Handle(
        GetAllCarsQuery request, 
        CancellationToken cancellationToken)
    {
        var (cars, totalCount) = _repository.GetAll(
            request.Page,
            request.PageSize,
            request.Brand,
            request.SortBy,
            request.IsDescending);

        var responseItems = cars.Select(c => new GetAllCarsQueryResponse(
            c.Id,
            c.Brand,
            c.Model,
            c.Color,
            c.Price,
            c.Year
        )).ToList();
        
        var result = new PaginatedResult<GetAllCarsQueryResponse>(
            responseItems, 
            totalCount, 
            request.Page, 
            request.PageSize
        );

        return Task.FromResult(result);
    }
}