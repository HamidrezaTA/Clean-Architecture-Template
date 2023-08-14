namespace API.Extensions.ServiceCollectionExt;

using ISampleGetAllServiceV1 = Application.Services.Interfaces.V1.Sample.ISampleGetAllService;
using SampleGetAllServiceV1 = Application.Services.Implementations.V1.Sample.SampleGetAllService;
// TODO: must be separate services
using ISampleServiceV1 = Application.Services.Interfaces.V1.ISampleService;
using SampleServiceV1 = Application.Services.Implementations.V1.SampleService;

public static class BusinessServicesRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ISampleGetAllServiceV1, SampleGetAllServiceV1>();
        services.AddScoped<ISampleServiceV1, SampleServiceV1>();
    }
}
