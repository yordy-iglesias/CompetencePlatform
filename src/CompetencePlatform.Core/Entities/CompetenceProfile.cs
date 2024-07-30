using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class CompetenceProfile : BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the IdCompetenceDictionary.
        /// </summary>
        
        public int? CompetenceDictionaryId { get; set; }
        [ForeignKey("CompetenceDictionaryId")]
        public virtual CompetenceDictionary CompetenceDictionary { get; set; }

        public virtual  ICollection<Responsability> Responsabilities { get; set; }


        /// <summary>
        /// Gets or sets the IdEmployeeProfile.
        /// </summary>

        public int? EmployeeProfileId { get; set; }
        [ForeignKey("EmployeeProfileId")]
        public virtual EmployeeProfile EmployeeProfile { get; set; }
        /// <summary>
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Deleted { get; set; }= false;



        //Audited Method

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public int? CreatedBy { get; set; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public int? UpdatedBy { get; set; }
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
