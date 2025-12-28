using ApiRestfulCSharp.Api.Controllers.Cars.Requests;
using ApiRestfulCSharp.Application.Cars.Commands.Create;
using AutoMapper;

namespace ApiRestfulCSharp.Api.Controllers.Cars.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CreateCarRequest, CreateCarCommand>();
    }
}