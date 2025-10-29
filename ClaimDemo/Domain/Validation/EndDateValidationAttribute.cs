using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

namespace ClaimDemo.Domain.Validation;
public class EndDateValidationAttribute(string startDatePropertyName, string reportDatePropertyName) : ValidationAttribute
{
    private readonly string _startDatePropertyName = startDatePropertyName;
    private readonly string _reportDatePropertyName = reportDatePropertyName;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var endDate = value as DateTime?;
        if (endDate is null)
            return ValidationResult.Success;

        var startDateValue = GetDateFromPropertyName(validationContext, _startDatePropertyName);
        if (startDateValue == null)
            return ValidationResult.Success;

        if (endDate.Value < startDateValue.Value)
            return new ValidationResult(ErrorMessages.ErrorMessage_EndDateBeforeStartDate_SE);

        var reportDateValue = GetDateFromPropertyName(validationContext, _reportDatePropertyName);
        if (reportDateValue != null && reportDateValue.Value > endDate.Value.AddDays(14))
            return new ValidationResult(ErrorMessages.ErrorMessage_ReportedTooLate_SE);

        return ValidationResult.Success;
    }

    private static DateTime? GetDateFromPropertyName(ValidationContext validationContext, string propertyName)
    {
        var dateProperty = validationContext.ObjectType.GetProperty(propertyName);
        if (dateProperty == null)
            return null;

        var dateValue = dateProperty.GetValue(validationContext.ObjectInstance) as DateTime?;
        return dateValue;
    }
}