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
        /// Gets or sets the CompetenceId.
        /// </summary>
      
        public int? CompetenceId { get; set; }
        public virtual Competence Competence { get; set; }
        /// <summary>
        /// Gets or sets the IdKnowlwdge.
        /// </summary>
        
        public int? KnowlwdgeId { get; set; }
        public virtual Knowledge Knowledge { get; set; }

        /// <summary>
        /// Gets or sets the IdPreference.
        /// </summary>
        
        public int? PreferenceId { get; set; }
        public virtual Preference Preference { get; set; }

        /// <summary>
        /// Gets or sets the IdSkill
        /// </summary>
        
        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        /// <summary>
        /// Gets or sets the IdMotivation
        /// </summary>
        
        public int? MotivationId { get; set; }
        public virtual Motivation Motivation { get; set; }

        /// <summary>
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Delete { get; set; }
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
        public bool? IsSelected { get; set; } = false;
    }
}
