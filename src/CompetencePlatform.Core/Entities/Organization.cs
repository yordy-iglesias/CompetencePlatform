using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Organization : BaseEntity, IAuditedEntity
    {

        /// <summary>
		/// Gets or sets the Name.
		/// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
		/// Gets or sets the Mision.
		/// </summary>
        [Required]
        public string Mision { get; set; }
        /// <summary>
		/// Gets or sets the Vision.
		/// </summary>
        [Required]
        public string Vision  { get; set; }
        public virtual ICollection<Departament> Departaments { get; set; } 
        public virtual ICollection<SolutionDomain> SolutionDomains { get; set; } 

        //Audited Method

        /// <summary>
		/// Gets or sets the CreatedBy.
		/// </summary>
        public string CreatedBy { get; set ; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime CreatedOn { get ; set ; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public string UpdatedBy { get ; set ; }
        /// <summary>
		/// Gets or sets the UpdatedOn.
		/// </summary>
        public DateTime? UpdatedOn { get ; set ; }
    }
}
