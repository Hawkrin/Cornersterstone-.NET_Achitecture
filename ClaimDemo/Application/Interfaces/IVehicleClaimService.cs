using ClaimDemo.Domain.Models;

namespace ClaimDemo.Application.Interfaces;

public interface IVehicleClaimService
{
    void ApplyBusinessRules(VehicleClaim claim);
}
