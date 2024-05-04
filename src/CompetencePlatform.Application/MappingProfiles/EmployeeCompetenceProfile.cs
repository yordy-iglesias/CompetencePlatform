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
using CompetencePlatform.Application.Models.EmployeeCompetence;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class EmployeeCompetenceProfile : Profile
    {
        public EmployeeCompetenceProfile()
        {
           
            CreateMap<EmployeeCompetence, EmployeeCompetenceViewModel>()
                 .ForMember(ecm => ecm.CompetenceName, ec => ec.MapFrom(ec => ec.Competence.Name))
                 .ForMember(ecm => ecm.EmployeeName, ec => ec.MapFrom(ec => ec.Employee.FirstName)).ReverseMap();

            CreateMap<EmployeeCompetence, CreateEmployeeCompetenceViewModel>().ReverseMap();
        }
    }
}
