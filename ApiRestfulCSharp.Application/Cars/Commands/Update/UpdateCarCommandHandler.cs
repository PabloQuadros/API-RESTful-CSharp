using System;
using ApiRestfulCSharp.Domain.Cars;
using ApiRestfulCSharp.Domain.Cars.ValueObjects;
using ApiRestfulCSharp.Domain.Exceptions;
using MediatR;

namespace ApiRestfulCSharp.Application.Cars.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
{
    private readonly ICarRepository _repository;

    public UpdateCarCommandHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _repository.GetById(request.Id) ?? throw NotFoundException.For<Car>(request.Id);

        car.Update(
            brand: request.Brand,
            model: request.Model,
            color: request.Color,
            year: request.Year,
            new Money(request.Price, request.Currency)
        );

        _repository.Update(car);

        return Task.FromResult(Unit.Value);
    }
}