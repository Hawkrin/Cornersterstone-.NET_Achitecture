using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;
using FluentResults;

namespace ClaimDemo.Application.Interfaces;
 
public interface IClaimRepository
{
    Task<Result<Claim>> Save(Claim claim);
    Task<Claim?> GetById(Guid id);
    Task<IEnumerable<Claim>> GetAll();
    Task<IEnumerable<Claim>> GetByType(ClaimType type);
    Task<Result> UpdateClaim(Claim claim);
    Task<Result> DeleteClaim(Guid id);
}