using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities
{
    public class Preference:CommonEntity
    {
        /// <summary>
        /// Gets or sets the IdPreferenceType.
        /// </summary>
        [ForeignKey("IdPreferenceType")]
        public int IdPreferenceType { get; set; }
        public virtual PreferenceType PreferenceType { get; set; }

        public virtual ICollection<Competence_Skill_Motivation_Knowledge_Preference> Competence_Skill_Motivation_Knowledge_Preferences { get; set; }
    }
}
