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

        
        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]

        public virtual Project Project { get; set; }

        /// <summary>
        /// Gets or sets the IdSolutionDomain.
        /// </summary>
        
        public int? SolutionDomainId { get; set; }
        [ForeignKey("SolutionDomainId")]
        public virtual SolutionDomain SolutionDomain { get; set; }

        public virtual ICollection<TechnicalSheetCompose> TechnicalSheetComposes { get; set; }
        /// <summary>
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Deleted { get; set; } = false;

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
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; } = false;
    }
}
