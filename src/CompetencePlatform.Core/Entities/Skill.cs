using CompetencePlatform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Skill:CommonEntity
    {
         /// <summary>
        /// Gets or sets the IdSkillType.
        /// </summary>
       
        public int? SkillTypeId { get; set; }
        [ForeignKey("SkillTypeId")]
        public virtual SkillType SkillType { get; set; }
        public virtual ICollection<C_S_M_K_P> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }

    }
}
