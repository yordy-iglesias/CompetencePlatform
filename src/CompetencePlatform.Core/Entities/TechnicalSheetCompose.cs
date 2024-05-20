using CompetencePlatform.Core.Common;
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
        // <summary>
        /// Gets or sets the Delete Borrado Logico.
        /// </summary>
        public bool? Deleted { get; set; }=false;
        /// <summary>
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; } = false;
    }
}
