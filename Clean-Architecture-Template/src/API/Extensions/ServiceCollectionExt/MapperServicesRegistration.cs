namespace API.Extensions.ServiceCollectionExt;

using Application.Mapper;
using Infrastructure.Mapper;

public static class MapperServicesRegistration
{
    public static void AddMapperServices(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, CustomMapper>();
    }
}
