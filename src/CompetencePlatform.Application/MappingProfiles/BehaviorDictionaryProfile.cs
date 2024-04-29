using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class BehaviorDictionaryProfile : Profile
    {
        public BehaviorDictionaryProfile()
        {
            CreateMap<BehaviorDictionary, BehaviorDictionaryModel>()
            .ForMember(bdm => bdm.BehaviorName, bd => bd.MapFrom(bd => bd.Behavior.Name))
            .ForMember(bdm => bdm.DegreeCompetenceName, bd => bd.MapFrom(bd => bd.DegreeCompetence.Name)).ReverseMap();

            CreateMap<BehaviorDictionary, CreateBehaviorDictionaryModel>().ReverseMap();


        }
    }
}
