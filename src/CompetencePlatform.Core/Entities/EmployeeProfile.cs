using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Core.Enums;
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

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("EmployeeProfileUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("EmployeeProfileUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public HierarchyLevelEnum Type { get; set; }
        public bool IsActive { get; set; }
        public int? SolutionDomainId { get; set; }
        [ForeignKey("SolutionDomainId")]
        public virtual SolutionDomain SolutionDomain { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfiles { get; set; }
        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposes { get; set; }


        
    }
}
