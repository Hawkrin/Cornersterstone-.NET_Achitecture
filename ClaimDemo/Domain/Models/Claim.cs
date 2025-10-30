namespace ClaimDemo.Domain.Models;

using ClaimDemo.Domain.Enums;

public abstract class Claim
{
    public Guid Id { get; set; }

    public ClaimType Type { get; set; }

    public DateTime ReportedDate { get; set; } = DateTime.UtcNow;

    public string Description { get; set; } = string.Empty;

    public ClaimStatus Statuses { get; set; } = ClaimStatus.None;

}