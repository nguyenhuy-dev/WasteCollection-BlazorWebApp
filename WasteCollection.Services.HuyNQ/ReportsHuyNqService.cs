using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Repositories.HuyNQ;

namespace WasteCollection.Services.HuyNQ;

public class ReportsHuyNqService
{
    private readonly ReportsHuyNqRepository _reportsRepository;

    public ReportsHuyNqService() => _reportsRepository ??= new();

    public async Task<List<ReportsHuyNq>> GetAllAsync() => await _reportsRepository.GetAllAsync();
}
