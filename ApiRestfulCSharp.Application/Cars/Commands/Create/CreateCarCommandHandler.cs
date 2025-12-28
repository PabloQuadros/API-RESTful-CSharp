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

    public async Task<CreateCarCommandResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car(
            request.Brand,
            request.Model,
            request.Color,
            request.Year,
            request.Currency,
            request.Price
        );
        
        _repository.Add(car);
        
        return new CreateCarCommandResponse(car.Id);
    }
}