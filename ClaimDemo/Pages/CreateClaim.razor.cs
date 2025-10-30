using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;
using ClaimDemo.Resources;
using Microsoft.AspNetCore.Components;

namespace ClaimDemo.Pages;

public partial class CreateClaim : ComponentBase
{
    [Inject]
    public IClaimService ClaimService { get; set; } = default!;

    [Inject] 
    public IToastService ToastService { get; set; } = default!;

    private Claim? claim = null;
    private ClaimType? selectedType;

    private async Task HandleValidSubmit()
    {
        try
        {
            var res = await ClaimService.CreateClaim(claim!);
            if (res.IsSuccess)
            {
                await ToastService.ShowSuccess(ResourceStrings.CreatedClaim_SuccessMessage_SE);
                claim = null;
                selectedType = null;
            }
            else
            {
                await ToastService.ShowError(ResourceStrings.CreatedClaim_FailMessage_SE);
            }
        }
        catch (Exception)
        {
            await ToastService.ShowError(ResourceStrings.ErrorMessage_SE);
        }
    }

    private void OnClaimTypeChanged()
    {
        if (selectedType.HasValue)
        {
            claim = selectedType.Value switch
            {
                ClaimType.Vehicle => new VehicleClaim(),
                ClaimType.Property => new PropertyClaim(),
                ClaimType.Travel => new TravelClaim(),
                _ => null,
            };
        }
    }
}
