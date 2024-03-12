using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Competence_Skill_Motivation_Knowledge_Preference: BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the IdCompetence.
        /// </summary>
        [ForeignKey("IdCompetence")]
        public int IdCompetence { get; set; }
        public virtual Competence Competence { get; set; }
        /// <summary>
        /// Gets or sets the IdKnowlwdge.
        /// </summary>
        [ForeignKey("IdKnowlwdge")]
        public int IdKnowlwdge { get; set; }
        public virtual Knowledge Knowledge { get; set; }

        /// <summary>
        /// Gets or sets the IdKnowlwdge.
        /// </summary>
        [ForeignKey("IdPreference")]
        public int IdPreference { get; set; }
        public virtual Preference Preference { get; set; }

        /// <summary>
        /// Gets or sets the IdSkill
        /// </summary>
        [ForeignKey("IdSkill")]
        public int IdSkill { get; set; }
        public virtual Skill Skill { get; set; }
        /// <summary>
        /// Gets or sets the IdMotivation
        /// </summary>
        [ForeignKey("IdMotivation")]
        public int IdMotivation { get; set; }
        public virtual Motiviation Motivation { get; set; }
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
