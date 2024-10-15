using CompetencePlatform.Core.Entities;
using CompetencePlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.EmployeeProfile
{
    public class EmployeeProfileViewModel : CommonEntityModel
    {
       // public int? SolutionDomainId { get; set; }
        public string SolutionDomainName { get; set; }
        public HierarchyLevelEnum Type { get; set; }
        //public List<EmployeeModel> Employees { get; set; }
        //public List<CompetenceProfileModel> CompetenceProfiles { get; set; }
        //public List<TechnicalSheetComposeModel> TechnicalSheetComposes { get; set; }
    }
}
