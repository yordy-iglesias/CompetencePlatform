using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class EmployeeProfile : CommonEntity
    {
       
        
        public int? SolutionDomainId { get; set; }
        public virtual SolutionDomain SolutionDomain { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfiles { get; set; }
        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposes { get; set; }


        
    }
}
