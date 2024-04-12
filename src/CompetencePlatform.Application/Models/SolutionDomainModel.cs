using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class SolutionDomainModel
    {
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        //public List<SolutionDomainCompetenceModel> SolutionDomainCompetences { get; set; }
        //public List<TechnicalSheetModel> TechnicalSheets { get; set; }
        //public List<EmployeeProfileModel> EmployeeProfiles { get; set; }
    }
}
