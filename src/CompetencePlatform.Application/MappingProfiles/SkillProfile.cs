﻿using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Models.CompetenceProfile;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Departament;
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.Project;
using CompetencePlatform.Application.Models.ProjectTeam;
using CompetencePlatform.Application.Models.Resposability;
using CompetencePlatform.Application.Models.Skill;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            
            CreateMap<Skill, SkillViewModel>()
                 .ForMember(skm => skm.SkillTypeName, sk => sk.MapFrom(sk => sk.SkillType.Name)).ReverseMap();
            CreateMap<Skill, CreateSkillViewModel>()
                 .ForMember(skm => skm.SkillTypeId, sk => sk.MapFrom(sk => sk.SkillType.Id)).ReverseMap();

        }
    }
}
