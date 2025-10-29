using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;

namespace ClaimDemo.Application.Services;

public class PropertyClaimService(IClaimRepository claimRepository) : IPropertyClaimService
{
    private readonly int _highlyEstimatedCost = 50000;
    private readonly IClaimRepository _claimRepository = claimRepository;

    public void ApplyBusinessRules(PropertyClaim claim)
    {
        // BR2: High estimated cost
        if (claim.EstimatedDamageCost > _highlyEstimatedCost)
            claim.Statuses |= ClaimStatus.Escalated;

        // BR5: Multiple claims at the same address within 6 months
        var res = _claimRepository.GetByType(ClaimType.Property).Result;
        var similarClaims = res
            .Where(c => c is PropertyClaim pc 
                && pc.Address == claim.Address 
                && c.Id != claim.Id
                && Math.Abs((claim.ReportedDate - pc.ReportedDate).TotalDays) <= 180);

        if (similarClaims.Any())
            claim.Statuses |= ClaimStatus.FraudCheck;
    }
}
