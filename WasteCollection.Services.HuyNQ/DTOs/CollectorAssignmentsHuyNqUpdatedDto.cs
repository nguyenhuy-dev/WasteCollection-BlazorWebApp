using System.ComponentModel.DataAnnotations;

namespace WasteCollection.Services.HuyNQ.DTOs;

public class CollectorAssignmentsHuyNqUpdatedDto
{
    public Guid AssignmentId { get; set; }

    public Guid ReportHuyNqId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public string Status { get; set; } = default!;

    [Required]
    public DateTime? ArrivalTime { get; set; }

    [Required]
    public DateTime? CompletionTime { get; set; }

    [Required]
    [Range(0, 100000, ErrorMessage = "CollectedWeight must be >= 0.")]
    public decimal? CollectedWeight { get; set; }

    public string ProofImageUrl { get; set; } = default!;

    [Required]
    public DateTime? EstimatedArrivalTime { get; set; }

    public string Notes { get; set; } = default!;
}
