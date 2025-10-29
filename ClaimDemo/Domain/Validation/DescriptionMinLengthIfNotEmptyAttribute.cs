using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

namespace ClaimDemo.Domain.Validation;

public class DescriptionMinLengthIfNotEmptyAttribute : ValidationAttribute
{
    private readonly int _minLength;

    public DescriptionMinLengthIfNotEmptyAttribute(int minLength)
    {
        _minLength = minLength;
        ErrorMessageResourceType = typeof(ErrorMessages);
        ErrorMessageResourceName = "ErrorMessage_DescriptionTooShort_SE";
    }

    public override bool IsValid(object? value)
    {
        if (value is null)
            return true;
        var str = value as string;
        if (string.IsNullOrWhiteSpace(str))
            return true;
        return str.Length >= _minLength;
    }
}