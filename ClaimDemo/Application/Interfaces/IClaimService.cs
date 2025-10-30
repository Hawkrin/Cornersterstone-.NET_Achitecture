using ClaimDemo.Domain.Models;
using FluentResults;

namespace ClaimDemo.Application.Interfaces;

public interface IClaimService
{
    Task<Result<Claim>> CreateClaim(Claim claim);
    Task<IEnumerable<Claim>> GetAllClaims();
    Task<Result> UpdateClaim(Claim claim);
    Task<Result> DeleteClaim(Guid id);
}