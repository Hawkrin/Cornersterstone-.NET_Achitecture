using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;

namespace ClaimDemo.Application.Services;

public class VehicleClaimService : IVehicleClaimService
{
    public void ApplyBusinessRules(VehicleClaim claim)
    {
        // BR1: Claim reported more than 30 days after the incident
        if ((DateTime.UtcNow - claim.ReportedDate).TotalDays > 30)
            claim.Statuses |= ClaimStatus.RequiresManualReview;
    }
}