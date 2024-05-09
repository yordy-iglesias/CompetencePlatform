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
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class CompetenceGlobalProfile:Profile
    {
        public CompetenceGlobalProfile()
        {
            CreateMap<BehaviorDictionary, BehaviorDictionaryViewModel>()
            .ForMember(bdm => bdm.BehaviorName, bd => bd.MapFrom(bd => bd.Behavior.Name))
            .ForMember(bdm => bdm.DegreeCompetenceName, bd => bd.MapFrom(bd => bd.DegreeCompetence.Name));

            CreateMap<BehaviorDictionaryViewModel, BehaviorDictionary>();

            CreateMap<Behavior, BehaviorViewModel>().ReverseMap();
            CreateMap<Competence_Skill_Motivation_Knowledge_Preference, C_S_M_K_PViewModel>()
               .ForMember(csmkpm => csmkpm.CompetenceName, csmkp => csmkp.MapFrom(csmkp => csmkp.Competence.Name))
               .ForMember(csmkpm => csmkpm.MotivationName, csmkp => csmkp.MapFrom(csmkp => csmkp.Motivation.Name))
               .ForMember(csmkpm => csmkpm.SkillName, csmkp => csmkp.MapFrom(csmkp => csmkp.Skill.Name))
               .ForMember(csmkpm => csmkpm.KnowledgeName, csmkp => csmkp.MapFrom(csmkp => csmkp.Knowledge.Name))
               .ForMember(csmkpm => csmkpm.PreferenceName, csmkp => csmkp.MapFrom(csmkp => csmkp.Preference.Name));

            CreateMap<CompetenceDictionary, CompetenceDictionaryViewModel>()
                .ForMember(cdm => cdm.CompetenceName, cd => cd.MapFrom(cd => cd.Competence.Name)).ReverseMap() ;

            CreateMap<Core.Entities.CompetenceProfile, CompetenceProfileViewModel>()
               .ForMember(cpm => cpm.EmployeeProfileName, cp => cp.MapFrom(cd => cd.EmployeeProfile.Name)).ReverseMap();

            CreateMap<CompetenceType, CompetenceTypeViewModel>().ReverseMap();
            CreateMap<DegreeCompetence, DegreeCompetenceViewModel>().ReverseMap(); 
            CreateMap<Departament, DepartamentViewModel>()
             .ForMember(dpm => dpm.OrganizationName, dp => dp.MapFrom(dp => dp.Organization.Name)).ReverseMap();
            CreateMap<Organization, OrganizationViewModel>().ReverseMap();
            CreateMap<Preference, PreferenceModel>()
                .ForMember(pm => pm.PreferenceTypeName, p => p.MapFrom(p => p.PreferenceType.Name)).ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<ProjectTeam, ProjectTeamModel>()
                .ForMember(ptm => ptm.ProjectName, pt => pt.MapFrom(pt => pt.Project.Name))
                .ForMember(ptm => ptm.TeamName, pt => pt.MapFrom(pt => pt.Team.Name)).ReverseMap();
            CreateMap<Responsability, ResponsabilityModel>().ReverseMap();
            CreateMap<Skill, SkillModel>()
                 .ForMember(skm => skm.SkillTypeName, sk => sk.MapFrom(sk => sk.SkillType.Name)).ReverseMap();
            CreateMap<SkillType, SkillTypeModel>().ReverseMap();
            CreateMap<SolutionDomain, SolutionDomainModel>()
                 .ForMember(sldm => sldm.OrganizationName, sld => sld.MapFrom(sld => sld.Organization.Name)).ReverseMap();
            CreateMap<SolutionDomainCompetence, SolutionDomainCompetenceModel>()
                .ForMember(sldcm => sldcm.SolutionDomainName, sld => sld.MapFrom(sldc => sldc.SolutionDomain.Name))
                .ForMember(sldcm => sldcm.CompetenceName, sld => sld.MapFrom(sldc => sldc.Competence.Name)).ReverseMap();
            CreateMap<Team, TeamModel>().ReverseMap();
            CreateMap<TechnicalSheet, TechnicalSheetModel>()
                .ForMember(tshm => tshm.SolutionDomainName, ts => ts.MapFrom(ts => ts.SolutionDomain.Name))
                .ForMember(tshm => tshm.ProjectName, ts => ts.MapFrom(ts => ts.Project.Name)).ReverseMap();
            CreateMap<TechnicalSheetCompose, TechnicalSheetComposeModel>()
               .ForMember(tshcm => tshcm.EmployeeProfileName, tsc => tsc.MapFrom(tsc => tsc.EmployeeProfile.Name)).ReverseMap();
        }
    }
}
