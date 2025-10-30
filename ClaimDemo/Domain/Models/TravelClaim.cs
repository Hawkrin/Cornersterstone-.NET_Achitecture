using ClaimDemo.Domain.Enums;

namespace ClaimDemo.Domain.Models;

public class TravelClaim : Claim
{
    public Country Country { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public DateTime EndDate { get; set; } = DateTime.UtcNow;

    public IncidentType IncidentType { get; set; }

    public TravelClaim()
    {
        Type = ClaimType.Travel;
    }
}