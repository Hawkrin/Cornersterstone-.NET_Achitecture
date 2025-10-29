using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;

namespace ClaimDemo.Infrastructures.Repositories;

public class InMemoryClaimRepository : IClaimRepository
{
    private readonly List<Claim> _claims = [];

    public Task<IEnumerable<Claim>> GetAll() 
        => Task.FromResult<IEnumerable<Claim>>(_claims);

    public Task<IEnumerable<Claim>> GetByType(ClaimType type)
    {
        var filteredClaims = _claims.Where(c => c.Type == type);
        return Task.FromResult<IEnumerable<Claim>>(filteredClaims);
    }

    public Task<Claim?> GetById(Guid id)
    {
        var claim = _claims.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(claim);
    }

    public Task<Claim> Save(Claim claim)
    {
        _claims.Add(claim);
        return Task.FromResult(claim);
    }

    public Task UpdateClaim(Claim claim)
    {
        var index = _claims.FindIndex(c => c.Id == claim.Id);
        if (index >= 0)
        {
            _claims[index] = claim;
        }
        else
        {
            // förbättra felhantering
        }
        return Task.CompletedTask;
    }

    public Task DeleteClaim(Guid id)
    {
        var claim = _claims.FirstOrDefault(c => c.Id == id);
        if (claim != null)
        {
            _claims.Remove(claim);
        }
        else
        {
            // förbättra felhantering
        }
        return Task.CompletedTask;
    }
}


