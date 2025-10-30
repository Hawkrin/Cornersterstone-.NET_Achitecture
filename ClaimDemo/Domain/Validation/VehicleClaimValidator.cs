using ClaimDemo.Domain.Models;
using ClaimDemo.Resources;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ClaimDemo.Domain.Validation;

public partial class VehicleClaimValidator : ClaimValidator<VehicleClaim>
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

    public VehicleClaimValidator()
    {
        RuleFor(x => x.RegistrationNumber)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(ErrorMessages.ErrorMessage_RegistrationNumberMissing_SE)
            .Must(value => ABC123Regex().IsMatch(value) || ABC12DRegex().IsMatch(value))
            .WithMessage(ErrorMessages.ErrorMessage_RegistrationNumberFormat_SE);
    }
}