namespace WasteCollection.Services.HuyNQ.DTOs;

public class CollectorAssignmentsHuyNqUpdatedDto
{
    public Guid AssignmentId { get; set; }

    public Guid ReportHuyNqId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public string Status { get; set; } = default!;

    public DateTime? ArrivalTime { get; set; }

    public DateTime? CompletionTime { get; set; }

    public decimal? CollectedWeight { get; set; }

    public string ProofImageUrl { get; set; } = default!;

    public DateTime? EstimatedArrivalTime { get; set; }

    public string Notes { get; set; } = default!;
}
