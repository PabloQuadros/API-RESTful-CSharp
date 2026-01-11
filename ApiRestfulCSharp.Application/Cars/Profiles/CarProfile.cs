using ApiRestfulCSharp.Application.Cars.Queries.GetAll;
using ApiRestfulCSharp.Application.Cars.Queries.GetById;
using ApiRestfulCSharp.Domain.Cars;
using AutoMapper;

namespace ApiRestfulCSharp.Application.Cars.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, GetAllCarsQueryResponseDto>()
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price.Amount)
            )
            .ForMember(
                dest => dest.Currency,
                opt => opt.MapFrom(src => src.Price.Currency)
            );

        CreateMap<Car, GetByIdCarQueryResponse>()
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price.Amount)
            )
            .ForMember(
                dest => dest.Currency,
                opt => opt.MapFrom(src => src.Price.Currency)
            );
    }
}