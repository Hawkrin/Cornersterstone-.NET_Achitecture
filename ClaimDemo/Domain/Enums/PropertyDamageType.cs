using System.ComponentModel.DataAnnotations;
using ClaimDemo.Resources;

namespace ClaimDemo.Domain.Enums;

public enum PropertyDamageType
{
    [Display(ResourceType = typeof(ResourceStrings), Name = "PropertyDamageType_Fire_SE")]
    Fire,
    [Display(ResourceType = typeof(ResourceStrings), Name = "PropertyDamageType_Water_SE")]
    Water,
    [Display(ResourceType = typeof(ResourceStrings), Name = "PropertyDamageType_Theft_SE")]
    Theft
}