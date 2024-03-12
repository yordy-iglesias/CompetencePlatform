using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class BehaviourDictionary:BaseEntity, IAuditedEntity
    {
        // <summary>
        /// Gets or sets the IdDegreeCompetence.
        /// </summary>
        [ForeignKey("IdDegreeCompetence")]
        public int IdDegreeCompetence { get; set; }
        public virtual DegreeCompetence DegreeCompetence { get; set; }
        // <summary>
        /// Gets or sets the IdDegreeCompetence.
        /// </summary>
        [ForeignKey("IdBehaviour")]
        public int IdBehaviour { get; set; }
        public virtual Behaviour Behaviour { get; set; }

        public virtual ICollection<CompetenceDictionary> CompetenceDictionaries { get; set; }

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
    }
}
