using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Models;
using ClaimDemo.Resources;
using Microsoft.AspNetCore.Components;

namespace ClaimDemo.Pages;

public partial class ClaimDetail : ComponentBase
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    public IClaimService ClaimService { get; set; } = default!;

    [Inject]
    public IToastService ToastService { get; set; } = default!;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    private Claim? claim;
    private bool isEditMode = false;
    private bool showDeleteConfirm = false;

    protected override async Task OnInitializedAsync()
    {
        var allClaims = await ClaimService.GetAllClaims();
        claim = allClaims.FirstOrDefault(c => c.Id == Id);
    }

    private void EnableEdit() => isEditMode = true;
    private void CancelEdit() => isEditMode = false;

    private async void HandleValidUpdate()
    {
        isEditMode = false;
        try
        {
            var res = ClaimService.UpdateClaim(claim!);
            if (res != null)
            {
                await ToastService.ShowSuccess(ResourceStrings.UpdatedClaim_SuccessMessage_SE);
            }
            else
            {
                await ToastService.ShowError(ResourceStrings.ErrorMessage_SE);
            }
        }
        catch (Exception)
        {
            await ToastService.ShowError(ResourceStrings.ErrorMessage_SE);
        }
    }

    private async Task ConfirmDelete()
    {
        showDeleteConfirm = false;
        await ClaimService.DeleteClaim(claim!.Id);
        Navigation.NavigateTo("/claims/claimsList");

        await ToastService.ShowSuccess(ResourceStrings.DeleteClaim_SuccessMessage_SE);
        await Task.Delay(2000);
    }

    private void CancelDelete() => showDeleteConfirm = false;
    private void DeleteClaim() => showDeleteConfirm = true;
    private void GoBack() => Navigation.NavigateTo("/claims/claimsList");
}