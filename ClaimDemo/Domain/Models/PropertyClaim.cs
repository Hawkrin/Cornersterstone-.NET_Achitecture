using ClaimDemo.Domain.Enums;

namespace ClaimDemo.Domain.Models;

public class PropertyClaim : Claim
{
    public string Address { get; set; } = string.Empty;

    public PropertyDamageType PropertyDamageType { get; set; }

    public decimal EstimatedDamageCost { get; set; }

    public PropertyClaim()
    {
        Type = ClaimType.Property;
    }
}