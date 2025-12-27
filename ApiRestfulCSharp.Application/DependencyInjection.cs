using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ApiRestfulCSharp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var myAssembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myAssembly));
        
        services.AddValidatorsFromAssembly(myAssembly);

        return services;
    }
}