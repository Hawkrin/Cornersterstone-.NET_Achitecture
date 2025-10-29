namespace ClaimDemo.Domain.Enums.Extensions;

public static class ClaimStatusExtensions
{
    public static IEnumerable<ClaimStatus> GetActiveStatuses(this ClaimStatus statuses)
    {
        foreach (ClaimStatus status in Enum.GetValues<ClaimStatus>())
        {
            if (status != ClaimStatus.None && statuses.HasFlag(status))
                yield return status;
        }
    }
}