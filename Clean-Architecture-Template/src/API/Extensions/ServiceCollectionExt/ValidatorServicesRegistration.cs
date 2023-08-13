namespace API.Extensions.ServiceCollectionExt;

using FluentValidation;
using SampleFilterV1 = Application.DTOs.V1.SampleFilter;
using SampleFilterValidatorV1 = Application.Validations.V1.SampleFilterValidator;

public static class ValidatorServicesRegistration
{
    public static void AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<SampleFilterV1>, SampleFilterValidatorV1>();
    }
}
