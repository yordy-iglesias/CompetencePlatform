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
using CompetencePlatform.Application.Models.Employee;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
            .ForMember(empm => empm.DepartamentName, emp => emp.MapFrom(emp => emp.Departament.Name))
            .ForMember(empm => empm.EmployeeProfileName, emp => emp.MapFrom(emp => emp.EmployeeProfile.Name))
            .ForMember(empm => empm.TeamName, emp => emp.MapFrom(emp => emp.Team.Name)).ReverseMap();

            CreateMap<Employee, CreateEmployeeViewModel>();
            CreateMap<CreateEmployeeViewModel, Employee>();

        }
    }
}
