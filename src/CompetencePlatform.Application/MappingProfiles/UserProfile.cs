using AutoMapper;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Core.DataAccess.Identity;

namespace CompetencePlatform.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, ApplicationUser>();
    }
}
