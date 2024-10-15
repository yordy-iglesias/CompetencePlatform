using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
         
            CreateMap<Organization, OrganizationViewModel>()
               .ForMember(orgvm => orgvm.TypeName, dp => dp.MapFrom(org => org.Type.ToString()));

            CreateMap<Organization, CreateOrganizationViewModel>()
                 .ForMember(orgvm => orgvm.Type, dp => dp.MapFrom(org => (int)org.Type));


        }
    }
}
