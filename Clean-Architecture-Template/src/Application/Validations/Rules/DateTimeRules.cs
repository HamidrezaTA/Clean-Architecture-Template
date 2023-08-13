namespace Application.Validations.Rules;

using System;
using System.Globalization;
using System.Linq.Expressions;
using FluentValidation;

public static class DateTimeRules
{
    public static IRuleBuilderOptions<T, DateTimeOffset?> DateTimeFormat<T>(
        this IRuleBuilder<T, DateTimeOffset?> ruleBuilder,
        bool nullable = true,
        string format = "yyyy-MM-dd HH:mm:ss"
    )
    {
        return ruleBuilder
            .Must(underReview =>
            {
                if (underReview == null) return nullable;

                return DateTimeOffset.TryParseExact(
                    input: underReview.Value.ToString(format),
                    format: format,
                    formatProvider: CultureInfo.InvariantCulture,
                    styles: DateTimeStyles.None,
                    result: out DateTimeOffset result);
            })
            .WithMessage(String.Format("Invalid date format! Please provide a valid date in the format '{0}'", format));
    }
    public static IRuleBuilderOptions<T, DateTime?> DateTimeFormat<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder,
        bool nullable = true,
        string format = "yyyy-MM-dd HH:mm:ss"
    )
    {
        return ruleBuilder
            .Must(underReview =>
            {
                if (underReview == null) return nullable;

                return DateTime.TryParseExact(
                    s: underReview.Value.ToString(format),
                    format: format,
                    provider: CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime result);
            })
            .WithMessage(String.Format("Invalid date format! Please provide a valid date in the format '{0}'", format));
    }
    public static IRuleBuilderOptions<T, DateTimeOffset?> GreaterThanDate<T>(
        this IRuleBuilder<T, DateTimeOffset?> ruleBuilder,
        Expression<Func<T, DateTimeOffset?>> dateExpression,
        bool nullable = true
    )
    {
        return ruleBuilder.Must((model, underReview) =>
        {
            DateTimeOffset? dateTime = dateExpression.Compile()(model);
            if (underReview.HasValue && dateTime.HasValue)
            {
                return underReview.Value > dateTime.Value;
            }

            return nullable;
        })
        .WithMessage("End date must be greater than start date.");
    }
    public static IRuleBuilderOptions<T, DateTime?> GreaterThanDate<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder,
        Expression<Func<T, DateTime?>> dateExpression,
        bool nullable = true
    )
    {
        return ruleBuilder.Must((model, underReview) =>
        {
            DateTime? dateTime = dateExpression.Compile()(model);
            if (underReview.HasValue && dateTime.HasValue)
            {
                return underReview.Value > dateTime.Value;
            }

            return nullable;
        })
        .WithMessage("End date must be greater than start date.");
    }


}
