using AutoMapper;
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
using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Application.Models.SolutionDomain;
using CompetencePlatform.Application.Models.SolutionDomainCompetence;
using CompetencePlatform.Application.Models.Team;
using CompetencePlatform.Application.Models.TechnicalSheet;
using CompetencePlatform.Application.Models.TechnicalSheetCompose;
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
            CreateMap<C_S_M_K_P, C_S_M_K_PViewModel>()
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
             .ForMember(dpm => dpm.CantEmployees, dp => dp.MapFrom(dp => dp.Employees.Count()))
             .ForMember(dpm => dpm.CantProjects, dp => dp.MapFrom(dp => dp.SolutionDomains.Count()))
            // .ForMember(dpm => dpm.Badgecolor, dp => dp.ConvertUsing(ConverterBgColorForDepartament(dp.)))
             .ForMember(dpm => dpm.OrganizationName, dp => dp.MapFrom(dp => dp.Organization.Name)).ReverseMap();
            CreateMap<Organization, OrganizationViewModel>().ReverseMap();
            CreateMap<Preference, PreferenceViewModel>()
                .ForMember(pm => pm.PreferenceTypeName, p => p.MapFrom(p => p.PreferenceType.Name)).ReverseMap();
            CreateMap<Project, ProjectViewModel>().ReverseMap();
            CreateMap<ProjectTeam, ProjectTeamViewModel>()
                .ForMember(ptm => ptm.ProjectName, pt => pt.MapFrom(pt => pt.Project.Name))
                .ForMember(ptm => ptm.TeamName, pt => pt.MapFrom(pt => pt.Team.Name)).ReverseMap();
            CreateMap<Responsability, ResponsabilityViewModel>().ReverseMap();
            CreateMap<Skill, SkillViewModel>()
                 .ForMember(skm => skm.SkillTypeName, sk => sk.MapFrom(sk => sk.SkillType.Name)).ReverseMap();
            CreateMap<SkillType, SkillTypeViewModel>().ReverseMap();
            CreateMap<SolutionDomain, SolutionDomainViewModel>()
                 .ForMember(sldm => sldm.DepartamentName, sld => sld.MapFrom(sld => sld.Departament.Name)).ReverseMap();
            CreateMap<SolutionDomainCompetence, SolutionDomainCompetenceViewModel>()
                .ForMember(sldcm => sldcm.SolutionDomainName, sld => sld.MapFrom(sldc => sldc.SolutionDomain.Name))
                .ForMember(sldcm => sldcm.CompetenceName, sld => sld.MapFrom(sldc => sldc.Competence.Name)).ReverseMap();
            CreateMap<Team, TeamViewModel>().ReverseMap();
            CreateMap<TechnicalSheet, TechnicalSheetViewModel>()
                .ForMember(tshm => tshm.SolutionDomainName, ts => ts.MapFrom(ts => ts.SolutionDomain.Name))
                .ReverseMap();
            CreateMap<TechnicalSheetCompose, TechnicalSheetComposeViewModel>()
               .ForMember(tshcm => tshcm.EmployeeProfileName, tsc => tsc.MapFrom(tsc => tsc.EmployeeProfile.Name)).ReverseMap();
        }
        private static object ConverterBgColorForDepartament(Departament value)
        {
            string bgColor = "";
            switch (value.HierarchyLevel)
            {
                case Core.Enums.HierarchyLevelEnum.None:
                    bgColor = "secondary";
                    break;
                case Core.Enums.HierarchyLevelEnum.Functional_Managment:
                    bgColor = "success";
                    break;
                case Core.Enums.HierarchyLevelEnum.Intermediate_Management:
                    bgColor = "primary";
                    break;
                case Core.Enums.HierarchyLevelEnum.Operative_Supervisors:
                    bgColor = "info";
                    break;
                case Core.Enums.HierarchyLevelEnum.Operative_Level:
                    bgColor = "warning";
                    break;
                case Core.Enums.HierarchyLevelEnum.Subcontrated_Support_Personal:
                    bgColor = "danger";
                    break;
                default:
                    break;
            }
            return bgColor;

           
        }
    }
    
}
