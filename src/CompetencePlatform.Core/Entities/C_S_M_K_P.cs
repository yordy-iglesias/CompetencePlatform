using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class C_S_M_K_P: BaseEntity, IAuditedEntity
    {
        /// <summary>
        /// Gets or sets the CompetenceId.
        /// </summary>
      
        public int? CompetenceId { get; set; }
        [ForeignKey("CompetenceId")]
        public virtual Competence Competence { get; set; }
        /// <summary>
        /// Gets or sets the IdKnowlwdge.
        /// </summary>
        
        public int? KnowledgeId { get; set; }
        [ForeignKey("KnowledgeId")]
        public virtual Knowledge Knowledge { get; set; }

        /// <summary>
        /// Gets or sets the IdPreference.
        /// </summary>
        
        public int? PreferenceId { get; set; }
        [ForeignKey("PreferenceId")]
        public virtual Preference Preference { get; set; }

        /// <summary>
        /// Gets or sets the IdSkill
        /// </summary>
        
        public int? SkillId { get; set; }
        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
        /// <summary>
        /// Gets or sets the IdMotivation
        /// </summary>
        
        public int? MotivationId { get; set; }
        [ForeignKey("MotivationId")]
        public virtual Motivation Motivation { get; set; }

        /// <summary>
		/// Gets or sets the Delete Borrado Logico.
		/// </summary>
        public bool? Deleted { get; set; }
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
        public bool? IsSelected { get; set; } = false;
    }
}
