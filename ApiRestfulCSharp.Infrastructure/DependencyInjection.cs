using ApiRestfulCSharp.Application.Cars;
using ApiRestfulCSharp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiRestfulCSharp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ICarRepository, CarRepository>();
        
        return services;
    }
}