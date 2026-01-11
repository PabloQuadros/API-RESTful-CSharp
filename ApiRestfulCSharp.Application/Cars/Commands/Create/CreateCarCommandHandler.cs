using ApiRestfulCSharp.Domain.Cars;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Commands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarCommandResponse>
{
    private readonly ICarRepository _repository;

    public CreateCarCommandHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public Task<CreateCarCommandResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new CarBuilder()
            .WithBrand(request.Brand)
            .WithModel(request.Model)
            .WithYear(request.Year)
            .WithColor(request.Color)
            .WithPrice(request.Price, request.Currency)
            .Build();
        
        _repository.Add(car);

        return Task.FromResult(new CreateCarCommandResponse(car.Id));
    }
}