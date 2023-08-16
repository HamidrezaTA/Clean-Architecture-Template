namespace Application.Validations.V1;

using FluentValidation;
using Application.DTOs.V1;
using Application.Validations.Rules;

public class SampleFilterValidatorV1 : AbstractValidator<SampleFilterV1>
{
    public SampleFilterValidatorV1()
    {
        RuleFor(dto => dto.From).DateTimeFormat();
        RuleFor(dto => dto.To).DateTimeFormat().GreaterThanDate(dto => dto.From);
    }
}