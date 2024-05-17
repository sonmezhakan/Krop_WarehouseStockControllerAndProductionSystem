using AutoMapper;
using Krop.Business.Features.Branches.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Branches.Profiles
{
    public class BranchProfiles:Profile
    {
        public BranchProfiles()
        {
            CreateMap<Branch, CreateBranchDTO>().ReverseMap();
            CreateMap<Branch, UpdateBranchDTO>().ReverseMap();
            CreateMap<Branch, GetBranchDTO>().ReverseMap();
        }
    }
}
