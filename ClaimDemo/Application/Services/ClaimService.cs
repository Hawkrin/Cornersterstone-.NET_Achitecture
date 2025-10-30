using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Models;
using FluentResults;

namespace ClaimDemo.Application.Services;

public class ClaimService(
    IVehicleClaimService vehicleClaimService, 
    IPropertyClaimService propertyClaimService, 
    ITravelClaimService travelClaimService, 
    IClaimRepository repository) : IClaimService
{
    private readonly IClaimRepository _repository = repository;

    public async Task<Result<Claim>> CreateClaim(Claim claim)
    {
        claim.Id = Guid.NewGuid();

        switch (claim)
        {
            case VehicleClaim vehicle:
                vehicleClaimService.ApplyBusinessRules(vehicle);
                break;
            case PropertyClaim property:
                propertyClaimService.ApplyBusinessRules(property);
                break;
            case TravelClaim travel:
                travelClaimService.ApplyBusinessRules(travel);
                break;
        }

        return await _repository.Save(claim);
    }

    public async Task<Result> DeleteClaim(Guid id)
        => await _repository.DeleteClaim(id);

    public async Task<Result> UpdateClaim(Claim claim)
        => await _repository.UpdateClaim(claim);

    public async Task<IEnumerable<Claim>> GetAllClaims()
        => await _repository.GetAll();

}