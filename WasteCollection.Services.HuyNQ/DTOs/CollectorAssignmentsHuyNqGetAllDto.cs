namespace WasteCollection.Services.HuyNQ.DTOs;

public class CollectorAssignmentsHuyNqGetAllDto
{
    public Guid AssignmentId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public string Status { get; set; } = default!;

    public DateTime? ArrivalTime { get; set; }

    public DateTime? CompletionTime { get; set; }

    public decimal? CollectedWeight { get; set; }

    public string ProofImageUrl { get; set; } = default!;

    public DateTime? EstimatedArrivalTime { get; set; }

    public string Notes { get; set; } = default!;

    public string Address { get; set; } = default!;
}
