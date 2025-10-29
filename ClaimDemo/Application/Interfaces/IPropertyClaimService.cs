using ClaimDemo.Domain.Models;

namespace ClaimDemo.Application.Interfaces;

public interface IPropertyClaimService
{
    void ApplyBusinessRules(PropertyClaim claim);
}
