using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public  class Responsability:BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the CompetenceProfileId.
        /// </summary>
        public int? CompetenceProfileId { get; set; }
        public virtual CompetenceProfile CompetenceProfile { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the Delete Borrado Logico.
        /// </summary>
        public bool? Delete { get; set; }=false;    
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
        /// <summary>
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; } = false;

    }
}
