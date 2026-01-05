using AutoMapper;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Queries.GetById;

public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarQueryResponse>
{
    private readonly ICarRepository _repository;
    private readonly IMapper _mapper;

    public GetByIdCarQueryHandler(ICarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public Task<GetByIdCarQueryResponse> Handle(
        GetByIdCarQuery request, 
        CancellationToken cancellationToken)
    {
        var car = _repository.GetById(request.Id);

        var result = _mapper.Map<GetByIdCarQueryResponse>(car);

        return Task.FromResult(result);
    }
}