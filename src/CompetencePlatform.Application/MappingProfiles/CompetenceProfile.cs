using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class CompetenceProfile:Profile
    {
        public CompetenceProfile()
        {
           
            CreateMap<Competence, CompetenceViewModel>()
               .ForMember(cm => cm.CompetenceTypeName, c => c.MapFrom(c => c.CompetenceType.Name)).ReverseMap();
            CreateMap<Competence, CreateCompetenceViewModel>()
              .ForMember(ccm => ccm.CompetenceTypeId, c => c.MapFrom(c => c.CompetenceTypeId)).ReverseMap();
        }
    }
}
