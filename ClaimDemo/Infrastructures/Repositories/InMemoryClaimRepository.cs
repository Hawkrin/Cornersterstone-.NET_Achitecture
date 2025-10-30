using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;
using FluentResults;

namespace ClaimDemo.Infrastructures.Repositories;

public class InMemoryClaimRepository : IClaimRepository
{
    private readonly List<Claim> _claims = [];

    public Task<IEnumerable<Claim>> GetAll()
        => Task.FromResult<IEnumerable<Claim>>(_claims);

    public Task<IEnumerable<Claim>> GetByType(ClaimType type)
    {
        var filteredClaims = _claims.Where(c => c.Type == type);
        return Task.FromResult(filteredClaims);
    }

    public Task<Claim?> GetById(Guid id)
    {
        var claim = _claims.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(claim);
    }

    public Task<Result<Claim>> Save(Claim claim)
    {
        _claims.Add(claim);
        return Task.FromResult(Result.Ok(claim));
    }

    public Task<Result> UpdateClaim(Claim claim)
    {
        var index = _claims.FindIndex(c => c.Id == claim.Id);
        if (index >= 0)
        {
            _claims[index] = claim;
            return Task.FromResult(Result.Ok());
        }
        else
        {
            return Task.FromResult(Result.Fail("Claim not found"));
        }
    }

    public Task<Result> DeleteClaim(Guid id)
    {
        var claim = _claims.FirstOrDefault(c => c.Id == id);
        if (claim != null)
        {
            _claims.Remove(claim);
            return Task.FromResult(Result.Ok());
        }
        else
        {
            return Task.FromResult(Result.Fail("Claim not found"));
        }
    }
}


