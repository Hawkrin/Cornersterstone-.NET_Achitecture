using ClaimDemo.Domain.Models;

namespace ClaimDemo.Application.Interfaces;

public interface IClaimService
{
    Task<Claim> CreateClaim(Claim claim);

    Task<IEnumerable<Claim>> GetAllClaims();

    Task UpdateClaim(Claim claim);

    Task DeleteClaim(Guid id);
}