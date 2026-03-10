namespace WasteCollection.Repositories.HuyNQ.Models;

public record PaginatedResult<T>(
    List<T> Items,
    int TotalCount,
    int PageNumber,
    int PageSize)
{
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPrev   => PageNumber > 1;
    public bool HasNext   => PageNumber < TotalPages;
}
