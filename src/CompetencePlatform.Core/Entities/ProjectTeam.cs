using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class ProjectTeam: BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the ProjectId.
        /// </summary>
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        /// <summary>
        /// Gets or sets the TeamId.
        /// </summary>
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }



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
        public bool? Delete { get; set; }
    }
}
