namespace ClaimDemo.Domain.Validation;

using ClaimDemo.Domain.Models;
using ClaimDemo.Resources;
using FluentValidation;

public abstract class ClaimValidator<T> : AbstractValidator<T> where T : Claim
{
    public ClaimValidator()
    {
        RuleFor(x => x.ReportedDate)
        .NotEmpty().WithMessage(ErrorMessages.ErrorMessage_MissingReportedDate_SE)
        .Must(date => date.Date <= DateTime.UtcNow.Date)
            .WithMessage(ErrorMessages.ErrorMessage_ReportedDateRange_SE)
        .Must(date => date.Date >= DateTime.UtcNow.Date.AddDays(-365))
            .WithMessage(ErrorMessages.ErrorMessage_ReportedDateRange_SE);

        RuleFor(x => x.Description)
            .Must(desc => string.IsNullOrEmpty(desc) || desc.Length >= 20)
            .WithMessage(ErrorMessages.ErrorMessage_DescriptionTooShort_SE);
    }
}