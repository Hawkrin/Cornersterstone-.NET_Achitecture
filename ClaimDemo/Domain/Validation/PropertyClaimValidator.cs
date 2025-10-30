using ClaimDemo.Domain.Models;
using ClaimDemo.Resources;
using FluentValidation;

namespace ClaimDemo.Domain.Validation;

public class PropertyClaimValidator : ClaimValidator<PropertyClaim>
{
    public PropertyClaimValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage(ErrorMessages.ErrorMessage_AddressMissing_SE);

        RuleFor(x => x.PropertyDamageType)
            .IsInEnum()
            .WithMessage(ErrorMessages.ErrorMessage_TypeOfPropertyDamageMissing_SE);

        RuleFor(x => x.EstimatedDamageCost)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ErrorMessages.ErrorMessage_EstimatedDamageCostZero_SE);
    }
}