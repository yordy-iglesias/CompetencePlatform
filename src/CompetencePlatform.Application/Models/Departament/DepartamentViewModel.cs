using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Departament
{
    public class DepartamentViewModel : CommonEntityModel
    {
        public string OrganizationName { get; set; }
        public string HierarchyLevel { get; set; }
        public string LogoUrl { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StateName { get; set; }
        public int CantEmployees { get; set; }
        public int CantProjects { get; set; }
        public string Bgcolor { get; set; } 
        //public List<EmployeeModel> Employees { get; set; }
    }
}
