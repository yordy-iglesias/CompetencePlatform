using AutoMapper;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Core.DataAccess.Identity;
using CompetencePlatform.Core.Entities.Identity;

namespace CompetencePlatform.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, User>()
           .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(orig => DateTime.Now))
           .ForMember(dest => dest.OrganizacionId, opt => opt.MapFrom(orig => orig.IdOrganization))
           .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(orig => orig.Email.ToUpper()))
           .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(orig => orig.Username.ToUpper()))
           .ReverseMap();

        CreateMap<UserViewModel, User>()
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(orig => orig.IsActive))
            .ForMember(dest => dest.OrganizacionId, opt => opt.MapFrom(orig => orig.Id));

        CreateMap<User, UserViewModel>()
           .ForMember(dest => dest.OrganizacionId, opt => opt.MapFrom(orig => orig.OrganizacionId))
           .ForMember(dest => dest.IdRole, opt => opt.MapFrom(orig => orig.UserRoles.FirstOrDefault().RoleId));
    }
}
