using ApiRestfulCSharp.Application.Cars.Commands.Create;
using ApiRestfulCSharp.Application.Cars.Queries.GetAll;
using ApiRestfulCSharp.Application.Cars.Queries.GetById;
using ApiRestfulCSharp.Domain.Cars;
using AutoMapper;

namespace ApiRestfulCSharp.Application.Cars.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, GetAllCarsQueryResponse>();
        CreateMap<Car, GetByIdCarQueryResponse>();
    }
}