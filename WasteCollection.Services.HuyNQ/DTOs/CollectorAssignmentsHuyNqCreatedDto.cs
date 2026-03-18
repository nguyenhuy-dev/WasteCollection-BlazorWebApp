using System.ComponentModel.DataAnnotations;

namespace WasteCollection.Services.HuyNQ.DTOs;

public class CollectorAssignmentsHuyNqCreatedDto
{
    public Guid AssignmentId { get; set; } = Guid.CreateVersion7();

    public Guid ReportHuyNqid { get; set; }

    public DateTime AssignedDate { get; set; } = DateTime.Now;

    public string Status { get; set; } = default!;

    [Required]
    public DateTime? ArrivalTime { get; set; }

    [Required]
    public DateTime? CompletionTime { get; set; }

    [Required]
    [Range(0, 100000, ErrorMessage = "CollectedWeight must be >= 0.")]
    public decimal? CollectedWeight { get; set; }

    [Required]
    public string ProofImageUrl { get; set; } = default!;

    [Required]
    public DateTime? EstimatedArrivalTime { get; set; }

    public string Notes { get; set; } = default!;

    public CollectorAssignmentsHuyNqCreatedDto()
    {
        AssignmentId = Guid.CreateVersion7();
        AssignedDate = DateTime.Now;
    }
}
