using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;

namespace ApiRestfulCSharp.Api.Configurations;

public class ConfigureApiVersioningOptions : 
    IConfigureOptions<ApiVersioningOptions>, 
    IConfigureOptions<ApiExplorerOptions>
{
    public void Configure(ApiVersioningOptions options)
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }

    public void Configure(ApiExplorerOptions options)
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    }
}