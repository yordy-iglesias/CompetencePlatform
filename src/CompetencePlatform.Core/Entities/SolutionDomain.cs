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
    public class SolutionDomain : CommonEntity
    {
        
        
        public int? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        
        public virtual ICollection<SolutionDomainCompetence> SolutionDomainCompetences { get; set; }
        public virtual ICollection<TechnicalSheet> TechnicalSheets { get; set; }
        public virtual ICollection<EmployeeProfile> EmployeeProfiles { get; set; }

        
    }
}
