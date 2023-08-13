namespace API.Extensions.ServiceCollectionExt;

using IMapperV1 = Application.Mapper.V1.IMapper;
using CustomMapperV1 = Infrastructure.Mapper.V1.CustomMapper;

public static class MapperServicesRegistration
{
    public static void AddMapperServices(this IServiceCollection services)
    {
        services.AddSingleton<IMapperV1, CustomMapperV1>();
    }
}
