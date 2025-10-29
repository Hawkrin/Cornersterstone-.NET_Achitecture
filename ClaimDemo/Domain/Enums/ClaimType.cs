using System.ComponentModel.DataAnnotations;
using ClaimDemo.Resources;

namespace ClaimDemo.Domain.Enums;

public enum ClaimType
{
    [Display(ResourceType = typeof(ResourceStrings), Name = "ClaimType_Vehicle_SE")]
    Vehicle,
    [Display(ResourceType = typeof(ResourceStrings), Name = "ClaimType_Property_SE")]
    Property,
    [Display(ResourceType = typeof(ResourceStrings), Name = "ClaimType_Travel_SE")]
    Travel,
}