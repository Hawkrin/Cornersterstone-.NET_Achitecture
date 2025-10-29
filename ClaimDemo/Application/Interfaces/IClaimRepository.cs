using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;
 
namespace ClaimDemo.Application.Interfaces;
 
public interface IClaimRepository
{
    Task<Claim> Save(Claim claim);
    Task<Claim?> GetById(Guid id);
    Task<IEnumerable<Claim>> GetAll();
    Task<IEnumerable<Claim>> GetByType(ClaimType type);
    Task UpdateClaim(Claim claim);
    Task DeleteClaim(Guid id);
}