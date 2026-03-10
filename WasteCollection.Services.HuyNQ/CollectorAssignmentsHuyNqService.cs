using AutoMapper;
using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Repositories.HuyNQ;
using WasteCollection.Repositories.HuyNQ.Models;
using WasteCollection.Services.HuyNQ.DTOs;
using WasteCollection.Services.HuyNQ.Exceptions;

namespace WasteCollection.Services.HuyNQ;

public class CollectorAssignmentsHuyNqService : ICollectorAssignmentsHuyNqService
{
    private readonly CollectorAssignmentsHuyNqRepository _collectorAsmRepository;

    private readonly IMapper _mapper;

    public CollectorAssignmentsHuyNqService(IMapper mapper)
    {
        _collectorAsmRepository ??= new();

        _mapper = mapper;
    }
        
    public async Task<int> CreateAsync(CollectorAssignmentsHuyNqCreatedDto request)
    {
        try
        {
            var asm = _mapper.Map<CollectorAssignmentsHuyNq>(request);
            return await _collectorAsmRepository.CreateAsync(asm);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var asm = await _collectorAsmRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("Collector Assignment not found.");

            bool isDeleted = await _collectorAsmRepository.RemoveAsync(asm);

            return isDeleted;
        } 
        catch (Exception)
        {
            throw;
        } 
    }

    public async Task<List<CollectorAssignmentsHuyNqGetAllDto>> GetAllAsync()
    {
        try
        {
            var asms = await _collectorAsmRepository.GetAllAsync();
            var asmDtos = new List<CollectorAssignmentsHuyNqGetAllDto>();

            asms.ForEach(asm =>
            {
                var asmDto = _mapper.Map<CollectorAssignmentsHuyNq, CollectorAssignmentsHuyNqGetAllDto>(asm);
                asmDto.Address = asm.ReportHuyNq.Address;
                asmDtos.Add(asmDto);
            });

            return asmDtos;
        } 
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CollectorAssignmentsHuyNqGetDto> GetByIdAsync(Guid id)
    {
        try
        {
            var asm = await _collectorAsmRepository.GetById(id) 
                ?? throw new NotFoundException("Collector Assignment not found.");
            
            var asmDto = _mapper.Map<CollectorAssignmentsHuyNq, CollectorAssignmentsHuyNqGetDto>(asm);
            asmDto.Address = asm.ReportHuyNq.Address;

            return asmDto;
        } 
        catch (Exception)
        {
            throw; 
        }
    }

    public async Task<PaginatedResult<CollectorAssignmentsHuyNqGetAllDto>> SearchAsync(CollectorAssignmentsHuyNqSearchOptions options)
    {
        try
        {
            var pagedAsms = await _collectorAsmRepository.SearchAsync(options);

            var dtos = pagedAsms.Items.Select(asm =>
            {
                var dto = _mapper.Map<CollectorAssignmentsHuyNq, CollectorAssignmentsHuyNqGetAllDto>(asm);
                dto.Address = asm.ReportHuyNq.Address;
                return dto;
            }).ToList();

            return new PaginatedResult<CollectorAssignmentsHuyNqGetAllDto>(
                dtos,
                pagedAsms.TotalCount,
                pagedAsms.PageNumber,
                pagedAsms.PageSize);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> UpdateAsync(CollectorAssignmentsHuyNqUpdatedDto dto)
    {
        try
        {
            var asm = _mapper.Map<CollectorAssignmentsHuyNqUpdatedDto, CollectorAssignmentsHuyNq>(dto);

            return await _collectorAsmRepository.UpdateAsync(asm);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
