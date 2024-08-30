using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class TechnicalSheetCompose:BaseEntity, IAuditedEntity
    {

        /// <summary>
        /// Gets or sets the EmployeeProfileId
        /// </summary>

        public int EmployeeProfileId { get; set; }
        [ForeignKey("EmployeeProfileId")]
        public virtual EmployeeProfile EmployeeProfile { get; set; }
        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the TechnicalSheetId
        /// </summary>

        public int? TechnicalSheetId { get; set; }
        [ForeignKey("TechnicalSheetId")]
        public virtual TechnicalSheet TechnicalSheet { get; set; }

        //Audited Method

        
        
        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("TechnicalSheetComposeUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("TechnicalSheetComposeUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedOn.
		/// </summary>
        public DateTime? UpdatedOn { get; set; }
        // <summary>
        /// Gets or sets the Delete Borrado Logico.
        /// </summary>
        public bool? Deleted { get; set; }
        /// <summary>
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; } 
        public bool? IsDefault { get; set; } 
    }
}
