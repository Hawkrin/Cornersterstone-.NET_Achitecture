using ClaimDemo.Domain.Enums;

namespace ClaimDemo.Domain.Models;

public class VehicleClaim : Claim
{
    public string RegistrationNumber { get; set; } = string.Empty;

    public string PlaceOfAccident { get; set; } = string.Empty;

    public VehicleClaim()
    {
        Type = ClaimType.Vehicle;
    }
}