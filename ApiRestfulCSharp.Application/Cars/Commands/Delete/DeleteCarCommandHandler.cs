using ApiRestfulCSharp.Domain.Cars;
using ApiRestfulCSharp.Domain.Exceptions;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
{
    private readonly ICarRepository _repository;

    public DeleteCarCommandHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = _repository.GetById(request.Id) ?? throw NotFoundException.For<Car>(request.Id);
        
        _repository.Delete(car);
        
        return Task.FromResult(true);
    }
}