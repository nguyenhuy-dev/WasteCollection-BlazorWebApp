namespace WasteCollection.Repositories.HuyNQ.Models;

public record CollectorAssignmentsHuyNqSearchOptions
{
    public string? Status { get; set; }
    public decimal? CollectedWeight { get; set; }
    public DateTime? AssignedDate { get; set; }

    public int PageNumber { get; set; } = 1;
    public int PageSize   { get; set; } = 5;
}
