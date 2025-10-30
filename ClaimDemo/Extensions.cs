namespace ClaimDemo;

using ClaimDemo.Application.Interfaces;
using ClaimDemo.Application.Services;
using ClaimDemo.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class DIServiceExtensions
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IVehicleClaimService, VehicleClaimService>();
        services.AddScoped<IPropertyClaimService, PropertyClaimService>();
        services.AddScoped<ITravelClaimService, TravelClaimService>();
        return services;
    }

    public static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        services.AddSingleton<IClaimRepository, InMemoryClaimRepository>();
        services.AddSingleton<IToastService, ToastService>();
        return services;
    }
}