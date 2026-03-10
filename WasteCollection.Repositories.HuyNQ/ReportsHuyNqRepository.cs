using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Repositories.HuyNQ.Base;

namespace WasteCollection.Repositories.HuyNQ;

public class ReportsHuyNqRepository : GenericRepository<ReportsHuyNq>
{
    public ReportsHuyNqRepository() { }

    public ReportsHuyNqRepository(WasteCollectionDbContext context) => _context = context;
}
