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
    /// Representa la ficha tècnica del pryecto.
    /// </summary>
    public class TechnicalSheet : BaseEntity, IAuditedEntity
    {

        /// <summary>
        /// Gets or sets the Target.
        /// </summary>
        [Required]
        public string Target { get; set; }
        /// <summary>
        /// Gets or sets the Scope.
        /// </summary>
        [Required]
        public string Scope { get; set; }
        /// <summary>
        /// Gets or sets the InitialTechnicalProposal.
        /// </summary>
        [Required]
        public string InitialTechnicalProposal { get; set; }

        /// <summary>
        /// Gets or sets the IdSolutionDomain.
        /// </summary>
        
        public int? SolutionDomainId { get; set; }
        [ForeignKey("SolutionDomainId")]
        public virtual SolutionDomain SolutionDomain { get; set; }

        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposes { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        /// <summary>
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Deleted { get; set; } 

        //Audited Methods
        
        
        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("TechnicalSheetUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("TechnicalSheetUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedOn.
		/// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; } 
        public bool? IsDefault { get; set; }
    }
}
