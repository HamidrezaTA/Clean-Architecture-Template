namespace API.Extensions.ServiceCollectionExt;

using Domain.Repositories;
using Infrastructure.Repositories;

public static class RepositoryServicesRegistration
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<ISampleRepository, SampleRepository>();
    }
}
