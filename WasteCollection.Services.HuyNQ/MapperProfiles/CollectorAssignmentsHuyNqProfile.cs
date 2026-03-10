using AutoMapper;
using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Services.HuyNQ.DTOs;

namespace WasteCollection.Services.HuyNQ.MapperProfiles;

public class CollectorAssignmentsHuyNqProfile : Profile
{
    public CollectorAssignmentsHuyNqProfile()
    {
        CreateMap<CollectorAssignmentsHuyNqCreatedDto, CollectorAssignmentsHuyNq>(MemberList.None);

        CreateMap<CollectorAssignmentsHuyNq, CollectorAssignmentsHuyNqGetAllDto>(MemberList.None);

        CreateMap<CollectorAssignmentsHuyNq, CollectorAssignmentsHuyNqGetDto>(MemberList.None);

        CreateMap<CollectorAssignmentsHuyNqUpdatedDto, CollectorAssignmentsHuyNq>(MemberList.None);

        CreateMap<CollectorAssignmentsHuyNqGetDto, CollectorAssignmentsHuyNqUpdatedDto>(MemberList.None);
    }
}
