using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace ClaimDemo.Pages;

public partial class ClaimList : ComponentBase
{
    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private IClaimService ClaimService { get; set; } = default!;

    private IEnumerable<Claim>? claims;
    private IEnumerable<Claim>? filteredClaims;
    private string? selectedType;
    private DateTime? filterDateFrom;
    private DateTime? filterDateTo;
    private string sortBy = "date";
    private bool sortDescending = true;

    protected override async Task OnInitializedAsync()
    {
        claims = await ClaimService.GetAllClaims();
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        if (claims is null)
            return;

        filteredClaims = claims;

        if (!string.IsNullOrEmpty(selectedType) && Enum.TryParse<ClaimType>(selectedType, out var type))
        {
            filteredClaims = filteredClaims.Where(c => c.Type == type);
        }
        if (filterDateFrom.HasValue)
        {
            filteredClaims = filteredClaims.Where(c => c.ReportedDate.Date >= filterDateFrom.Value.Date);
        }
        if (filterDateTo.HasValue)
        {
            filteredClaims = filteredClaims.Where(c => c.ReportedDate.Date <= filterDateTo.Value.Date);
        }

        filteredClaims = sortBy switch
        {
            "type" => sortDescending
                ? filteredClaims.OrderByDescending(c => c.Type)
                : filteredClaims.OrderBy(c => c.Type),
            _ => sortDescending
                ? filteredClaims.OrderByDescending(c => c.ReportedDate)
                : filteredClaims.OrderBy(c => c.ReportedDate)
        };
    }

    private void ResetFilter()
    {
        selectedType = null;
        filterDateFrom = null;
        filterDateTo = null;
        ApplyFilter();
    }

    private void ToggleSortOrder()
    {
        sortDescending = !sortDescending;
        ApplyFilter();
    }

    private void GoToDetail(Guid claimId)
        => Navigation.NavigateTo($"/claimdetail/{claimId}");
}

