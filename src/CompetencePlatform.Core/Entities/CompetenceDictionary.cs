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
    /// <summary>
    /// Entidad que representa el dicionario de competencias.
    /// </summary>
    public class CompetenceDictionary: BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the IdCompetence.
        /// </summary>
        
        public int? CompetenceId { get; set; }
        [ForeignKey("CompetenceId")]
        public virtual Competence Competence { get; set; }
        /// <summary>
        /// Gets or sets the BehavoiurDictionaryId.
        /// </summary>
        
        public int? BehaviorDictionaryId { get; set; }
        [ForeignKey("BehaviorDictionaryId")]
        public virtual BehaviorDictionary BehaviorDictionary { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfiles { get; set; }

        //Audited Method
        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy"), InverseProperty("CompetenceDictionaryUserCreatedBy")]
        public virtual User UserCreatedBy { get; set; }
        /// <summary>
		/// Gets or sets the CreatedOn.
		/// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedBy.
		/// </summary>
        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy"), InverseProperty("CompetenceDictionaryUserUpdatedBy")]
        public virtual User UserUpdatedBy { get; set; }
        /// <summary>
		/// Gets or sets the UpdatedOn.
		/// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
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
