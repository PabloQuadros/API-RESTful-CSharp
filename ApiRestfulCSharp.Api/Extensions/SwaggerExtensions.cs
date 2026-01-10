using Asp.Versioning.ApiExplorer;

namespace ApiRestfulCSharp.Api.Extensions;

public static class SwaggerExtensions
{
    public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app)
    {
        app.UseSwagger();

        var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant()
                );
            }
        });

        return app;
    }
}