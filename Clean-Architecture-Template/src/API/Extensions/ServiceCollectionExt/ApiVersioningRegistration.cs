namespace API.Extensions.ServiceCollectionExt;

using Microsoft.AspNetCore.Mvc.Versioning;

public static class ApiVersioningRegistration
{
    public static void AddApiVersioningService(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                // new QueryStringApiVersionReader("api-version"),
                // new HeaderApiVersionReader("X-API-Version"),
                // new MediaTypeApiVersionReader("ver"),
                new UrlSegmentApiVersionReader()
            );
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}
