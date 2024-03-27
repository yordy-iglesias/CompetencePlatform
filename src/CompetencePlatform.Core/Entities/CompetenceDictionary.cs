using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class CompetenceDictionary: BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the IdCompetence.
        /// </summary>
        
        public int? CompetenceId { get; set; }
        public virtual Competence Competence { get; set; }
        /// <summary>
        /// Gets or sets the BehavoiurDictionaryId.
        /// </summary>
        
        public int? BehavoiurDictionaryId { get; set; }
        public virtual BehaviourDictionary BehaviourDictionary { get; set; }
        public virtual ICollection<CompetenceProfile> CompetenceProfiles { get; set; }

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
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Delete { get; set; }
    }
}
