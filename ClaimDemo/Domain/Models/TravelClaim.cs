using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Validation;
using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

namespace ClaimDemo.Domain.Models;

public class TravelClaim : Claim
{
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_CountryMissing_SE")]
    public Country Country { get; set; }

    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_StartDateMissing_SE")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [EndDateValidation(nameof(StartDate), nameof(ReportedDate))]
    public DateTime EndDate { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_TypeOfIncidentMissing_SE")]
    public IncidentType IncidentType { get; set; }

    public TravelClaim()
    {
        Type = ClaimType.Travel;
    }
}