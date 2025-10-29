using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Validation;
using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

namespace ClaimDemo.Domain.Models;

public class VehicleClaim : Claim
{
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_RegistrationNumberMissing_SE")]
    [RegistrationNumberFormat]
    public string RegistrationNumber { get; set; } = string.Empty;

    public string PlaceOfAccident { get; set; } = string.Empty;

    public VehicleClaim()
    {
        Type = ClaimType.Vehicle;
    }
}