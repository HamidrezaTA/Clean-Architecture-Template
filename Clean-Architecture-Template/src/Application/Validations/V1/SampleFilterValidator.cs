namespace Application.Validations.V1;

using FluentValidation;
using Application.DTOs.V1;
using Application.Validations.Rules;

public class SampleFilterValidator : AbstractValidator<SampleFilter>
{
    public SampleFilterValidator()
    {
        RuleFor(dto => dto.From).DateTimeFormat();
        RuleFor(dto => dto.To).DateTimeFormat().GreaterThanDate(dto => dto.From);
    }
}