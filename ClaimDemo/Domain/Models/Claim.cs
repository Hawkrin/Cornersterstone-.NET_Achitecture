namespace ClaimDemo.Domain.Models;

using ClaimDemo.Domain.Enums;
using ClaimDemo.Domain.Validation;
using ClaimDemo.Resources;
using System.ComponentModel.DataAnnotations;

public abstract class Claim
{
    public Guid Id { get; set; }

    public ClaimType Type { get; set; }

    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "ErrorMessage_MissingReportedDate_SE")]
    [ReportedDateRange]
    public DateTime ReportedDate { get; set; } = DateTime.UtcNow;

    [DescriptionMinLengthIfNotEmpty(20)]
    public string Description { get; set; } = string.Empty;

    public ClaimStatus Statuses { get; set; } = ClaimStatus.None;

}