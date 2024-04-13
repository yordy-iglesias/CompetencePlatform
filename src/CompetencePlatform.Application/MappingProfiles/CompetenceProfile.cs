using AutoMapper;
using CompetencePlatform.Application.Models;
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
            CreateMap<BehaviorDictionary, BehaviorDictionaryModel>()
            .ForMember(bdm => bdm.BehaviorName, bd => bd.MapFrom(bd => bd.Behavior.Name))
            .ForMember(bdm => bdm.DegreeCompetenceName, bd => bd.MapFrom(bd => bd.DegreeCompetence.Name));

            CreateMap<BehaviorDictionaryModel, BehaviorDictionary>();

            CreateMap<Behavior, BehaviorModel>().ReverseMap();
            CreateMap<Competence_Skill_Motivation_Knowledge_Preference, Competence_Skill_Motivation_Knowledge_PreferenceModel>()
               .ForMember(csmkpm => csmkpm.CompetenceName, csmkp => csmkp.MapFrom(csmkp => csmkp.Competence.Name))
               .ForMember(csmkpm => csmkpm.MotivationName, csmkp => csmkp.MapFrom(csmkp => csmkp.Motivation.Name))
               .ForMember(csmkpm => csmkpm.SkillName, csmkp => csmkp.MapFrom(csmkp => csmkp.Skill.Name))
               .ForMember(csmkpm => csmkpm.KnowledgeName, csmkp => csmkp.MapFrom(csmkp => csmkp.Knowledge.Name))
               .ForMember(csmkpm => csmkpm.PreferenceName, csmkp => csmkp.MapFrom(csmkp => csmkp.Preference.Name));



        }
    }
}
