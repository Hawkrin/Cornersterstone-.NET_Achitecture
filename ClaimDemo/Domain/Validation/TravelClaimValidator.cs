using ClaimDemo.Domain.Models;
using ClaimDemo.Resources;
using FluentValidation;

namespace ClaimDemo.Domain.Validation;

public class TravelClaimValidator : ClaimValidator<TravelClaim>
{
    public TravelClaimValidator()
    {
        RuleFor(x => x.Country)
            .IsInEnum()
            .WithMessage(ErrorMessages.ErrorMessage_CountryMissing_SE);

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage(ErrorMessages.ErrorMessage_StartDateMissing_SE);

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage(ErrorMessages.ErrorMessage_EndDateBeforeStartDate_SE);

        RuleFor(x => x.ReportedDate)
            .Must((claim, reportedDate) => reportedDate <= claim.EndDate.AddDays(14))
            .WithMessage(ErrorMessages.ErrorMessage_ReportedTooLate_SE);

        RuleFor(x => x.IncidentType)
            .IsInEnum()
            .WithMessage(ErrorMessages.ErrorMessage_TypeOfIncidentMissing_SE);
    }
}