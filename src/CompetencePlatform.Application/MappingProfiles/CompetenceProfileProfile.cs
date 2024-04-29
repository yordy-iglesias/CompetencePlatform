using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Models.CompetenceProfile;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class CompetenceProfileProfile : Profile
    {
        public CompetenceProfileProfile()
        {
           
            CreateMap<Core.Entities.CompetenceProfile, CompetenceProfileModel>()
               .ForMember(cpm => cpm.EmployeeProfileName, cp => cp.MapFrom(cd => cd.EmployeeProfile.Name)).ReverseMap();
            CreateMap<Core.Entities.CompetenceProfile, CreateCompetenceProfileModel>().ReverseMap();


        }
    }
}
