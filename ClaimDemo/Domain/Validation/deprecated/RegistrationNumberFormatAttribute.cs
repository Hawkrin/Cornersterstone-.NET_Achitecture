using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClaimDemo.Domain.Validation;

public partial class RegistrationNumberFormatAttribute : ValidationAttribute
{
    /// <summary>
    /// ABC123: 3 letters + 3 digits
    /// </summary>
    [GeneratedRegex(@"^[A-Za-z]{3}\d{3}$")]
    private static partial Regex ABC123Regex();

    /// <summary>
    /// ABC12D: 3 letters + 2 digits + 1 letter
    /// </summary>
    [GeneratedRegex(@"^[A-Za-z]{3}\d{2}[A-Za-z]{1}$")]
    private static partial Regex ABC12DRegex();

    public RegistrationNumberFormatAttribute()
    {
        ErrorMessageResourceType = typeof(ErrorMessages);
        ErrorMessageResourceName = "ErrorMessage_RegistrationNumberFormat_SE";
    }

    public override bool IsValid(object? value)
    {
        if (value is not string str || string.IsNullOrWhiteSpace(str))
            return true;

        return ABC123Regex().IsMatch(str) || ABC12DRegex().IsMatch(str);
    }
}
