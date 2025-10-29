using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

namespace ClaimDemo.Domain.Validation;

public class ReportedDateRangeAttribute : ValidationAttribute
{
    public ReportedDateRangeAttribute()
    {
        ErrorMessageResourceType = typeof(ErrorMessages);
        ErrorMessageResourceName = "ErrorMessage_ReportedDateRange_SE";
    }

    public override bool IsValid(object? value)
    {
        if (value is not DateTime date)
            return true;

        var now = DateTime.UtcNow.Date;
        if (date.Date > now)
            return false;
        if (date.Date < now.AddDays(-365))
            return false;
        return true;
    }
}