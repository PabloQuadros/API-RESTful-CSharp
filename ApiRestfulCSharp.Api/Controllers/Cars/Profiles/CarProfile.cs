using ApiRestfulCSharp.Api.Controllers.Cars.Requests;
using ApiRestfulCSharp.Api.Controllers.Cars.Responses;
using ApiRestfulCSharp.Application.Cars.Commands.Create;
using ApiRestfulCSharp.Application.Cars.Queries.GetById;
using AutoMapper;

namespace ApiRestfulCSharp.Api.Controllers.Cars.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CreateCarRequest, CreateCarCommand>();
        
        CreateMap<GetByIdCarQueryResponse, GetByIdCarResponse>()
            .ConstructUsing(src => new GetByIdCarResponse(
                src.Id,
                $"Car {src.Model} - {src.Year} by {src.Brand} in {src.Color}, Price: {src.Currency} {src.Price}"
            ));

        CreateMap<GetByIdCarQueryResponse, GetByIdCarV2Response>();
    }
}