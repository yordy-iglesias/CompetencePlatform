using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    /// <summary>
    /// Representa las soluciones de dominio.
    /// </summary>
    public class SolutionDomain : CommonEntity
    {
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("SolutionDomainUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("SolutionDomainUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }


        //public int? OrganizationId { get; set; }
        //[ForeignKey("OrganizationId")]
        //public virtual Organization Organization { get; set; }

        public int? DepartamentId { get; set; }
        [ForeignKey("DepartamentId")]
        public virtual Departament Departament { get; set; }

        public virtual ICollection<SolutionDomainCompetence> SolutionDomainCompetences { get; set; }
        public virtual ICollection<TechnicalSheet> TechnicalSheets { get; set; }
        public virtual ICollection<EmployeeProfile> EmployeeProfiles { get; set; }

        
    }
}
