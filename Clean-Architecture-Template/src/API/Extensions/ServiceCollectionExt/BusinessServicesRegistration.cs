namespace API.Extensions.ServiceCollectionExt;

using Application.Services.Implementations;
using Application.Services.Interfaces;


public static class BusinessServicesRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ISampleService, SampleService>();
    }
}
