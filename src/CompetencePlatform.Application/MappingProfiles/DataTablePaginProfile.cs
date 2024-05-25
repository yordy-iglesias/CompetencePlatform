using AutoMapper;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Models.CompetenceProfile;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Departament;
using CompetencePlatform.Application.Models.Employee;
using CompetencePlatform.Application.Models.EmployeeProfile;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.Resposability;
using CompetencePlatform.Application.Models.Skill;
using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Application.Models.SolutionDomain;
using CompetencePlatform.Application.Models.Team;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Utils;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class DataTablePaginProfile : Profile
    {
        public DataTablePaginProfile()
        {
            CreateMap<PageResult<Behavior>, DataTablePagin<BehaviorViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();

            CreateMap<PageResult<BehaviorDictionary>, DataTablePagin<BehaviorDictionaryViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();

            CreateMap<PageResult<DegreeCompetence>, DataTablePagin<DegreeCompetenceViewModel>>()
               .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
               .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
               .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
               .ReverseMap();
            CreateMap<PageResult<Competence>, DataTablePagin<CompetenceViewModel>>()
              .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
              .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
              .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
              .ReverseMap();
            CreateMap<PageResult<CompetenceType>, DataTablePagin<CompetenceTypeViewModel>>()
              .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
              .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
              .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
              .ReverseMap();
            CreateMap<PageResult<PreferenceType>, DataTablePagin<PreferenceTypeViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();
            CreateMap<PageResult<SkillType>, DataTablePagin<SkillTypeViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();
            CreateMap<PageResult<Motivation>, DataTablePagin<MotivationViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();
            CreateMap<PageResult<Skill>, DataTablePagin<SkillViewModel>>()
               .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
               .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
               .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
               .ReverseMap();
            CreateMap<PageResult<Preference>, DataTablePagin<PreferenceViewModel>>()
               .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
               .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
               .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
               .ReverseMap();

            CreateMap<PageResult<Knowledge>, DataTablePagin<KnowledgeViewModel>>()
               .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
               .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
               .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
               .ReverseMap();
            CreateMap<PageResult<CompetenceProfile>, DataTablePagin<CompetenceProfileViewModel>>()
              .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
              .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
              .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
              .ReverseMap();
            CreateMap<PageResult<Team>, DataTablePagin<TeamViewModel>>()
             .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
             .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
             .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
             .ReverseMap();
            CreateMap<PageResult<SolutionDomain>, DataTablePagin<SolutionDomainViewModel>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
            .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
            .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
            .ReverseMap();
            CreateMap<PageResult<Core.Entities.EmployeeProfile>, DataTablePagin<EmployeeProfileViewModel>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
            .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
            .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
            .ReverseMap();
            CreateMap<PageResult<CompetenceProfile>, DataTablePagin<CompetenceProfileViewModel>>()
           .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
           .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
           .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
           .ReverseMap();
            CreateMap<PageResult<Responsability>, DataTablePagin<ResponsabilityViewModel>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
            .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
            .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
            .ReverseMap();
            CreateMap<PageResult<Organization>, DataTablePagin<OrganizationViewModel>>()
           .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
           .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
           .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
           .ReverseMap();
         CreateMap<PageResult<Departament>, DataTablePagin<DepartamentViewModel>>()
          .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
          .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
          .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
          .ReverseMap();

        CreateMap<PageResult<Employee>, DataTablePagin<EmployeeViewModel>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
            .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
            .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
            .ReverseMap();

         CreateMap<PageResult<CompetenceDictionary>, DataTablePagin<CompetenceDictionaryViewModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => orig.Result))
                .ForMember(dest => dest.RecordsTotal, opt => opt.MapFrom(orig => orig.Total))
                .ForMember(dest => dest.RecordsFiltered, opt => opt.MapFrom(orig => orig.TotalFilter))
                .ReverseMap();






        }
    }
}
