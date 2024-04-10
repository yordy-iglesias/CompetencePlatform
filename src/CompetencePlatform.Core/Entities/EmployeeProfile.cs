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
    public class EmployeeProfile : BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the IdSolutionDomain.
        /// </summary>
        
        public int? SolutionDomainId { get; set; }
        public virtual SolutionDomain SolutionDomain { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfiles { get; set; }
        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposes { get; set; }


        //Audited Methods

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedOn.
		/// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Delete { get; set; } = false;
        /// <summary>
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; } = false;
    }
}
