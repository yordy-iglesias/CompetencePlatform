using AutoMapper;
using CompetencePlatform.Application.Models.Role;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.Entities.Identity;

namespace CompetencePlatform.Application.MappingProfiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleViewModel, Role>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(orig => orig.Name))
                .ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(orig => orig.NormalizedName))
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.MapFrom(orig => orig.ConcurrencyStamp))
                .ReverseMap();
    }
}
