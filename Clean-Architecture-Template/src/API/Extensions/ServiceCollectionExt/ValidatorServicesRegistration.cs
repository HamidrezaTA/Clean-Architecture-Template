namespace API.Extensions.ServiceCollectionExt;

using Application.DTOs.V1;
using Application.Validations.V1;
using FluentValidation;

public static class ValidatorServicesRegistration
{
    public static void AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<SampleFilterV1>, SampleFilterValidatorV1>();
    }
}
