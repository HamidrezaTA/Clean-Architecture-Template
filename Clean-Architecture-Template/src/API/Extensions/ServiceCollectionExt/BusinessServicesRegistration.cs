namespace API.Extensions.ServiceCollectionExt;

using ISampleCreateServiceV1 = Application.Services.Interfaces.V1.Sample.ISampleCreateService;
using SampleCreateServiceV1 = Application.Services.Implementations.V1.Sample.SampleCreateService;
using ISampleDeleteServiceV1 = Application.Services.Interfaces.V1.Sample.ISampleDeleteService;
using SampleDeleteServiceV1 = Application.Services.Implementations.V1.Sample.SampleDeleteService;
using ISampleGetAllServiceV1 = Application.Services.Interfaces.V1.Sample.ISampleGetAllService;
using SampleGetAllServiceV1 = Application.Services.Implementations.V1.Sample.SampleGetAllService;
using ISampleGetServiceV1 = Application.Services.Interfaces.V1.Sample.ISampleGetService;
using SampleGetServiceV1 = Application.Services.Implementations.V1.Sample.SampleGetService;
using ISampleUpdateServiceV1 = Application.Services.Interfaces.V1.Sample.ISampleUpdateService;
using SampleUpdateServiceV1 = Application.Services.Implementations.V1.Sample.SampleUpdateService;

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
