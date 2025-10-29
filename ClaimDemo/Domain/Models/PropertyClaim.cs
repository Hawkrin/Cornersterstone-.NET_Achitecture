using ClaimDemo.Domain.Enums;
using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

namespace ClaimDemo.Domain.Models;

public class PropertyClaim : Claim
{
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_AddressMissing_SE")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_TypeOfPropertyDamageMissing_SE")]
    public PropertyDamageType PropertyDamageType { get; set; }

    [Range(0, double.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_EstimatedDamageCostZero_SE")]
    public decimal EstimatedDamageCost { get; set; }

    public PropertyClaim()
    {
        Type = ClaimType.Property;
    }
}