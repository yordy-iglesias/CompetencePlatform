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
    /// <summary>
    /// Representa los departamentos de la organizaciòn.
    /// </summary>
    public class Departament : CommonEntity
    {
        /// <summary>
        /// Gets or sets the IdOrganization.
        /// </summary>
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("DepartamentUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("DepartamentUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        public int? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public HierarchyLevelEnum HierarchyLevel { get; set; }
        public string Code {  get; set; }   
        public string Email {  get; set; }   
        public string PhoneNumber {  get; set; }
        public DepartamentStateEnum State { get; set; }
        public string? LogoUrl { get; set; }
        public virtual  ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SolutionDomain> SolutionDomains { get; set; }




    }
}
