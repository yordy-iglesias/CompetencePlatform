using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Models.CompetenceProfile;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Departament;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class DepartamentProfile : Profile
    {
        public DepartamentProfile()
        {
          
            CreateMap<Departament, DepartamentModel>()
             .ForMember(dpm => dpm.OrganizationName, dp => dp.MapFrom(dp => dp.Organization.Name)).ReverseMap();
            CreateMap<Departament, CreateDepartamentModel>()
            .ForMember(cdpm => cdpm.OrganizationId, dp => dp.MapFrom(dp => dp.OrganizationId)).ReverseMap();

        }
    }
}
