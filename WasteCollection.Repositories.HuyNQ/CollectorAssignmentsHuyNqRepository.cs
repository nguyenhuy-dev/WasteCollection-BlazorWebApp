using Microsoft.EntityFrameworkCore;
using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Repositories.HuyNQ.Base;
using WasteCollection.Repositories.HuyNQ.Models;

namespace WasteCollection.Repositories.HuyNQ;

public class CollectorAssignmentsHuyNqRepository : GenericRepository<CollectorAssignmentsHuyNq>
{
    public CollectorAssignmentsHuyNqRepository() { }

    public CollectorAssignmentsHuyNqRepository(WasteCollectionDbContext context) => _context = context;

    public new async Task<List<CollectorAssignmentsHuyNq>> GetAllAsync()
    {
        var items = await _context.CollectorAssignmentsHuyNqs
            .Include(c => c.ReportHuyNq)
            .ToListAsync();

        return items;
    }

    public new async Task<CollectorAssignmentsHuyNq> GetById(Guid id)
    {
        var item = await _context.CollectorAssignmentsHuyNqs
            .Include(c => c.ReportHuyNq)
            .FirstOrDefaultAsync(c => c.AssignmentId == id);

        return item ?? new();
    }

    public async Task<PaginatedResult<CollectorAssignmentsHuyNq>> SearchAsync(CollectorAssignmentsHuyNqSearchOptions options)
    {
        var status = options.Status ?? string.Empty;
        var collectedWeight = options.CollectedWeight;
        var assignedDate = options.AssignedDate;

        var query = _context.CollectorAssignmentsHuyNqs
            .Include(c => c.ReportHuyNq)
            .Where(c =>
                (c.Status.Contains(status) || string.IsNullOrEmpty(status)) &&
                (c.CollectedWeight == collectedWeight || collectedWeight == 0 || collectedWeight == null) &&
                (
                    assignedDate == null ||
                    (
                        c.AssignedDate.HasValue &&
                        c.AssignedDate.Value.Date == assignedDate.Value.Date
                    )
                )
            );

        var totalCount = await query.CountAsync();

        var pageNumber = options.PageNumber < 1 ? 1 : options.PageNumber;
        var pageSize   = options.PageSize   < 1 ? 5 : options.PageSize;

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<CollectorAssignmentsHuyNq>(items, totalCount, pageNumber, pageSize);
    }
}
