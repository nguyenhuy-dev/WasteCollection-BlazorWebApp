using WasteCollection.Repositories.HuyNQ.Models;
using WasteCollection.Services.HuyNQ.DTOs;

namespace WasteCollection.Services.HuyNQ;

public interface ICollectorAssignmentsHuyNqService
{
    Task<List<CollectorAssignmentsHuyNqGetAllDto>> GetAllAsync();

    Task<CollectorAssignmentsHuyNqGetDto> GetByIdAsync(Guid id);

    Task<PaginatedResult<CollectorAssignmentsHuyNqGetAllDto>> SearchAsync(CollectorAssignmentsHuyNqSearchOptions options);

    Task<int> CreateAsync(CollectorAssignmentsHuyNqCreatedDto request);

    Task<int> UpdateAsync(CollectorAssignmentsHuyNqUpdatedDto asm);

    Task<bool> DeleteAsync(Guid id);
}
