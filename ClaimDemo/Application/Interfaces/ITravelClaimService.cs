using ClaimDemo.Domain.Models;

namespace ClaimDemo.Application.Interfaces;

public interface ITravelClaimService
{
    void ApplyBusinessRules(TravelClaim claim);
}
