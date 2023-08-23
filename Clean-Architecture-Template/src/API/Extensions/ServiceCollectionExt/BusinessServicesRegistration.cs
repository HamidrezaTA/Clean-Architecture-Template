using Application.Services.Implementations.V1.Sample;
using Application.Services.Interfaces.V1.Sample;

namespace API.Extensions.ServiceCollectionExt;

public static class BusinessServicesRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ISampleCreateServiceV1, SampleCreateServiceV1>();
        services.AddScoped<ISampleDeleteServiceV1, SampleDeleteServiceV1>();
        services.AddScoped<ISampleGetAllServiceV1, SampleGetAllServiceV1>();
        services.AddScoped<ISampleGetServiceV1, SampleGetServiceV1>();
        services.AddScoped<ISampleUpdateServiceV1, SampleUpdateServiceV1>();


    }
}
