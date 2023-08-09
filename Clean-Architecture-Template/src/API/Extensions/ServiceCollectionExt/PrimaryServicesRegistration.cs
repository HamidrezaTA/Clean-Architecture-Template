namespace API.Extensions.ServiceCollectionExt;

using API.Extensions.MvcOptionsExt;

public static class PrimaryServicesRegistration
{
    public static void AddPrimaryServices(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ActionResultFilter>();
            options.Filters.Add<GlobalExceptionHandlerFilter>();
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddHttpContextAccessor();
    }
}
