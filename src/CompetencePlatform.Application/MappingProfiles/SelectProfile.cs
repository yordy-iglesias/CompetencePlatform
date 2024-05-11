using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class SelectProfile : Profile
    {
        public SelectProfile()
        {

            CreateMap<Behavior, SelectViewModel>()
               .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
               .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<DegreeCompetence, SelectViewModel>()
              .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
              .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Competence, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Knowledge, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Preference, SelectViewModel>()
              .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
              .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Skill, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Motivation, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<CompetenceType, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Core.Entities.EmployeeProfile, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<CompetenceType, SelectViewModel>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Departament, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Team, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<SolutionDomain, SelectViewModel>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));

            CreateMap<Project, SelectViewModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(orig => orig.Name));




        }
    }
}
