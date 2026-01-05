using ApiRestfulCSharp.Application.Common;
using ApiRestfulCSharp.Domain.Cars;
using AutoMapper;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Queries.GetAll;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, PaginatedResult<GetAllCarsQueryResponse>>
{
    private readonly ICarRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCarsQueryHandler(ICarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

        var responseItems = _mapper.Map<List<GetAllCarsQueryResponse>>(cars);
        
        var result = new PaginatedResult<GetAllCarsQueryResponse>(
            responseItems, 
            totalCount, 
            request.Page, 
            request.PageSize
        );

        return Task.FromResult(result);
    }
}